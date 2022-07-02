using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Modules;
using Abp.Reflection;
using Abp.AutoMapper;
using AutoMapper;
using Castle.MicroKernel.Registration;
using System;
using System.Reflection;

namespace Abp.AutoMapper
{
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpAutoMapperModule : AbpModule
    {
        private readonly ITypeFinder _typeFinder;

        private static volatile bool _createdMappingsBefore;

        private static readonly object SyncObj = new object();

        public AbpAutoMapperModule(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        /// <summary>
        /// 这是应用程序启动时调用的第一个事件。代码可以放在这里在依赖注入注册之前运行。
        /// </summary>
        public override void PreInitialize()
        {
            // 注册本模块的配置
            IocManager.Register<IAbpAutoMapperConfiguration, AbpAutoMapperConfiguration>();

            // 将对象映射器的实现替换为本模块中定义
            Configuration.ReplaceService<ObjectMapping.IObjectMapper, AutoMapperObjectMapper>();

            // 添加自定义配置
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CreateCoreMappings);
        }

        /// <summary>
        /// 这个方法在应用程序启动的最后被调用
        /// </summary>
        public override void PostInitialize()
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            lock (SyncObj)
            {
                Action<IMapperConfigurationExpression> configurer = configuration =>
                {
                    FindAndAutoMapTypes(configuration);
                    // 根据模块配置创建映射
                    foreach (var configurator in Configuration.Modules.AbpAutoMapper().Configurators)
                    {
                        configurator(configuration);
                    }
                };

                // 使用静态 Mapper 实例，是在 AutoMapper 类里面的静态实例
                if (Configuration.Modules.AbpAutoMapper().UseStaticMapper)
                {
                    //We should prevent duplicate mapping in an application, since Mapper is static.
                    if (!_createdMappingsBefore)
                    {
                        Mapper.Initialize(configurer);
                        _createdMappingsBefore = true;
                    }

                    IocManager.IocContainer.Register(
                        Component.For<IMapper>().Instance(Mapper.Instance).LifestyleSingleton()
                    );
                }
                // 不适用静态实例就需要 new 一个
                else
                {
                    var config = new MapperConfiguration(configurer);
                    IocManager.IocContainer.Register(
                        Component.For<IMapper>().Instance(config.CreateMapper()).LifestyleSingleton()
                    );
                }
            }
        }

        /// <summary>
        /// 寻找添加了自动映射特性的类型并自动创建映射配置
        /// </summary>
        /// <param name="configuration"></param>
        private void FindAndAutoMapTypes(IMapperConfigurationExpression configuration)
        {
            // 找到定义了自动映射特性的类
            var types = _typeFinder.Find(type =>
            {
                var typeInfo = type.GetTypeInfo();
                return typeInfo.IsDefined(typeof(AutoMapAttribute)) ||
                       typeInfo.IsDefined(typeof(AutoMapFromAttribute)) ||
                       typeInfo.IsDefined(typeof(AutoMapToAttribute));
            });

            Logger.DebugFormat("Found {0} classes define auto mapping attributes", types.Length);

            // 为符合条件的类依次创建映射配置
            foreach (var type in types)
            {
                Logger.Debug(type.FullName);
                configuration.CreateAutoAttributeMaps(type);
            }
        }
        /// <summary>
        /// 创建核心映射
        /// 当前只创建了本地化string映射到string
        /// </summary>
        /// <param name="configuration"></param>
        private void CreateCoreMappings(IMapperConfigurationExpression configuration)
        {
            var localizationContext = IocManager.Resolve<ILocalizationContext>();

            configuration.CreateMap<ILocalizableString, string>().ConvertUsing(ls => ls?.Localize(localizationContext));
            configuration.CreateMap<LocalizableString, string>().ConvertUsing(ls => ls == null ? null : localizationContext.LocalizationManager.GetString(ls));
        }
    }
}
