namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonPositionEditor
{
    [Parameter]
    public List<PersonPositionEditModel> Positions { get; set; } 
        = new();

    [Parameter]
    public Sport[] Sports { get; set; } 
        = Array.Empty<Sport>();

    protected PersonPositionEditModel Model 
        = new();

    protected override void OnParametersSet()
    {
        if (Positions.Any())
            Model.PositionType = Enum.PositionType.Secondary;
    }

    private void Add()
    {
        if (Model.Position == null)
            return;

        Positions.Add(Model);

        Model = new PersonPositionEditModel
        {
            PositionType = Enum.PositionType.Secondary
        };
    }

    private void Delete(PersonPositionEditModel position)
    {
        position.IsDeleted = true;

        Model.PositionType = Positions.Any(position => !position.IsDeleted)
            ? Enum.PositionType.Secondary
            : Enum.PositionType.Primary;
    }

    private void OnPositionTypeChange(bool value)
    {
        Model.PositionType = value 
            ? Enum.PositionType.Primary 
            : Enum.PositionType.Secondary;
    }
}
