using NLNameDivision.Service.Abstraction;

namespace NLNameDivision.Service.NameDivisionCofR
{
    public static class NameDivisionRulesFactory
    {
        public static INameDivisionHandler GetRuleOne()
        {
            var ruleOne = new FirstNameDivisionHandler();
            ruleOne.SetNext(new LastFirstNameDivisionHandler());

            return ruleOne;
        }
    }
}