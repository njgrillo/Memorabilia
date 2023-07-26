namespace Memorabilia.Domain.Entities;

public class ThroughTheMailMemorabilia : Framework.Library.Domain.Entity.DomainEntity
{
    public ThroughTheMailMemorabilia() { }

    public ThroughTheMailMemorabilia(int throughTheMailId,
        int memorabiliaId,
        decimal? cost)
    {
        ThroughTheMailId = throughTheMailId;
        MemorabiliaId = memorabiliaId;
        Cost = cost;   
    }

    public decimal? Cost { get; set; }

    public virtual Memorabilia Memorabilia { get; set; }

    public int MemorabiliaId { get; set; }    

    public int ThroughTheMailId { get; set; }

    public void Set(decimal? cost)
    {
        Cost = cost;
    }
}
