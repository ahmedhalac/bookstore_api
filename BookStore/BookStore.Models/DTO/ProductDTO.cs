using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.DTO;

public class ProductDTO
{

    public string Title { get; set; }
    public string Description { get; set; }
    public string ISBN { get; set; }
    public string Author { get; set; }
    public double ListPrice { get; set; }
    public double Price { get; set; }
    public double Price50 { get; set; }
    public double Price100 { get; set; }
    public int CategoryId { get; set; }
    public string ImageUrl { get; set; }
}

