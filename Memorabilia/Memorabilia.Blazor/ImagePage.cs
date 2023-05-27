namespace Memorabilia.Blazor;

public class ImagePage : CommandQuery
{
    [Parameter]
    public string DomainImageRootPath { get; set; } = ImagePath.DomainImageRootPath;

    [Parameter]
    public string ImageRootPath { get; set; }

    protected string GetDomainImageData(string imageFileName)
    {
        return GetImageData(DomainImageRootPath, imageFileName);
    }

    protected string GetImageData(string imageFileName)
    {
        if (imageFileName == ImageFileName.ImageNotAvailable)
            return GetImageData(DomainImageRootPath, imageFileName);

        return GetImageData(ImageRootPath, imageFileName);
    }

    private static string GetImageData(string imageRootPath, string imageFileName)
    {
        if (imageRootPath.IsNullOrEmpty())
            return string.Empty;

        return Path.Combine(imageRootPath, imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName).ToImageData();
    }
}
