using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Helmet
{
    public class SaveHelmetViewModel : SaveItemViewModel
    {
        public SaveHelmetViewModel() { }

        public SaveHelmetViewModel(HelmetViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            GameDate = viewModel.Game?.GameDate;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            HelmetFinishId = viewModel.Helmet.HelmetFinishId ?? 0;
            HelmetQualityTypeId = viewModel.Helmet.HelmetQualityTypeId ?? 0;
            HelmetTypeId = viewModel.Helmet.HelmetTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;
            SportIds = viewModel.Sports.Select(x => x.Id).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
            Throwback = viewModel.Helmet.Throwback;
        }

        private int _gameStyleTypeId;

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool CanEditHelmetQualityType { get; private set; } = true;

        public bool DisplayGameDate => IsGameWorthly;

        public bool DisplayHelmetFinish => !IsGameWorthly;

        public bool DisplayHelmetQualityType => Size.Find(SizeId) == Size.Full;

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public DateTime? GameDate { get; set; }

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

                HelmetTypes = HelmetType.GetAll(GameStyleType.Find(value));

                CanEditHelmetQualityType = !IsGameWorthly;

                if (IsGameWorthly)
                {
                    HelmetQualityTypeId = HelmetQualityType.Authentic.Id;                    
                }                    
            }
        }

        public GameStyleType[] GameStyleTypes => GameStyleType.GetAll(ItemType.Helmet);

        public bool HasPerson => People.Any();

        public bool HasTeam => Teams.Any();

        public HelmetFinish[] HelmetFinishes => HelmetFinish.All;

        public int HelmetFinishId { get; set; }

        public int HelmetQualityTypeId { get; set; }

        public HelmetQualityType[] HelmetQualityTypes => HelmetQualityType.All;

        public HelmetType HelmetType => HelmetType.Find(HelmetTypeId);

        public int HelmetTypeId { get; set; }

        public HelmetType[] HelmetTypes { get; set; } = HelmetType.All;

        public override string ImagePath => "images/helmet.jpg";

        public bool IsGameWorthly => GameStyleType.IsGameWorthly(GameStyleType);

        public override ItemType ItemType => ItemType.Helmet;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<int> SportIds { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();

        public bool Throwback { get; set; }
    }
}
