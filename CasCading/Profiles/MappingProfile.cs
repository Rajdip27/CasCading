using AutoMapper;
using CasCading.Models;
using CasCading.ViewModel;

namespace CasCading.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<VmState, State>().ReverseMap().ForMember(x => x.CountryName,
            x => x.MapFrom(x => x.Country != null ? x.Country.Name : ""));
        CreateMap<VmCity, City>().ReverseMap()
            .ForMember(x => x.StateName, x => x.MapFrom(x => x.State != null ? x.State.Name : ""));
    }
}