﻿using Gym.DataAccess.Request;
using Gym.DataAccess.Response;

namespace Gym.Services
{
    public interface IAuthService
    {
        public abstract AuthResponse AuthenticateByEmail(AuthRequest authRequest, string ipAddress);

    }
}
