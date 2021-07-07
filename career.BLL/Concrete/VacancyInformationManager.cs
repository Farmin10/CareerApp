using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO.VacancyInformationDto;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class VacancyInformationManager : IVacancyInformationService
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public VacancyInformationManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

       

        
    }
}
