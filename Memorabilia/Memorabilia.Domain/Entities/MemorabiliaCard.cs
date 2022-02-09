namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaCard : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaCard() { }

        public MemorabiliaCard(int memorabiliaId, int? year, int? numerator, int? denominator)
        {
            MemorabiliaId = memorabiliaId;
            Year = year;
            Numerator = numerator;
            Denominator = denominator;
        }

        public int? Denominator { get; set; }

        public int MemorabiliaId { get; private set; }

        public int? Numerator { get; set; }

        public int? Year { get; private set; }

        public void Set(int? year, int? numerator, int? denominator)
        {
            Year = year;
            Numerator = numerator;
            Denominator = denominator;
        }
    }
}
