﻿using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen Rol Adı Giriniz")]
        public string Name { get; set; }
    }
}
