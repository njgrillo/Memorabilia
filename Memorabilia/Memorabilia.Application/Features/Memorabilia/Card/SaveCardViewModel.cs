using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Card
{
    public class SaveCardViewModel : SaveItemViewModel
    {
        public SaveCardViewModel() { }

        public SaveCardViewModel(CardViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            Custom = viewModel.Card.Custom;
            Denominator = viewModel.Card?.Denominator;
            LevelTypeId = viewModel.Level.LevelTypeId;
            Licensed = viewModel.Card.Licensed;
            MemorabiliaId = viewModel.MemorabiliaId;
            Numerator = viewModel.Card.Numerator;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;
            SportIds = viewModel.Sports.Select(x => x.Id).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
            Year = viewModel.Card.Year;
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool Custom { get; set; }

        public int? Denominator { get; set; }

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public bool HasPerson => People.Any();

        public bool HasSport => SportIds.Any();

        public bool HasTeam => Teams.Any();

        public override string ImagePath => "images/tradingcard.jpg";

        public bool IsNumbered => Numerator.HasValue || Denominator.HasValue;

        public override ItemType ItemType => ItemType.TradingCard;

        public string ItemTypeName => ItemType.Name.Replace(" ", "");

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        public bool Licensed { get; set; }

        public int? Numerator { get; set; }

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<int> SportIds { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();

        public int? Year { get; set; }
    }
}
