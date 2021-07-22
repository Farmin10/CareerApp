using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class PictureManager : IPictureService
    {

        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public PictureManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PictureForAddDto AddPicture(PictureForAddDto pictureForAddDto)
        {
            var mappedPicture = _mapper.Map<Picture>(pictureForAddDto);
            _unitOfWork.PictureDal.Add(mappedPicture);
            return pictureForAddDto;
        }

        public void Delete(int id)
        {
            var deletedPicture = _unitOfWork.PictureDal.Get(x => x.ProjectId == id);
            foreach (var item in deletedPicture)
            {
                _unitOfWork.PictureDal.Delete(item);
            }
            
        }

        public PictureForUpdateDto UpdatePicture(PictureForUpdateDto pictureForUpdateDto)
        {
            var mappedPicture = _mapper.Map<Picture>(pictureForUpdateDto);
            _unitOfWork.PictureDal.Update(mappedPicture);
            _unitOfWork.Commit();
            return pictureForUpdateDto;
        }
    }
}
