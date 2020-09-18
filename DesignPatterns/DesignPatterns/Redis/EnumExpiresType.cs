using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Redis
{
    /// <summary>
    /// 超时类型
    /// </summary>
    public enum EnumExpiresType
    {
        /// <summary>
        /// Default
        /// </summary>
        Default = 0,
        /// <summary>
        /// 指定过期时间（即在xxxx时间点过期）
        /// </summary>
        Expiration = 1,
        /// <summary>
        /// 弹性过期时间（即在xxxx秒后过期）
        /// </summary>
        Sliding = 2,
    }
}
