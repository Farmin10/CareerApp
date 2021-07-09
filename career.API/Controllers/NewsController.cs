using career.BLL.Abstract;
using career.DTO.NewsDTO;
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
    public class NewsController : ControllerBase
    {
        INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        /// <summary>
        /// muracietlerin siyahisi
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public IActionResult GetNews()
        {
            var result = _newsService.GetNews();
            return Ok(result);
        }




        /// <summary>
        /// Muraciet elave etmek
        /// </summary>
        /// <param name="newsForAddDto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult AddNews(NewsForAddDto newsForAddDto)
        {
            var result = _newsService.AddNews(newsForAddDto);
            return Ok(result);
        }



        /// <summary>
        /// muracietin yenilenmesi 
        /// </summary>
        /// <param name="newsForUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult UpdateAppeal(NewsForUpdateDto newsForUpdateDto)
        {
            var result = _newsService.UpdateNews(newsForUpdateDto);
            return Ok(result);
        }


        /// <summary>
        /// muracietin silinmesi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteAppeal(int id)
        {
            _newsService.Delete(id);
            return Ok();
        }
    }
}
