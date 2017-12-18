using BudgetMoiCa.DAL.Repository;
using BudgetMoiCa.DAL.Repository.Interface;
using BudgetMoiCa.Entities;
using BudgetMoiCa.Models.ViewModels.Category;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace BudgetMoiCa.Controllers
{
    [RoutePrefix("category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryRepository repo;

        public CategoryController(ICategoryRepository _repo)
        {
            repo = _repo;
        }

        public CategoryController()
        {
            repo = new CategoryRepository();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("list")]
        [ResponseType(typeof(List<CategoryViewModel>))]
        public IHttpActionResult GetAllCategories()
        {
            List<Category> categories = repo.GetAllCategories();
            List<CategoryViewModel> categoriesVM = new List<CategoryViewModel>();

            if (categories.Count > 0)
            {
                foreach (Category c in categories)
                {
                    CategoryViewModel ct = new CategoryViewModel();
                    ct.CategoryId = c.CategoryId;
                    ct.Name = c.Name;
                    ct.Description = c.Description;
                    categoriesVM.Add(ct);
                }
            }
            return Ok(categoriesVM);
        }

        [AllowAnonymous]
        [Route("array")]
        [ResponseType(typeof(List<string>))]
        public IHttpActionResult GetArrayOfCategories()
        {
            List<Category> categories = repo.GetAllCategories();
            List<string> catList = new List<string>();

            if (categories.Count > 0)
            {
                foreach (Category c in categories)
                {
                    catList.Add(c.Name);
                }
            }
            return Ok(catList);
        }
    }
}
