using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.AutoMapper
{
    /// <summary>
    /// Ignore this member for configuration validation and skip during mapping.
    /// </summary>
    /// <remarks>
    /// 属性上添加该特性在映射时会被忽略
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class IgnoreAttribute : Attribute, IMemberConfigurationProvider
    {
        public void ApplyConfiguration(IMemberConfigurationExpression memberConfigurationExpression)
        {
            memberConfigurationExpression.Ignore();
        }
    }
}
