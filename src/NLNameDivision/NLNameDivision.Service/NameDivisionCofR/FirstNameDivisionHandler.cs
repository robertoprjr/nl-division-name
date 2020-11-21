using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR
{
    public class FirstNameDivisionHandler : NameDivisionHandler
    {
        private int _order = 1;
        public override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionByOrder(_order, NameDivisionTypeEnum.PrimeiroNome);
            return nameParts;
        }
    }
}