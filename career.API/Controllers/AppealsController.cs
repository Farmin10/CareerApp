using career.BLL.Abstract;
using career.DTO.AppealDTO;
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
    public class AppealsController : ControllerBase
    {
        IAppealService _appealService;

        public AppealsController(IAppealService appealService)
        {
            _appealService = appealService;
        }



        /// <summary>
        /// muracietlerin siyahisi
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public IActionResult GetAppeals()
        {
            var result = _appealService.GetAppeals();
            return Ok(result);
        }




        /// <summary>
        /// vakansiya Id-sine gore siyahi
        /// </summary>
        /// <param name="vacancyId"></param>
        /// <returns></returns>
        [HttpGet("getById")]
        public IActionResult GetAppealByVacancyId(int vacancyId)
        {
            var result = _appealService.GetAppealByVacancyId(vacancyId);
            return Ok(result);
        }




        /// <summary>
        /// Muraciet elave etmek
        /// </summary>
        /// <param name="appealForAddDto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult AddAppeal(AppealForAddDto appealForAddDto)
        {
            var result = _appealService.AddAppeal(appealForAddDto);
            return Ok(result);
        }



        /// <summary>
        /// muracietin yenilenmesi 
        /// </summary>
        /// <param name="appealForUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult UpdateAppeal(AppealForUpdateDto appealForUpdateDto)
        { 
            var result=_appealService.UpdateAppeal(appealForUpdateDto);
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
            var result=  _appealService.Delete(id);
            return Ok(result);
        }
    }
}
