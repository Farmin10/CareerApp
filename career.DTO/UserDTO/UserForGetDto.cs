using career.DTO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.DTO.UserDTO
{
    public class UserForGetDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public FilterDTO Employee { get; set; }
    }
}
