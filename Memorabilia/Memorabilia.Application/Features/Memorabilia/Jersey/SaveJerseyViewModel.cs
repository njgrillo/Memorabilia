using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
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
            BrandId = viewModel.MemorabiliaBrand.BrandId;
            GameDate = viewModel.MemorabiliaGame?.GameDate;
            GamePersonId = viewModel.MemorabiliaGame?.PersonId ?? 0;
            GameStyleTypeId = viewModel.MemorabiliaGame?.GameStyleTypeId ?? 0;
            JerseyQualityTypeId = viewModel.MemorabiliaJersey.JerseyQualityTypeId;
            JerseyStyleTypeId = viewModel.MemorabiliaJersey.JerseyStyleTypeId;
            JerseyTypeId = viewModel.MemorabiliaJersey.JerseyTypeId;
            LevelTypeId = viewModel.MemorabiliaLevelType.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.MemorabiliaSize.SizeId;
            SportIds = viewModel.Sports.Select(x => x.Id).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }   

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }       

        public bool DisplayGameDate => DisplayGameStyleType && 
                                       (GameStyleTypeId == GameStyleType.GameUsed.Id || GameStyleTypeId == GameStyleType.GameIssued.Id);

        public bool DisplayGameStyleType => JerseyQualityTypeId == JerseyQualityType.Authentic.Id;

        public DateTime? GameDate { get; set; }

        public int GamePersonId { get; set; }

        public int GameStyleTypeId { get; set; }

        public bool HasPerson => People.Any();

        public bool HasSport => SportIds.Any();

        public bool HasTeam => Teams.Any();

        public ItemType ItemType => ItemType.Jersey;

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

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<int> SportIds { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
