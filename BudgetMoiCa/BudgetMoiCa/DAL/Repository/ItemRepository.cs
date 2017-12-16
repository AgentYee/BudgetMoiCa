﻿using System.Collections.Generic;
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
    }
}