using career.DAL.Utilities.Results;
using career.DTO.AppealDTO;
using career.DTO.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Abstract
{
    public interface IAppealService
    {
        IDataResult<List<AppealForGetDto>> GetAppeals();
        IDataResult<AppealForAddResponse>  AddAppeal(AppealForAddDto appealForAddDto);
        IDataResult<List<AppealForGetDto>>  GetAppealByVacancyId(int vacancyId);
        IDataResult<AppealForUpdateResponse>  UpdateAppeal(AppealForUpdateDto appealForUpdateDto);
        IResult Delete(int id);
    }
}
