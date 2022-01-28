using System;

namespace Memorabilia.Application.Features.Admin.Franchise
{
    public class FranchiseViewModel
    {
        private readonly Domain.Entities.Franchise _franchise;

        public FranchiseViewModel() { }

        public FranchiseViewModel(Domain.Entities.Franchise franchise)
        {
            _franchise = franchise;
        }

        public int FoundYear => _franchise.FoundYear;

        public string FullName => _franchise.FullName;

        public int Id => _franchise.Id;

        public string ImagePath => _franchise.ImagePath;

        public DateTime? LastModifiedDate => _franchise.LastModifiedDate;

        public string Location => _franchise.Location;

        public string Name => _franchise.Name;

        public int SportId => _franchise.SportId;

        public string SportName => Domain.Constants.Sport.Find(SportId)?.Name;
    }
}
