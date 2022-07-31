using PracticaProiect.Entities;
using PraticaProiect.Services.Repositories;

namespace PracticaProiect.Services.Repositories
{
    public interface IOrderMenuRepository: IRepository<OrderMenu>
    {
        public OrderMenu GetOrderMenuDetails(Guid OrderMenuId);
    }
}
