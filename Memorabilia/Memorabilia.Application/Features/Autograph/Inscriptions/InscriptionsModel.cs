namespace Memorabilia.Application.Features.Autograph.Inscriptions;

public class InscriptionsModel : Model
{
    public InscriptionsModel() { }

    public InscriptionsModel(IEnumerable<Entity.Inscription> inscriptions)
    {
        Inscriptions = inscriptions.Select(inscription => new InscriptionModel(inscription)).ToList();
    }

    public int AutographId { get; set; }

    public string ImageFileName { get; set; }

    public List<InscriptionModel> Inscriptions { get; set; } = new();

    public override string PageTitle => "Inscriptions";
}
