using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR.Handler
{
    public class SecondLastNameForAllPlusDivisionHandler: NameDivisionHandler
    {
        protected override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionForAllUndefined(NameDivisionTypeEnum.SecondLastName);
            return nameParts;
        }
    }
}