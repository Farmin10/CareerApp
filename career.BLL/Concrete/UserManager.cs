using AutoMapper;
using career.BLL.Abstract;
using career.DAL.DataAccess;
using career.DAL.Utilities.Security.Hashing;
using career.DTO.UserDTO;
using career.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.Concrete
{
    public class UserManager : IUserService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UserManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(User user)
        {
            await _unitOfWork.UserDal.AddAsync(user);
        }

        public User GetByUserName(string userName)
        {
            return _unitOfWork.UserDal.Get(u => u.UserName == userName).FirstOrDefault();
        }

        public User UpdateUser(UserForUpdateDto userForUpdateDto,string password)
        {

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var result = _unitOfWork.UserDal.Get(x => x.UserId == userForUpdateDto.UserId).FirstOrDefault();


            result.EmployeeId = userForUpdateDto.EmployeeId;
            result.UserName = userForUpdateDto.UserName;
            result.PasswordHash = passwordHash;
            result.PasswordSalt = passwordSalt;
            
            
            _unitOfWork.UserDal.Update(result);


            _unitOfWork.Commit();
            return result;
        }
    }
}
