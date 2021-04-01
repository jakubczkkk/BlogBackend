using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string UserName { get; set; }

        [MaxLength(30)]
        public string Password { get; set; }
    }
}