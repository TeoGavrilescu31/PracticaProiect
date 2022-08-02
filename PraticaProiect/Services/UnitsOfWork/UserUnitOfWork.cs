using PracticaProiect.Contexts;
using PracticaProiect.Services.UnitsOfWork;
using PracticaProiect.Services.Repositories;
using PracticaProiect.Services.Repositories;

namespace PracticaProiect.Services.UnitsOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly RestaurantContext _context;
        public UserUnitOfWork(RestaurantContext context, IUserRepository users)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Users = users ?? throw new ArgumentNullException(nameof(users));
        }
        public IUserRepository Users { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
