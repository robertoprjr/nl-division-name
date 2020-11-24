using System;
using NLNameDivision.Constant;
using NLNameDivision.Constant.Enum;

namespace NLNameDivision.Entity
{
    public class NameStructured
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }

        public NameStructured() => ClearNames();
        
        public void ClearNames() =>
            FirstName = MiddleName = FirstLastName = SecondLastName = String.Empty;
        
        public void FillNameStructured(NameParts nameParts)
        {
            foreach (var namePart in nameParts.Parts) 
                FillName(namePart);
        }

        private void FillName(NamePart namePart)
        {
            switch (namePart.Type)
            {
                case NameDivisionTypeEnum.FirstName:
                    FirstName = ComposeName(FirstName, namePart);
                    break;
                case NameDivisionTypeEnum.MiddleName:
                    MiddleName = ComposeName(MiddleName, namePart);
                    break;
                case NameDivisionTypeEnum.FirstLastName:
                    FirstLastName = ComposeName(FirstLastName, namePart);
                    break;
                case NameDivisionTypeEnum.SecondLastName:
                    SecondLastName = ComposeName(SecondLastName, namePart);
                    break;
            }
        }
        
        private string ComposeName(string actualNameComposed, NamePart namePart)
        {
            var newNameComposed = actualNameComposed;
            newNameComposed += ComposeUnionChar(newNameComposed);
            newNameComposed += ComposeParticle(namePart.Particle);
            newNameComposed += namePart.Value;

            return newNameComposed;
        }

        private string ComposeUnionChar(string actualNameComposed)
        {
            if (actualNameComposed == String.Empty)
                return String.Empty;
            
            return NameDivisionConstant.UnionChar;
        }

        private string ComposeParticle(string particle)
        {
            if (particle == String.Empty)
                return String.Empty;

            return particle + NameDivisionConstant.UnionChar;
        }
    }
}