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
            _unitOfWork.Commit();
            return pictureForAddDto;
        }
    }
}
