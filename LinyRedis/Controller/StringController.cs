using LinyRedis.Service.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace LinyRedis.Controller
{
    /// <summary>
    /// String类型
    /// </summary>
    public class StringController: AbpController
    {
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("set")]
        public async Task<IActionResult> SetAsync([FromBody] KeyValueRequest request)
        {
            Logger.LogInformation($"[String:set] key:{request.Key},value:{request.Value}");
            var key = string.Format("String:{0}",request.Key);
            await RedisHelper.SetAsync(key, request.Value);
            return Ok();
        }

        /// <summary>
        /// get
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(string key)
        {
            Logger.LogInformation($"[String:get] key:{key}");
            key = string.Format("String:{0}",key);
            var value = await RedisHelper.GetAsync(key);
            return Ok(value);
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] string key)
        {
            Logger.LogInformation($"[String:delete] key:{key}");
            key = string.Format("String:{0}", key);
            await RedisHelper.DelAsync(key);
            return Ok();
        }
    }
}
