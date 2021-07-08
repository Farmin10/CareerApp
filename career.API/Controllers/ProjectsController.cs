using career.BLL.Abstract;
using career.DTO.ProjectDTO;
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
    public class ProjectsController : ControllerBase
    {
        IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }




        /// <summary>
        /// layihelerin siyahisi
        /// </summary>
        /// <param name="projectForAddDto"></param>
        /// <returns></returns>
        [HttpGet("getAllProjects")]
        public IActionResult GetProjects()
        {
            var result = _projectService.GetAll();
            return Ok(result);
        }




        /// <summary>
        /// layihe elave etmek
        /// </summary>
        /// <param name="projectForAddDto"></param>
        /// <returns></returns>
        [HttpPost("addProject")]
        public IActionResult AddProject(ProjectForAddDto projectForAddDto)
        {
            var result = _projectService.AddProject(projectForAddDto);
            return Ok(result);
        }




        /// <summary>
        /// layihe update
        /// </summary>
        /// <param name="projectForUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult UpdateProject(ProjectForUpdateDto projectForUpdateDto)
        {
            var result = _projectService.UpdateProject(projectForUpdateDto);
            return Ok(result);
        }




        /// <summary>
        /// layihenin silinmeesi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult DeleteProject(int id)
        {
            _projectService.DeleteProject(id);
            return Ok();
        }
    }
}
