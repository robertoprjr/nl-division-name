using AutoMapper;
using NLNameDivision.Cross.DTO;
using NLNameDivision.Entity;

namespace NLNameDivision.Cross.MapperProfile
{
    public class NamePartMapperProfile: Profile
    {
        public NamePartMapperProfile()
        {
            CreateMap<NamePart, NamePartDto>();
        }
    }
}