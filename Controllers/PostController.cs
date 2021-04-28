using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BlogBackend.Models;

namespace BlogBackend.Controllers
{
    [ApiController]
    [Route("/posts")]
    public class PostController : ControllerBase
    {
        private BlogDbContext context;

        public PostController(BlogDbContext context) 
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetPosts()
        {
            return context.Posts.ToList();
        }

        [HttpGet("{id}")] 
        public ActionResult<Post> GetPost(Guid id) 
        { 
            var post = context.Posts.Find(id); 
            
            if (post == null) 
            { 
                return NotFound(); 
            }

            return post; 
        }

        [HttpPost]
        public ActionResult<Post> AddPost(Post post)
        {
            post.Id = new Guid();
            context.Add(post);
            context.SaveChanges();
            return Accepted();
        }
    }
}
