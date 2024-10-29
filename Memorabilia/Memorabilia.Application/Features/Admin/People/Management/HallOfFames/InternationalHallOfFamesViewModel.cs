namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

public class InternationalHallOfFamesViewModel
{
    private readonly int _internationalHallOfFameTypeId;
    private readonly Entity.InternationalHallOfFame[] _hallOfFamers;

    public InternationalHallOfFamesViewModel() { }

    public InternationalHallOfFamesViewModel(int internationalHallOfFameTypeId, Entity.InternationalHallOfFame[] hallOfFamers)
    {
        _hallOfFamers = hallOfFamers;
        _internationalHallOfFameTypeId = internationalHallOfFameTypeId;
    }

    public Entity.InternationalHallOfFame[] HallOfFamers
        => _hallOfFamers;

    public int InternationalHallOfFameTypeId
        => _internationalHallOfFameTypeId;    
}
