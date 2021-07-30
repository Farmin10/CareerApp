using AutoMapper;
using career.BLL.Abstract;
using career.BLL.Constants;
using career.DAL.DataAccess;
using career.DAL.Utilities.Results;
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

        public IDataResult<NewsResponse> AddNews(NewsForAddDto newsForAddDto)
        {
            try
            {
                var mappedNews = _mapper.Map<News>(newsForAddDto);
                _unitOfWork.NewsDal.Add(mappedNews);
                _unitOfWork.Commit();

                var news = _unitOfWork.NewsDal.Get().SingleOrDefault(x => x.NewsId == mappedNews.NewsId);
                var response = _mapper.Map<NewsResponse>(news);
                return new SuccessDataResult<NewsResponse>(response,Messages.DataSuccessfullyAdded);
            }
            catch (Exception)
            {
                return new ErrorDataResult<NewsResponse>(Messages.ErrorOccured);
            }
            
        }

        public IResult Delete(int id)
        {
            try
            {
                var news = _unitOfWork.NewsDal.Get().SingleOrDefault(x => x.NewsId == id);
                news.IsDeleted = true;
                _unitOfWork.NewsDal.Update(news);
                _unitOfWork.Commit();
                return new SuccessResult(Messages.DataDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ErrorOccured);
            }
            
        }

        public IDataResult<List<NewsForGetDto>> GetNews()
        {
            try
            {
                var result = _unitOfWork.NewsDal.Get();
                var mappedNews = _mapper.Map<List<NewsForGetDto>>(result);
                return new SuccessDataResult<List<NewsForGetDto>>(mappedNews,Messages.DatasListedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<NewsForGetDto>>(Messages.DatasListedSuccessfully);
            }
           
        }

        public IDataResult<NewsForGetDto> GetNewsById(int id)
        {
            try
            {
                var result = _unitOfWork.NewsDal.Get(x => x.NewsId == id).SingleOrDefault();
                var mappedNews = _mapper.Map<NewsForGetDto>(result);
                return new SuccessDataResult<NewsForGetDto>(mappedNews, Messages.DataListedSuccessfully);
            }
            catch (Exception)
            {
                return new SuccessDataResult<NewsForGetDto>(Messages.ErrorOccured);
            }
           
        }

        public IDataResult<NewsResponse> UpdateNews(NewsForUpdateDto newsForUpdateDto)
        {
            try
            {
                var mappedNews = _mapper.Map<News>(newsForUpdateDto);
                _unitOfWork.NewsDal.Update(mappedNews);
                _unitOfWork.Commit();

                var news = _unitOfWork.NewsDal.Get().SingleOrDefault(x => x.NewsId == mappedNews.NewsId);
                var result = _mapper.Map<NewsResponse>(news);
                return new SuccessDataResult<NewsResponse>(result,Messages.DataUpdated);
            }
            catch (Exception)
            {
                return new ErrorDataResult<NewsResponse>(Messages.ErrorOccured);
            }
            
        }
    }
}
