namespace Memorabilia.Application.Features.Admin.Sports;

public class SportModel
{
    private readonly Entity.Sport _sport;

    public SportModel() { }

    public SportModel(Entity.Sport sport)
    {
        _sport = sport;
    }

    public string AlternateName 
        => _sport.AlternateName;

    public int Id 
        => _sport.Id;

    public DateTime? LastModifiedDate 
        => _sport.LastModifiedDate;

    public string Name 
        => _sport.Name;
}
