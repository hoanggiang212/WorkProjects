using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TbsGroup.ViewModels
{
    public class UserManager
    {
        public string Username { set; get; }

        public string CurrentPassword { set; get; }

        public string Password { set; get; }

        public string PasswordCofirm { set; get;}

        public string JobPosition { set; get; }
    }
}