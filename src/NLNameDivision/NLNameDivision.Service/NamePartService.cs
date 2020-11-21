using System.Collections.Generic;
using System.Linq;
using NLNameDivision.Constant;
using NLNameDivision.Entity;
using NLNameDivision.Entity.Struct;
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

        public NameParts GetNameParted(string nameToDivide) => SeparateNameInParts(nameToDivide);
        
        private NameParts SeparateNameInParts(string nameToDivide)
        {
            var nameParts = new NameParts();
            var nameSlices = SeparateNameInSlices(nameToDivide);
            
            foreach (var nameSlice in nameSlices.Slices.OrderBy(x => x.Order))
                SetPartBySlice(nameParts, nameSlice);
            
            return nameParts;
        }

        private void SetPartBySlice(NameParts nameParts, NameSlice nameSlice)
        {
            if (nameSlice.IsParticle)
                nameParts.SetParticle(nameSlice.Value);
            else
                nameParts.Add(nameSlice.Value);
        }
        public NameSlices GetNameSliced(string nameToDivide) => SeparateNameInSlices(nameToDivide);
        
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