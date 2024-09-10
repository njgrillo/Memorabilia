namespace Memorabilia.Application.Features.DisplayCases;

public class DisplayCaseMemorabiliaModel
{
    private readonly Entity.DisplayCaseMemorabilia _displayCaseMemorabilia;

    public DisplayCaseMemorabiliaModel() { }

    public DisplayCaseMemorabiliaModel(Entity.DisplayCaseMemorabilia displayCaseMemorabilia)
    {
        _displayCaseMemorabilia = displayCaseMemorabilia;
    }    

    public int DisplayCaseId
        => _displayCaseMemorabilia.DisplayCaseId;

    public Entity.Memorabilia Memorabilia
        => _displayCaseMemorabilia.Memorabilia;

    public int MemorabiliaId
        => _displayCaseMemorabilia.MemorabiliaId;

    public int XPosition
        => _displayCaseMemorabilia.XPosition;

    public int YPosition
        => _displayCaseMemorabilia.YPosition;
}
