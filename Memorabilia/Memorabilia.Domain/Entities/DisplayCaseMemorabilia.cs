namespace Memorabilia.Domain.Entities;

public class DisplayCaseMemorabilia : Entity
{
    public DisplayCaseMemorabilia() { }

    public DisplayCaseMemorabilia(int displayCaseId, int memorabiliaId, int xPosition, int yPosition)
    {
        DisplayCaseId = displayCaseId;
        MemorabiliaId = memorabiliaId;
        XPosition = xPosition;
        YPosition = yPosition;
    }

    public int DisplayCaseId { get; private set; }

    public virtual Memorabilia Memorabilia { get; set; }

    public int MemorabiliaId { get; private set; }

    public int XPosition { get; private set; }

    public int YPosition { get; private set; }

    public void Set(int xPosition, int yPosition)
    {
        XPosition = xPosition;
        YPosition = yPosition;
    }
}
