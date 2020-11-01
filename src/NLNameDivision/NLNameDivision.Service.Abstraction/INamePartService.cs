using System.Collections.Generic;
using NLNameDivision.Entity;

namespace NLNameDivision.Service.Abstraction
{
    public interface INamePartService
    {
        List<string> ReportParticleList();
        NameSlices SliceName(string nameToDivide);
    }
}