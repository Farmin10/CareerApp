using career.DAL.Utilities.Results;
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
        Task<IResult> Add(User user);
        IDataResult<User> GetByUserName(string userName);
        IDataResult<UserForUpdateResponse> UpdateUser(UserForUpdateDto userForUpdateDto,string password);
    }
}
