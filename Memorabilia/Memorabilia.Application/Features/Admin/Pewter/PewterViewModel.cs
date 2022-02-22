namespace Memorabilia.Application.Features.Admin.Pewter
{
    public class PewterViewModel
    {
        private readonly Domain.Entities.Pewter _pewter;

        public PewterViewModel() { }

        public PewterViewModel(Domain.Entities.Pewter pewter)
        {
            _pewter = pewter;
        }

        public int FranchiseId => _pewter.FranchiseId;

        public string FranchiseName => _pewter.FranchiseName;

        public int Id => _pewter.Id;

        public string ImagePath => _pewter.ImagePath;

        public int? ImageTypeId => _pewter.ImageTypeId;

        public string ImageTypeName => _pewter.ImageTypeName;

        public int SizeId => _pewter.SizeId;

        public string SizeName => _pewter.SizeName;

        public int TeamId => _pewter.TeamId;

        public string TeamName => _pewter.Team?.Name;
    }
}
