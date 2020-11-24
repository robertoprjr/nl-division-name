using NLNameDivision.Service.Abstraction.NameDivisionCofR;
using NLNameDivision.Service.NameDivisionCofR.Rule;

namespace NLNameDivision.Service.NameDivisionCofR
{
    public static class NameDivisionRuleFactory
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

        private static INameDivisionHandler GetRuleOne() => 
            new OneNameDivisionRule().SetRule();

        private static INameDivisionHandler GetRuleTwo() =>
            new TwoNameDivisionRule().SetRule();

        private static INameDivisionHandler GetRuleThree() =>
            new ThreeNameDivisionRule().SetRule();

        private static INameDivisionHandler GetRuleFour() => 
            new FourNameDivisionRule().SetRule();

        private static INameDivisionHandler GetRulePlus() =>
            new PlusNameDivisionRule().SetRule();
    }
}