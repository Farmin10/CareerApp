using career.BLL.Abstract;
using career.DTO.VacancyDTO;
using career.DTO.VacancyTypeDTO;
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
    [Consumes("application/json")]
    public class VacancyTypesController : ControllerBase
    {
        IVacancyTypeService _vacancyTypeService;

        public VacancyTypesController(IVacancyTypeService vacancyTypeService)
        {
            _vacancyTypeService = vacancyTypeService;
        }


        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns></returns>
        [HttpGet("Getall")]
        public IActionResult GetAll()
        {
            var result = _vacancyTypeService.GetAll();
            return Ok(result);
        }


        /// <summary>
        /// vakansiya novu elave etme
        /// </summary>
        /// <param name="vacancyTypeAddDto"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public IActionResult AddVacancyType(VacancyTypeAddDto vacancyTypeAddDto)
        {
            var result = _vacancyTypeService.AddVacancyType(vacancyTypeAddDto);
            return Ok(result);
        
        }




        /// <summary>
        /// update 
        /// </summary>
        /// <param name="vacancyTypeUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult UpdateVacancyType(VacancyTypeUpdateDto vacancyTypeUpdateDto)
        {
            var result = _vacancyTypeService.UpdateVacancyType(vacancyTypeUpdateDto);
            return Ok(result);

        }
    }
}
