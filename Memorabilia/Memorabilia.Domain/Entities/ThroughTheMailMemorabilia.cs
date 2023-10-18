namespace Memorabilia.Domain.Entities;

public class ThroughTheMailMemorabilia : Entity
{
    public ThroughTheMailMemorabilia() { }

    public ThroughTheMailMemorabilia(int throughTheMailId,
        int memorabiliaId,
        int? autographId,
        decimal? cost,
        bool isExtraReceieved)
    {
        ThroughTheMailId = throughTheMailId;
        MemorabiliaId = memorabiliaId;
        AutographId = autographId;
        Cost = cost;   
        IsExtraReceived = isExtraReceieved;
    }

    public int? AutographId { get; private set; }

    public virtual Autograph Autograph { get; set; }

    public decimal? Cost { get; private set; }

    public bool IsExtraReceived { get; private set; }

    public virtual Memorabilia Memorabilia { get; set; }

    public int MemorabiliaId { get; private set; }    

    public int ThroughTheMailId { get; private set; }

    public void Set(int? autographId, decimal? cost, bool isExtraReceived)
    {
        AutographId = autographId;
        Cost = cost;
        IsExtraReceived = isExtraReceived;
    }
}
