using AutoMapper;
using career.BLL.Abstract;
using career.BLL.Constants;
using career.DAL.DataAccess;
using career.DAL.Utilities.Results;
using career.DTO.DepartmantDTO;
using career.DTO.EmployeeDTO;
using career.DTO.PositionDTO;
using career.DTO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class DepartmantManager : IDepartmantService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public DepartmantManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<GetDepartmantDto> GetAll()
        {
            var result = _unitOfWork.DepartmantDal.Get();
            
            var mappedDepartmant = _mapper.Map<List<GetDepartmantDto>>(result);
           
           
            return mappedDepartmant;
        }

        public IDataResult<List<FilterDTO>> GetAllWithFilter()
        {
            var result = _unitOfWork.DepartmantDal.Get();

            var mappedDepartmant = _mapper.Map<List<FilterDTO>>(result);


            return new SuccessDataResult<List<FilterDTO>>(mappedDepartmant,Messages.DatasListedSuccessfully);
        }
    }
}
