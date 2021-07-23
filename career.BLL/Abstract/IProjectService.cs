using career.DTO.ProjectDTO;
using career.DTO.Responses;
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
        ProjectForAddResponse AddProject(ProjectForAddDto projectForAddDto);
        ProjectForUpdateDto UpdateProject(ProjectForUpdateDto projectForUpdateDto);
        List<ProjectForGetDto> GetAll();
        ProjectForGetDto GetById(int id);
        void DeleteProject(int id);
    }
}
