using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Hat;

public class SaveHatViewModel : MemorabiliaItemEditViewModel
{
    public SaveHatViewModel()
    { 
        BrandId = Brand.NewEra.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Other.Id;
    }

    public SaveHatViewModel(HatViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false);

    public override string ImageFileName 
        => Domain.Constants.ImageFileName.Hat;

    public override ItemType ItemType 
        => ItemType.Hat;
}
