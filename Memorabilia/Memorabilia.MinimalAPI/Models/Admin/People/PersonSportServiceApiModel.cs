namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonSportServiceApiModel
{
    private readonly Entity.SportService _sportService;

    public PersonSportServiceApiModel()
    {
        _sportService = new Entity.SportService();
    }

    public PersonSportServiceApiModel(Entity.SportService sportService)
    {
        _sportService = sportService;
    }

    public string DebutDate
        => _sportService.DebutDate?.ToShortDateString();

    public string FreeAgentSigningDate
        => _sportService.FreeAgentSigningDate?.ToShortDateString();

    public string LastAppearanceDate
        => _sportService.LastAppearanceDate?.ToShortDateString();
}
