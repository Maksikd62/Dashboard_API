using Dashboard.DAL.Models.Identity;
using Dashboard.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse> GetAllUsersAsync();
        Task<ServiceResponse> GetByIdAsync(Guid id);
        Task<ServiceResponse> DeleteById(Guid id);
        Task<ServiceResponse> GetRolesAsync();
        Task<ServiceResponse> UpdateAsync(UserVM model);
    }
}
