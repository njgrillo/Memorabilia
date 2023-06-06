using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Bammer;

public class SaveBammerViewModel : MemorabiliaItemEditViewModel
{
    public SaveBammerViewModel() 
    {
        BrandId = Brand.Salvino.Id;
        LevelTypeId = LevelType.Professional.Id;
    }

    public SaveBammerViewModel(BammerViewModel viewModel)
    {
        BammerTypeId = viewModel.Bammer?.BammerTypeId ?? 0;
        BrandId = viewModel.Brand.BrandId;
        InPackage = viewModel.Bammer?.InPackage ?? false;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        Year = viewModel.Bammer?.Year;
    }

    public int BammerTypeId { get; set; }

    public bool CanHaveBammerType => BrandId == Brand.Salvino.Id;

    public override string ImageFileName => Constant.ImageFileName.Bammer;

    public bool InPackage { get; set; }

    public override ItemType ItemType => ItemType.Bammer;

    public int? Year { get; set; }
}
