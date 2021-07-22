using career.BLL.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace career.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        ICountService _countService;

        public CountController(ICountService countService)
        {
            _countService = countService;
        }



        /// <summary>
        /// cem
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCount")]
        public IActionResult GetCount()
        {
            return Ok(_countService.Count());
        }
    }
}
