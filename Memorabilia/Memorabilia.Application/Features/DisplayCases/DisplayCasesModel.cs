namespace Memorabilia.Application.Features.DisplayCases;

public class DisplayCasesModel : Model
{
    public DisplayCasesModel() { }

    public DisplayCasesModel(IEnumerable<Entity.DisplayCase> displayCases, PageInfoResult pageInfo = null)
    {
        DisplayCases = displayCases.Select(displayCase => new DisplayCaseModel(displayCase))
                                   .ToList();

        PageInfo = pageInfo;
    }

    public List<DisplayCaseModel> DisplayCases { get; set; }
        = [];
}
