using PracticaProiect.Entities;

namespace PracticaProiect.Services.Repositories
{
    public interface IMenuRepository:IRepository<Menu>
    {
        public Menu GetMenuDetails(Guid MenuId);
    }
}
