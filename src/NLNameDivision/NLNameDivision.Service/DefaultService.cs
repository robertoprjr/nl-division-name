using System.Collections.Generic;
using NLNameDivision.Cross.Constant;
using NLNameDivision.Service.Abstraction;

namespace NLNameDivision.Service
{
    public class DefaultService : IDefaultService
    {
        public string[] ReportDefaultData()
        {
            return new[]
            {
                GeneralConstant.TitleApi, GeneralConstant.AuthorId
            };
        }
    }
}