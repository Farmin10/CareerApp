
using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO;
using career.DTO.PictureDTO;
using career.DTO.ProjectDTO;
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
        public ProjectForAddDto AddProject(ProjectForAddDto projectForAddDto)
        {
            var mappedProject = _mapper.Map<Project>(projectForAddDto);
            _unitOfWork.ProjectDal.Add(mappedProject);
            _unitOfWork.Commit();
            PictureForAddDto pictureForAddDto = new PictureForAddDto();
            foreach (var item in projectForAddDto.PicturesPath)
            {
                pictureForAddDto = new PictureForAddDto { PicturePath = item ,ProjectId=mappedProject.ProjectId};
                _pictureService.AddPicture(pictureForAddDto);
                _unitOfWork.Commit();
            }
           
            return projectForAddDto;
        }

        public void DeleteProject(int id)
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
        }

        public List<ProjectForGetDto> GetAll()
        {
            var result = _unitOfWork.ProjectDal.GetAll();
            var mappedProject = _mapper.Map<List<ProjectForGetDto>>(result);
            
            return mappedProject;
        }

        public ProjectForUpdateDto UpdateProject(ProjectForUpdateDto projectForUpdateDto)
        {
            var mappedProject = _mapper.Map<Project>(projectForUpdateDto);
            _unitOfWork.ProjectDal.Update(mappedProject);
            _unitOfWork.Commit();

            var deletedPicture = _unitOfWork.PictureDal.Get(x => x.ProjectId == projectForUpdateDto.ProjectId);
            foreach (var item in deletedPicture)
            {
                _unitOfWork.PictureDal.Delete(item);
            }

            PictureForAddDto pictureForAddDto = new PictureForAddDto();
            foreach (var item in projectForUpdateDto.PicturesPath)
            {
                pictureForAddDto = new PictureForAddDto { PicturePath = item, ProjectId = mappedProject.ProjectId };
                _pictureService.AddPicture(pictureForAddDto);
                _unitOfWork.Commit();
            }
            return projectForUpdateDto;
        }
    }
}
