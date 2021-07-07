using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DTO.DepartmantDTO;
using career.DTO.EmployeeDTO;
using career.DTO.PositionDTO;
using career.DTO.Utility;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public EmployeeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GetEmployeeDto AddEmployee(EmployeeAddDto employeeAddDto)
        {
           
            var mappedEmployee = _mapper.Map<Employee>(employeeAddDto);
            _unitOfWork.EmployeeDal.Add(mappedEmployee);
            _unitOfWork.Commit();
            var mapped = _unitOfWork.EmployeeDal.GetAll().SingleOrDefault(x => x.EmployeeId == mappedEmployee.EmployeeId);
            var result = _mapper.Map<GetEmployeeDto>(mapped);
            return result;
        }

        public void DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeDal.Get().SingleOrDefault(x => x.EmployeeId == id);
            employee.IsDeleted = true;
            _unitOfWork.EmployeeDal.Update(employee);
            _unitOfWork.Commit();
        }

        public List<GetEmployeeDto> GetAll()
        {
            var result = _unitOfWork.EmployeeDal.GetAll();

            var mappedEmployee = _mapper.Map<List<GetEmployeeDto>>(result);
            return mappedEmployee;
        }

        public List<FilterDTO> GetAllWithFilter()
        {
            var result = _unitOfWork.EmployeeDal.GetAll();

            var mappedEmployee = _mapper.Map<List<FilterDTO>>(result);
            return mappedEmployee;
        }

        public UpdateEmployeeDto UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var mappedEmployee = _mapper.Map<Employee>(updateEmployeeDto);
            _unitOfWork.EmployeeDal.Update(mappedEmployee);
            _unitOfWork.Commit();
            return updateEmployeeDto;
        }
    }
}
