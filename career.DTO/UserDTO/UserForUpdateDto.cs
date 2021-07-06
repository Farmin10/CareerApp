using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DTO.UserDTO
{
    public class UserForUpdateDto
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
