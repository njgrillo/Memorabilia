namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailMemorabiliaModel
{
    private readonly Entity.ThroughTheMailMemorabilia _throughTheMailMemorabilia;

    public ThroughTheMailMemorabiliaModel() { }

    public ThroughTheMailMemorabiliaModel(Entity.ThroughTheMailMemorabilia throughTheMailMemorabilia)
    {
        _throughTheMailMemorabilia = throughTheMailMemorabilia;
    }

    public Entity.Autograph Autograph
        => _throughTheMailMemorabilia.Autograph;

    public decimal? Cost
        => _throughTheMailMemorabilia.Cost;

    public bool IsExtraReceived
        => _throughTheMailMemorabilia.IsExtraReceived;

    public Entity.Memorabilia Memorabilia
        => _throughTheMailMemorabilia.Memorabilia;

    public string PrimaryImageFileName
        => Autograph?.Images?
                     .FirstOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
                     .FileName
        ?? Memorabilia?.Images?
                       .FirstOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
                       .FileName;

    public int ThroughTheMailId
        => _throughTheMailMemorabilia.Id;
}
