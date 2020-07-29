using LinyRedis.Service.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace LinyRedis.Controller
{
    /// <summary>
    /// Set类型
    /// </summary>
    public class SetController : AbpController
    {
        /// <summary>
        /// 将给定元素添加到集合
        /// </summary>
        /// <returns></returns>
        [HttpPost("SAdd")]
        public async Task<IActionResult> SAddAsync(KeyValueRequest request)
        {
            Logger.LogInformation($"[Set:SAdd] key:{request.Key},value:{request.Value}");
            var key = string.Format("Set:{0}", request.Key);
            await RedisHelper.SAddAsync(key, request.Value);
            return Ok();
        }

        /// <summary>
        /// 查询集合包含的所有元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("SMembers")]
        public async Task<IActionResult> SMembersAsync([FromQuery] string key)
        {
            Logger.LogInformation($"[Set:SMembers]");
            key = string.Format("Set:{0}", key);
            var set = await RedisHelper.SMembersAsync(key);
            return Ok(set);
        }

        /// <summary>
        /// 查询给定元素是否在集合中
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("SISMember")]
        public async Task<IActionResult> SISMemberAsync([FromQuery] KeyValueRequest request)
        {
            Logger.LogInformation($"[Set:ISSMember]");
            var key = string.Format("Set:{0}", request.Key);
            var isMember = await RedisHelper.SIsMemberAsync(key, request.Value);
            return Ok(isMember);
        }

        /// <summary>
        /// 如果给定元素存在于集合中，删除这个元素
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("SRem")]
        public async Task<IActionResult> SRemAsync([FromBody] KeyValueRequest request)
        {
            Logger.LogInformation($"[Set:SRem] key:{request.Key},value:{request.Value}");
            var key = string.Format("Set:{0}", request.Key);
            var isRemove = await RedisHelper.SRemAsync(key, request.Value);
            return Ok(isRemove == Convert.ToInt64(0) ? false : true);
        }
    }
}
