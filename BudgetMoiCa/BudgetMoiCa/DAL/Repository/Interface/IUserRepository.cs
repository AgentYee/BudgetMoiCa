using BudgetMoiCa.Entities;

namespace BudgetMoiCa.DAL.Repository.Interface
{
    public interface IUserRepository
    {
        bool ValidateUser(string username, string password);
        bool RegisterUser(User user);
    }
}
