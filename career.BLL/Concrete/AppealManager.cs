using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO.AppealDTO;
using career.DTO.Responces;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class AppealManager : IAppealService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public AppealManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AppealForAddResponse AddAppeal(AppealForAddDto appealForAddDto)
        {
            var mappedAppeal = _mapper.Map<Appeal>(appealForAddDto);
            _unitOfWork.AppealDal.Add(mappedAppeal);
            _unitOfWork.Commit();

            var appeal = _unitOfWork.AppealDal.GetAll().SingleOrDefault(x => x.AppealId == mappedAppeal.AppealId);
            var response = _mapper.Map<AppealForAddResponse>(appeal);
            return response;
        }

        public void Delete(int id)
        {
            var appeal = _unitOfWork.AppealDal.Get().SingleOrDefault(x => x.AppealId == id);
            appeal.IsDeleted = true;
            _unitOfWork.AppealDal.Update(appeal);
            _unitOfWork.Commit();
        }

        public List<AppealForGetDto> GetAppealByVacancyId(int  vacancyId)
        {
            var result = _unitOfWork.AppealDal.GetAll().Where(x => x.VacancyId == vacancyId);
            var mappedAppeal = _mapper.Map<List<AppealForGetDto>>(result);
            return mappedAppeal;
        }

        public List<AppealForGetDto> GetAppeals()
        {
            var result = _unitOfWork.AppealDal.GetAll();
            var mappedAppeal = _mapper.Map<List<AppealForGetDto>>(result);
            return mappedAppeal;
        }

        public AppealForUpdateResponse UpdateAppeal(AppealForUpdateDto appealForUpdateDto)
        {
            var mappedAppeal = _mapper.Map<Appeal>(appealForUpdateDto);
            mappedAppeal.VacancyId = appealForUpdateDto.VacancyId;
            _unitOfWork.AppealDal.Update(mappedAppeal);
            _unitOfWork.Commit();

            var appeal = _unitOfWork.AppealDal.GetAll().SingleOrDefault(x => x.AppealId == mappedAppeal.AppealId);
            var result = _mapper.Map<AppealForUpdateResponse>(appeal);
            return result;
        }
    }
}
