using System;

namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaAcquisition : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaAcquisition() { }

        public MemorabiliaAcquisition(int memorabiliaId, int acquisitionTypeId, DateTime? acquiredDate, decimal? cost, int? purchaseTypeId)
        {
            MemorabiliaId = memorabiliaId;
            
            Acquisition = new Acquisition(acquisitionTypeId, acquiredDate, cost, purchaseTypeId);
        }

        public Acquisition Acquisition { get; private set; }

        public int MemorabiliaId { get; private set; }

        public void Set(int acquisitionTypeId, DateTime? acquiredDate, decimal? cost, int? purchaseTypeId)
        {
            Acquisition.Set(acquisitionTypeId, acquiredDate, cost, purchaseTypeId);
        }
    }
}
