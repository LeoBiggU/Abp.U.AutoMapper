using Abp.Configuration.Startup;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.AutoMapper
{
    /// <summary>
    /// 定义扩展方法 <see cref="IModuleConfigurations"/>，为了允许配置 Abp.AutoMapper 模块
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure Abp.AutoMapper module.
    /// </summary>
    public static class AbpAutoMapperConfigurationExtensions
    {
        /// <summary>
        /// 用来配置 Abp.AutoMapper 模块
        /// Used to configure Abp.AutoMapper module.
        /// </summary>
        public static IAbpAutoMapperConfiguration AbpAutoMapper(this IModuleConfigurations configurations)
        {
            // 这一步会把本模块的配置加入到AbpModule模块自定义配置中
            return configurations.AbpConfiguration.Get<IAbpAutoMapperConfiguration>();
        }
    }
}
