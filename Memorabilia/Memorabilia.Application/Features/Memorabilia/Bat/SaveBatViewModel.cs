using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia.Bat
{
    public class SaveBatViewModel : SaveViewModel
    {
        public SaveBatViewModel() { }

        public SaveBatViewModel(BatViewModel viewModel)
        {
            BatTypeId = viewModel.MemorabiliaBat?.BatTypeId ?? 0;
            BrandId = viewModel.MemorabiliaBrand.BrandId;
            ColorId = viewModel.MemorabiliaBat?.ColorId ?? 0;
            GameDate = viewModel.MemorabiliaGame?.GameDate;
            GameStyleTypeId = viewModel.MemorabiliaGame?.GameStyleTypeId ?? 0;
            Length = viewModel.MemorabiliaBat?.Length ?? 0;
            MemorabiliaId = viewModel.MemorabiliaId;
            Person = new PersonViewModel(new Domain.Entities.Person());
            SizeId = viewModel.MemorabiliaSize.SizeId;
            TeamId = viewModel.TeamId ?? 0;
        }

        public BatType BatType => BatType.Find(BatTypeId);

        public int BatTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public int ColorId { get; set; }

        //public bool DisplayBatType => BrandId == Brand.Rawlings.Id &&
        //                                   LevelTypeId == LevelType.Professional.Id &&
        //                                   SizeId == Size.Standard.Id;

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

        public PersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.MajorLeagueBaseball;

        public int TeamId { get; set; }
    }
}
