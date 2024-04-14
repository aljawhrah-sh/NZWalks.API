using System;
using NZWalks.API.Models.Domian;

namespace NZWalks.API.Repository
{
	public interface IWalkRepository
	{
		public Task<Walk> CreateAsync(Walk walk);
		public Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
											string? sortBy = null, bool isAscending = true);
		public Task<Walk?> GetByIdAsync(Guid id);
		public Task<Walk?> UpdateAsync(Guid id, Walk walk);
		public Task<Walk?> DeleteAsync(Guid id);
	}
}

