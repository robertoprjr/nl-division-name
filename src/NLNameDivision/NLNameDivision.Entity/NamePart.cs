using System.Reflection.Metadata;
using NLNameDivision.Constant.Enum;

namespace NLNameDivision.Entity
{
    public class NamePart
    {
        public int Order { get; set; }
        public string Particle { get; set; }
        public string Value { get; set; }
        public NameDivisionTypeEnum Type { get; set; }
    }
}