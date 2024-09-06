namespace Memorabilia.Application.Features.DisplayCase;

public class DisplayCaseModel
{
    private readonly Entity.DisplayCase _displayCase;

    public DisplayCaseModel() { }

    public DisplayCaseModel(Entity.DisplayCase displayCase)
    {
        _displayCase = displayCase;
    }

    public List<DisplayCaseDimensionModel> Dimensions
        => _displayCase.Dimensions
                       .Select(x => new DisplayCaseDimensionModel(x))
                       .ToList();

    public string Description
        => _displayCase.Description;

    public int Id
        => _displayCase.Id;

    public int ItemCount
        => _displayCase.Memorabilias.Count;

    public List<DisplayCaseMemorabiliaModel> Memorabilias 
        => _displayCase.Memorabilias
                       .Select(x => new DisplayCaseMemorabiliaModel(x))
                       .ToList();

    public string Name
        => _displayCase.Name;

    public Constant.PrivacyType PrivacyType
        => Constant.PrivacyType.Find(_displayCase.PrivacyTypeId);

    public string PrivacyTypeName
        => PrivacyType?.Name;

    public int UserId
        => _displayCase.UserId;
}
