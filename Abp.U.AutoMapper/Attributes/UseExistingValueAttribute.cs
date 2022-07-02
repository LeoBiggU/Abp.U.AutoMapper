using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.AutoMapper
{
    /// <summary>
    /// Use the destination value instead of mapping from the source value or creating a new instance
    /// 使用目标值，而不是从源值映射或创建新实例
    /// </summary>
    /// <remarks>
    /// Must be used in combination with <see cref="AutoMapAttribute" />
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class UseExistingValueAttribute : Attribute, IMemberConfigurationProvider
    {
        public void ApplyConfiguration(IMemberConfigurationExpression memberConfigurationExpression)
        {
            memberConfigurationExpression.UseDestinationValue();
        }
    }
}
