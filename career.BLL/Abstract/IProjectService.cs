using career.DAL.Utilities.Results;
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
        IDataResult<ProjectForAddResponse> AddProject(ProjectForAddDto projectForAddDto);
        IDataResult<ProjectForUpdateDto> UpdateProject(ProjectForUpdateDto projectForUpdateDto);
        IDataResult<List<ProjectForGetDto>> GetAll();
        IDataResult<ProjectForGetDto> GetById(int id);
        IResult DeleteProject(int id);
    }
}
