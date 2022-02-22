using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class SaveBaseballViewModel : SaveViewModel
    {
        public SaveBaseballViewModel() { }

        public SaveBaseballViewModel(BaseballViewModel viewModel)
        {            
            BaseballTypeAnniversary = viewModel.MemorabiliaBaseball?.Anniversary;
            BaseballTypeId = viewModel.MemorabiliaBaseball?.BaseballTypeId ?? 0;
            BaseballTypeYear = viewModel.MemorabiliaBaseball?.Year;
            BrandId = viewModel.MemorabiliaBrand.BrandId;
            CommissionerId = viewModel.MemorabiliaCommissioner.CommissionerId;
            GameDate = viewModel.MemorabiliaGame?.GameDate;
            GameStyleTypeId = viewModel.MemorabiliaGame?.GameStyleTypeId ?? 0;
            LevelTypeId = viewModel.MemorabiliaLevelType.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            Person = new PersonViewModel(new Domain.Entities.Person());
            SizeId = viewModel.MemorabiliaSize.SizeId;
            TeamId = viewModel.TeamId ?? 0;
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

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => TeamId > 0;

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

        public PersonViewModel Person { get; set; } 

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.MajorLeagueBaseball;

        public int TeamId { get; set; }
    }
}
