namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailModel
{
    private readonly Entity.ThroughTheMail _throughTheMail;

    public ThroughTheMailModel() { }

    public ThroughTheMailModel(Entity.ThroughTheMail throughTheMail)
    {
        _throughTheMail = throughTheMail;
    }

    public int Id 
        => _throughTheMail.Id;

    public Entity.Person Person
        => _throughTheMail.Person;

    public DateTime? ReceivedDate
        => _throughTheMail.ReceivedDate;

    public DateTime? SentDate 
        => _throughTheMail.SentDate;

    public int UserId
        => _throughTheMail.UserId;
}
