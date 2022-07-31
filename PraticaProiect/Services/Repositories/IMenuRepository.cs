using PracticaProiect.Entities;

namespace PraticaProiect.Services.Repositories
{
    public interface IMenuRepository:IRepository<Menu>
    {
        public Menu GetMenuDetails(Guid MenuId);
    }
}
