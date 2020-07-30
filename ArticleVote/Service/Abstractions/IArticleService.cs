using System.Threading.Tasks;
using ArticleVote.Service.Request;
using Volo.Abp.DependencyInjection;

namespace ArticleVote.Service.Abstractions
{
    /// <summary>
    /// 文章服务
    /// </summary>
    public interface IArticleService:IScopedDependency
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task CreateAsync(ArticleCreateRequest request);

        /// <summary>
        /// 投票
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task VoteAsync(ArticleVoteRequest request);
    }
}