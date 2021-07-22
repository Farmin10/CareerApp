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
        List<NewsForGetDto> GetNews();
        NewsResponse AddNews(NewsForAddDto newsForAddDto);
        NewsForGetDto GetNewsById(int id);
        NewsResponse UpdateNews(NewsForUpdateDto newsForUpdateDto);
        void Delete(int id);
    }
}
