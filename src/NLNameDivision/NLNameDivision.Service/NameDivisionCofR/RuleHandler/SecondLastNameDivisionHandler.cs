using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR.RuleHandler
{
    public class SecondLastNameDivisionHandler: NameDivisionHandler
    {
        private readonly NamePositionEnum _position;

        public SecondLastNameDivisionHandler(NamePositionEnum position)
        {
            _position = position;
        }
        public override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionByPosition((int) _position, NameDivisionTypeEnum.SecondLastName);
            return nameParts;
        }
    }
}