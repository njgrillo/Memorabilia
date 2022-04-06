using Memorabilia.Domain.Entities;
using System;

namespace Memorabilia.Application.Features.Admin.Franchises
{
    public class FranchiseViewModel
    {
        private readonly Franchise _franchise;

        public FranchiseViewModel() { }

        public FranchiseViewModel(Franchise franchise)
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

        public int SportLeagueLevelId => _franchise.SportLeagueLevelId;

        public string SportLeagueLevelName => _franchise.SportLeagueLevelName;
    }
}
