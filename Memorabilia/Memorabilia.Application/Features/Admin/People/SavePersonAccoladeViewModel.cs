using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonAccoladeViewModel : SaveViewModel
    {
        public SavePersonAccoladeViewModel() { }

        public SavePersonAccoladeViewModel(int personId, PersonAccoladeViewModel viewModel)
        {
            PersonId = personId;
            Accomplishments = viewModel.Accomplishments.Select(accomplishment => new SavePersonAccomplishmentViewModel(accomplishment)).ToList();
            AllStarYears = viewModel.AllStars.Select(allStar => allStar.Year).ToList();
            Awards = viewModel.Awards.Select(award => new SavePersonAwardViewModel(award)).ToList();
            CareerRecords = viewModel.CareerRecords.Select(careerRecord => new SavePersonCareerRecordViewModel(careerRecord)).ToList();
            Leaders = viewModel.Leaders.Select(leader => new SavePersonLeaderViewModel(leader)).ToList();
            RetiredNumbers = viewModel.RetiredNumbers.Select(retiredNumber => new SavePersonRetiredNumberViewModel(retiredNumber)).ToList();
            SingleSeasonRecords = viewModel.SingleSeasonRecords.Select(singleSeasonRecord => new SavePersonSingleSeasonRecordViewModel(singleSeasonRecord)).ToList();  
        }

        public List<SavePersonAccomplishmentViewModel> Accomplishments { get; set; } = new();

        public List<int> AllStarYears { get; set; } = new();

        public List<SavePersonAwardViewModel> Awards { get; set; } = new();

        public override string BackNavigationPath => $"People/Team/Edit/{PersonId}";

        public List<SavePersonCareerRecordViewModel> CareerRecords { get; set; } = new();

        public override string ContinueNavigationPath => $"People/HallOfFame/Edit/{PersonId}";

        public override EditModeType EditModeType => AllStarYears.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => $"Admin/EditDomainItems";

        public string ImagePath => "images/athletes.jpg";

        public override string ItemTitle => "Accolade";

        public List<SavePersonLeaderViewModel> Leaders { get; set; } = new();

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Accolades";

        public int PersonId { get; set; }

        public PersonStep PersonStep => PersonStep.Accolade;

        public List<SavePersonRetiredNumberViewModel> RetiredNumbers { get; set; } = new();

        public List<SavePersonSingleSeasonRecordViewModel> SingleSeasonRecords { get; set; } = new();
    }
}
