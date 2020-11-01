using System.Collections.Generic;
using AutoMapper;
using NLNameDivision.Cross.Constant;
using NLNameDivision.Entity;
using NLNameDivision.Service.Abstraction;
using NLNameDivision.Cross.DTO;

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

        public NameSlicesDto ReportNameSliced(string nameToDivide) => 
            _mapper.Map<NameSlicesDto>(_namePartService.SliceName(nameToDivide));
    }
}
