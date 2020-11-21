using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR
{
    public class FirstLastNameDivisionHandler: NameDivisionHandler
    {
        private int _order = 2;
        public override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionByOrder(_order, NameDivisionTypeEnum.FirstLastName);
            return nameParts;
        }
    }
}