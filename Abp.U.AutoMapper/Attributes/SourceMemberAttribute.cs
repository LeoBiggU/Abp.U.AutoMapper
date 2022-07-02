using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.AutoMapper
{
    /// <summary>
    /// Specify the source member to map from. Can only reference a member on the <see cref="AutoMapAttribute.SourceType" /> type
    /// 指定要映射的源成员，只能引用源类型上的成员
    /// </summary>
    /// <remarks>
    /// Must be used in combination with <see cref="AutoMapAttribute" />
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class SourceMemberAttribute : Attribute, IMemberConfigurationProvider
    {
        public string Name { get; }

        public SourceMemberAttribute(string name) => Name = name;

        public void ApplyConfiguration(IMemberConfigurationExpression memberConfigurationExpression)
        {
            memberConfigurationExpression.MapFrom(Name);
        }
    }
}
