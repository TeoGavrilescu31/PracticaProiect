using PracticaProiect.Entities;

namespace PracticaProiect.Services.Repositories
{
    public interface IOrderMenuRepository: IRepository<OrderMenu>
    {
        public OrderMenu GetOrderMenuDetails(Guid OrderMenuId);
    }
}
