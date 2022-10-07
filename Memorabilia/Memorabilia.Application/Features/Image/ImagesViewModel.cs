namespace Memorabilia.Application.Features.Image;

public class ImagesViewModel : ViewModel
{
    public ImagesViewModel() { }

    public ImagesViewModel(IEnumerable<Domain.Entities.Image> images)
    {
        Images = images.Select(image => new ImageViewModel(image));
    }

    public virtual IEnumerable<ImageViewModel> Images { get; set; } = Enumerable.Empty<ImageViewModel>();

    public override string PageTitle => "Images";
}
