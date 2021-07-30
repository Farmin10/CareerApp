using career.DAL.Utilities.Results;
using career.DTO.NewsDTO;
using career.DTO.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Abstract
{
    public interface INewsService
    {
        IDataResult<List<NewsForGetDto>> GetNews();
        IDataResult<NewsResponse> AddNews(NewsForAddDto newsForAddDto);
        IDataResult<NewsForGetDto> GetNewsById(int id);
        IDataResult<NewsResponse> UpdateNews(NewsForUpdateDto newsForUpdateDto);
        IResult Delete(int id);
    }
}
