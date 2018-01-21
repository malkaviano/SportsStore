using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModel
{
    public class Login
    {
        [Required]
        [UIHint("user")]
        public string Username { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
