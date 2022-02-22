using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia.Football
{
    public class SaveFootballViewModel : SaveViewModel
    {
        public SaveFootballViewModel() { }

        public SaveFootballViewModel(FootballViewModel viewModel)
        {            
            BrandId = viewModel.MemorabiliaBrand.BrandId;
            CommissionerId = viewModel.MemorabiliaCommissioner.CommissionerId;
            FootballTypeId = viewModel.MemorabiliaFootball?.FootballTypeId ?? 0;
            GameDate = viewModel.MemorabiliaGame?.GameDate;
            GameStyleTypeId = viewModel.MemorabiliaGame?.GameStyleTypeId ?? 0;
            LevelTypeId = viewModel.MemorabiliaLevelType.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            Person = new PersonViewModel(new Domain.Entities.Person());
            SizeId = viewModel.MemorabiliaSize.SizeId;
            TeamId = viewModel.TeamId ?? 0;
        }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public int CommissionerId { get; set; }

        public FootballType FootballType => FootballType.Find(FootballTypeId);

        public int FootballTypeId { get; set; }

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => TeamId > 0;

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

        public PersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalFootballLeague;

        public int TeamId { get; set; }
    }
}
