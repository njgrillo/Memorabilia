namespace Memorabilia.Blazor;

public class ImageService
{
    public static string GetImageData(string imageRootPath, string imageFileName)
        => imageFileName == ImageFileName.ImageNotAvailable
            ? GetDomainImageData(imageFileName)
            : Path.Combine(Path.Combine(imageRootPath),
                           imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName)
                  .ToImageData();

    public static string GetDomainImageData(string imageFileName)
        => Path.Combine(ImagePath.DomainImageRootPath,
                        imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName)
               .ToImageData();

    public static string GetPersonImageData(string imageFileName)
        => imageFileName == ImageFileName.ImageNotAvailable
            ? GetDomainImageData(imageFileName)
            : Path.Combine(Path.Combine(ImagePath.PersonImageRootPath),
                           imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName)
                  .ToImageData();

    public static string GetPewterImageData(string imageFileName)
        => imageFileName == ImageFileName.ImageNotAvailable
            ? GetDomainImageData(imageFileName)
            : Path.Combine(Path.Combine(ImagePath.PewterImageRootPath),
                           imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName)
                  .ToImageData();

    public static string GetUserImageData(string imageFileName, int userId)
        => imageFileName == ImageFileName.ImageNotAvailable
            ? GetDomainImageData(imageFileName)
            : Path.Combine(Path.Combine(ImagePath.MemorabiliaImageRootPath, userId.ToString()),
                           imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName)
                  .ToImageData();
}
