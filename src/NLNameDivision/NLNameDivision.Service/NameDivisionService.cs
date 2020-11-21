using System.Collections.Generic;
using AutoMapper;
using NLNameDivision.Constant;
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

        public NamePartsDto GetNameDivided(string nameToDivide)
        {
            var nameParts = _namePartService.GetNameParted(nameToDivide);
            var ruleToApply = NameDivisionRulesFactory.GetRuleOne();

            var namePartsDivided = ruleToApply.Handle(nameParts);
            
            return _mapper.Map<NamePartsDto>(namePartsDivided);
        }
    }
}
