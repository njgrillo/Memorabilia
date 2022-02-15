using Memorabilia.Application.Features.Image;

namespace Memorabilia.Application.Features.Autograph.Image
{
    public class AutographImageViewModel : ImageViewModel
    {
        private readonly Domain.Entities.AutographImage _image;

        public AutographImageViewModel() { }

        public AutographImageViewModel(Domain.Entities.AutographImage image)
        {
            _image = image;
        }

        public int AutographId => _image.AutographId;
    }
}
