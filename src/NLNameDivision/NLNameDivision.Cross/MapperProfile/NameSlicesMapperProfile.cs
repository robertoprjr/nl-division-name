using AutoMapper;
using NLNameDivision.Entity;
using NLNameDivision.Cross.DTO;

namespace NLNameDivision.Cross.MapperProfile
{
    public class NameSlicesMapperProfile : Profile
    {
        public NameSlicesMapperProfile()
        {
            CreateMap<NameSlices, NameSlicesDto>();               
        }
    }
}