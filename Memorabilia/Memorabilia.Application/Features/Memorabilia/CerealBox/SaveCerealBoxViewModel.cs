using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.CerealBox;

public class SaveCerealBoxViewModel : MemorabiliaItemEditViewModel
{
    public SaveCerealBoxViewModel() 
    {
        BrandId = Brand.GeneralMills.Id;
        LevelTypeId = LevelType.Professional.Id;
    }

    public SaveCerealBoxViewModel(CerealBoxViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        CerealTypeId = viewModel.Cereal?.CerealTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public int CerealTypeId { get; set; }

    public override string ImageFileName => Constant.ImageFileName.CerealBox;

    public override ItemType ItemType => ItemType.CerealBox;
}
