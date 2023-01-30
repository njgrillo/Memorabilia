using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Canvas;

public class SaveCanvasViewModel : MemorabiliaItemEditViewModel
{
    public SaveCanvasViewModel() 
    {
        BrandId = Brand.None.Id;
        SizeId = Size.TwentyByThirty.Id;
    }

    public SaveCanvasViewModel(CanvasViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        Matted = viewModel.Picture.Matted;
        MemorabiliaId = viewModel.MemorabiliaId;
        OrientationId = viewModel.Picture.OrientationId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(sport => sport.SportId).ToList();
        Stretched = viewModel.Picture.Stretched;
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.Canvas;

    public override ItemType ItemType => ItemType.Canvas;

    public bool Matted { get; set; }

    public int OrientationId { get; set; } = Orientation.Portrait.Id;

    public bool Stretched { get; set; }
}
