﻿using PracticaProiect.Entities;

namespace PracticaProiect.Services.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
