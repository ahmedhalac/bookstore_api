using System;
using BookStore_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore_API.Extensions
{
	public static class ModelBuilderExtensions
	{
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}

