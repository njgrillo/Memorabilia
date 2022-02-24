using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Basketball
{
    public class SaveBasketballViewModel : SaveViewModel
    {
        public SaveBasketballViewModel() { }

        public SaveBasketballViewModel(BasketballViewModel viewModel)
        {
            BasketballTypeId = viewModel.Basketball?.BasketballTypeId ?? 0;
            BrandId = viewModel.Brand.BrandId;
            CommissionerId = viewModel.Commissioner.CommissionerId;
            GameDate = viewModel.Game?.GameDate;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        public BasketballType BasketballType => BasketballType.Find(BasketballTypeId);

        public int BasketballTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public int CommissionerId { get; set; }

        public bool DisplayGameDate => GameStyleType == GameStyleType.GameUsed;

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public bool HasPerson => People.Any();

        public bool HasTeam => Teams.Any();

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayBasketballType && BasketballType != null)
                //{
                //    return $"{path}{BasketballType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}basketball.jpg";
            }
        }

        public ItemType ItemType => ItemType.Basketball;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Basketball.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalBasketballAssociation;

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
