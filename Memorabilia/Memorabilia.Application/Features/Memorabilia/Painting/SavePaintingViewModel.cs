using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Painting;

public class SavePaintingViewModel : MemorabiliaItemEditViewModel
{
    public SavePaintingViewModel()
    {
        BrandId = Brand.None.Id;
        SizeId = Size.EightByTen.Id;
    }

    public SavePaintingViewModel(PaintingViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        Matted = viewModel.Picture.Matted;
        MemorabiliaId = viewModel.MemorabiliaId;
        OrientationId = viewModel.Picture.OrientationId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(sport => sport.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.Painting;

    public override ItemType ItemType => ItemType.Painting;

    public bool Matted { get; set; }

    public int OrientationId { get; set; } = Orientation.Portrait.Id;
}
