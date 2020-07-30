using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleVote.Service.Request
{
    /// <summary>
    /// 文章投票请求
    /// </summary>
    public class ArticleVoteRequest
    {
        /// <summary>
        /// 文章id
        /// </summary>
        public int ArticleId{get;set;}

        /// <summary>
        /// 用户
        /// </summary>
        public string User { get; set; }
    }
}
