using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Bammer
{
    public class SaveBammerViewModel : SaveViewModel
    {
        public SaveBammerViewModel() { }

        public SaveBammerViewModel(BammerViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        public Brand Brand => Brand.Find(BrandId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => Team?.Id > 0;

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayBammerType && BammerType != null)
                //{
                //    return $"{path}{BammerType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}Bammer.jpg";
            }
        }

        public ItemType ItemType => ItemType.Bammer;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Bammer.Name} Details";

        public SavePersonViewModel Person { get; set; }

        public SaveTeamViewModel Team { get; set; }
    }
}
