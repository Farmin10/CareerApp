using career.BLL.Abstract;
using career.DTO.EmployeeDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace career.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;
        private readonly IHub _sentryHub;

        public EmployeesController(IEmployeeService employeeService, IHub sentryHub)
        {
            _employeeService = employeeService;
            _sentryHub = sentryHub;
        }


        /// <summary>
        /// isci siyahisi
        /// </summary>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result =_employeeService.GetAll();
            return Ok(result);
        }





       


        /// <summary>
        /// isci elave etme
        /// </summary>
        /// <param name="employeeAddDto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult AddEmployee(EmployeeAddDto employeeAddDto)
        {
            var result = _employeeService.AddEmployee(employeeAddDto);
            return Ok(result);
        }


        /// <summary>
        /// isci yenileme
        /// </summary>
        /// <param name="updateEmployeeDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var result = _employeeService.UpdateEmployee(updateEmployeeDto);
            return Ok(result);
        }



        /// <summary>
        /// isci silme
        /// </summary>
        /// <param name="updateEmployeeDto"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
           var result= _employeeService.DeleteEmployee(id);
            return Ok(result);
        }
    }
}
