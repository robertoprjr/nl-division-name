using AutoMapper;
using NLNameDivision.Cross.DTO;
using NLNameDivision.Entity;

namespace NLNameDivision.Cross.MapperProfile
{
    public class NamePartsMapperProfile: Profile
    {
        public NamePartsMapperProfile()
        {
            CreateMap<NameParts, NamePartsDto>();
        }
    }
}