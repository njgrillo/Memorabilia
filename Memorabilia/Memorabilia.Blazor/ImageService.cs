namespace Memorabilia.Blazor;

public class ImageService
{
    public static string GetDomainImageData(string imageFileName)
    {
        return Path.Combine(ImagePath.DomainImageRootPath,
                            imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName).ToImageData();
    }

    public static string GetPersonImageData(string imageFileName)
    {
        return imageFileName == ImageFileName.ImageNotAvailable
        ? GetDomainImageData(imageFileName)
            : Path.Combine(Path.Combine(ImagePath.PersonImageRootPath),
                           imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName).ToImageData();
    }

    public static string GetUserImageData(string imageFileName, int userId)
    {
        return imageFileName == ImageFileName.ImageNotAvailable
            ? GetDomainImageData(imageFileName)
            : Path.Combine(Path.Combine(ImagePath.MemorabiliaImageRootPath, userId.ToString()),
                           imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName).ToImageData();
    }
}
