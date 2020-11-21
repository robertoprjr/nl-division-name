using System;
using System.Collections.Generic;
using System.Linq;
using NLNameDivision.Constant;
using NLNameDivision.Constant.Enum;

namespace NLNameDivision.Entity
{
    public class NameParts
    {
        private int _currentPart;
        private string _particlePart;
        
        public List<NamePart> Parts { get; private set; }
        public NameParts() => Start();

        public void Start()
        {
            _currentPart = NameDivisionConstant.CounterStart;
            Parts = new List<NamePart>();
            ClearParticle();
        }

        private void ClearParticle() =>
            _particlePart = string.Empty;

        public void SetParticle(string sliceParticle)
        {
            if (_particlePart == string.Empty)
                _particlePart = sliceParticle;
            else
                _particlePart += NameDivisionConstant.UnionChar + sliceParticle;
        }

        public void Add(string sliceName)
        {
            AddItemPart(sliceName);
            _currentPart++;
            ClearParticle();
        }

        private void AddItemPart(string sliceName)
        {
            Parts.Add(new NamePart()
                {
                    Order = _currentPart,
                    Particle = _particlePart,
                    Value = sliceName,
                    Type = NameDivisionTypeEnum.Indefinido
                }
            );
        }
        
        public void SetAllUndefined() =>
            Parts.ForEach(x => x.Type = NameDivisionTypeEnum.Indefinido);

        public bool IsAllDefined() => 
            Parts.All(x => x.Type != NameDivisionTypeEnum.Indefinido);

        public void SetDefinitionByOrder(int order, NameDivisionTypeEnum type)
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                if (Parts[i].Order == order)
                    Parts[i].Type = type;
            }
        }
    }
}