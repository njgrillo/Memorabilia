namespace Memorabilia.Application.Features.Autograph.Spot
{
    public class SpotViewModel
    {
        private readonly Domain.Entities.Autograph _autograph;

        public SpotViewModel() { }

        public SpotViewModel(Domain.Entities.Autograph autograph)
        {
            _autograph = autograph;
        }

        public int AutographId => _autograph.Id;

        public int ItemTypeId => _autograph.Memorabilia.ItemTypeId;

        public int SpotId => _autograph?.Spot?.SpotId ?? 0;
    }
}
