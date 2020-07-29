using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinyRedis.Service.Request.ZSet
{
    public class ZAddRequest
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 成员
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        /// 分值
        /// </summary>
        public decimal Score { get; set; }
    }
}
