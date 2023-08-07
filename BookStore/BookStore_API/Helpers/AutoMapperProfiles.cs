using AutoMapper;
using BookStore.Models;
using BookStore.Models.DTO;

namespace BookStore_API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<CategoryDTO, Category>().ReverseMap();
        CreateMap<ProductDTO, Product>().ReverseMap();
    }
}

