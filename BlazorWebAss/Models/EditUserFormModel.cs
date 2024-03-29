﻿using System.ComponentModel.DataAnnotations;

namespace BlazorWebAss.Models
{
    public class EditUserFormModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FatherName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Login is required field")]
        public string Login { get; set; } = string.Empty;

        public string NewLogin { get; set; } = string.Empty;
    }
}
