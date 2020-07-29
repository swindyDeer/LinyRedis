using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinyRedis.Service.Request.Hash
{
    public class HGetRequest
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 子键
        /// </summary>
        public string SubKey { get; set; }
    }
}
