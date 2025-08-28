﻿using Application.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomAuthenticationService
    {
        Task<string?> Login(LoginRequest loginRequest);
        Task<bool> Register(RegisterRequest registerRequest);
    }
}
