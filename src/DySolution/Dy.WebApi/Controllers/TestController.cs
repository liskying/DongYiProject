using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dy.Dto.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dy.WebApi.Controllers
{
    /// <summary>
    /// 测试示例
    /// </summary>
    [Route("api/[controller]")]
    public class TestController : BaseController
    {
        /// <summary>
        /// 获取测试信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<TestDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<TestDto>), StatusCodes.Status400BadRequest)]
        public IActionResult GetTest()
        {
            var rdn = new Random();
            List<TestDto> list = new List<TestDto>();
            list.Add(new TestDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = "名称" + rdn.Next(),
                Address = "地址" + rdn.Next(),
                Color = ConsoleColor.Blue.ToString()
            });
            list.Add(new TestDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = "名称" + rdn.Next(),
                Address = "地址" + rdn.Next(),
                Color = ConsoleColor.Blue.ToString()
            });
            return Ok(list);
        }
    }
}