﻿using BudgetMoiCa.Entities;
using System.Collections.Generic;

namespace BudgetMoiCa.DAL.Repository.Interface
{
    public interface IItemRepository
    {
        List<Item> GetUserItems(int userId);
    }
}