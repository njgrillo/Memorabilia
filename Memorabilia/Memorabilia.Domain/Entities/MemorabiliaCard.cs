namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaCard : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaCard() { }

        public MemorabiliaCard(int memorabiliaId, bool custom, int? denominator, bool licensed, int? numerator, int? year)
        {
            MemorabiliaId = memorabiliaId;
            Custom = custom;
            Denominator = denominator;
            Licensed = licensed;
            Numerator = numerator;
            Year = year;
        }

        public bool Custom { get; private set; }

        public int? Denominator { get; private set; }

        public bool Licensed { get; private set; }

        public int MemorabiliaId { get; private set; }

        public int? Numerator { get; private set; }

        public int? Year { get; private set; }

        public void Set(bool custom, int? denominator, bool licensed, int? numerator, int? year)
        {
            Custom = custom;
            Denominator = denominator;
            Licensed = licensed;
            Numerator = numerator;
            Year = year;
        }
    }
}
