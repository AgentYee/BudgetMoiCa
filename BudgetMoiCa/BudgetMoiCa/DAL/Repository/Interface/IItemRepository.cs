using BudgetMoiCa.Entities;
using System.Collections.Generic;

namespace BudgetMoiCa.DAL.Repository.Interface
{
    public interface IItemRepository
    {
        List<Item> GetUserItems(int userId);
        bool CreateItem(Item item);
        Item GetItem(int itemId);
        bool EditItem(Item item);
    }
}
