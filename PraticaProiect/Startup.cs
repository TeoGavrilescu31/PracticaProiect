using Microsoft.EntityFrameworkCore;
using PracticaProiect.Contexts;
using PracticaProiect.Services.Repositories;
using PracticaProiect.Services.UnitsOfWork;

namespace PracticaProiect
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void ConfigurationService(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration["ConnectionStrings:RestaurantDBConnectionString"];
            builder.Services.AddDbContext<RestaurantContext>(o => o.UseSqlServer(connectionString));

            builder.Services.AddScoped<IMenuRepository, MenuRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IOrderMenuRepository, OrderMenuRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IOrderUnitOfWork,OrderUnitOfWork>();
            builder.Services.AddScoped<IMenuUnitOfWork, MenuUnitOfWork>();
            builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();
        }

        public static void Configure(WebApplication app)
        {
            //Configure the HTTP request pipeline
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
