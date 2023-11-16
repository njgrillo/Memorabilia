namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class SportServiceProfileModel(Entity.SportService sportService)
{
    public DateTime? DebutDate 
        => sportService?.DebutDate;

    public DateTime? FreeAgentSigningDate 
        => sportService?.FreeAgentSigningDate;

    public DateTime? LastAppearanceDate 
        => sportService?.LastAppearanceDate;
}
