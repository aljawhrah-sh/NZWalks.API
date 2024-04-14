using System;
using NZWalks.API.Models.Domian;

namespace NZWalks.API.Repository
{
	public interface IImageRepository
	{
		public Task<Image> Upload(Image image);
	}
}

