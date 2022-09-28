namespace Memorabilia.Domain.Entities
{
    public class InternationalHallOfFame : Framework.Library.Domain.Entity.DomainEntity
    {
        public InternationalHallOfFame() { }

        public InternationalHallOfFame(int personId, int internationalHallOfFameTypeId, int? inductionYear)
        {            
            PersonId = personId;
            InternationalHallOfFameTypeId = internationalHallOfFameTypeId;
            InductionYear = inductionYear;
        }

        public int? InductionYear { get; private set; }

        public int InternationalHallOfFameTypeId { get; private set; }

        public int PersonId { get; private set; }

        public void Set(int internationalHallOfFameTypeId, int? inductionYear)
        {
            InternationalHallOfFameTypeId = internationalHallOfFameTypeId;
            InductionYear = inductionYear;
        }
    }
}
