﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
	public class RegisterDTO
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string password { get; set; }

		public string[] roles { get; set; }
	}
}

