namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Products;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> Product
        CreateMap<CreateRequest, Product>();

        // UpdateRequest -> Product
        CreateMap<UpdateRequest, Product>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
    }
}