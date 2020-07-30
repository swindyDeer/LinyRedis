using System.Threading.Tasks;
using ArticleVote.Service.Abstractions;
using ArticleVote.Service.Implements;
using ArticleVote.Service.Request;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace ArticleVote.Controller
{
    /// <summary>
    /// 文章控制器
    /// </summary>
    public class ArticleController:AbpController
    {
        /// <summary>
        /// 文章服务
        /// </summary>
        private IArticleService ArticleService;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="articleService"></param>
        public ArticleController(IArticleService articleService)
        {
            ArticleService = articleService;
        }
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] ArticleCreateRequest request)
        {
            await ArticleService.CreateAsync(request);
            return Ok();
        }

        /// <summary>
        /// 投票
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Vote")]
        public async Task<IActionResult> VoteAsync([FromBody] ArticleVoteRequest request)
        {
            await ArticleService.VoteAsync(request);
            return Ok();
        }
    }
}