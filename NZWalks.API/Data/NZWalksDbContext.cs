using System;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domian;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //create difficulties

        //    var difficulties = new List<Difficulty>()
        //    {
        //        new Difficulty()
        //        {
        //            id= Guid.Parse("ea50e3db-07fc-426c-a2a8-b57b0e6edd4b"),
        //            Name = "easy"
        //        },
        //        new Difficulty()
        //        {
        //            id = Guid.Parse("c930b61d-5734-4d68-9ce0-2990de87cd09"),
        //            Name = "medium"
        //        },
        //        new Difficulty()
        //        {
        //            id = Guid.Parse("ef1c17e1-6b37-4df5-9b38-82c4bcfa7692"),
        //            Name = "hard"
        //        }

        //    };

        //    //seed difficulties to the  database
        //    modelBuilder.Entity<Difficulty>().HasData(difficulties);

        //    //create regions
        //    var regions = new List<Region>()
        //    {
        //        new Region()
        //        {
        //            Id = Guid.Parse("47b83a8b-8e3d-4017-b2d7-7e4ed093fd94"),
        //            Name = "Riyadh",
        //            Code = "RUH",
        //            RegionImageUrl = "https://images.unsplash.com/photo-1642762890357-910e7be63d82?q=80&w=3015&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
        //        },
        //        new Region()
        //        {
        //            Id = Guid.Parse("1328ac8f-057c-4457-932d-1e5eab00bf20"),
        //            Name = "Jeddah",
        //            Code = "JED",
        //            RegionImageUrl = "https://images.unsplash.com/photo-1642762890357-910e7be63d82?q=80&w=3015&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"

        //        },
        //        new Region()
        //        {
        //            Id = Guid.Parse("0daba18c-8b88-49d5-ac64-b79ad3454073"),
        //            Name = "Al Khobar",
        //            Code = "ALK",
        //            RegionImageUrl = "https://images.unsplash.com/photo-1642762890357-910e7be63d82?q=80&w=3015&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"

        //        }
        //    };

        //    //seed regions to the database
        //    modelBuilder.Entity<Region>().HasData(regions);
        //}

    }
}

