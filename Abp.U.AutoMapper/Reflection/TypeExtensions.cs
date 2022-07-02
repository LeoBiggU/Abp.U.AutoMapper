using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Abp.U.AutoMapper.Reflection
{
    /// <summary>
    /// <see cref="Type"/> 类型扩展
    /// </summary>
    public static class TypeExtensions
    {

        /// <summary>
        /// 从类中获取满足条件的属性
        /// </summary>
        /// <param name="type"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties(this Type type, Func<PropertyInfo, bool> predicate) =>
            type.GetProperties().Where(predicate).ToArray();

        /// <summary>
        /// 获取类中带有某特性的属性
        /// </summary>
        /// <typeparam name="TAttribute">用来筛选的特性</typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetPropertiesWithAttribute<TAttribute>(this Type type) where TAttribute : Attribute, new() =>
            type.GetProperties().Where(p => p.IsDefined(typeof(TAttribute), true)).ToArray();
    }
}
