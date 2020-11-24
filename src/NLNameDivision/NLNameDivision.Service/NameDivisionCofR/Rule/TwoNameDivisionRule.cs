using NLNameDivision.Constant.Enum;
using NLNameDivision.Service.Abstraction.NameDivisionCofR;
using NLNameDivision.Service.NameDivisionCofR.Handler;

namespace NLNameDivision.Service.NameDivisionCofR.Rule
{
    public class TwoNameDivisionRule : INameDivisionRule
    {
        public INameDivisionHandler SetRule()
        {
            var rule = new FirstNameDivisionHandler(NamePositionEnum.First);
            rule.SetNext(new FirstLastNameDivisionHandler(NamePositionEnum.Second));

            return rule;
        }
    }
}