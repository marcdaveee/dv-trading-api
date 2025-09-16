﻿using System.ComponentModel.DataAnnotations;

namespace DvTrading.Application.DTOs.Account.Request
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;



    }
}
