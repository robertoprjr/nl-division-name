using System.ComponentModel;

namespace NLNameDivision.Constant.Enum
{
    public enum NameDivisionTypeEnum
    {
        [Description("Indefinido")]
        Indefinido = 0,
        [Description("Primeiro Nome")]
        PrimeiroNome = 1,
        [Description("Segundo Nome")]
        SegundoNome = 2,
        [Description("Primeiro Sobrenome")]
        PrimeiroSobrenome = 3,
        [Description("Segundo Sobrenome")]
        SegundoSobrenome = 4
    }
}