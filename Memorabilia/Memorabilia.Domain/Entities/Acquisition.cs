

namespace Memorabilia.Domain.Entities
{
    public class Acquisition : Framework.Domain.Entity.DomainEntity
    {
        public Acquisition() { }

        public Acquisition(int acquisitionTypeId, 
                           DateTime? acquiredDate, 
                           decimal? cost,                            
                           int? purchaseTypeId,
                           bool? acquiredWithAutograph = null)
        {
            AcquisitionTypeId = acquisitionTypeId;
            AcquiredDate = acquiredDate;
            AcquiredWithAutograph = acquiredWithAutograph;
            Cost = cost;
            PurchaseTypeId = purchaseTypeId;
        }

        public DateTime? AcquiredDate { get; private set; }

        public bool? AcquiredWithAutograph { get; private set; }

        public int AcquisitionTypeId { get; private set; }

        public decimal? Cost { get; private set; }        

        public int? PurchaseTypeId { get; private set; }

        public void Set(int acquisitionTypeId, 
                        DateTime? acquiredDate, 
                        decimal? cost, 
                        int? purchaseTypeId,
                        bool? acquiredWithAutograph = null)
        {
            AcquisitionTypeId = acquisitionTypeId;
            AcquiredDate = acquiredDate;
            AcquiredWithAutograph = acquiredWithAutograph;
            Cost = cost;
            PurchaseTypeId = purchaseTypeId;
        }
    }
}
