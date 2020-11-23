using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR.RuleHandler
{
    public class FirstLastNameDivisionHandler: NameDivisionHandler
    {
        private readonly NamePositionEnum _position;

        public FirstLastNameDivisionHandler(NamePositionEnum position)
        {
            _position = position;
        }
        public override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionByPosition((int) _position, NameDivisionTypeEnum.FirstLastName);
            return nameParts;
        }
    }
}