using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dy.WebApi.Controllers
{
    /// <summary>
    /// 示例Api
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 查找信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="value">信息内容</param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="id">信息Id</param>
        /// <param name="value">信息内容</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="id">信息Id</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
