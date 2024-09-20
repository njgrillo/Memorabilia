namespace Memorabilia.Application.Features.Admin.People.Management.SportServices;

public class SportServiceEditModel : EditModel
{
    public SportServiceEditModel() { }

    public SportServiceEditModel(Entity.SportService sportService)
    {
        DebutDate = sportService.DebutDate;
        Id = sportService.Id;
        FreeAgentSigningDate = sportService.FreeAgentSigningDate;
        LastAppearanceDate = sportService.LastAppearanceDate;        
        PersonId = sportService.PersonId;
    }

    public DateTime? DebutDate { get; set; }

    public DateTime? FreeAgentSigningDate { get; set; }

    public DateTime? LastAppearanceDate { get; set; }

    public int PersonId { get; set; }

    public void Set(DateTime? debutDate, DateTime? freeAgentSigningDate, DateTime? lastAppearanceDate)
    {
        DebutDate = debutDate;
        FreeAgentSigningDate = freeAgentSigningDate;
        LastAppearanceDate = lastAppearanceDate;
    }
}
