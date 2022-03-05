using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Tennisball
{
    public class SaveTennisballViewModel : SaveViewModel
    {
        public SaveTennisballViewModel() { }

        public SaveTennisballViewModel(TennisballViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            GameDate = viewModel.Game?.GameDate;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            SizeId = viewModel.Size.SizeId;

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
        }

        public Brand Brand => Brand.Find(BrandId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public bool HasPerson => Person?.Id > 0;

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayTennisballType && TennisballType != null)
                //{
                //    return $"{path}{TennisballType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}Tennisball.jpg";
            }
        }

        public ItemType ItemType => ItemType.Tennisball;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Tennisball.Name} Details";

        public SavePersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        //public Sport Sport => Sport.Tennis;

        //public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.MajorLeagueTennisball;
    }
}
