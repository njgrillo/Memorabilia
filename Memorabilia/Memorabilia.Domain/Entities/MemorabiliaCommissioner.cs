namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaCommissioner : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaCommissioner() { }

        public MemorabiliaCommissioner(int memorabiliaId, int commissionerId)
        {
            MemorabiliaId = memorabiliaId;
            CommissionerId = commissionerId;
        }

        public int CommissionerId { get; private set; }

        public int MemorabiliaId { get; private set; }

        public void Set(int commissionerId)
        {
            CommissionerId = commissionerId;
        }
    }
}
