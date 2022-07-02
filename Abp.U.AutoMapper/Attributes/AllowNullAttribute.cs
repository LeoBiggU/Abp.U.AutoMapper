using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.AutoMapper.Attributes
{
    /// <summary>
    /// Allow this member to be null. This prevents generating a check condition for it.
    /// 允许此成员为空。 这可以防止为其生成检查条件。
    /// </summary>
    /// <remarks>
    /// 属性上添加该特性在映射时会被忽略
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class AllowNullAttribute : Attribute, IMemberConfigurationProvider
    {
        public void ApplyConfiguration(IMemberConfigurationExpression memberConfigurationExpression)
        {
            memberConfigurationExpression.AllowNull();
        }
    }
}
