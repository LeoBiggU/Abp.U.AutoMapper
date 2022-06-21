using AutoMapper;
using System;
using System.Collections.Generic;

namespace Abp.U.AutoMapper
{
    /// <summary>
    /// 本模块配置项
    /// </summary>
    public class AbpAutoMapperConfiguration : IAbpAutoMapperConfiguration
    {
        public List<Action<IMapperConfigurationExpression>> Configurators { get; }

        public bool UseStaticMapper { get; set; }

        public AbpAutoMapperConfiguration()
        {
            UseStaticMapper = true;
            Configurators = new List<Action<IMapperConfigurationExpression>>();
        }
    }
}
