using PracticaProiect.Entities;

namespace PracticaProiect.Services.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        public Order GetOrderDetails(Guid OrderId);
    }
}
