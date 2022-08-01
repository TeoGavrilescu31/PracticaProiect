using Microsoft.EntityFrameworkCore;
using PracticaProiect.Contexts;
using PracticaProiect.Entities;
using PracticaProiect.Services.Repositories;

namespace PracticaProiect.Services.Repositories
{
    public class OrderMenuRepository : Repository<OrderMenu>, IOrderMenuRepository
    {
        private readonly RestaurantContext _context;
        public OrderMenuRepository(RestaurantContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public OrderMenu GetOrderMenuDetails(Guid OrderMenuId)
        {
            return _context.OrderMenus
                .Where(o => o.ID == OrderMenuId && (o.Deleted == false || o.Deleted == null))
                .FirstOrDefault();
        }
    }
}