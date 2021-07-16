﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SerfClub.Models
{
    public class LoginViewModel
    {
        public string Nickname { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
