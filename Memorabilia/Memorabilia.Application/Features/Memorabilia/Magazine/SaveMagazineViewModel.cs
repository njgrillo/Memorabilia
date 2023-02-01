using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Magazine;

public class SaveMagazineViewModel : MemorabiliaItemEditViewModel
{
    public SaveMagazineViewModel()
    { 
        SizeId = Size.Standard.Id;
    }

    public SaveMagazineViewModel(MagazineViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        Date = viewModel.Magazine.Date;
        Framed = viewModel.Magazine.Framed;
        Matted = viewModel.Magazine.Matted;
        MemorabiliaId = viewModel.MemorabiliaId;
        OrientationId = viewModel.Magazine.OrientationId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public DateTime? Date { get; set; }

    public bool Framed { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.Magazine;

    public override ItemType ItemType => ItemType.Magazine;

    public bool Matted { get; set; }

    public int OrientationId { get; set; } = Domain.Constants.Orientation.Portrait.Id;
}
