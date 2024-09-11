using Dashboard.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.BLL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                return ServiceResponse<List<User>>.GetServiceResponse("Список користувачів", true, users);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<User>>.GetServiceResponse("Помилка під час отримання користувачів", false, null, ex.Message);
            }
        }

        public async Task<ServiceResponse<User>> GetByIdAsync(Guid id)
        {
            try
            {
                var user = await  _userManager.Users.FirstOrDefaultAsync(p => p.Id == id);
                return ServiceResponse<User>.GetServiceResponse("Користувач", true, user);
            }
            catch (Exception ex)
            {
                return ServiceResponse<User>.GetServiceResponse("Помилка під час отримання користувачa", false, null, ex.Message);
            }
        }

        public async Task<ServiceResponse<User>> DeleteById(Guid id)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(p => p.Id == id);
                await _userManager.DeleteAsync(user);
                return ServiceResponse<User>.GetServiceResponse("Користувач", true, user);
            }
            catch (Exception ex)
            {
                return ServiceResponse<User>.GetServiceResponse("Помилка під час отримання користувачa", false, null, ex.Message);
            }
        }
    }
}
