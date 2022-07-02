using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.AutoMapper
{
    public interface IMemberConfigurationProvider
    {
        void ApplyConfiguration(IMemberConfigurationExpression memberConfigurationExpression);
    }
}
