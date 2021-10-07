using LeaveAppApi.DTOs;
using LeaveAppApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveAppApi.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<GetUserDto>> CreateUser(User newUser);
    }
}
