using AutoMapper;
using LeaveAppApi.Context;
using LeaveAppApi.Context.Model;
using LeaveAppApi.DTOs;
using LeaveAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAppApi.Services.UserService
{
    public class UserService : IUserService
    {

        [TempData]
        public string PlainPassword { get; set; }

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserService(DatabaseContext context, IMapper mapper  )
        {
            _context = context;
            _mapper = mapper;

        }

        private static string value = "";
        private static Random random = new Random();
        private static char[] charList = new char[]
        {   'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
            'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z',
            '@', '#', '$', '%', '&',
            '0', '1', '2','3', '4', '5', '6', '7', '8', '9',
            'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P',
            'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z',
        };
        private dynamic GeneratePassword(int max)
        {
            while (value.Length < max)
            {
                value += charList[random.Next(0, charList.Count())];
            }
            return value;
        }

        public async Task<ServiceResponse<GetUserDto>> CreateUser(User newUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();


            string randomPassword = GeneratePassword(10);
            PlainPassword = randomPassword;
            newUser.UserId = Guid.NewGuid();

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(PlainPassword);             

            try
            {  
                        var isUserExist = await _context.Users.SingleOrDefaultAsync(u => u.Email == newUser.Email);

                        if (isUserExist == null)
                        {
                            _context.Add(newUser);
                            await _context.SaveChangesAsync();
                            serviceResponse.Data = _mapper.Map<GetUserDto>(newUser);
                            serviceResponse.Message = "User created successfully";
                            Helper.Helper.SendLoginCredential(newUser, PlainPassword);   
                        }
                       else
                        {
                            serviceResponse.Success = false;
                            serviceResponse.Message = $"The email {newUser.Email} is already taken";
                        }
                    
                




            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }
              

        public Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
