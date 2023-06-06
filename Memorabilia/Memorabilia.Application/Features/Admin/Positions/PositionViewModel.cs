using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Positions;

public class PositionViewModel
{
    private readonly Position _position;

    public PositionViewModel() { }

    public PositionViewModel(Position Position)
    {
        _position = Position;
    }

    public string Abbreviation => _position.Abbreviation;

    public int Id => _position.Id;

    public string Name => _position.Name;

    public int SportId => _position.SportId;

    public string SportName => Constant.Sport.Find(SportId)?.Name;
}
