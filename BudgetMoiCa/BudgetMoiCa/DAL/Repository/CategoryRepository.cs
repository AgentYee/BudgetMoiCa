using System.Collections.Generic;
using BudgetMoiCa.DAL.Repository.Interface;
using BudgetMoiCa.Entities;
using System.Linq;
using System.Data.Entity;

namespace BudgetMoiCa.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                var categories = ctx.Categories;
                return categories.ToList();
            }
        }
    }
}