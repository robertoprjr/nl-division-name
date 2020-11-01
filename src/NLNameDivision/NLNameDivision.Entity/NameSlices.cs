using System.Collections.Generic;
using NLNameDivision.Entity.Struct;

namespace NLNameDivision.Entity
{
    public class NameSlices
    {
        private int _currentSlice;
        public List<NameSliceStruct> Slices { get; private set; } 
        public NameSlices() => Start();
        
        public void Start()
        {
            _currentSlice = 1;
            Slices = new List<NameSliceStruct>();
        }

        public void Add(string nameTerm, bool isParticle = false)
        {
            Slices.Add(new NameSliceStruct()
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