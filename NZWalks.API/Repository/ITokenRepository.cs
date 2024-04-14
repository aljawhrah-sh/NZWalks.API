﻿using System;
using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repository
{
	public interface ITokenRepository
	{
		public string CreateJWTtoken(IdentityUser user, List<string> roles);
	}
}

