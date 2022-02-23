using Memorabilia.Application.Features.Admin.Person;
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
            BrandId = viewModel.MemorabiliaBrand.BrandId;
            GameDate = viewModel.MemorabiliaGame?.GameDate;
            GameStyleTypeId = viewModel.MemorabiliaGame?.GameStyleTypeId ?? 0;
            HelmetQualityTypeId = viewModel.MemorabiliaHelmet?.HelmetQualityTypeId ?? 0;
            HelmetTypeId = viewModel.MemorabiliaHelmet?.HelmetTypeId ?? 0;
            LevelTypeId = viewModel.MemorabiliaLevelType.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            Person = new PersonViewModel(new Domain.Entities.Person());
            SizeId = viewModel.MemorabiliaSize.SizeId;
            SportIds = viewModel.MemorabiliaSports.Select(sport => sport.SportId).ToList();
            TeamIds = viewModel.MemorabiliaTeams.Select(team => team.TeamId).ToList();
        }   

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => TeamIds.Any();

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

        public PersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<int> SportIds { get; set; } = new();

        public List<int> TeamIds { get; set; } = new();
    }
}
