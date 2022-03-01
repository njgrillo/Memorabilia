using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Bat
{
    public class SaveBatViewModel : SaveViewModel
    {
        public SaveBatViewModel() { }

        public SaveBatViewModel(BatViewModel viewModel)
        {
            BatTypeId = viewModel.Bat?.BatTypeId ?? 0;
            BrandId = viewModel.Brand.BrandId;
            ColorId = viewModel.Bat?.ColorId ?? 0;
            GameDate = viewModel.Game?.GameDate;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            Length = viewModel.Bat?.Length ?? 0;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        public BatType BatType => BatType.Find(BatTypeId);

        public int BatTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public int ColorId { get; set; }

        public bool DisplayGameDate => GameStyleType == GameStyleType.GameUsed;

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public bool HasPerson => People.Any();

        public bool HasTeam => Team?.Id > 0;

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayBatType && BatType != null)
                //{
                //    return $"{path}{BatType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}bat.jpg";
            }
        }

        public ItemType ItemType => ItemType.Bat;

        public int? Length { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Bat.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.MajorLeagueBaseball;

        public SaveTeamViewModel Team { get; set; }
    }
}
