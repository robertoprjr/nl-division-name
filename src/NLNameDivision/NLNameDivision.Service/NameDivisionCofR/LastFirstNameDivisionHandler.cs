using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR
{
    public class LastFirstNameDivisionHandler: NameDivisionHandler
    {
        private int _order = 2;
        public override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionByOrder(_order, NameDivisionTypeEnum.PrimeiroSobrenome);
            return nameParts;
        }
    }
}