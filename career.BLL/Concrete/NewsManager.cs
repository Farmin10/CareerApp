using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO.NewsDTO;
using career.DTO.Responces;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class NewsManager : INewsService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public NewsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public NewsResponse AddNews(NewsForAddDto newsForAddDto)
        {
            var mappedNews = _mapper.Map<News>(newsForAddDto);
            _unitOfWork.NewsDal.Add(mappedNews);
            _unitOfWork.Commit();

            var news=_unitOfWork.NewsDal.Get().SingleOrDefault(x => x.NewsId == mappedNews.NewsId);
            var response = _mapper.Map<NewsResponse>(news);
            return response;
        }

        public void Delete(int id)
        {
            var news = _unitOfWork.NewsDal.Get().SingleOrDefault(x => x.NewsId == id);
            news.IsDeleted = true;
            _unitOfWork.NewsDal.Update(news);
            _unitOfWork.Commit();
        }

        public List<NewsForGetDto> GetNews()
        {
            var result = _unitOfWork.NewsDal.Get();
            var mappedNews = _mapper.Map<List<NewsForGetDto>>(result);
            return mappedNews;
        }

        public NewsResponse UpdateNews(NewsForUpdateDto newsForUpdateDto)
        {
            var mappedNews = _mapper.Map<News>(newsForUpdateDto);
            mappedNews.NewsId = newsForUpdateDto.NewsId;
            _unitOfWork.NewsDal.Update(mappedNews);
            _unitOfWork.Commit();

            var news = _unitOfWork.NewsDal.Get().SingleOrDefault(x => x.NewsId == mappedNews.NewsId);
            var result = _mapper.Map<NewsResponse>(news);
            return result;
        }
    }
}
