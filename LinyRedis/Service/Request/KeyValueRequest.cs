using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinyRedis.Service.Request
{
    /// <summary>
    /// 键值请求
    /// </summary>
    public class KeyValueRequest
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
