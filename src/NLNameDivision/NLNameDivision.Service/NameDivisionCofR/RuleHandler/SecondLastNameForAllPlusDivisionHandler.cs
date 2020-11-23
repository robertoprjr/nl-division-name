using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR.RuleHandler
{
    public class SecondLastNameForAllPlusDivisionHandler: NameDivisionHandler
    {
        public override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionForAllUndefined(NameDivisionTypeEnum.SecondLastName);
            return nameParts;
        }
    }
}