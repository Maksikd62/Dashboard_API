using Dashboard.DAL.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetAllUsersAsync();
        Task<ServiceResponse<User>> GetByIdAsync(Guid id);
        Task<ServiceResponse<User>> DeleteById(Guid id);
    }
}
