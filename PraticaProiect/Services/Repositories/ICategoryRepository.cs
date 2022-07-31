using PracticaProiect.Entities;
using PraticaProiect.Services.Repositories;

namespace PracticaProiect.Services.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryDetails(Guid categoryId); 
    }
}
