using NLNameDivision.Entity;

namespace NLNameDivision.Service.Abstraction.NameDivisionCofR
{
    public interface INameDivisionHandler
    {
        INameDivisionHandler SetNext(INameDivisionHandler handler);

        NameParts Handle(NameParts nameParts);
    }
}    