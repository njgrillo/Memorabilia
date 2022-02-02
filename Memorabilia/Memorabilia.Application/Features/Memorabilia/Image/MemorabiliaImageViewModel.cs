using Memorabilia.Application.Features.Image;

namespace Memorabilia.Application.Features.Memorabilia.Image
{
    public class MemorabiliaImageViewModel : ImageViewModel
    {
        private readonly Domain.Entities.MemorabiliaImage _image;

        public MemorabiliaImageViewModel() { }

        public MemorabiliaImageViewModel(Domain.Entities.MemorabiliaImage image)
        {
            _image = image;
        }

        public int MemorabiliaId => _image.MemorabiliaId;
    }
}
