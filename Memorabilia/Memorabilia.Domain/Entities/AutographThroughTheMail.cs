using System;

namespace Memorabilia.Domain.Entities
{
    public class AutographThroughTheMail : Framework.Domain.Entity.DomainEntity
    {
        public AutographThroughTheMail() { }

        public AutographThroughTheMail(int autographId, DateTime? sentDate, DateTime? receivedDate)
        {
            AutographId = autographId;
            SentDate = sentDate;
            ReceivedDate = receivedDate;
        }

        public int AutographId { get; private set; }

        public DateTime? ReceivedDate { get; private set; }

        public DateTime? SentDate { get; private set; }

        public void Set(DateTime? sentDate, DateTime? receivedDate)
        {
            SentDate = sentDate;
            ReceivedDate = receivedDate;
        }
    }
}
