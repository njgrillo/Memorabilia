using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Helmet
{
    public class SaveHelmetViewModel : SaveViewModel
    {
        public SaveHelmetViewModel() { }

        public SaveHelmetViewModel(HelmetViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            GameDate = viewModel.Game?.GameDate;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            HelmetQualityTypeId = viewModel.Helmet?.HelmetQualityTypeId ?? 0;
            HelmetTypeId = viewModel.Helmet?.HelmetTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;
            SportIds = viewModel.Sports.Select(x => x.Id).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }   

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType);

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public bool HasPerson => People.Any();

        public bool HasTeam => Teams.Any();

        public int HelmetQualityTypeId { get; set; }

        public HelmetType HelmetType => HelmetType.Find(HelmetTypeId);

        public int HelmetTypeId { get; set; }

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayHelmetType && HelmetType != null)
                //{
                //    return $"{path}{HelmetType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}helmet.jpg";
            }
        }

        public ItemType ItemType => ItemType.Helmet;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Helmet.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<int> SportIds { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
