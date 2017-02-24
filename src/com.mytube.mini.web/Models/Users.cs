﻿using System;
using System.Collections.Generic;

namespace com.mytube.mini.web.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Videos> Videos { get; set; }
    }
}