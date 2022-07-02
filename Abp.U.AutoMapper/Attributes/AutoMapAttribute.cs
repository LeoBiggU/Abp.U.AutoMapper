using System;
using System.Linq;
using System.Reflection;
using Abp.Collections.Extensions;
using Abp.U.AutoMapper;
using Abp.U.AutoMapper.Reflection;
using AutoMapper;
using AutoMapper.Configuration;

namespace Abp.AutoMapper
{
    public class AutoMapAttribute : AutoMapAttributeBase
    {
        public AutoMapAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {

        }

        public override void CreateMap(IMapperConfigurationExpression configuration, Type type)
        {
            if (TargetTypes.IsNullOrEmpty())
            {
                return;
            }

            foreach (var targetType in TargetTypes)
            {
                var sourseMappingExpression = configuration.CreateMap(type, targetType, MemberList.None);
                var targetMappingExpression = configuration.CreateMap(targetType, type, MemberList.None);

                foreach (var memberInfo in targetType.GetMembers(BindingFlags.Public | BindingFlags.Instance))
                {
                    foreach (var memberConfigurationProvider in memberInfo.GetCustomAttributes().OfType<IMemberConfigurationProvider>())
                    {
                        sourseMappingExpression.ForMember(memberInfo.Name,
                            cfg => memberConfigurationProvider.ApplyConfiguration(cfg));
                        targetMappingExpression.ForMember(memberInfo.Name,
                            cfg => memberConfigurationProvider.ApplyConfiguration(cfg));
                    }
                }
            }
        }
    }
}
