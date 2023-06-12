namespace Memorabilia.Application.Features.Autograph;

public class AutographsModel : Model
{
    public AutographsModel() { }

    public AutographsModel(IEnumerable<Entity.Autograph> autographs)
    {
        Autographs = autographs.Select(autograph => new AutographModel(autograph));
    }

    public IEnumerable<AutographModel> Autographs { get; set; } 
        = Enumerable.Empty<AutographModel>();

    public override string PageTitle 
        => "Autographs";
}
