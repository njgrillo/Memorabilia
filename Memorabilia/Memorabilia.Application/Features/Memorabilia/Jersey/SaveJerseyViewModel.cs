using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Jersey
{
    public class SaveJerseyViewModel : SaveItemViewModel
    {
        public SaveJerseyViewModel() { }

        public SaveJerseyViewModel(JerseyViewModel viewModel)
        {            
            BrandId = viewModel.Brand.BrandId;
            GameDate = viewModel.Game?.GameDate;
            GamePersonId = viewModel.Game?.PersonId ?? 0;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            JerseyQualityTypeId = viewModel.Jersey.JerseyQualityTypeId;
            JerseyStyleTypeId = viewModel.Jersey.JerseyStyleTypeId;
            JerseyTypeId = viewModel.Jersey.JerseyTypeId;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;
            SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        private int _gameStyleTypeId;

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool CanEditJerseyQualityType { get; private set; } = true;

        public bool DisplayGameDate => DisplayGameStyleType && GameStyleType.IsGameWorthly(GameStyleType);

        public bool DisplayGameStyleType => JerseyQualityTypeId == JerseyQualityType.Authentic.Id;

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public DateTime? GameDate { get; set; }

        public int GamePersonId { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId
        {
            get
            {
                return _gameStyleTypeId;
            }
            set
            {
                _gameStyleTypeId = value;
                CanEditJerseyQualityType = !IsGameWorthly;

                if (IsGameWorthly)
                {
                    JerseyQualityTypeId = JerseyQualityType.Authentic.Id;
                }
            }
        }

        public GameStyleType[] GameStyleTypes => GameStyleType.GetAll(ItemType.Jersey);

        public override string ImagePath => "images/itemtypes.jpg";

        public bool IsGameWorthly => GameStyleType.IsGameWorthly(GameStyleType);

        public override ItemType ItemType => ItemType.Jersey;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quality is required.")]
        public int JerseyQualityTypeId { get; set; }

        public JerseyQualityType[] JerseyQualityTypes => JerseyQualityType.All;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Style is required.")]
        public int JerseyStyleTypeId { get; set; }

        public JerseyStyleType[] JerseyStyleTypes => JerseyStyleType.All;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Type is required.")]
        public int JerseyTypeId { get; set; }

        public JerseyType[] JerseyTypes => JerseyType.All;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public int SportId { get; set; } 

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
