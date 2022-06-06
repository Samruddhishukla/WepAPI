using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodProject.API.Models
{
    public class SignUp
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
    }
}