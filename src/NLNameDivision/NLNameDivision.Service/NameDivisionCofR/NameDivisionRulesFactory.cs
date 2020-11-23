using NLNameDivision.Constant.Enum;
using NLNameDivision.Service.Abstraction.NameDivisionCofR;
using NLNameDivision.Service.NameDivisionCofR.RuleHandler;

namespace NLNameDivision.Service.NameDivisionCofR
{
    public static class NameDivisionRulesFactory
    {
        public static INameDivisionHandler GetRule(int divisionsCount)
        {
            switch (divisionsCount)
            {
                case 0:
                    return GetRuleZero();
                case 1:
                    return GetRuleOne();
                case 2:
                    return GetRuleTwo();
                case 3:
                    return GetRuleThree();
                case 4:
                    return GetRuleFour();
                default:
                    return GetRulePlus();
            }
        }

        private static INameDivisionHandler GetRuleZero() => null;

        private static INameDivisionHandler GetRuleOne()
        {
            var ruleOne = new AddAlternativeFirstLastNameDivisionHandler();
            ruleOne.SetNext(new FirstNameDivisionHandler(NamePositionEnum.First))
                   .SetNext(new FirstLastNameDivisionHandler(NamePositionEnum.Second));

            return ruleOne;
        }
        private static INameDivisionHandler GetRuleTwo()
        {
            var ruleTwo = new FirstNameDivisionHandler(NamePositionEnum.First);
            ruleTwo.SetNext(new FirstLastNameDivisionHandler(NamePositionEnum.Second));

            return ruleTwo;
        }

        private static INameDivisionHandler GetRuleThree()
        {
            var ruleThree = new FirstNameDivisionHandler(NamePositionEnum.First);
            ruleThree.SetNext(new MiddleNameDivisionHandler(NamePositionEnum.Second))
                     .SetNext(new FirstLastNameDivisionHandler(NamePositionEnum.Third));

            return ruleThree;
        }
        private static INameDivisionHandler GetRuleFour()
        {
            var ruleFour = new FirstNameDivisionHandler(NamePositionEnum.First);
            ruleFour.SetNext(new MiddleNameDivisionHandler(NamePositionEnum.Second))
                    .SetNext(new FirstLastNameDivisionHandler(NamePositionEnum.Third))
                    .SetNext(new SecondLastNameDivisionHandler(NamePositionEnum.Forth));

            return ruleFour;
        }

        private static INameDivisionHandler GetRulePlus()
        {
            var rulePlus = new FirstNameDivisionHandler(NamePositionEnum.First);
            rulePlus.SetNext(new MiddleNameDivisionHandler(NamePositionEnum.Second))
                    .SetNext(new FirstLastNameDivisionHandler(NamePositionEnum.Third))
                    .SetNext(new SecondLastNameForAllPlusDivisionHandler());

            return rulePlus;
        }
    }
}