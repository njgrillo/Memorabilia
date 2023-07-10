namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonPositionApiModel
{
    private readonly Entity.PersonPosition _personPosition;

    public PersonPositionApiModel(Entity.PersonPosition personPosition)
    {
        _personPosition = personPosition;
    }

    public string Position
        => Constant.Position.Find(_personPosition.PositionId).Name;

    public string PositionType
        => _personPosition.IsPrimary
        ? "Primary"
        : "Secondary";
}
