using PracticaProiect.Services.Repositories;

namespace PracticaProiect.Services.UnitsOfWork
{
    public interface IOrderUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IOrderMenuRepository OrderMenus { get; }
        int Complete();
    }
}
