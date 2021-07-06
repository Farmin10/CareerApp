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
    }
}
