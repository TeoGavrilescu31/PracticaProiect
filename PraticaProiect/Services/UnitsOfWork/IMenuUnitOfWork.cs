using PracticaProiect.Services.Repositories;

namespace PracticaProiect.Services.UnitsOfWork
{
    public interface IMenuUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IMenuRepository Menus { get; }
        int Complete();
    }
}
