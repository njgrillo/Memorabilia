namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

public class PromoterPrivateSigningsModel : Model
{
    public PromoterPrivateSigningsModel() { }

    public PromoterPrivateSigningsModel(Entity.PrivateSigning[] privateSignings)
    {
        PrivateSignings
            = privateSignings.Select(privateSigning => new PromoterPrivateSigningModel(privateSigning))
                             .ToList();
    }

    public PromoterPrivateSigningsModel(Entity.PrivateSigning[] privateSignings,
                                  PageInfoResult pageInfo)
    {
        PrivateSignings
            = privateSignings.Select(privateSigning => new PromoterPrivateSigningModel(privateSigning))
                             .ToList();

        PageInfo = pageInfo;
    }

    public List<PromoterPrivateSigningModel> PrivateSignings { get; set; }
        = new();
}
