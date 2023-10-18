namespace Memorabilia.Domain.Entities;

public class ThroughTheMail : DomainIdEntity
{
    public ThroughTheMail() { }

    public ThroughTheMail(int personId,
        int? addressId,
        DateTime? sentDate,
        DateTime? receivedDate,
        string notes,
        int? throughTheMailFailureTypeId,
        int userId)
    {
        PersonId = personId;
        AddressId = addressId;
        SentDate = sentDate;
        ReceivedDate = receivedDate;
        Notes = notes;
        ThroughTheMailFailureTypeId = throughTheMailFailureTypeId;
        UserId = userId;
    }

    public int? AddressId { get; private set; }

    public virtual List<ThroughTheMailMemorabilia> Memorabilia { get; set; }
        = new();

    public string Notes { get; private set; }

    public virtual Person Person{ get; set; }

    public int PersonId { get; private set; }

    public DateTime? ReceivedDate { get; private set; }

    public DateTime? SentDate { get; private set; }

    public int? ThroughTheMailFailureTypeId { get; private set; }

    public int UserId { get; private set; } 

    public void RemoveMemorabilia(int[] memorabiliaIds)
    {
        if (memorabiliaIds == null || memorabiliaIds.Length == 0)
            return;

        Memorabilia.RemoveAll(throughTheMailMemorabilia => memorabiliaIds.Contains(throughTheMailMemorabilia.MemorabiliaId));
    }

    public void Set(int? addressId,
        DateTime? sentDate,
        DateTime? receivedDate,
        string notes,
        int? throughTheMailFailureTypeId)
    {
        AddressId = addressId;
        SentDate = sentDate;
        ReceivedDate = receivedDate;
        Notes = notes;
        ThroughTheMailFailureTypeId = throughTheMailFailureTypeId;
    }

    public void SetMemorabilia(int id, 
        int throughTheMailId,
        int memorabiliaId,
        int? autographId,
        decimal? cost,
        bool isExtraReceived)
    {
        ThroughTheMailMemorabilia throughTheMailMemorabilia = id > 0
            ? Memorabilia.SingleOrDefault(throughTheMailMemorabilia => throughTheMailMemorabilia.Id == id)
            : Memorabilia.SingleOrDefault(throughTheMailMemorabilia => throughTheMailMemorabilia.MemorabiliaId == memorabiliaId && throughTheMailMemorabilia.ThroughTheMailId == throughTheMailId);

        if (throughTheMailMemorabilia == null)
        {
            Memorabilia.Add(new ThroughTheMailMemorabilia(Id,
                            memorabiliaId,
                            autographId,
                            cost,
                            isExtraReceived));

            return;
        }

        throughTheMailMemorabilia.Set(autographId, cost, isExtraReceived);
    }
}
