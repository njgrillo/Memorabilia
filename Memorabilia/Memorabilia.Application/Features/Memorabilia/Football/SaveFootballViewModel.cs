using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Football
{
    public class SaveFootballViewModel : SaveViewModel
    {
        public SaveFootballViewModel() { }

        public SaveFootballViewModel(FootballViewModel viewModel)
        {            
            BrandId = viewModel.Brand.BrandId;
            CommissionerId = viewModel.Commissioner.CommissionerId;
            FootballTypeId = viewModel.Football?.FootballTypeId ?? 0;
            GameDate = viewModel.Game?.GameDate;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            SizeId = viewModel.Size.SizeId;

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public int CommissionerId { get; set; }

        public bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType);

        public FootballType FootballType => FootballType.Find(FootballTypeId);

        public int FootballTypeId { get; set; }

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => Team?.Id > 0;

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayFootballType && FootballType != null)
                //{
                //    return $"{path}{FootballType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}football.jpg";
            }
        }

        public ItemType ItemType => ItemType.Football;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Name} Details";

        public SavePersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public Sport Sport => Sport.Football;

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalFootballLeague;

        public SaveTeamViewModel Team { get; set; }
    }
}
