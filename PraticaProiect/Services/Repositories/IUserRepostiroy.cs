using PracticaProiect.Entities;

namespace PraticaProiect.Services.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
