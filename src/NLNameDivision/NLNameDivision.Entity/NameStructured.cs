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
        
        private string ComposeName(string actualName, NamePart namePart)
        {
            var returnName = actualName;
            
            if (returnName != String.Empty)
                returnName += NameDivisionConstant.UnionChar;

            if (namePart.Particle != String.Empty)
                returnName += namePart.Particle + NameDivisionConstant.UnionChar;

            returnName += namePart.Value;
            return returnName;
        }
    }
}