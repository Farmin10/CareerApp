using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO.Utility;
using career.DTO.VacancyDTO;
using career.DTO.VacancyTypeDTO;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class VacancyTypeManager : IVacancyTypeService
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public VacancyTypeManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public VacancyTypeAddDto AddVacancyType(VacancyTypeAddDto vacancyTypeAddDto)
        {
            var mappedVacancyType = _mapper.Map<VacancyType>(vacancyTypeAddDto);
            _unitOfWork.VacancyTypeDal.Add(mappedVacancyType);
            _unitOfWork.Commit();
            return vacancyTypeAddDto;
        }

        public List<VacancyTypesDTO> GetAll()
        {
            var result= _unitOfWork.VacancyTypeDal.Get();
            var mappedEntity = _mapper.Map<List<VacancyTypesDTO>>(result);
            return mappedEntity;
        }

        public List<FilterDTO> GetAllByFilter()
        {
            var result = _unitOfWork.VacancyTypeDal.Get();
            var mappedEntity = _mapper.Map<List<FilterDTO>>(result);
            return mappedEntity;
        }

        public VacancyTypeUpdateDto UpdateVacancyType(VacancyTypeUpdateDto vacancyTypeUpdateDto)
        {
            var mappedVacancyType = _mapper.Map<VacancyType>(vacancyTypeUpdateDto);
            _unitOfWork.VacancyTypeDal.Update(mappedVacancyType);
            _unitOfWork.Commit();
            return vacancyTypeUpdateDto;
        }
    }
}
