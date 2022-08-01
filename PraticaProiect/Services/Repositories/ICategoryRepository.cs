using PracticaProiect.Entities;

namespace PracticaProiect.Services.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryDetails(Guid categoryId); 
    }
}
