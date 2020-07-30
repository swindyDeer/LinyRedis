using ArticleVote.Infrastructure;
using ArticleVote.Service.Abstractions;
using ArticleVote.Service.Request;
using System;
using System.Threading.Tasks;

namespace ArticleVote.Service.Implements
{
    /// <summary>
    /// 文章服务
    /// </summary>
    public class ArticleService:IArticleService
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CreateAsync(ArticleCreateRequest request)
        {
            //生成文章id
            var id = await GetIdAsync();
            
            //初始化投票记录
            //作者默认投自己一票
            //一周内可投票
            var votedKey = string.Format(CacheConst.Voted, id);
            await RedisHelper.SAddAsync(votedKey, request.User);
            await RedisHelper.ExpireAsync(votedKey, CacheConst.OneWeekSeconds);

            var articleKey = string.Format(CacheConst.Article,id);
            var time = GetTimestamp(DateTime.Now);
            var articleArr = new object[]
            {
                "title",request.Title,
                "link",request.Link,
                "poster",request.User,
                "time",time,
                "votes",1
            };
            await  RedisHelper.HMSetAsync(articleKey, articleArr);
            
            //评分排序
            await RedisHelper.ZAddAsync(CacheConst.Score,(time + CacheConst.VoteScore,articleKey));
            //时间排序
            await RedisHelper.ZAddAsync(CacheConst.Time,(time,articleKey));
        }

        /// <summary>
        /// 投票
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task VoteAsync(ArticleVoteRequest request)
        {
            var articleKey = string.Format(CacheConst.Article, request.ArticleId);

            //检查文章是否超过投票时间（文章发布一周内可投）
            var time = GetTimestamp(DateTime.Now) - CacheConst.OneWeekSeconds;
            var publishTime = await RedisHelper.ZScoreAsync(CacheConst.Time, articleKey);
            if (publishTime < time)
                return;

            var votedKey = string.Format(CacheConst.Voted, request.ArticleId);
            //第一次投票添加记录
            var isSuccess = await RedisHelper.SAddAsync(votedKey, request.User);
            if(isSuccess == 0L ? false : true)
            {
                //增加评分
                await RedisHelper.ZIncrByAsync(CacheConst.Score,articleKey,CacheConst.VoteScore);
                //增加票数
                await RedisHelper.HIncrByAsync(articleKey,"votes",1);
            }
        }

        /// <summary>
        /// 获取id
        /// </summary>
        /// <returns></returns>
        private async Task<long> GetIdAsync()
        {
            var exist = await RedisHelper.ExistsAsync(CacheConst.ArticleId);
            if (!exist)
            {
                await RedisHelper.SetAsync(CacheConst.ArticleId, 1);
                return 1L;
            }
            else
            {
                return await RedisHelper.IncrByAsync(CacheConst.ArticleId);
            }
        }
        
        
        /// <summary>
        /// 获取1970-01-01至dateTime的毫秒数
        /// </summary>
        private long GetTimestamp(DateTime dateTime)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return (dateTime.Ticks - dt1970.Ticks) / 10000;
        }
    }
}