using NLNameDivision.Constant.Enum;
using NLNameDivision.Service.Abstraction.NameDivisionCofR;
using NLNameDivision.Service.NameDivisionCofR.Handler;

namespace NLNameDivision.Service.NameDivisionCofR.Rule
{
    public class OneNameDivisionRule : INameDivisionRule
    {
        public INameDivisionHandler SetRule()
        {
            var rule = new AddAlternativeFirstLastNameDivisionHandler();
            rule.SetNext(new FirstNameDivisionHandler(NamePositionEnum.First))
                .SetNext(new FirstLastNameDivisionHandler(NamePositionEnum.Second));

            return rule;
        }
    }
}