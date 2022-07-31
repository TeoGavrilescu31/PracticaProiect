using PraticaProiect.Services.Repositories;

namespace PraticaProiect.Services.UnitsOfWork
{
    public interface IOrderUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        int Complete();
    }
}
