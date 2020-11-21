using NLNameDivision.Entity;

namespace NLNameDivision.Service.Abstraction
{
    public interface INameDivisionHandler
    {
        INameDivisionHandler SetNext(INameDivisionHandler handler);

        NameParts Handle(NameParts nameParts);
    }
}    