﻿using System;
using System.ComponentModel.DataAnnotations;

namespace com.mytube.mini.web.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [StringLength(16, MinimumLength = 5)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
