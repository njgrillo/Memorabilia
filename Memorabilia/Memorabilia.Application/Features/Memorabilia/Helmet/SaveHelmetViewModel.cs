using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Helmet;

public class SaveHelmetViewModel : MemorabiliaItemEditViewModel
{
    public SaveHelmetViewModel()
    { 
        BrandId = Brand.Riddell.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Mini.Id;
    }

    public SaveHelmetViewModel(HelmetViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        HelmetFinishId = viewModel.Helmet.HelmetFinishId ?? 0;
        HelmetQualityTypeId = viewModel.Helmet.HelmetQualityTypeId ?? 0;
        HelmetTypeId = viewModel.Helmet.HelmetTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        Throwback = viewModel.Helmet.Throwback;
    }

    public bool CanEditHelmetQualityType { get; private set; } = true;

    public override bool DisplayGameDate 
        => IsGameWorthly && DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Size.Full.Id;

    public bool DisplayHelmetFinish 
        => !IsGameWorthly;

    public bool DisplayHelmetQualityType 
        => Size.Find(SizeId) == Size.Full;

    public int HelmetFinishId { get; set; }

    public int HelmetQualityTypeId { get; set; }

    public int HelmetTypeId { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.Helmet;

    public bool IsGameWorthly 
        => (GameStyleType?.IsGameWorthly() ?? false);

    public override ItemType ItemType 
        => ItemType.Helmet;

    public bool Throwback { get; set; }
}
