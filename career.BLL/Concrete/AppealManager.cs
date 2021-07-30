using AutoMapper;
using career.BLL.Abstract;
using career.BLL.Constants;
using career.DAL.DataAccess;
using career.DAL.Utilities.Results;
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

        public IDataResult<AppealForAddResponse> AddAppeal(AppealForAddDto appealForAddDto)
        {
            var result = _unitOfWork.AppealDal.GetAll().Where(x => x.VacancyId == appealForAddDto.VacancyId);
            if (result != null)
            {
                var mappedAppeal = _mapper.Map<Appeal>(appealForAddDto);
                _unitOfWork.AppealDal.Add(mappedAppeal);
                _unitOfWork.Commit();
                var appeal = _unitOfWork.AppealDal.GetAll().SingleOrDefault(x => x.AppealId == mappedAppeal.AppealId);
                var response = _mapper.Map<AppealForAddResponse>(appeal);
                return new SuccessDataResult<AppealForAddResponse>(response, Messages.DataSuccessfullyAdded);
            }
            return new ErrorDataResult<AppealForAddResponse>(Messages.ErrorOccured);
        }

        public IResult Delete(int id)
        {
            var appeal = _unitOfWork.AppealDal.Get().SingleOrDefault(x => x.AppealId == id);
            if (appeal != null)
            {
                appeal.IsDeleted = true;
                _unitOfWork.AppealDal.Update(appeal);
                _unitOfWork.Commit();
                return new SuccessResult(Messages.DataDeleted);
            }
            return new ErrorResult(Messages.ErrorOccured);
        }

        public IDataResult<List<AppealForGetDto>> GetAppealByVacancyId(int vacancyId)
        {
            var result = _unitOfWork.AppealDal.GetAll().Where(x => x.VacancyId == vacancyId);
            var mappedAppeal = _mapper.Map<List<AppealForGetDto>>(result);
            if (mappedAppeal.Count > 0)
                return new SuccessDataResult<List<AppealForGetDto>>(mappedAppeal, Messages.DataListedSuccessfully);

            return new ErrorDataResult<List<AppealForGetDto>>(mappedAppeal, Messages.DataNotFound);
        }

        public IDataResult<List<AppealForGetDto>> GetAppeals()
        {
            var result = _unitOfWork.AppealDal.GetAll();
            var mappedAppeal = _mapper.Map<List<AppealForGetDto>>(result);
            return new SuccessDataResult<List<AppealForGetDto>>(mappedAppeal, Messages.DatasListedSuccessfully);
        }

        public IDataResult<AppealForUpdateResponse> UpdateAppeal(AppealForUpdateDto appealForUpdateDto)
        {
            var data = _unitOfWork.AppealDal.GetAll().SingleOrDefault(x => x.AppealId == appealForUpdateDto.AppealId);
            var vacancy = _unitOfWork.AppealDal.GetAll().SingleOrDefault(x => x.VacancyId == appealForUpdateDto.VacancyId);
            if (data != null && vacancy != null)
            {
                var mappedAppeal = _mapper.Map<Appeal>(appealForUpdateDto);
                _unitOfWork.AppealDal.Update(mappedAppeal);
                _unitOfWork.Commit();
                var result = _mapper.Map<AppealForUpdateResponse>(data);
                return new SuccessDataResult<AppealForUpdateResponse>(result, Messages.DataUpdated);
            }
            return new ErrorDataResult<AppealForUpdateResponse>(Messages.ErrorOccured);
        }
    }
}
