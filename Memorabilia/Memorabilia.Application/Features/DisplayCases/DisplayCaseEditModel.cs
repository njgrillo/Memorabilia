namespace Memorabilia.Application.Features.DisplayCases;

public class DisplayCaseEditModel : EditModel
{
    public DisplayCaseEditModel() { }

    public DisplayCaseEditModel(DisplayCaseModel displayCase)
    {
        Description = displayCase.Description;
        Id = displayCase.Id;
        Memorabilias = displayCase.Memorabilias
                                  .Select(x => new DisplayCaseMemorabiliaEditModel(x))
                                  .ToList();
        Name = displayCase.Name;
        PrivacyTypeId = displayCase.PrivacyType?.Id ?? 0;
        UserId = displayCase.UserId;
    }

    public DisplayCaseEditModel(Entity.DisplayCase displayCase)
    {
        Description = displayCase.Description;
        Id = displayCase.Id;
        Memorabilias = displayCase.Memorabilias
                                  .Select(x => new DisplayCaseMemorabiliaEditModel(x))
                                  .ToList();
        Name = displayCase.Name;
        PrivacyTypeId = displayCase.PrivacyTypeId;
        UserId = displayCase.UserId;
    }

    public string Description { get; set; }

    public List<DisplayCaseMemorabiliaEditModel> Memorabilias { get; set; }
        = [];

    public int PrivacyTypeId { get; set; }

    public int UserId { get; set; }
}
