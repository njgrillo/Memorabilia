namespace Memorabilia.Domain.Entities
{
    public class SingleSeasonRecord : Framework.Domain.Entity.DomainEntity
    {
        public SingleSeasonRecord() { }

        public SingleSeasonRecord(int personId, int recordTypeId, int year, int amount)
        {
            PersonId = personId;
            RecordTypeId = recordTypeId;
            Year = year;
            Amount = amount;
        }

        public int Amount { get; private set; }

        public int PersonId { get; private set; }

        public int RecordTypeId { get; private set; }

        public int Year { get; private set; }

        public void Set(int recordTypeId, int year, int amount)
        {
            RecordTypeId = recordTypeId;
            Year = year;
            Amount = amount;
        }
    }
}
