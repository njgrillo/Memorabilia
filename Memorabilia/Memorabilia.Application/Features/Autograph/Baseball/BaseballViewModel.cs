namespace Memorabilia.Application.Features.Autograph.Baseball
{
    public class BaseballViewModel
    {
        private readonly Domain.Entities.Autograph _autograph;

        public BaseballViewModel() { }

        public BaseballViewModel(Domain.Entities.Autograph autograph)
        {
            _autograph = autograph;
        }

        public int AutographId => _autograph.Id;

        public int SpotId => _autograph?.Spot?.SpotId ?? 0;
    }
}
