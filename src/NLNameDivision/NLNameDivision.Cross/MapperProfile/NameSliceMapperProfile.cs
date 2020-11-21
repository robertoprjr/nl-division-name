using AutoMapper;
using NLNameDivision.Entity.Struct;
using NLNameDivision.Cross.DTO;

namespace NLNameDivision.Cross.MapperProfile
{
    public class NameSliceMapperProfile : Profile
    {
        public NameSliceMapperProfile()
        {
            CreateMap<NameSlice, NameSliceDto>();
        }
    }
}