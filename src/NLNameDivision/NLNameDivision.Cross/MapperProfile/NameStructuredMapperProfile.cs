using AutoMapper;
using NLNameDivision.Cross.DTO;
using NLNameDivision.Entity;

namespace NLNameDivision.Cross.MapperProfile
{
    public class NameStructuredMapperProfile: Profile
    {
        public NameStructuredMapperProfile()
        {
            CreateMap<NameStructured, NameStructuredDto>();               
        }
    }
}