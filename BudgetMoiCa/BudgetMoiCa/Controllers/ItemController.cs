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

        public ItemController(IItemRepository _repo)
        {
            repo = _repo;
        }

        public ItemController()
        {
            repo = new ItemRepository();
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
    }
}
