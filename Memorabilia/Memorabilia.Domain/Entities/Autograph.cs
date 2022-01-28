using System;

namespace Memorabilia.Domain.Entities
{
    public class Autograph : Framework.Domain.Entity.DomainEntity
    {
        public Autograph() { }

        public Autograph(int memorabiliaId,
                         int personId,
                         int? conditionId,
                         int? spotId,
                         int? writingInstrumentId,
                         int? colorId,
                         int userId)
        {
            MemorabiliaId = memorabiliaId;
            PersonId = personId;
            ConditionId = conditionId;
            SpotId = spotId;
            WritingInstrumentId = writingInstrumentId;
            ColorId = colorId;
            UserId = userId;
            CreateDate = DateTime.UtcNow;
        }       

        public int? ColorId { get; private set; }

        public Constants.Color Color => Constants.Color.Find(ColorId ?? 0);

        public Constants.Condition Condition => Constants.Condition.Find(ConditionId ?? 0);

        public int? ConditionId { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public Memorabilia Memorabilia { get; set; }

        public int MemorabiliaId { get; private set; }

        public Person Person { get; set; }

        public int PersonId { get; private set; }

        public Constants.Spot Spot => Constants.Spot.Find(SpotId ?? 0);

        public int? SpotId { get; private set; }

        public int UserId { get; private set; }

        public Constants.WritingInstrument WritingInstrument => Constants.WritingInstrument.Find(WritingInstrumentId ?? 0);

        public int? WritingInstrumentId { get; private set; }

        public void Set(int personId, 
                        int? conditionId,
                        int? spotId,
                        int? writingInstrumentId,
                        int? colorId)
        {
            PersonId = personId;
            ConditionId = conditionId;
            SpotId = spotId;
            WritingInstrumentId = writingInstrumentId;
            ColorId = colorId;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}
