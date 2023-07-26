namespace Memorabilia.Domain.Entities;

public class ThroughTheMail : Framework.Library.Domain.Entity.DomainEntity
{
    public ThroughTheMail() { }

    public ThroughTheMail(int personId,
        int? addressId,
        DateTime? sentDate,
        DateTime? receivedDate,
        int userId)
    {
        PersonId = personId;
        AddressId = addressId;
        SentDate = sentDate;
        ReceivedDate = receivedDate;
        UserId = userId;
    }

    public int? AddressId { get; set; }

    public virtual List<ThroughTheMailMemorabilia> Memorabilia { get; set; }
        = new();

    public virtual Person Person{ get; set; }

    public int PersonId { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public DateTime? SentDate { get; set; }

    public int UserId { get; set; } 

    public void RemoveMemorabilia(int[] memorabiliaIds)
    {
        if (memorabiliaIds == null || memorabiliaIds.Length == 0)
            return;

        Memorabilia.RemoveAll(throughTheMailMemorabilia => memorabiliaIds.Contains(throughTheMailMemorabilia.MemorabiliaId));
    }

    public void Set(int? addressId,
        DateTime? sentDate,
        DateTime? receivedDate)
    {
        AddressId = addressId;
        SentDate = sentDate;
        ReceivedDate = receivedDate;
    }

    public void SetMemorabilia(int id, 
        int throughTheMailId,
        int memorabiliaId,
        decimal? cost)
    {
        ThroughTheMailMemorabilia throughTheMailMemorabilia = id > 0
            ? Memorabilia.SingleOrDefault(throughTheMailMemorabilia => throughTheMailMemorabilia.Id == id)
            : Memorabilia.SingleOrDefault(throughTheMailMemorabilia => throughTheMailMemorabilia.MemorabiliaId == memorabiliaId && throughTheMailMemorabilia.ThroughTheMailId == throughTheMailId);

        if (throughTheMailMemorabilia == null)
        {
            Memorabilia.Add(new ThroughTheMailMemorabilia(Id,
                            memorabiliaId,
                            cost));

            return;
        }

        throughTheMailMemorabilia.Set(cost);
    }
}
