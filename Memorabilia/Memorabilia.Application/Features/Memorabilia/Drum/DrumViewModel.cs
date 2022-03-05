namespace Memorabilia.Application.Features.Memorabilia.Drum
{
    public class DrumViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public DrumViewModel() { }

        public DrumViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public int MemorabiliaId => _memorabilia.Id;
    }
}
