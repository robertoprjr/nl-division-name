using System;
using System.Collections.Generic;
using NLNameDivision.Entity.Struct;

namespace NLNameDivision.Entity
{
    public class NameParts
    {
        private int _currentPart;
        private string _particlePart;
        
        public List<NamePartStruct> Parts { get; private set; }
        public NameParts() => Start();

        public void Start()
        {
            _currentPart = 1;
            Parts = new List<NamePartStruct>();
            ClearParticle();
        }

        private void ClearParticle() =>
            _particlePart = string.Empty;
        
        public void SetParticle(string sliceParticle) =>
            _particlePart = sliceParticle;
        
        public void Add(string sliceName)
        {
            Parts.Add(new NamePartStruct()
                {
                    Order = _currentPart,
                    Particle = _particlePart,
                    Value = sliceName
                }
            );

            _currentPart++;
            ClearParticle();
        }
    }
}