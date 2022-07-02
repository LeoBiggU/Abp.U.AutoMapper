using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.U.AutoMapper
{
    public interface IMemberConfigurationProvider
    {
        void ApplyConfiguration(IMemberConfigurationExpression memberConfigurationExpression);
    }
}
