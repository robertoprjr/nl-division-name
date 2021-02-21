using NLNameDivision.Entity;
using NLNameDivision.Service.Abstraction;
using NLNameDivision.Service.Abstraction.NameDivisionCofR;

namespace NLNameDivision.Service.NameDivisionCofR
{
    public abstract class NameDivisionHandler : INameDivisionHandler
    {
        private INameDivisionHandler _nextHandler;

        public INameDivisionHandler SetNext(INameDivisionHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual NameParts Handle(NameParts nameParts)
        {
            var namePartsDefined = DefineDivision(nameParts);
            return CheckIsAllDefinedDivision(namePartsDefined) ? namePartsDefined : _nextHandler?.Handle(namePartsDefined);
        }

        protected virtual NameParts DefineDivision(NameParts nameParts)
        {
            nameParts.SetAllUndefined();
            return nameParts;
        }

        private static bool CheckIsAllDefinedDivision(NameParts namePartsDefined) =>
            namePartsDefined.IsAllDefined();
    }
}