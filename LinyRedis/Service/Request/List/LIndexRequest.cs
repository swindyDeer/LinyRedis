using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinyRedis.Service.Request.List
{
    public class LIndexRequest
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 索引
        /// </summary>
        public long Index { get; set; }
    }
}
