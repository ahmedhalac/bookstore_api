using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public string ISBN { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    [Range(1, 10000)]
    public double ListPrice { get; set; }

    // Price if user buys 1-50 books
    [Required]
    [Range(1,10000)]
    public double Price { get; set; }

    // Price if user buys 50+ books
    [Required]
    [Range(1, 10000)]
    public double Price50 { get; set; }

    // Price if user buys 100+ books
    [Required]
    [Range(1, 10000)]
    public double Price100 { get; set; }

    public int CategoryId { get; set; }

    public string ImageUrl { get; set; }
}

