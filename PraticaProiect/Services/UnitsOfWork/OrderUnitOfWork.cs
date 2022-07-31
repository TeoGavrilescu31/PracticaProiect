﻿using PracticaProiect.Contexts;
using PraticaProiect.Services.Repositories;

namespace PraticaProiect.Services.UnitsOfWork
{
    public class OrderUnitOfWork : IOrderUnitOfWork
    {
        private readonly RestaurantContext _context;
        public OrderUnitOfWork(RestaurantContext context, IOrderRepository orders)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Orders = orders ?? throw new ArgumentNullException(nameof(orders));
        }
        public IOrderRepository Orders { get; }

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
