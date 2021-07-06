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
    public class FiltersController : ControllerBase
    {
        IDepartmantService _departmantService;
        IPositionService _positionService;
        IVacancyTypeService _vacancyTypeService;
        IEmployeeService _employeeService;
        IVacancyService _vacancyService;

        public FiltersController(IDepartmantService departmantService, IPositionService positionService, IVacancyTypeService vacancyTypeService, IEmployeeService employeeService, IVacancyService vacancyService)
        {
            _departmantService = departmantService;
            _positionService = positionService;
            _vacancyTypeService = vacancyTypeService;
            _employeeService = employeeService;
            _vacancyService = vacancyService;
        }


        /// <summary>
        /// departmant siyahisi filter ile
        /// </summary>
        [HttpGet("getDepartmantsWithFilter")]
        public IActionResult GetDeptWithFilter()
        {
            var result = _departmantService.GetAllWithFilter();
            return Ok(result);
        }



        /// <summary>
        /// get positions with filters
        /// </summary>
        [HttpGet("GetPositionsWithFilter")]
        public IActionResult GetPositionsWithFilter()
        {

            var result = _positionService.GetPositionFilters();
            return Ok(result);
        }



        /// <summary>
        /// Get all data by filter
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetVacancyTypesWithFilter")]
        public IActionResult GetAllByFilter()
        {
            var result = _vacancyTypeService.GetAllByFilter();
            return Ok(result);
        }



        /// <summary>
        /// isci siyahisi filter ile
        /// </summary>
        [HttpGet("getEmployeesWithFilter")]
        public IActionResult GetAllWithFilter()
        {
            var result = _vacancyService.GetAllWithFilter();
            return Ok(result);
        }




        /// <summary>
        /// vakansiya siyahisi filter ile
        /// </summary>
        [HttpGet("getVacanciesWithFilter")]
        public IActionResult GetVacanciesWithFilter()
        {
            var result = _employeeService.GetAllWithFilter();
            return Ok(result);
        }
    }
}
