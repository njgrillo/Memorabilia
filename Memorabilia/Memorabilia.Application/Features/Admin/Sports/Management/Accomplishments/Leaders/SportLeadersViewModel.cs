namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.Leaders;

public class SportLeadersViewModel
{
    private readonly Entity.Leader[] _leaders;
    private readonly int _sportId;

    public SportLeadersViewModel() { }

    public SportLeadersViewModel(int sportId, Entity.Leader[] leaders)
    {
        _leaders = leaders;
        _sportId = sportId;
    }

    public Entity.Leader[] Leaders
        => _leaders;

    public int SportId
        => _sportId;
}
