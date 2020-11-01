using System.Collections.Generic;

namespace NLNameDivision.Service.Abstraction
{
    public interface IParticleService
    {
        List<string> ReportParticleList();
        bool IsParticle(string valueToVerify);
    }
}