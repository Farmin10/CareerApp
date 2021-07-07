using career.DTO.Responces;
using career.DTO.Utility;
using career.DTO.VacancyDTO;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Abstract
{
    public interface IVacancyService
    {
        List<VacanciesDto> GetVacancies();
        List<FilterDTO> GetAllWithFilter();
        VacanciesDto GetVacancyById(int id);
        VacancyAddDto AddVacancy(VacancyAddDto vacancyAddDto);
        Vacancy UpdateVacancy(VacancyUpdateDto vacancyUpdateDto);
        void DeleteVacancy(int id);
    }
}
