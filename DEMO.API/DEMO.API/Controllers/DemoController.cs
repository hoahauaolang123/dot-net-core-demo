using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.API.Controllers
{
    [Route("api/v1/demonation")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        /// <summary>
        /// Lấy dữ liệu không cần tham số
        /// </summary>
        /// <returns>
        /// status code 200, string
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Trung dep zai!!!");
        }


        /// <summary>
        /// Lấy dữ liệu tham số trên router
        /// </summary>
        /// <param name="name">string: tên người</param>
        /// <returns>
        /// status code 200, string 
        /// </returns>
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok($"{name} dep zai!!!");
        }

        /// <summary>
        /// Lấy dữ liệu truyền vào nhiều tham số
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <returns></returns>
        [HttpGet("person")]
        public IActionResult GetPerson(string name1, string name2)
        {
            return Ok($"{name1} and {name2} adu vjp pr0 n0 1 !!!");
        }


    }
}
