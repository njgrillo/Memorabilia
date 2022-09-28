namespace Memorabilia.Application.Features.Memorabilia.Image
{
    public class MemorabiliaImagesViewModel : ViewModel
    {
        public MemorabiliaImagesViewModel() { }

        public MemorabiliaImagesViewModel(IEnumerable<Domain.Entities.MemorabiliaImage> images)
        {
            Images = images.Select(image => new MemorabiliaImageViewModel(image));
        }

        public IEnumerable<MemorabiliaImageViewModel> Images { get; set; } = Enumerable.Empty<MemorabiliaImageViewModel>();

        public override string PageTitle => "Memorabilia Images";
    }
}
