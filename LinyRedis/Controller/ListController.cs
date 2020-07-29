using LinyRedis.Service.Request;
using LinyRedis.Service.Request.List;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace LinyRedis.Controller
{
    /// <summary>
    /// List类型
    /// </summary>
    public class ListController: AbpController
    {
        /// <summary>
        /// 将给定值推入列表右端（插入值）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("RPush")]
        public async Task<IActionResult> RPushAsync([FromBody] KeyValueRequest request)
        {
            Logger.LogInformation($"[List:rpush] key:{request.Key},value:{request.Value}");
            var key = string.Format("List:{0}", request.Key);
            await RedisHelper.RPushAsync(key,request.Value);
            return Ok();
        }

        /// <summary>
        /// 获取列表上在给定范围的所有值
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("LRange")]
        public async Task<IActionResult> LRange([FromQuery]LRangeRequest request)
        {
            Logger.LogInformation($"[List:lrange] key:{request.Key},{nameof(request.MinIndex)}:{request.MinIndex},{nameof(request.MaxIndex)}:{request.MaxIndex}");
            var key = string.Format("List:{0}", request.Key);
            var list = await RedisHelper.LRangeAsync(key,request.MinIndex,request.MaxIndex);
            return Ok(list);
        }

        /// <summary>
        /// 获取列表在给定位置上的单个元素
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("LIndex")]
        public async Task<IActionResult> LIndex([FromQuery] LIndexRequest request)
        {
            Logger.LogInformation($"[List:lindex] key:{request.Key},index:{request.Index}");
            var key= string.Format("List:{0}", request.Key);
            var value = await RedisHelper.LIndexAsync(key,request.Index);
            return Ok(value);
        }

        /// <summary>
        /// 从列表左端弹出一个值（删除值）
        /// LPop即是一个删除操作，也是一个查询操作 所以也可以考虑delete语义
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("LPop")]
        public async Task<IActionResult> LPop([FromQuery] string key)
        {
            Logger.LogInformation($"[List:lpop] key:{key}");
            key = string.Format("List:{0}", key);
            var value = await RedisHelper.LPopAsync(key);
            return Ok(value);
        }
    }
}
