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
        private Dictionary<int, int> _keyPositionPart;
        
        public List<NamePart> Parts { get; private set; }
        public NameParts() => Start();

        private void Start()
        {
            StartCounter();
            ClearPositionDictionary();
            ClearParts();
            ClearParticle();
        }
        
        private void StartCounter() =>
            _currentPart = NameDivisionConstant.CounterStart;
        
        private void ClearParticle() =>
            _particlePart = string.Empty;

        private void ClearParts() =>
            Parts = new List<NamePart>();
        
        private void ClearPositionDictionary() =>
            _keyPositionPart = new Dictionary<int, int>();

        public void SetParticle(string sliceParticle)
        {
            if (_particlePart != string.Empty)
                _particlePart += NameDivisionConstant.UnionChar;
            _particlePart += sliceParticle;
        }

        public void Add(string sliceName)
        {
            AddItemPart(sliceName);
            AddPositionDictionary();
            IncrementCounter();
            ClearParticle();
        }

        private void AddItemPart(string sliceName)
        {
            Parts.Add(new NamePart()
                {
                    Position = _currentPart,
                    Particle = _particlePart,
                    Value = sliceName,
                    Type = NameDivisionTypeEnum.Undefined
                }
            );
        }
        
        private void AddPositionDictionary() =>
            _keyPositionPart.Add(_currentPart, Parts.Count - 1);
        
        private void IncrementCounter() =>
            _currentPart++;
        
        public void SetAllUndefined() =>
            Parts.ForEach(x => x.Type = NameDivisionTypeEnum.Undefined);

        public bool IsAllDefined() => 
            Parts.All(x => x.Type != NameDivisionTypeEnum.Undefined);

        public void SetDefinitionForAllUndefined(NameDivisionTypeEnum type) =>
            SetDefinitionByPositionsList(Parts.Where(x => x.Type == NameDivisionTypeEnum.Undefined)
                                              .Select(x => x.Position), type);
            
        public void SetDefinitionByPositionsList(IEnumerable<int> positions, NameDivisionTypeEnum type)
        {
            foreach (var position in positions)
                SetDefinitionByPosition(position, type);
        }
        
        public void SetDefinitionByPosition(int position, NameDivisionTypeEnum type)
        {
            if (_keyPositionPart.ContainsKey(position))
                Parts[_keyPositionPart[position]].Type = type;
        }
        
        public int Count() => Parts.Count;
    }
}