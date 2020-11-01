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
        private readonly IParticleService _particleService;
        
        public NameDivisionService(IMapper mapper, 
                                   IParticleService particleService)
        {
            _mapper = mapper;
            _particleService = particleService;
        }

        public List<string> ReportList()
        {
            var tempList = _particleService.ReportParticleList();
            tempList.Add(_particleService.IsParticle("Roberto").ToString());
            tempList.Add(_particleService.IsParticle("da").ToString());
            tempList.Add(_particleService.IsParticle("Silva").ToString());

            return tempList;
        }

        public NameSlicesDto ComputeNameDivision(string nameToDivide)
        {
            var nameDivideSlices = SeparateNameInSlices(nameToDivide);
            return _mapper.Map<NameSlicesDto>(nameDivideSlices);
        }

        private NameSlices SeparateNameInSlices(string nameToDivide)
        {
            var nameSlices = new NameSlices();
            var nameTerms = GetNameTerms(nameToDivide);
            
            foreach (var nameTerm in nameTerms)
                nameSlices.Add(nameTerm, _particleService.IsParticle(nameTerm));
            
            return nameSlices;
        }

        private string[] GetNameTerms(string nameToDivide) =>
            nameToDivide.Split(NameDivisionConstant.SplitChar);
    }
}
