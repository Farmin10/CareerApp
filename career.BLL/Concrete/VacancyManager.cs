using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO.VacancyDTO;
using career.DTO.VacancyInformationDto;
using career.DTO.VacancyRequirementDto;
using career.DTO.VacancyTypeDTO;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using career.DTO.Utility;
using career.DTO.Responces;

namespace career.BLL.Concrete
{
    public class VacancyManager : IVacancyService
    {

        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public VacancyManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public VacancyAddDto AddVacancy(VacancyAddDto vacancyAddDto)
        {
            #region VacancyAdd
            var mappedVacancy = _mapper.Map<Vacancy>(vacancyAddDto);
            _unitOfWork.VacancyDal.Add(mappedVacancy);
            _unitOfWork.Commit();
            var result = _unitOfWork.VacancyDal.Get().FirstOrDefault(x => x.VacancyId == mappedVacancy.VacancyId).VacancyId;
            #endregion

            #region VacancyInformation
            List<VacancyInformationAddDto> vacancyInformationAddDto = vacancyAddDto.VacancyInformationAddDto;
            var mappedInformation = _mapper.Map<List<VacancyInformation>>(vacancyInformationAddDto);
            foreach (var item in mappedInformation)
            {
                item.VacancyId = result;
            }
            _unitOfWork.VacancyInformationDal.AddRange(mappedInformation);
            #endregion

            #region VcancyRequirements
            List<VacancyRequirementAddDto> vacancyRequirementAddDtos = vacancyAddDto.VacancyRequirementAddDtos;
            var mappedRequirements = _mapper.Map<List<VacancyRequirement>>(vacancyRequirementAddDtos);
            foreach (var item in mappedRequirements)
            {
                item.VacancyId = result;
            }

            _unitOfWork.VacancyRequirementDal.AddRange(mappedRequirements);
            #endregion

            _unitOfWork.Commit();

            return vacancyAddDto;
        }

        public void DeleteVacancy(int id)
        {
            var vacancy = _unitOfWork.VacancyDal.Get().SingleOrDefault(x => x.VacancyId == id);
            vacancy.IsDeleted = true;
            _unitOfWork.VacancyDal.Update(vacancy);

            var info = _unitOfWork.VacancyInformationDal.Get().Where(x => x.VacancyId == id).ToList();
            foreach (var item in info)
            {
                item.IsDeleted = true;
            }
            _unitOfWork.VacancyInformationDal.UpdateRange(info);


            var requirements = _unitOfWork.VacancyRequirementDal.Get().Where(x => x.VacancyId == id).ToList();
            foreach (var requirement in requirements)
            {
                requirement.IsDeleted = true;
            }
            _unitOfWork.VacancyRequirementDal.UpdateRange(requirements);
            _unitOfWork.Commit();
        }

        public List<FilterDTO> GetAllWithFilter()
        {
            var result = _unitOfWork.VacancyDal.GetVacancies();

            var mappedVacancy = _mapper.Map<List<FilterDTO>>(result);
            return mappedVacancy;
        }

        public List<VacanciesDto> GetVacancies()
        {
            #region GetAllVacancies
            var result = _unitOfWork.VacancyDal.GetVacancies().ToList();
            var mappedVacancies = _mapper.Map<List<VacanciesDto>>(result);
            foreach (var list in result)
            {
                var mappedType = _mapper.Map<VacancyTypeDto>(list.VacancyType);
                var mappedInfo = _mapper.Map<List<VacancyInformationGetDto>>(list.VacancyInformation);
                var mappedRequirement = _mapper.Map<List<VacancyRequirementGetDto>>(list.VacancyRequirements);
                foreach (var item in mappedVacancies)
                {
                    item.VacancyTypeDto = mappedType;
                    item.VacancyInformationGetDtos = mappedInfo;
                    item.VacancyRequirementGetDtos = mappedRequirement;

                }
            }
            return mappedVacancies.ToList();
            #endregion

        }

        public VacanciesDto GetVacancyById(int id)
        {
            #region Get Vacancy By Id

            var result = _unitOfWork.VacancyDal.GetVacancyById(id);

            var mappedVacancy = _mapper.Map<VacanciesDto>(result);


            var mappedType = _mapper.Map<VacancyTypeDto>(result.VacancyType);
            var mappedInfo = _mapper.Map<List<VacancyInformationGetDto>>(result.VacancyInformation);
            var mappedRequirement = _mapper.Map<List<VacancyRequirementGetDto>>(result.VacancyRequirements);

            mappedVacancy.VacancyTypeDto = mappedType;
            mappedVacancy.VacancyInformationGetDtos = mappedInfo;
            mappedVacancy.VacancyRequirementGetDtos = mappedRequirement;

            return mappedVacancy;
            #endregion
        }

        public Vacancy UpdateVacancy(VacancyUpdateDto vacancyUpdateDto)
        {
            #region VacancyUpdate
            var mappedVacancy = _mapper.Map<Vacancy>(vacancyUpdateDto);
            _unitOfWork.VacancyDal.Update(mappedVacancy);
            _unitOfWork.Commit();
            #endregion

            #region VacancyInfoUpdate
            var deletedInfo= _unitOfWork.VacancyInformationDal.Get(x=>x.VacancyId==vacancyUpdateDto.VacancyId);
            foreach (var item in deletedInfo)
            {
                _unitOfWork.VacancyInformationDal.Delete(item);
            }
            List<VacancyInformationUpdateDto> vacancyInformationUpdateDtos = vacancyUpdateDto.VacancyInformationUpdateDtos;
            var mappedInformation = _mapper.Map<List<VacancyInformation>>(vacancyInformationUpdateDtos);
            foreach (var item in mappedInformation)
            {
                var vacancyInfo = _unitOfWork.VacancyInformationDal.Get().Where(x => x.VacancyId == mappedVacancy.VacancyId);
                foreach (var list in vacancyInfo)
                {
                    item.VacancyId = vacancyUpdateDto.VacancyId;
                    item.VacancyInfoId = list.VacancyInfoId;
                    _unitOfWork.VacancyInformationDal.Add(item);
                }
               
            }
            #endregion

            #region VacancyReqirementUpdate
            var deletedRequirements = _unitOfWork.VacancyRequirementDal.Get(x => x.VacancyId == vacancyUpdateDto.VacancyId);
            foreach (var item in deletedRequirements)
            {
                _unitOfWork.VacancyRequirementDal.Delete(item);
               
            }
            List<VacancyRequirementUpdateDto> vacancyRequirementUpdateDtos = vacancyUpdateDto.VacancyRequirementUpdateDtos;
            var mappedRequirement = _mapper.Map<List<VacancyRequirement>>(vacancyRequirementUpdateDtos);
            foreach (var item in mappedRequirement)
            {
                var vacancyRequiremnt = _unitOfWork.VacancyRequirementDal.Get().Where(x => x.VacancyId == mappedVacancy.VacancyId);
                foreach (var list in vacancyRequiremnt)
                {
                    item.VacancyId = vacancyUpdateDto.VacancyId;
                    item.VacancyRequirementId = list.VacancyRequirementId;
                    _unitOfWork.VacancyRequirementDal.Add(item);
                }
                
            }
            #endregion
            _unitOfWork.Commit();
            var mapped = _unitOfWork.VacancyDal.GetVacancies().SingleOrDefault(x=>x.VacancyId==vacancyUpdateDto.VacancyId);
            return mapped;
        }
    }
}
