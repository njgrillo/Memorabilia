namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class SportServiceProfileModel
{
    private readonly Entity.SportService _sportService;

    public SportServiceProfileModel(Entity.SportService sportService)
    {
        _sportService = sportService;
    }

    public DateTime? DebutDate 
        => _sportService?.DebutDate;

    public DateTime? FreeAgentSigningDate 
        => _sportService?.FreeAgentSigningDate;

    public DateTime? LastAppearanceDate 
        => _sportService?.LastAppearanceDate;
}
