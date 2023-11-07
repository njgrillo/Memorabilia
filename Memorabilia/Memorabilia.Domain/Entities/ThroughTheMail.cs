namespace Memorabilia.Domain.Entities;

public class ThroughTheMail : Entity
{
    public ThroughTheMail() { }

    public ThroughTheMail(int personId,
        int? addressId,
        DateTime? sentDate,
        DateTime? receivedDate,
        string notes,
        string selfAddressedStampedEnvelopeTrackingNumber,
        int? throughTheMailFailureTypeId,
        string trackingNumber,
        int userId)
    {        
        AddressId = addressId;
        Notes = notes;
        PersonId = personId;
        ReceivedDate = receivedDate;
        SelfAddressedStampedEnvelopeTrackingNumber = selfAddressedStampedEnvelopeTrackingNumber;
        SentDate = sentDate;
        ThroughTheMailFailureTypeId = throughTheMailFailureTypeId;
        TrackingNumber = trackingNumber;
        UserId = userId;
    }

    public virtual Address Address { get; private set; }

    public int? AddressId { get; private set; }

    public virtual List<ThroughTheMailMemorabilia> Memorabilia { get; set; }
        = new();

    public string Notes { get; private set; }

    public virtual Person Person{ get; set; }

    public int PersonId { get; private set; }

    public DateTime? ReceivedDate { get; private set; }

    public string SelfAddressedStampedEnvelopeTrackingNumber { get; private set; }

    public DateTime? SentDate { get; private set; }

    public int? ThroughTheMailFailureTypeId { get; private set; }

    public string TrackingNumber { get; private set; }

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
        string trackingNumber,
        string selfAddressedStampedEnvelopeTrackingNumber,
        string notes,
        int? throughTheMailFailureTypeId)
    {
        AddressId = addressId;
        Notes = notes;
        ReceivedDate = receivedDate;
        SelfAddressedStampedEnvelopeTrackingNumber = selfAddressedStampedEnvelopeTrackingNumber;
        SentDate = sentDate;
        ThroughTheMailFailureTypeId = throughTheMailFailureTypeId;
        TrackingNumber = trackingNumber;
    }

    public void SetAddress(string addressLine1,
                           string addressLine2,
                           string city,
                           string country,
                           string postalCode,
                           string singleLine,
                           string stateProvidence)
    {
        if (Address == null)
        {
            Address = new(addressLine1,
                          addressLine2,
                          city,
                          country,
                          postalCode,
                          singleLine,
                          stateProvidence);

            return;
        }

        Address.Set(addressLine1,
                    addressLine2,
                    city,
                    country,
                    postalCode,
                    singleLine,
                    stateProvidence);
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
