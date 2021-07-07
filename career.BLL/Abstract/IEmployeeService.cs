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
        List<GetEmployeeDto> GetAll();
        List<FilterDTO> GetAllWithFilter();
        GetEmployeeDto AddEmployee(EmployeeAddDto employeeAddDto);
        GetEmployeeDto UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        void DeleteEmployee(int id);
    }
}
