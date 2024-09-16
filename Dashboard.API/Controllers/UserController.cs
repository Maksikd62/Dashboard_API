using Azure;
using Dashboard.BLL.Services.UserService;
using Dashboard.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Dashboard.BLL.Validators;
using Dashboard.DAL.Models.Identity;
using Dashboard.DAL.ViewModels;

namespace Dashboard.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userService.GetAllUsersAsync();

            return await GetResultAsync(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserVM model)
        {
            var validator = new UserValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _userService.UpdateAsync(model);

            return await GetResultAsync(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _userService.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var response = await _userService.DeleteById(id);

            if (response.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRolesAsync()
        {
            var response = await _userService.GetRolesAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
