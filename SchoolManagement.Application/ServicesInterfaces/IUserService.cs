using SchoolManagement.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.ServicesInterfaces
{
     public interface IUserService
    {

            Task<GetUserDto> LoginAsync(LoginDto loginDto);
            Task<CreateUserDto> RegisterAsync(RegisterDto registerDto);
            Task<bool> CheckEmailExitsAsync(string email);

     }
    }

