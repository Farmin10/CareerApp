using career.DTO.Responces;
using career.DTO.UserDTO;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Abstract
{

    public interface IUserService
    {
        Task Add(User user);
        User GetByUserName(string userName);
        UserForUpdateResponse UpdateUser(UserForUpdateDto userForUpdateDto,string password);
    }
}
