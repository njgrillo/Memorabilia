namespace Memorabilia.Application.Features.DisplayCases;

public class DisplayCaseMemorabiliaEditModel : EditModel
{
    public DisplayCaseMemorabiliaEditModel() { }

    public DisplayCaseMemorabiliaEditModel(Entity.DisplayCaseMemorabilia displayCaseMemorabilia)
    {
        DisplayCaseId = displayCaseMemorabilia.DisplayCaseId;
        Identifier = displayCaseMemorabilia.YPosition.ToString();
        Memorabilia = displayCaseMemorabilia.Memorabilia;
        MemorabiliaId = displayCaseMemorabilia.MemorabiliaId;
        XPosition = displayCaseMemorabilia.XPosition;
        YPosition = displayCaseMemorabilia.YPosition;
    }

    public DisplayCaseMemorabiliaEditModel(DisplayCaseMemorabiliaModel displayCaseMemorabilia)
    {
        DisplayCaseId = displayCaseMemorabilia.DisplayCaseId;
        Identifier = displayCaseMemorabilia.YPosition.ToString();
        Memorabilia = displayCaseMemorabilia.Memorabilia;
        MemorabiliaId = displayCaseMemorabilia.MemorabiliaId;
        XPosition = displayCaseMemorabilia.XPosition;
        YPosition = displayCaseMemorabilia.YPosition;
    }

    public DisplayCaseMemorabiliaEditModel(int displayCaseId, int memorabliaId, int xPosition, int yPosition)
    {
        DisplayCaseId = displayCaseId;
        Identifier = yPosition.ToString();
        MemorabiliaId = memorabliaId;
        XPosition = xPosition;
        YPosition = yPosition;
    }    

    public int DisplayCaseId { get; set; }

    public string DisplayName
        => Memorabilia?.Autographs?.Count > 0 
            ? Memorabilia?.Autographs?.Count > 1 
                ? string.Join(", ", Memorabilia.Autographs.Select(x => x.Person.ProfileName))
                : Memorabilia.Autographs.First().Person.ProfileName
            : Memorabilia?.ItemType?.Name; 

    public string Identifier { get; set; }

    public Entity.Memorabilia Memorabilia { get; set; }

    public int MemorabiliaId { get; set; }

    public string PrimaryImageFileName
        => Memorabilia?.Images?.IsNullOrEmpty() ?? true
            ? Constant.ImageFileName.ImageNotAvailable
            : Memorabilia.Images
                         .FirstOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
                         .FileName ?? Memorabilia.Images.First().FileName;

    public bool Removed { get; set; }

    public int XPosition { get; set; }

    public int YPosition { get; set; }
}
