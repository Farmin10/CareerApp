using career.DAL.Utilities.Results;
using career.DTO.EmployeeDTO;
using career.DTO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<GetEmployeeDto>> GetAll();
        IDataResult<List<FilterDTO>> GetAllWithFilter();
        IDataResult<GetEmployeeDto> AddEmployee(EmployeeAddDto employeeAddDto);
        IDataResult<GetEmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        IResult DeleteEmployee(int id);
    }
}
