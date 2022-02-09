using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Jersey
{
    public class SaveJerseyViewModel : SaveViewModel
    {
        public SaveJerseyViewModel() { }

        public SaveJerseyViewModel(JerseyViewModel viewModel)
        {
            AuthenticTypeId = viewModel.MemorabiliaGame?.AuthenticTypeId ?? 0;
            BrandId = viewModel.MemorabiliaBrand.BrandId;
            GameDate = viewModel.MemorabiliaGame?.GameDate;
            GamePersonId = viewModel.MemorabiliaGame?.PersonId ?? 0;
            JerseyQualityTypeId = viewModel.MemorabiliaJersey.JerseyQualityTypeId;
            JerseyStyleTypeId = viewModel.MemorabiliaJersey.JerseyStyleTypeId;
            JerseyTypeId = viewModel.MemorabiliaJersey.JerseyTypeId;
            LevelTypeId = viewModel.MemorabiliaLevelType.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            PersonIds = viewModel.People.Select(x => x.Id);
            SizeId = viewModel.MemorabiliaSize.SizeId;
            SportIds = viewModel.Sports.Select(x => x.Id);
            TeamIds = viewModel.Teams.Select(x => x.Id);    
        }        

        public int AuthenticTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool DisplayAuthenticType => JerseyQualityTypeId == JerseyQualityType.Authentic.Id;

        public bool DisplayGameDate => DisplayAuthenticType && 
                                       (AuthenticTypeId == AuthenticType.GameUsed.Id || AuthenticTypeId == AuthenticType.GameIssued.Id);

        public DateTime? GameDate { get; set; }

        public int GamePersonId { get; set; }

        public bool HasPerson => PersonIds.Any();

        public bool HasSport => SportIds.Any();

        public bool HasTeam => TeamIds.Any();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quality is required.")]
        public int JerseyQualityTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Style is required.")]
        public int JerseyStyleTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Type is required.")]
        public int JerseyTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {Domain.Constants.ItemType.Jersey.Name} Details";

        public IEnumerable<int> PersonIds { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public IEnumerable<int> SportIds { get; set; }

        public IEnumerable<int> TeamIds { get; set; }
    }
}
