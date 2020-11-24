using System;
using NLNameDivision.Constant;
using NLNameDivision.Constant.Enum;

namespace NLNameDivision.Entity
{
    public class NameStructured
    {
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string FirstLastName { get; private set; }
        public string SecondLastName { get; private set; }

        public NameStructured() => ClearNames();
        
        private void ClearNames() =>
            FirstName = MiddleName = FirstLastName = SecondLastName = string.Empty;
        
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
                case NameDivisionTypeEnum.Undefined:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private static string ComposeName(string actualNameComposed, NamePart namePart)
        {
            var newNameComposed = actualNameComposed;
            newNameComposed += ComposeUnionChar(newNameComposed);
            newNameComposed += ComposeParticle(namePart.Particle);
            newNameComposed += namePart.Value;

            return newNameComposed;
        }

        private static string ComposeUnionChar(string actualNameComposed) =>
            (actualNameComposed == string.Empty ? string.Empty : NameDivisionConstant.UnionChar);

        private static string ComposeParticle(string particle) => 
            (particle == string.Empty ? string.Empty : particle + NameDivisionConstant.UnionChar);
    }
}