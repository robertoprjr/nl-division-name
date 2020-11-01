using AutoMapper;
using NLNameDivision.Entity.Struct;
using NLNameDivision.Cross.DTO;

namespace NLNameDivision.Service.MapperProfile
{
    public class NameSliceMapperProfile : Profile
    {
        public NameSliceMapperProfile()
        {
            CreateMap<NameSliceStruct, NameSliceDto>();
        }
    }
}