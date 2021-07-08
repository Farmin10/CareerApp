using career.BLL.Abstract;
using career.DTO.UserDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace career.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }



        /// <summary>
        /// Giriş
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (userToLogin == null)
            {
                return Ok(userToLogin);
            }

            var result = await _authService.CreateAccessToken(userToLogin);
            if (result != null)
            {
                return Ok(result);
            }

            return Ok(userToLogin);
        }



        /// <summary>
        /// Qeydiyyat
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            if (!await _authService.UserExists(userForRegisterDto.UserName))
            {
                return BadRequest();
            }

            var registerResult = await _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            return Ok(registerResult);
        }


        [HttpPost("update")]
        public ActionResult Update(UserForUpdateDto userForUpdate)
        {
            var registerResult = _userService.UpdateUser(userForUpdate, userForUpdate.Password);

            return Ok(registerResult);
        }



        /// <summary>
        /// istifadeci siyahisi
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _authService.GetUsers();
            return Ok(result);
        }



        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            _authService.DeleteUser(id);
            return Ok();
        }
    }
}
