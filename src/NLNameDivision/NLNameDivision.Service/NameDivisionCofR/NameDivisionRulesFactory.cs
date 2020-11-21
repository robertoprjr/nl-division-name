using NLNameDivision.Service.Abstraction;
using NLNameDivision.Service.Abstraction.NameDivisionCofR;

namespace NLNameDivision.Service.NameDivisionCofR
{
    public static class NameDivisionRulesFactory
    {
        public static INameDivisionHandler GetRuleOne()
        {
            var ruleOne = new FirstNameDivisionHandler();
            ruleOne.SetNext(new FirstLastNameDivisionHandler());

            return ruleOne;
        }
    }
}