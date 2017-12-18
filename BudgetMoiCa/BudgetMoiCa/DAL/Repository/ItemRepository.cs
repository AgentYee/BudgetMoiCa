using System.Collections.Generic;
using BudgetMoiCa.DAL.Repository.Interface;
using BudgetMoiCa.Entities;
using System.Linq;

namespace BudgetMoiCa.DAL.Repository
{
    public class ItemRepository : IItemRepository
    {
        public List<Item> GetUserItems(string username)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                List<Item> items = new List<Item>();

                User user = ctx.Users.Where(x => x.Username == username).FirstOrDefault();
                if (user == null)
                    return items;

                items = ctx.Items.Where(x => x.UserId == user.UserId).ToList();
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

        public bool DeleteItem(Item item)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                int result = -1;
                ctx.Items.Attach(item);
                ctx.Items.Remove(item);
                result = ctx.SaveChanges();

                return result >= 1 ? true : false;
            }
        }
    }
}