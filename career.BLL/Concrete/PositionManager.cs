using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class PositionManager : IPositionService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public PositionManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<FilterDTO> GetPositionFilters()
        {
            var result = _unitOfWork.PositionDal.Get();

            var mappedPosition = _mapper.Map<List<FilterDTO>>(result);
            return mappedPosition;
        }
    }
}
