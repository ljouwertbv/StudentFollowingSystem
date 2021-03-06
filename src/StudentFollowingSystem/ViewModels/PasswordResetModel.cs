﻿using System.ComponentModel.DataAnnotations;

namespace StudentFollowingSystem.ViewModels
{
    public class PasswordResetModel
    {
        [Display(Name = "E-mailadres")]
        [Required(ErrorMessage = "Vul een e-mailadres in.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vul een geldig e-mailadres in.")]
        [EmailAddress(ErrorMessage = "Vul een geldig e-mailadres in.")]
        public string Email { get; set; }

        public bool Success { get; set; }
    }
}
