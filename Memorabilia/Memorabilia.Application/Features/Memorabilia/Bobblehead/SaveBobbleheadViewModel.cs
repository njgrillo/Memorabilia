using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Bobblehead
{
    public class SaveBobbleheadViewModel : SaveViewModel
    {
        public SaveBobbleheadViewModel() { }

        public SaveBobbleheadViewModel(BobbleheadViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            SizeId = viewModel.Size.SizeId;

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

                //if (DisplayBobbleheadType && BobbleheadType != null)
                //{
                //    return $"{path}{BobbleheadType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}Bobblehead.jpg";
            }
        }

        public ItemType ItemType => ItemType.Bobble;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Bobble.Name} Details";

        public SavePersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public SaveTeamViewModel Team { get; set; }
    }
}
