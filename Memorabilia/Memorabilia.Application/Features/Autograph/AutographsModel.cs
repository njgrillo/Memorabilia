namespace Memorabilia.Application.Features.Autograph;

public class AutographsModel : Model
{
    public AutographsModel() { }

    public AutographsModel(List<Entity.Autograph> autographs)
    {
        Autographs = autographs.Select(autograph => new AutographModel(autograph))
                               .ToList();
    }

    public List<AutographModel> Autographs { get; set; } 
        = [];

    public override string PageTitle 
        => "Autographs";
}
