namespace Memorabilia.Application.Features.Admin.Positions;

public class PositionModel
{
    private readonly Entity.Position _position;

    public PositionModel() { }

    public PositionModel(Entity.Position Position)
    {
        _position = Position;
    }

    public string Abbreviation 
        => _position.Abbreviation;

    public int Id 
        => _position.Id;

    public string Name 
        => _position.Name;

    public int SportId 
        => _position.SportId;

    public string SportName 
        => Constant.Sport.Find(SportId)?.Name;
}
