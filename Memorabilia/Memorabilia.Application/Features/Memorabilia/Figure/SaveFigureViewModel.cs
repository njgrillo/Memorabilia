using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Figure;

public class SaveFigureViewModel : MemorabiliaItemEditViewModel
{
    public SaveFigureViewModel() 
    { 
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveFigureViewModel(FigureViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        FigureSpecialtyTypeId = viewModel.Figure?.FigureSpecialtyTypeId ?? 0;
        FigureTypeId = viewModel.Figure?.FigureTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        Year = viewModel.Figure?.Year;
    }

    public int FigureSpecialtyTypeId { get; set; }

    public FigureType FigureType => FigureType.Find(FigureTypeId);

    public int FigureTypeId { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.Figure;

    public override ItemType ItemType => ItemType.Figure;

    public int? Year { get; set; }
}
