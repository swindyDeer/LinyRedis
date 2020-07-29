using LinyRedis.Service.Request.ZSet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace LinyRedis.Controller
{
    /// <summary>
    /// ZSet类型
    /// </summary>
    public class ZSetController : AbpController
    {
        /// <summary>
        /// 有序集合添加分值
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ZSet")]
        public async Task<IActionResult> ZAddAsync([FromBody] ZAddRequest request)
        {
            Logger.LogInformation($"[ZSet:ZAdd] key:{request.Key},member:{request.Member},score:{request.Score}");
            var key = string.Format("ZSet:{0}", request.Key);
            await RedisHelper.ZAddAsync(key, (request.Score, request.Member));
            return Ok();
        }

        /// <summary>
        /// 从有序集合指定区间获取元素
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("ZRange")]
        public async Task<IActionResult> ZRangeAsync([FromQuery] ZRangeRequest request)
        {
            Logger.LogInformation($"[ZSet:ZRange] key:{request.Key},minIndex:{request.MinIndex},MaxIndex:{request.MaxIndex}");
            var key = string.Format("ZSet:{0}", request.Key);
            var zset = await RedisHelper.ZRangeAsync(key, request.MinIndex, request.MaxIndex);
            return Ok(zset);
        }

        /// <summary>
        /// 获取有序集合在给定分值范围内的所有元素
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("ZRangeByScore")]
        public async Task<IActionResult> ZRangeByScoreAsync([FromQuery] ZRangeByScoreRequest request)
        {
            Logger.LogInformation($"[ZSet:ZRange] key:{request.Key},minScore:{request.MinScore},MaxScore:{request.MaxScore}");
            var key = string.Format("ZSet:{0}", request.Key);
            var zset = await RedisHelper.ZRangeByScoreAsync(key, request.MinScore, request.MaxScore);
            return Ok(zset);
        }

        /// <summary>
        /// 有序集合移除指定成员
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("ZRem")]
        public async Task<IActionResult> ZRemAsync(ZRemRequest request)
        {
            Logger.LogInformation($"[ZSet:ZRem] key:{request.Key},member:{request.Member}");
            var key = string.Format("ZSet:{0}", request.Key);
            var isRemove = await RedisHelper.ZRemAsync(key, request.Member);
            return Ok(isRemove == Convert.ToInt64(0) ? false : true);
        }
    }
}
