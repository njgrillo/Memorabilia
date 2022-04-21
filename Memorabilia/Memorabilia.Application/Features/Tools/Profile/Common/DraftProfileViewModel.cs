using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class DraftProfileViewModel
    {
        private readonly Draft _draft;

        public DraftProfileViewModel(Draft draft)
        {
            _draft = draft;
        }

        public int FranchiseId => _draft.FranchiseId;

        public string FranchiseName => Domain.Constants.Franchise.Find(FranchiseId)?.Name;

        public int? Overall => _draft.Overall;

        public int? Pick => _draft.Pick;

        public int Round => _draft.Round;

        public int Year => _draft.Year;

        public override string ToString()
        {
            return $"{FranchiseName} - {Year} - Round {Round}, Pick {Pick} - {Overall} Overall";
        }
    }
}
