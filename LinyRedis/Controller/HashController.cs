using LinyRedis.Service.Request.Hash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace LinyRedis.Controller
{
    /// <summary>
    /// Hash类型
    /// </summary>
    public class HashController : AbpController
    {
        /// <summary>
        /// 设置给定散列键值对
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("HSet")]
        public async Task<IActionResult> HSetAsync([FromBody]HSetRequest request)
        {
            Logger.LogInformation($"[Hash:HSet] key:{request.Key},subKey:{request.SubKey},value:{request.Value}");
            var key = string.Format("Hash:{0}", request.Key);
            await RedisHelper.HSetAsync(key, request.SubKey, request.Value);
            return Ok();
        }

        /// <summary>
        /// 获取指定散列键的值
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("HGet")]
        public async Task<IActionResult> HGetAsync([FromQuery]HGetRequest request)
        {
            Logger.LogInformation($"[Hash:HGet] key:{request.Key},subKey:{request.SubKey}");
            var key = string.Format("Hash:{0}", request.Key);
            var value = await RedisHelper.HGetAsync(key, request.SubKey);
            return Ok(value);
        }

        /// <summary>
        /// 获取指定散列所有键值对
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("HGetAll")]
        public async Task<IActionResult> HGetAllAsync([FromQuery]string key)
        {
            Logger.LogInformation($"[Hash:HGetAll] key:{key}");
            key = string.Format("Hash:{0}", key);
            var hash = await RedisHelper.HGetAllAsync(key);
            return Ok(hash);
        }

        /// <summary>
        /// 删除散列的指定键
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("HDel")]
        public async Task<IActionResult> HDelAsync(HDelRequest request)
        {
            Logger.LogInformation($"[Hash:HDel] key:{request.Key},subKey:{request.SubKey}");
            var key = string.Format("Hash:{0}", request.Key);
            var isRemove = await RedisHelper.HDelAsync(key, request.SubKey);
            return Ok(isRemove == Convert.ToInt64(0) ? false : true);
        }
    }
}
