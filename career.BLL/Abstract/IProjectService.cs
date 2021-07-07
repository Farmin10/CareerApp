using career.DTO.ProjectDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Abstract
{
    public interface IProjectService
    {
        ProjectForAddDto AddProject(ProjectForAddDto projectForAddDto);
        List<ProjectForGetDto> GetAll();
    }
}
