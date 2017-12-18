using BudgetMoiCa.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetMoiCa.Entities;
using BudgetMoiCa.Helpers.Encryption;

namespace BudgetMoiCa.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool RegisterUser(User user)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                int result = -1;
                ctx.Users.Add(user);
                result = ctx.SaveChanges();

                return result >= 1 ? true : false;
            }
        }

        public bool ValidateUser(string username, string password)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                User user = ctx.Users.Where(x => x.Username == username).FirstOrDefault();
                if (user != null)
                    if (EncryptionHelper.HashToSHA256(password) == user.Password)
                    {
                        return true;
                    }
                return false;
            }
        }

        public bool CheckUserExistence(string username)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                if(ctx.Users.Where(x => x.Username == username).FirstOrDefault() == null)
                {
                    return false;
                }
                return true;
            }
        }

        public User GetUser(int userId)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                User user = ctx.Users.Where(x => x.UserId == userId).FirstOrDefault();
                return user;
            }
        }

        public User GetUserByUsername(string username)
        {
            using (BudgetContext ctx = new BudgetContext())
            {
                User user = ctx.Users.Where(x => x.Username == username).FirstOrDefault();
                return user;
            }
        }
    }
}