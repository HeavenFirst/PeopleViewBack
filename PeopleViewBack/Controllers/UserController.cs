using Microsoft.AspNetCore.Mvc;
using PeopleViewBack.Constants;
using PeopleViewBack.DTOs;
using PeopleViewBack.Interfaces;

namespace PeopleViewBack.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) : base()
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Warnings.NOT_EVERY_REQUIRED_FIELD_IS_FILLED);
            }

            try
            {
                var user = await _userService.CreateUser(userDto);
                if (user is null)
                {
                    return BadRequest(Warnings.SOMTHING_WENT_WRONG);
                }
                else
                {
                    return Ok(user);
                }

            }
            catch (Exception ex)
            {
                return await ExceptionHandling(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] EditUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Warnings.NOT_EVERY_REQUIRED_FIELD_IS_FILLED);
            }

            try
            {
                var user = await _userService.EditUser(userDto);
                if (user is null)
                {
                    return BadRequest(Warnings.SOMTHING_WENT_WRONG);
                }
                else
                {
                    return Ok(user);
                }

            }
            catch (Exception ex)
            {
                return await ExceptionHandling(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] long id)
        {
            try
            {
                bool? result = await _userService.DeleteUser(id);
                if (result ?? true == true)
                {
                    return Ok();
                }

                return BadRequest(Warnings.SOMTHING_WENT_WRONG);
            }

            catch (Exception ex)
            {
                return await ExceptionHandling(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] long id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                if (user is not null)
                {
                    return Ok(user);
                }

                return BadRequest(Warnings.SOMTHING_WENT_WRONG);
            }

            catch (Exception ex)
            {
                return await ExceptionHandling(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();
                if (users is not null)
                {
                    return Ok(users);
                }

                return BadRequest(Warnings.SOMTHING_WENT_WRONG);
            }

            catch (Exception ex)
            {
                return await ExceptionHandling(ex);
            }
        }
    }
}
