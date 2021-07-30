using career.DAL.Utilities.Results;
using career.DTO.Responces;
using career.DTO.Utility;
using career.DTO.VacancyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Abstract
{
    public interface IVacancyService
    {
        IDataResult<List<VacanciesDto>> GetVacancies();
        IDataResult<List<FilterDTO>> GetAllWithFilter();
        IDataResult<VacanciesDto> GetVacancyById(int id);
        IDataResult<VacancyForAddResponse> AddVacancy(VacancyAddDto vacancyAddDto);
        IDataResult<VacancyForUpdateResponse> UpdateVacancy(VacancyUpdateDto vacancyUpdateDto);
        IResult DeleteVacancy(int id);
    }
}
