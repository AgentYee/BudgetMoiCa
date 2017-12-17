using BudgetMoiCa.Entities;
using System.Collections.Generic;

namespace BudgetMoiCa.DAL.Repository.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategory(int categoryId);
    }
}
