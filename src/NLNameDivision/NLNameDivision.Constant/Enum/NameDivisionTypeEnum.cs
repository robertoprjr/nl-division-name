using System.ComponentModel;

namespace NLNameDivision.Constant.Enum
{
    public enum NameDivisionTypeEnum
    {
        [Description("Undefined")]
        Undefined = 0,
        [Description("First Name")]
        FirstName = 1,
        [Description("Middle Name")]
        MiddleName = 2,
        [Description("First Last Name")]
        FirstLastName = 3,
        [Description("Second Last Name")]
        SecondLastName = 4
    }
}