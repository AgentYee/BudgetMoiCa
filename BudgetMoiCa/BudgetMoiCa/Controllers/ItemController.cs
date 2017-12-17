using BudgetMoiCa.DAL.Repository;
using BudgetMoiCa.DAL.Repository.Interface;
using BudgetMoiCa.Entities;
using BudgetMoiCa.Models.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BudgetMoiCa.Controllers
{
    [RoutePrefix("item")]
    public class ItemController : ApiController
    {
        private readonly IItemRepository repo;
        private readonly IUserRepository repo2;
        private readonly ICategoryRepository repo3;

        public ItemController(IItemRepository _repo, IUserRepository _repo2, ICategoryRepository _repo3)
        {
            repo = _repo;
            repo2 = _repo2;
            repo3 = _repo3;
        }

        public ItemController()
        {
            repo = new ItemRepository();
            repo2 = new UserRepository();
            repo3 = new CategoryRepository();
        }

        [HttpGet]
        [Route("list/{userId}")]
        [ResponseType(typeof(List<ItemViewModel>))]
        public IHttpActionResult GetUserItems(int userId)
        {
            if (!string.IsNullOrEmpty("userId"))
            {
                List<Item> items = repo.GetUserItems(userId);
                List<ItemViewModel> itemsVM = new List<ItemViewModel>();

                if (items.Count > 0)
                {
                    foreach (Item i in items)
                    {
                        ItemViewModel it = new ItemViewModel();
                        it.Name = i.Name;
                        it.Description = i.Description;
                        it.Amount = (float)i.Amount;
                        itemsVM.Add(it);
                    }
                }
                return Ok(itemsVM);
            }
            return BadRequest("No user provided.");
        }

        [HttpPost]
        [Route("create")]
        [ResponseType(typeof(ItemCreateViewModel))]
        public IHttpActionResult CreateItem(ItemCreateViewModel item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            User user = repo2.GetUserByUsername(item.Username);
            if (user == null)
                return BadRequest("Invalid user provided");

            if (repo3.GetCategory(item.CategoryId) == null)
                return BadRequest("Category invalid");

            Item itemCreate = new Item();
            itemCreate.CategoryId = item.CategoryId;
            itemCreate.Name = item.Name;
            itemCreate.Description = item.Description;
            itemCreate.Amount = item.Amount;
            itemCreate.UserId = user.UserId;

            if (repo.CreateItem(itemCreate))
                return Ok("Item has been successfully created!");

            return BadRequest("An error has occured");
        }

        [HttpPut]
        [Route("edit")]
        [ResponseType(typeof(ItemEditViewModel))]
        public IHttpActionResult EditItem(ItemEditViewModel item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Item itemEdit = repo.GetItem(item.ItemId);
            if (itemEdit == null)
                return BadRequest("Inexistant item");

            Category cat = repo3.GetCategoryByName(item.Name);
            if (cat == null)
                return BadRequest("Inexistant category, needs to have one");

            itemEdit.Name = item.Name;
            itemEdit.Description = item.Description;
            itemEdit.Amount = item.Amount;
            itemEdit.CategoryId = cat.CategoryId;

            if (repo.EditItem(itemEdit))
                return Ok("Item has been modified");

            return BadRequest("An error has occured");
        }
    }
}
