using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinyRedis.Service.Request.List
{
    public class LRangeRequest
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 最小索引
        /// </summary>
        public long MinIndex { get; set; }

        /// <summary>
        /// 最大索引
        /// </summary>
        public long MaxIndex { get; set; }
    }
}
