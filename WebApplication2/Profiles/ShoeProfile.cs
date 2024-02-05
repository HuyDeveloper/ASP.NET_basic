using AutoMapper;
using WebApplication2.Model;

namespace WebApplication2.Profiles;

public class ShoeProfile : Profile
{
    public ShoeProfile()
    {
        CreateMap<ShoeDTO, Shoe>();
    }
}