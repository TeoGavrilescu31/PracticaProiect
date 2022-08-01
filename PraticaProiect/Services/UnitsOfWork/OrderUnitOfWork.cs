using PracticaProiect.Contexts;
using PracticaProiect.Services.Repositories;

namespace PracticaProiect.Services.UnitsOfWork
{
    public class OrderUnitOfWork : IOrderUnitOfWork
    {
        private readonly RestaurantContext _context;
        public OrderUnitOfWork(RestaurantContext context, IOrderRepository orders, IOrderMenuRepository ordermenus)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Orders = orders ?? throw new ArgumentNullException(nameof(orders));
            OrderMenus = ordermenus ?? throw new ArgumentNullException(nameof(ordermenus));
        }
        public IOrderRepository Orders { get; }
        public IOrderMenuRepository OrderMenus { get;}

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
