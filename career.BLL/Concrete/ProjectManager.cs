
using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO;
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

        public List<ProjectForGetDto> GetAll()
        {
            var result = _unitOfWork.ProjectDal.GetAll();
            var mappedProject = _mapper.Map<List<ProjectForGetDto>>(result);
            return mappedProject;
        }
    }
}
