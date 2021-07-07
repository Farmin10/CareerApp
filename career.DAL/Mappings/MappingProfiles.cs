﻿using AutoMapper;
using career.DTO;
using career.DTO.DepartmantDTO;
using career.DTO.EmployeeDTO;
using career.DTO.FileDTO;
using career.DTO.PositionDTO;
using career.DTO.ProjectDTO;
using career.DTO.UserDTO;
using career.DTO.Utility;
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

namespace career.DAL.Mappings
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<VacancyType, VacancyTypesDTO>().ReverseMap();
            CreateMap<VacancyType, VacancyTypeAddDto>().ReverseMap();
            CreateMap<VacancyType, VacancyTypeDto>().ReverseMap();
            CreateMap<VacancyType, FilterDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.VacancyTypeId))
                .ForMember(x => x.Value, opt => opt.MapFrom(a => a.Name));



            CreateMap<Departmant, GetDepartmantDto>().ReverseMap();
            CreateMap<Departmant, GetDepartmantForEmployeeDto>().ReverseMap();
            CreateMap<Departmant, FilterDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.DepartmantId))
                .ForMember(x => x.Value, opt => opt.MapFrom(a => a.Name));





            CreateMap<User, UserForGetDto>().ReverseMap();
            CreateMap<UserForGetDto, FilterDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.UserId))
                .ForMember(x => x.Value, opt => opt.MapFrom(a => a.UserName));




            CreateMap<Position, GetPositionDto>().ReverseMap();
            CreateMap<Position, GetPositionForEmployeeDto>().ReverseMap();
            CreateMap<Position, FilterDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.PositionId))
                .ForMember(x => x.Value, opt => opt.MapFrom(a => a.Name));



            CreateMap<Employee, GetEmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeAddDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, FilterDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.EmployeeId))
                .ForMember(x => x.Value, opt => opt.MapFrom(a => a.Name+" "+a.SurName));





            CreateMap<File, FileUploadDto>().ReverseMap();




            CreateMap<Picture, PictureForAddDto>().ReverseMap();





            CreateMap<Project, ProjectForAddDto>().ReverseMap();
            CreateMap<Project, ProjectForGetDto>().ReverseMap();





            CreateMap<Vacancy, VacancyUpdateDto>().ReverseMap();
            CreateMap<Vacancy, VacancyAddDto>().ReverseMap();
            CreateMap<Vacancy, VacanciesDto>().ReverseMap();
            CreateMap<Vacancy, VacancyDeleteDto>().ReverseMap();
            CreateMap<Vacancy, FilterDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.VacancyId))
                .ForMember(x => x.Value, opt => opt.MapFrom(a => a.Education + "," + a.WorkLocation));




            CreateMap<VacancyInformation, VacancyInformationUpdateDto>().ReverseMap();
            CreateMap<VacancyInformation, VacancyInformationAddDto>().ReverseMap();
            CreateMap<VacancyInformation, VacancyInformationGetDto>().ReverseMap();
            CreateMap<VacancyInformation, VacancyInformationDeleteDto>().ReverseMap();


            CreateMap<VacancyRequirement, VacancyRequirementUpdateDto>().ReverseMap();
            CreateMap<VacancyRequirement, VacancyRequirementAddDto>().ReverseMap();
            CreateMap<VacancyRequirement, VacancyRequirementGetDto>().ReverseMap();
            CreateMap<VacancyRequirement, VacancyRequirementDeleteDto>().ReverseMap();

            
        }
    }
}
