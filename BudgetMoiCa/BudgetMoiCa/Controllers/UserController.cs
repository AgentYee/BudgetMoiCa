using BudgetMoiCa.DAL.Repository;
using BudgetMoiCa.DAL.Repository.Interface;
using BudgetMoiCa.Entities;
using BudgetMoiCa.Helpers.Encryption;
using BudgetMoiCa.Models.ViewModels.User;
using System.Web.Http;
using System.Web.Http.Description;

namespace BudgetMoiCa.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private readonly IUserRepository repo;

        public UserController(IUserRepository _repo)
        {
            repo = _repo;
        }

        public UserController()
        {
            repo = new UserRepository();
        }

        [HttpPost]
        [Route("register")]
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult Register(UserViewModel userVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (repo.CheckUserExistence(userVM.Username))
                return BadRequest("Username is already taken.");

            User user = new User();
            user.Username = userVM.Username;
            user.Password = EncryptionHelper.HashToSHA256(userVM.Password);

            if (repo.RegisterUser(user))
                return Ok("User has been registerd");

            return BadRequest("An error has occured");
        }

        [HttpPost]
        [Route("login")]
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult Login(UserViewModel userVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (repo.ValidateUser(userVM.Username, userVM.Password))
                return Ok("Login successful.");

            return BadRequest("An error has occured");
        }
    }
}
