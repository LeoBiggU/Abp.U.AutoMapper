﻿using Abp.Configuration.Startup;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.U.AutoMapper
{
    /// <summary>
    /// 定义扩展方法 <see cref="IModuleConfigurations"/>，为了允许配置 Abp.U.AutoMapper 模块
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure Abp.U.AutoMapper module.
    /// </summary>
    public static class AbpUAutoMapperConfigurationExtensions
    {
        /// <summary>
        /// 用来配置 Abp.U.AutoMapper 模块
        /// Used to configure Abp.U.AutoMapper module.
        /// </summary>
        public static IAbpAutoMapperConfiguration AbpUAutoMapper(this IModuleConfigurations configurations)
        {
            // 这一步会把本模块的配置加入到AbpModule模块自定义配置中
            return configurations.AbpConfiguration.Get<IAbpAutoMapperConfiguration>();
        }
    }
}