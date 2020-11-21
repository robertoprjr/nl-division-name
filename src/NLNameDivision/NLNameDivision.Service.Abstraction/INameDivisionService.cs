using System.Collections.Generic;
using NLNameDivision.Cross.DTO;

namespace NLNameDivision.Service.Abstraction
{
    public interface INameDivisionService
    {
        List<string> ReportParticleList();
        NameSlicesDto GetNameSliced(string nameToDivide);
        NamePartsDto GetNameParted(string nameToDivide);
        NamePartsDto GetNameDivided(string nameToDivide);
    }
}