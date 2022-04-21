namespace Memorabilia.Domain.Entities
{
    public class CareerRecord : Framework.Domain.Entity.DomainEntity
    {
        public CareerRecord() { }

        public CareerRecord(int personId, int recordTypeId, int amount)
        {
            PersonId = personId;
            RecordTypeId = recordTypeId;
            Amount = amount;
        }

        public int Amount { get; private set; }

        public int PersonId { get; private set; }

        public int RecordTypeId { get; private set; }

        public void Set(int recordTypeId, int amount)
        {
            RecordTypeId = recordTypeId;
            Amount = amount;
        }
    }
}
