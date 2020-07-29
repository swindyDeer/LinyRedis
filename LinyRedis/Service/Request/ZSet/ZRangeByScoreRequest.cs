using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinyRedis.Service.Request.ZSet
{
    public class ZRangeByScoreRequest
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 最小分值
        /// </summary>
        public decimal MinScore { get; set; }

        /// <summary>
        /// 最大分值
        /// </summary>
        public decimal MaxScore { get; set; }
    }
}
