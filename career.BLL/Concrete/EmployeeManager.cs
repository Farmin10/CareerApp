using AutoMapper;
using career.BLL.Abstract;
using career.BLL.Constants;
using career.DAL.DataAccess;
using career.DAL.Utilities.Results;
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

        public IDataResult<GetEmployeeDto> AddEmployee(EmployeeAddDto employeeAddDto)
        {
            try
            {
                var mappedEmployee = _mapper.Map<Employee>(employeeAddDto);
                _unitOfWork.EmployeeDal.Add(mappedEmployee);
                _unitOfWork.Commit();
                var mapped = _unitOfWork.EmployeeDal.GetAll().SingleOrDefault(x => x.EmployeeId == mappedEmployee.EmployeeId);
                var result = _mapper.Map<GetEmployeeDto>(mapped);
                return new SuccessDataResult<GetEmployeeDto>(result, Messages.DataSuccessfullyAdded);
            }
            catch (Exception)
            {
                return new ErrorDataResult<GetEmployeeDto>(Messages.ErrorOccured);
            }
           
        }

        public IResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _unitOfWork.EmployeeDal.Get().SingleOrDefault(x => x.EmployeeId == id);
                var user = _unitOfWork.UserDal.Get().Where(x => x.EmployeeId == employee.EmployeeId);
                employee.IsDeleted = true;
                _unitOfWork.EmployeeDal.Update(employee);
                foreach (var item in user)
                {
                    item.IsDeleted = true;
                    _unitOfWork.UserDal.Update(item);
                }
                _unitOfWork.Commit();
                return new SuccessResult(Messages.DataDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ErrorOccured);
            }
            
        }

        public IDataResult<List<GetEmployeeDto>> GetAll()
        {
            try
            {
                var result = _unitOfWork.EmployeeDal.GetAll();
                var mappedEmployee = _mapper.Map<List<GetEmployeeDto>>(result);
                return new SuccessDataResult<List<GetEmployeeDto>>(mappedEmployee,Messages.DatasListedSuccessfully);
            }
            catch (Exception)
            {
                return new SuccessDataResult<List<GetEmployeeDto>>(Messages.DatasListedSuccessfully);
            }
           
        }

        public IDataResult<List<FilterDTO>> GetAllWithFilter()
        {
            try
            {
                var result = _unitOfWork.EmployeeDal.GetAll();
                var mappedEmployee = _mapper.Map<List<FilterDTO>>(result);
                return new SuccessDataResult<List<FilterDTO>>(mappedEmployee,Messages.DatasListedSuccessfully);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<FilterDTO>>(Messages.ErrorOccured);
            }
            
        }

        public IDataResult<GetEmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            try
            {
                var mappedEmployee = _mapper.Map<Employee>(updateEmployeeDto);
                _unitOfWork.EmployeeDal.Update(mappedEmployee);
                _unitOfWork.Commit();
                var updatedEmployee = _unitOfWork.EmployeeDal.GetAll().SingleOrDefault(x => x.EmployeeId == mappedEmployee.EmployeeId);
                var result = _mapper.Map<GetEmployeeDto>(updatedEmployee);
                return new SuccessDataResult<GetEmployeeDto>(result,Messages.DataUpdated);
            }
            catch (Exception)
            {
                return new ErrorDataResult<GetEmployeeDto>( Messages.DataListedSuccessfully);
            }
            
        }
    }
}
