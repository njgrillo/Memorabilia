using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class RetiredNumberProfileViewModel
    {
        private readonly RetiredNumber _retiredNumber;

        public RetiredNumberProfileViewModel(RetiredNumber retiredNumber)
        {
            _retiredNumber = retiredNumber;
        }

        public Domain.Constants.Franchise Franchise => Domain.Constants.Franchise.Find(FranchiseId);

        public int FranchiseId => _retiredNumber.FranchiseId;

        public string FranchiseName => Franchise?.Name;

        public int Number => _retiredNumber.PlayerNumber;
    }
}
