using System.Collections.Generic;
using NLNameDivision.Constant;
using NLNameDivision.Entity.Struct;

namespace NLNameDivision.Entity
{
    public class NameSlices
    {
        private int _currentSlice;
        public List<NameSlice> Slices { get; private set; } 
        public NameSlices() => Start();
        
        public void Start()
        {
            _currentSlice = NameDivisionConstant.CounterStart;
            Slices = new List<NameSlice>();
        }

        public void Add(string nameTerm, bool isParticle = false)
        {
            Slices.Add(new NameSlice()
                {
                    Order = _currentSlice,
                    IsParticle = isParticle,
                    Value = nameTerm
                }
            );

            _currentSlice++;
        } 
    }
}