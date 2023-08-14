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

    public Entity.Memorabilia Memorabilia
        => _throughTheMailMemorabilia.Memorabilia;

    public int ThroughTheMailId
        => _throughTheMailMemorabilia.Id;
}
