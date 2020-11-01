using AutoMapper;
using NLNameDivision.Cross.DTO;
using NLNameDivision.Entity.Struct;

namespace NLNameDivision.Cross.MapperProfile
{
    public class NamePartMapperProfile: Profile
    {
        public NamePartMapperProfile()
        {
            CreateMap<NamePartStruct, NamePartDto>();
        }
    }
}