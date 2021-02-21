using NLNameDivision.Constant;
using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR.Handler
{
    public class AddAlternativeFirstLastNameDivisionHandler: NameDivisionHandler
    {
        protected override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.Add(NameDivisionConstant.AlternativeNotDefinedName);
            return nameParts;
        }
    }
}