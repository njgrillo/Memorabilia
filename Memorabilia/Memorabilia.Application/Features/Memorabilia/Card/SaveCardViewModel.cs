using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Card;

public class SaveCardViewModel : MemorabiliaItemEditViewModel
{
    public SaveCardViewModel() 
    {
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveCardViewModel(CardViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        Custom = viewModel.Card.Custom;
        LevelTypeId = viewModel.Level.LevelTypeId;
        Licensed = viewModel.Card.Licensed;
        MemorabiliaId = viewModel.MemorabiliaId;
        OrientationId = viewModel.Card.OrientationId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        Year = viewModel.Card.Year;
    }

    public bool Custom { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.TradingCard;

    public override ItemType ItemType => ItemType.TradingCard;

    public bool Licensed { get; set; }

    public int OrientationId { get; set; }

    public int? Year { get; set; }
}
