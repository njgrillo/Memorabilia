namespace Memorabilia.Domain.Entities
{
    public class PersonAccomplishment : Framework.Library.Domain.Entity.DomainEntity
    {
        public PersonAccomplishment() { }

        public PersonAccomplishment(int personId, int accomplishmentTypeId, DateTime? date, int? year)
        {
            PersonId = personId;
            AccomplishmentTypeId = accomplishmentTypeId;
            Date = date;
            Year = year;
        }

        public int AccomplishmentTypeId { get; private set; }

        public DateTime? Date { get; private set; }

        public virtual Person Person { get; private set; }

        public int PersonId { get; private set; }

        public int? Year { get; private set; }

        public void Set(int accomplishmentTypeId, DateTime? date, int? year)
        {
            AccomplishmentTypeId = accomplishmentTypeId;
            Date = date;
            Year = year;
        }
    }
}
