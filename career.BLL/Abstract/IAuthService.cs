using career.DAL.Utilities.Security.JWT;
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
    public interface IAuthService
    {
        Task<UserForAddResponse> Register(UserForRegisterDto userForRegisterDto, string password);
        List<UserForGetDto> GetUsers();
        Task<User> Login(UserForLoginDto userForLoginDto);
        Task<bool> UserExists(string userName);
        Task<AccessToken> CreateAccessToken(User user);
        void DeleteUser(int id);
    }
}
