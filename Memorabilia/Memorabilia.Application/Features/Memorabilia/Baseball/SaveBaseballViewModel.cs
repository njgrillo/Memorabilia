using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class SaveBaseballViewModel : SaveViewModel
    {
        public SaveBaseballViewModel() { }

        public SaveBaseballViewModel(BaseballViewModel viewModel)
        {            
            BaseballTypeAnniversary = viewModel.Baseball?.Anniversary;
            BaseballTypeId = viewModel.Baseball?.BaseballTypeId ?? 0;
            BaseballTypeYear = viewModel.Baseball?.Year;
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

        [StringLength(5, ErrorMessage = "Anniversary is too long.")]
        public string BaseballTypeAnniversary { get; set; }

        public BaseballType BaseballType => BaseballType.Find(BaseballTypeId);

        public int BaseballTypeId { get; set; }        

        public int? BaseballTypeYear { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }  
        
        public int CommissionerId { get; set; }

        public bool DisplayBaseballType => BrandId == Brand.Rawlings.Id &&
                                           LevelTypeId == LevelType.Professional.Id &&
                                           SizeId == Size.Standard.Id;

        public bool DisplayBaseballTypeAnniversary => DisplayBaseballType && BaseballType.CanHaveAnniversary(BaseballType);

        public bool DisplayBaseballTypeYear => DisplayBaseballType && BaseballType.CanHaveYear(BaseballType);

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

                if (DisplayBaseballType && BaseballType != null)
                {
                    return $"{path}{BaseballType.Name.Replace(" ", "")}.jpg";
                }

                return $"{path}baseball.jpg";
            }
        }

        public ItemType ItemType => ItemType.Baseball;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Baseball.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }        

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.MajorLeagueBaseball;

        public List<SaveTeamViewModel> Teams { get; set; }
    }
}
