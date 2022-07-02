using AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Abp.U.AutoMapper
{
    internal static class AutoMapperConfigurationExtensions
    {
        /// <summary>
        /// 根据 AutoMap 特性创建映射配置
        /// </summary>
        /// <param name="configuration">映射配置</param>
        /// <param name="type">要创建的类型</param>
        public static void CreateAutoAttributeMaps(this IMapperConfigurationExpression configuration, Type type)
        {
            // 找到指定类型上基于 AutoMapAttributeBase 的特性，调用该方法保证了一定会存在符合条件的特性
            foreach (var autoMapAttribute in type.GetTypeInfo().GetCustomAttributes<AutoMapAttributeBase>())
            {
                autoMapAttribute.CreateMap(configuration, type);
            }
        }
    }
}
