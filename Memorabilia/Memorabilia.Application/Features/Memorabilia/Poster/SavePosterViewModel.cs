using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Poster;

public class SavePosterViewModel : MemorabiliaItemEditViewModel
{
    public SavePosterViewModel() 
    { 
        BrandId = Brand.None.Id;
        SizeId = Size.TwentyByThirty.Id;
    }

    public SavePosterViewModel(PosterViewModel viewModel)
    {
        Matted = viewModel.Picture.Matted;
        MemorabiliaId = viewModel.MemorabiliaId;
        OrientationId = viewModel.Picture.OrientationId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(sport => sport.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.Poster;

    public override ItemType ItemType => ItemType.Poster;

    public bool Matted { get; set; }

    public int OrientationId { get; set; } = Orientation.Portrait.Id;    
}
