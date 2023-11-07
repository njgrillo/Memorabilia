namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailModel
{
    private readonly Entity.ThroughTheMail _throughTheMail;

    public ThroughTheMailModel() { }

    public ThroughTheMailModel(Entity.ThroughTheMail throughTheMail)
    {
        _throughTheMail = throughTheMail;

        Address = new(_throughTheMail.Address);
    }

    public ThroughTheMailAddressModel Address { get; set; }
        = new();

    public bool DisplayMemorabiliaDetails { get; set; }

    public int Id 
        => _throughTheMail.Id;

    public int ItemsSentCount
        => Memorabilia?.Count(memorabilia => !memorabilia.IsExtraReceived) ?? 0;

    public string ItemSuccessCount
        => $"{Memorabilia.Length}/{Memorabilia.Count(item => !item.IsExtraReceived)}";

    public Entity.ThroughTheMailMemorabilia[] Memorabilia
        => _throughTheMail.Memorabilia
                          .ToArray();

    public string Notes
        => _throughTheMail.Notes;

    public Entity.Person Person
        => _throughTheMail.Person;

    public DateTime? ReceivedDate
        => _throughTheMail.ReceivedDate;

    public string SelfAddressedStampedEnvelopeTrackingNumber
        => _throughTheMail.SelfAddressedStampedEnvelopeTrackingNumber;

    public DateTime? SentDate 
        => _throughTheMail.SentDate;

    public string Status
        => ReceivedDate.HasValue || Memorabilia.Any(item => item.AutographId.HasValue)
        ? (Memorabilia.Any()
           ? (Memorabilia.All(item => item.AutographId.HasValue)
                ? "Success"
                : (Memorabilia.Any(item => item.AutographId.HasValue)
                    ? "Partial Success"
                    : string.Empty))
           : string.Empty)
        : "Pending";

    public int? ThroughTheMailFailureTypeId
        => _throughTheMail.ThroughTheMailFailureTypeId;

    public string TrackingNumber
        => _throughTheMail.TrackingNumber;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public decimal? TotalCost
        => Memorabilia?.Sum(memorabilia => memorabilia.Cost) ?? 0;

    public int UserId
        => _throughTheMail.UserId;
}
