using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.U.AutoMapper
{
    /// <summary>
    /// 本模块的配置项接口
    /// </summary>
    public interface IAbpAutoMapperConfiguration
    {
        List<Action<IMapperConfigurationExpression>> Configurators { get; }

        /// <summary>
        /// 使用静态的 <see cref="Mapper.Instance"/>.
        /// Use static <see cref="Mapper.Instance"/>.
        /// 默认：true
        /// Default: true.
        /// </summary>
        bool UseStaticMapper { get; set; }
    }
}
