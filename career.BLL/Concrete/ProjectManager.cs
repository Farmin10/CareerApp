using AutoMapper;
using career.BLL.Abstract;
using career.BLL.Constants;
using career.DAL.DataAccess;
using career.DAL.Utilities.Results;
using career.DTO;
using career.DTO.PictureDTO;
using career.DTO.ProjectDTO;
using career.DTO.Responses;
using career.Entity.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class ProjectManager : IProjectService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        IPictureService _pictureService;
        public ProjectManager(IUnitOfWork unitOfWork, IMapper mapper, IPictureService pictureService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pictureService = pictureService;
        }
        public IDataResult<ProjectForAddResponse> AddProject(ProjectForAddDto projectForAddDto)
        {
            try
            {
                var mappedProject = _mapper.Map<Project>(projectForAddDto);
                _unitOfWork.ProjectDal.Add(mappedProject);
                _unitOfWork.Commit();
                foreach (var item in projectForAddDto.Pictures)
                {
                    var result = _mapper.Map<Picture>(projectForAddDto);
                    _unitOfWork.PictureDal.Add(result);
                }
                var project = _unitOfWork.ProjectDal.GetAll().SingleOrDefault(x => x.ProjectId == mappedProject.ProjectId);
                var response = _mapper.Map<ProjectForAddResponse>(project);
                return new SuccessDataResult<ProjectForAddResponse>(response, Messages.DataSuccessfullyAdded);
            }
            catch (Exception)
            {

                return new ErrorDataResult<ProjectForAddResponse>(Messages.ErrorOccured);
            }
            
        }

        public IResult DeleteProject(int id)
        {
            try
            {
                var project = _unitOfWork.ProjectDal.Get().SingleOrDefault(x => x.ProjectId == id);
                project.IsDeleted = true;
                _unitOfWork.ProjectDal.Update(project);

                var picture = _unitOfWork.PictureDal.Get().Where(x => x.ProjectId == id).ToList();
                foreach (var item in picture)
                {
                    item.IsDeleted = true;
                }
                _unitOfWork.PictureDal.UpdateRange(picture);
                _unitOfWork.Commit();
                return new SuccessResult(Messages.DataDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ErrorOccured);
            }
            
        }

        public IDataResult<List<ProjectForGetDto>> GetAll()
        {
            try
            {
                var result = _unitOfWork.ProjectDal.GetAll();
                var mappedProject = _mapper.Map<List<ProjectForGetDto>>(result);

                return new SuccessDataResult<List<ProjectForGetDto>>(mappedProject,Messages.DatasListedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<ProjectForGetDto>>(Messages.ErrorOccured);
            }
           
        }

        public IDataResult<ProjectForGetDto> GetById(int id)
        {
            try
            {
                var result = _unitOfWork.ProjectDal.GetAll().SingleOrDefault(x => x.ProjectId == id);
                var mappedProject = _mapper.Map<ProjectForGetDto>(result);
                return new SuccessDataResult<ProjectForGetDto>(mappedProject, Messages.DataListedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorDataResult<ProjectForGetDto>(Messages.ErrorOccured);
            }
            
        }

        public IDataResult<ProjectForUpdateDto> UpdateProject(ProjectForUpdateDto projectForUpdateDto)
        {
            try
            {
                var mappedProject = _mapper.Map<Project>(projectForUpdateDto);
                _unitOfWork.ProjectDal.Update(mappedProject);
                _unitOfWork.Commit();

                var deletedPicture = _unitOfWork.PictureDal.Get(x => x.ProjectId == projectForUpdateDto.ProjectId);
                foreach (var item in deletedPicture)
                {
                    _unitOfWork.PictureDal.Delete(item);
                    _unitOfWork.Commit();
                }

                PictureForAddDto pictureForAddDto = new PictureForAddDto();
                foreach (var item in projectForUpdateDto.Pictures)
                {
                    pictureForAddDto = new PictureForAddDto { PicturePath = item.PicturePath, ProjectId = mappedProject.ProjectId };
                    _pictureService.AddPicture(pictureForAddDto);
                    _unitOfWork.Commit();
                }
                return new SuccessDataResult<ProjectForUpdateDto>(projectForUpdateDto, Messages.DataUpdated);
            }
            catch (Exception)
            {
                return new ErrorDataResult<ProjectForUpdateDto>(Messages.ErrorOccured);
            }
            
        }
    }
}
