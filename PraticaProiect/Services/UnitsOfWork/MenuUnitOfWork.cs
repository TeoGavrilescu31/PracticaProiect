﻿using PracticaProiect.Contexts;
using PracticaProiect.Services.Repositories;

namespace PracticaProiect.Services.UnitsOfWork
{
    public class MenuUnitOfWork : IMenuUnitOfWork
    {
        private readonly RestaurantContext _context;
        public MenuUnitOfWork(RestaurantContext context, ICategoryRepository categories, IMenuRepository menus)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
            Menus = menus ?? throw new ArgumentNullException(nameof(menus));
        }
        public ICategoryRepository Categories { get; }
        public IMenuRepository Menus { get; }

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