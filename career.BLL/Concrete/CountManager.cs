using AutoMapper;
using career.BLL.Abstract;
using career.BLL.Constants;
using career.DAL.DataAccess;
using career.DAL.Utilities.Results;
using career.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class CountManager : ICountService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CountManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IDataResult<CountResponse> Count()
        {
            var employeeCount = _unitOfWork.EmployeeDal.Count(null);
            var vacancyCount= _unitOfWork.VacancyDal.Count(null);
            var appealCount = _unitOfWork.AppealDal.Count(null);
            var projectCount = _unitOfWork.ProjectDal.Count(null);
            var response = new CountResponse { 
            CountOfAppeal=appealCount,CountOfEmployee=employeeCount,CountOfProject=projectCount,CountOfVacancy=vacancyCount
            };
            return new SuccessDataResult<CountResponse>(response,Messages.DatasListedSuccessfully);
        }
    }
}
