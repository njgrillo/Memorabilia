﻿using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Glove;

public class SaveGloveViewModel : SaveItemViewModel
{
    public SaveGloveViewModel() { }

    public SaveGloveViewModel(GloveViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GamePersonId = viewModel.Game?.PersonId ?? 0;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        GloveTypeId = viewModel.Glove?.GloveTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; }

    public bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType) && DisplayGameStyle;

    public bool DisplayGameStyle => SizeId == Size.Standard.Id;

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public DateTime? GameDate { get; set; }

    public int GamePersonId { get; set; }

    public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Style Type is required.")]
    public int GameStyleTypeId { get; set; } = GameStyleType.None.Id;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Glove Type is required.")]
    public int GloveTypeId { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.Glove;

    public override ItemType ItemType => ItemType.Glove;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;

    public List<SavePersonViewModel> People { get; set; } = new();

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.Standard.Id;

    public int SportId { get; set; }

    public List<SaveTeamViewModel> Teams { get; set; } = new();
}
