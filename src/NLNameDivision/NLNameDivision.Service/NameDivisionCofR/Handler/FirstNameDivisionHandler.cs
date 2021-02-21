using NLNameDivision.Constant.Enum;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.NameDivisionCofR.Handler
{
    public class FirstNameDivisionHandler : NameDivisionHandler
    {
        private readonly NamePositionEnum _position;

        public FirstNameDivisionHandler(NamePositionEnum position)
        {
            _position = position;
        }

        protected override NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetDefinitionByPosition((int) _position, NameDivisionTypeEnum.FirstName);
            return nameParts;
        }
    }
}