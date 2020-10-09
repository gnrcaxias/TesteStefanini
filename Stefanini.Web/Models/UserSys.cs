using Stefanini.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stefanini.Web.Models
{
    public class UserSys
    {
        public string Login { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }

    }
}