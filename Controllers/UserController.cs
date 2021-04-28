using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BlogBackend.Models;

namespace BlogBackend.Controllers
{
    [ApiController]
    [Route("/users")]
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

        [HttpGet("{username}")] 
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
