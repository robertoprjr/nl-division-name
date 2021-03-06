using System.Collections.Generic;
using AutoMapper;
using NLNameDivision.Entity;
using NLNameDivision.Service.Abstraction;
using NLNameDivision.Cross.DTO;
using NLNameDivision.Service.NameDivisionCofR;

namespace NLNameDivision.Service
{
    public class NameDivisionService : INameDivisionService
    {
        private readonly IMapper _mapper;
        private readonly INamePartService _namePartService;
        
        public NameDivisionService(IMapper mapper, 
                                   INamePartService namePartService)
        {
            _mapper = mapper;
            _namePartService = namePartService;
        }
        
        public List<string> ReportParticleList() => _namePartService.ReportParticleList();

        public NameSlicesDto GetNameSliced(string nameToDivide) => 
            _mapper.Map<NameSlicesDto>(_namePartService.GetNameSliced(nameToDivide));
        
        public NamePartsDto GetNameParted(string nameToDivide) => 
            _mapper.Map<NamePartsDto>(_namePartService.GetNameParted(nameToDivide));

        public NamePartsDto GetNameDivided(string nameToDivide) => 
            _mapper.Map<NamePartsDto>(DivideName(nameToDivide));

        private NameParts DivideName(string nameToDivide)
        {
            var nameParts = _namePartService.GetNameParted(nameToDivide);
            var ruleToApply = NameDivisionRuleFactory.GetRule(nameParts.Count());

            var namePartsDivided = ruleToApply.Handle(nameParts);
            return namePartsDivided;
        }

        public NameStructuredDto GetNameStructured(string nameToDivide) =>
            _mapper.Map<NameStructuredDto>(StructureName(nameToDivide));

        private NameStructured StructureName(string nameToDivide)
        {
            var namePartsDivided = DivideName(nameToDivide);
            return FillNameStructured(namePartsDivided);
        }

        private static NameStructured FillNameStructured(NameParts namePartsDivided)
        {
            var nameStructured = new NameStructured();
            nameStructured.FillNameStructured(namePartsDivided);

            return nameStructured;
        }
    }
}
