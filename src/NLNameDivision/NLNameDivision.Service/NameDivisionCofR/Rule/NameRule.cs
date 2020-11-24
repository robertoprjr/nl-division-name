using NLNameDivision.Service.Abstraction.NameDivisionCofR;

namespace NLNameDivision.Service.NameDivisionCofR.Rule
{
    public abstract class NameRule
    {
        public abstract INameDivisionHandler GetRule();
    }
}