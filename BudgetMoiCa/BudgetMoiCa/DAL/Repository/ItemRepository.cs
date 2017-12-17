using System.Collections.Generic;
using BudgetMoiCa.DAL.Repository.Interface;
using BudgetMoiCa.Entities;
using System.Linq;

namespace BudgetMoiCa.DAL.Repository
{
    public class ItemRepository : IItemRepository
    {
        public List<Item> GetUserItems(int userId)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                List<Item> items = new List<Item>();
                items = ctx.Items.Where(x => x.UserId == userId).ToList();
                return items;
            }
        }

        public bool CreateItem(Item item)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                int result = -1;
                ctx.Items.Add(item);
                result = ctx.SaveChanges();

                return result >= 1 ? true : false;
            }
        }

        public Item GetItem(int itemId)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                Item item = ctx.Items.Where(x => x.ItemId == itemId).FirstOrDefault();
                return item;
            }
        }

        public bool EditItem(Item item)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                int result = -1;
                ctx.Entry(item).State = System.Data.Entity.EntityState.Modified;
                result = ctx.SaveChanges();

                return result >= 1 ? true : false;
            }
        }
    }
}