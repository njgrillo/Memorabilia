namespace Memorabilia.Domain.Entities;

public class MemorabiliaAcquisition : DomainIdEntity
{
    public MemorabiliaAcquisition() { }

    public MemorabiliaAcquisition(int memorabiliaId,
                                  int acquisitionTypeId, 
                                  DateTime? acquiredDate,
                                  bool acquiredWithAutograph,
                                  decimal? cost,                                       
                                  int? purchaseTypeId)
    {
        MemorabiliaId = memorabiliaId;
        
        Acquisition = new Acquisition(acquisitionTypeId, acquiredDate, cost, purchaseTypeId, acquiredWithAutograph);
    }

    public virtual Acquisition Acquisition { get; private set; }

    public int MemorabiliaId { get; private set; }

    public void Set(int acquisitionTypeId, 
                    DateTime? acquiredDate,
                    bool acquiredWithAutograph,
                    decimal? cost,                        
                    int? purchaseTypeId)
    {
        Acquisition.Set(acquisitionTypeId, acquiredDate, cost, purchaseTypeId, acquiredWithAutograph);
    }
}
