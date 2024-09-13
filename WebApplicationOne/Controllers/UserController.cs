using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApplicationOne.Authentication;
using WebApplicationOne.Data;
using WebApplicationOne.Model;

namespace WebApplicationOne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContext _appDbContext;
        private CustomAuthentication _authentication;
        public UserController(AppDbContext appDbContext,CustomAuthentication authentication)
        {
            _appDbContext = appDbContext;
            _authentication = authentication;
        }

        [HttpPost]
        public void Post(User user)
        {
            _appDbContext.User.Add(user);
            _appDbContext.SaveChanges();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            User user = _appDbContext.User.Where(x => x.Id == id).First();
            return user;
        }

        [HttpGet]
        public List<User> Get()
        {
            List<User> users = _appDbContext.User.ToList();
            return users;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = _appDbContext.User.Where(x => x.Id == id).First();
            _appDbContext.User.Remove(user);
            _appDbContext.SaveChanges();
        }


        [HttpPost("validate")]
        public async Task<string> ValidateLogin(string email, string password)
        {
            string token = await  _authentication.Validate(email,password);
            return token;
        }
    }
}
