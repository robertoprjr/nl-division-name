using NLNameDivision.Constant.Enum;
using NLNameDivision.Service.Abstraction.NameDivisionCofR;
using NLNameDivision.Service.NameDivisionCofR.Handler;

namespace NLNameDivision.Service.NameDivisionCofR.Rule
{
    public class ThreeNameDivisionRule : INameDivisionRule
    {
        public INameDivisionHandler SetRule()
        {
            var rule = new FirstNameDivisionHandler(NamePositionEnum.First);
            rule.SetNext(new MiddleNameDivisionHandler(NamePositionEnum.Second))
                .SetNext(new FirstLastNameDivisionHandler(NamePositionEnum.Third));

            return rule;
        }
    }
}