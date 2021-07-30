using career.DAL.Utilities.Results;
using career.DTO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Abstract
{
    public interface IPositionService
    {
        IDataResult<List<FilterDTO>> GetPositionFilters();
    }
}
