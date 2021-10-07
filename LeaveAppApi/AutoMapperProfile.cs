﻿using AutoMapper;
using LeaveAppApi.DTOs;
using LeaveAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAppApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
        }
    }
}
