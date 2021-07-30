using AutoMapper;
using career.BLL.Abstract;
using career.BLL.Constants;
using career.DAL.DataAccess;
using career.DAL.Utilities.Results;
using career.DAL.Utilities.Security.Hashing;
using career.DTO.Responces;
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

        public async Task<IResult> Add(User user)
        {
            try
            {
                await _unitOfWork.UserDal.AddAsync(user);
                return new SuccessResult(Messages.DataSuccessfullyAdded);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ErrorOccured);
            }
            
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            try
            {
                var result = _unitOfWork.UserDal.Get(u => u.UserName == userName).FirstOrDefault();
                return new SuccessDataResult<User>(result,Messages.DataListedSuccessfully);
            }
            catch (Exception)
            {

                return new ErrorDataResult<User>(Messages.ErrorOccured);
            }
            
        }

        public IDataResult<UserForUpdateResponse> UpdateUser(UserForUpdateDto userForUpdateDto,string password)
        {
            try
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

                var mappedUser = _unitOfWork.UserDal.GetUsers().SingleOrDefault(x => x.UserId == result.UserId);
                var response = _mapper.Map<UserForUpdateResponse>(mappedUser);
                return new SuccessDataResult<UserForUpdateResponse>(response,Messages.DataUpdated);
            }
            catch (Exception)
            {
                return new ErrorDataResult<UserForUpdateResponse>(Messages.ErrorOccured);
            }
           
        }
    }
}
