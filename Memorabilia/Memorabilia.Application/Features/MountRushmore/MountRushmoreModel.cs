namespace Memorabilia.Application.Features.MountRushmore;

public class MountRushmoreModel
{
    private readonly Entity.MountRushmore _mountRushmore;

    public MountRushmoreModel() { }

    public MountRushmoreModel(Entity.MountRushmore mountRushmore)
    {
        _mountRushmore = mountRushmore;
    }

    public string Description
        => _mountRushmore.Description;

    public int Id
        => _mountRushmore.Id;

    public string Name 
        => _mountRushmore.Name;

    public List<MountRushmorePersonModel> People
        => _mountRushmore.People.Select(person => new MountRushmorePersonModel(person)).ToList();

    public Constant.PrivacyType PrivacyType
        => Constant.PrivacyType.Find(_mountRushmore.PrivacyTypeId);

    public string PrivacyTypeName
        => PrivacyType?.Name;

    public int UserId
        => _mountRushmore.UserId;
}
