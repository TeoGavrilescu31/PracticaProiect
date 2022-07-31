using PraticaProiect.Services.Repositories;

namespace PracticaProiect.Services.UnitsOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
