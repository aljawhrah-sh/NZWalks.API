﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
	public class LoginDTO
	{
        [Required]
        [DataType(DataType.EmailAddress)]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}

