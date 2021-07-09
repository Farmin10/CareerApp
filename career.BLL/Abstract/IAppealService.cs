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
        List<AppealForGetDto> GetAppeals();
        AppealForAddResponse  AddAppeal(AppealForAddDto appealForAddDto);
        AppealForUpdateResponse  UpdateAppeal(AppealForUpdateDto appealForUpdateDto);
        void Delete(int id);
    }
}
