using PracticaProiect.Entities;

namespace PraticaProiect.Services.Repositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        public Order GetOrderDetails(Guid OrderId);
    }
}
