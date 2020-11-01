using System.Collections.Generic;
using NLNameDivision.Cross.Constant;
using NLNameDivision.Entity;
using NLNameDivision.Service.Abstraction;

namespace NLNameDivision.Service
{
    public class NamePartService : INamePartService
    {
        private readonly IParticleService _particleService;
        
        public NamePartService(IParticleService particleService)
        {
            _particleService = particleService;
        }

        public List<string> ReportParticleList() => _particleService.ReportParticleList();

        public NameSlices SliceName(string nameToDivide) => SeparateNameInSlices(nameToDivide);
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