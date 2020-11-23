using NLNameDivision.Constant.Enum;

namespace NLNameDivision.Cross.DTO
{
    public struct NamePartDto
    {
        public int Position { get; set; }
        public string Particle { get; set; }
        public string Value { get; set; }
        public NameDivisionTypeEnum Type { get; set; }
    }
}