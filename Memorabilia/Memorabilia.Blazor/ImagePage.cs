#nullable disable

using Memorabilia.Blazor.Pages;

namespace Memorabilia.Blazor;

public class ImagePage : CommandQuery
{
    [Parameter]
    public string DomainImageRootPath { get; set; }

    [Parameter]
    public string ImageRootPath { get; set; }

    [Parameter]
    public bool IsDomainImage { get; set; } = true;

    protected virtual string GetImageData(string imageFileName)
    {
        if ((DomainImageRootPath.IsNullOrEmpty() && IsDomainImage)
            || (ImageRootPath.IsNullOrEmpty() && !IsDomainImage))
            return string.Empty;

        return imageFileName.IsNullOrEmpty() 
            ? Path.Combine(DomainImageRootPath, ImageFileName.ImageNotAvailable).ToImageData()
            : Path.Combine(IsDomainImage ? DomainImageRootPath : ImageRootPath, imageFileName).ToImageData();
    }
}
