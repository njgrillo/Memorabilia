namespace Memorabilia.Application.Features.MountRushmores;

public class MountRushmoresModel : Model
{
    public MountRushmoresModel() { }

    public MountRushmoresModel(IEnumerable<Entity.MountRushmore> mountRushmores, PageInfoResult pageInfo = null)
    {
        MountRushmores = mountRushmores.Select(mountRushmore => new MountRushmoreModel(mountRushmore))
                                       .ToList();

        PageInfo = pageInfo;
    }

    public List<MountRushmoreModel> MountRushmores { get; set; }
        = [];
}
