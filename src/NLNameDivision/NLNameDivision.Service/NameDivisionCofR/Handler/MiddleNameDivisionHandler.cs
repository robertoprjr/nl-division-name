using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR.Handler
{
    public class MiddleNameDivisionHandler : NameDivisionHandler
    {
        private readonly NamePositionEnum _position;

        public MiddleNameDivisionHandler(NamePositionEnum position)
        {
            _position = position;
        }

        protected override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionByPosition((int) _position, NameDivisionTypeEnum.MiddleName);
            return nameParts;
        }
    }
}