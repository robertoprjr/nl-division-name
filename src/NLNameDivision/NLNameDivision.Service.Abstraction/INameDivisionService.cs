using System.Collections.Generic;
using NLNameDivision.Cross.DTO;

namespace NLNameDivision.Service.Abstraction
{
    public interface INameDivisionService
    {
        List<string> ReportList();
        NameSlicesDto ComputeNameDivision(string nameToDivide);
    }
}