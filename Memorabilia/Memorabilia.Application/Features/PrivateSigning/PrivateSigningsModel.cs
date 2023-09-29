namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningsModel : Model
{
    public PrivateSigningsModel() { }

    public PrivateSigningsModel(Entity.PrivateSigning[] privateSignings)
    {
        PrivateSignings
            = privateSignings.Select(privateSigning => new PrivateSigningModel(privateSigning))
                             .ToList();
    }

    public PrivateSigningsModel(Entity.PrivateSigning[] privateSignings,
                                PageInfoResult pageInfo)
    {
        PrivateSignings
            = privateSignings.Select(privateSigning => new PrivateSigningModel(privateSigning))
                             .ToList();

        PageInfo = pageInfo;
    }

    public List<PrivateSigningModel> PrivateSignings { get; set; }
        = new();
}
