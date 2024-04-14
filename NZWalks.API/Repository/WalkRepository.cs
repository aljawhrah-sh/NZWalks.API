using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domian;

namespace NZWalks.API.Repository
{
	public class WalkRepository : IWalkRepository
	{


		private readonly NZWalksDbContext nZWalksDb;

		public WalkRepository(NZWalksDbContext nZWalksDb)
		{
			this.nZWalksDb = nZWalksDb;
		}

		public async Task<Walk> CreateAsync(Walk walk)
		{
			await nZWalksDb.Walks.AddAsync(walk);
			nZWalksDb.SaveChanges();
			return walk;
		}

		public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
                                                string? sortBy = null, bool isAscending = true)
		{
			var walks = nZWalksDb.Walks.Include("Region").Include("Difficulty").AsQueryable();

			//filtering
			if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
			{
				if (filterOn.Equals("name"))
				{
					walks = walks.Where(x => x.Name.Contains(filterQuery));
				}
			}
			//sorting
			if( string.IsNullOrWhiteSpace(sortBy) == false)
			{
				if (sortBy.Equals("name"))
				{
					walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
				}
				else if (sortBy.Equals("length"))
				{
					walks = isAscending ? walks.OrderBy(x => x.LengthinKm) : walks.OrderByDescending(x => x.LengthinKm);
				}
			}

            return await walks.ToListAsync();
            //return await nZWalksDb.Walks.Include("Region").Include("Difficulty").ToListAsync();
        }

		public async Task<Walk?> GetByIdAsync(Guid id)
		{
			return await nZWalksDb.Walks.FirstOrDefaultAsync(x => x.Id == id);

		}

		public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
		{
			var existingwalk = await nZWalksDb.Walks.FirstOrDefaultAsync(x => x.Id == id);

			if (existingwalk == null)
			{
				return null;

			}

			existingwalk.Name = walk.Name;
			existingwalk.Description = walk.Description;
			existingwalk.Difficulty = walk.Difficulty;
			existingwalk.LengthinKm = walk.LengthinKm;
			existingwalk.WalkImageUrl = walk.WalkImageUrl;
			existingwalk.DifficultyId = walk.DifficultyId;
			existingwalk.RegionId = walk.RegionId;

			await nZWalksDb.SaveChangesAsync();
			return existingwalk;
		}

		public async Task<Walk?> DeleteAsync(Guid id)
		{
			var existingWalk = await nZWalksDb.Walks.FirstOrDefaultAsync(x => x.Id == id);

			if (existingWalk == null)
			{
				return null;
			}

			//if found delete the walk from the database through the dbcontext class
			nZWalksDb.Walks.Remove(existingWalk);
			await nZWalksDb.SaveChangesAsync();

			return existingWalk;
		}
	}
}


