﻿using Gym.Entities;

namespace Gym.Application.Repositories
{
    public interface IUserRepository
    {
        public User Create(User model);
        public User? Get(string email);
        public void SaveChanges();
    }
}
