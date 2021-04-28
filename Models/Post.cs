using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Content { get; set; }

        public User Author { get; set; }
    }
}