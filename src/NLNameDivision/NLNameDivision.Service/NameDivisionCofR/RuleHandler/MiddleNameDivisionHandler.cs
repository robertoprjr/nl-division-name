using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR.RuleHandler
{
    public class MiddleNameDivisionHandler : NameDivisionHandler
    {
        private readonly NamePositionEnum _position;

        public MiddleNameDivisionHandler(NamePositionEnum position)
        {
            _position = position;
        }
        public override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionByPosition((int) _position, NameDivisionTypeEnum.MiddleName);
            return nameParts;
        }
    }
}