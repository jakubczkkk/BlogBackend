using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogBackend.Models;

namespace BlogBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private BlogDbContext context;

        public UserController(BlogDbContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return context.Users.ToList();
        }

        [HttpGet("{id}")] 
        public ActionResult<User> GetUser(Guid id) 
        { 
            var user = context.Users.Find(id); 
            
            if (user == null) 
            { 
                return NotFound(); 
            } 

            return user; 
        }

        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            user.Id = new Guid();
            context.Add(user);
            context.SaveChanges();
            return Accepted();
        }
    }
}
