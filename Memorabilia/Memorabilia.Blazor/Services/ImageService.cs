namespace Memorabilia.Blazor.Services;

public class ImageService(IApplicationStateService applicationStateService,
                          IImagePath imagePathConfiguration)
{
    private string _userId;

    protected string UserId
    {
        get
        {
            if (!_userId.IsNullOrEmpty())
                return _userId;

            _userId = applicationStateService.CurrentUser.Id.ToString();

            return _userId;
        }
        set
        {
            _userId = value;
        }
    }

    public string GetImageData(Enum.ImageRootType imageRootType, string imageFileName)
     => imageRootType switch
        {
            Enum.ImageRootType.People => GetPersonImageData(imageFileName),
            Enum.ImageRootType.Pewter => GetPewterImageData(imageFileName),
            Enum.ImageRootType.User => GetUserImageData(imageFileName),
            _ => throw new ArgumentException(message: "invalid image root type", paramName: nameof(imageRootType)),
        };

    public string GetDomainImageData(string imageFileName)
        => Path.Combine(imagePathConfiguration.DomainImageRootPath,
                        imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName)
               .ToImageData();

    public string GetPersonImageData(string imageFileName)
        => imageFileName.IsNullOrEmpty() || imageFileName == ImageFileName.ImageNotAvailable
            ? GetDomainImageData(imageFileName)
            : Path.Combine(Path.Combine(imagePathConfiguration.PersonImageRootPath),
                           imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName)
                  .ToImageData();

    public string GetPewterImageData(string imageFileName)
        => imageFileName.IsNullOrEmpty() || imageFileName == ImageFileName.ImageNotAvailable
            ? GetDomainImageData(imageFileName)
            : Path.Combine(Path.Combine(imagePathConfiguration.PewterImageRootPath),
                           imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName)
                  .ToImageData();

    public string GetUserImageData(string imageFileName, int? userId = null)
        => imageFileName.IsNullOrEmpty() || imageFileName == ImageFileName.ImageNotAvailable
            ? GetDomainImageData(imageFileName)
            : Path.Combine(Path.Combine(imagePathConfiguration.MemorabiliaImageRootPath, !userId.HasValue ? UserId : userId.Value.ToString()),
                           imageFileName.IsNullOrEmpty() ? ImageFileName.ImageNotAvailable : imageFileName)
                  .ToImageData();  

    public void DeleteImage(Enum.ImageRootType imageRootType, string imageFileName)
    {
        string imageRootPath = GetImageRootPath(imageRootType);
        string imageFilePath = Path.Combine(imageRootPath, imageFileName);

        if (File.Exists(imageFilePath))
            File.Delete(imageFilePath);
    }

    public async Task<string> LoadFile(IBrowserFile file, Enum.ImageRootType imageRootType)
    {
        string imageRootPath = GetImageRootPath(imageRootType);

        if (!Directory.Exists(imageRootPath))
            Directory.CreateDirectory(imageRootPath);

        string fileName = Path.GetRandomFileName();
        string path = Path.Combine(imageRootPath, fileName);

        await using FileStream fs = new(path, FileMode.Create);
        await file.OpenReadStream(5120000).CopyToAsync(fs);

        return fileName;
    }

    private string GetImageRootPath(Enum.ImageRootType imageRootType)
        => imageRootType switch
            {
                Enum.ImageRootType.People => imagePathConfiguration.PersonImageRootPath,
                Enum.ImageRootType.Pewter => imagePathConfiguration.PewterImageRootPath,
                Enum.ImageRootType.User => Path.Combine(imagePathConfiguration.MemorabiliaImageRootPath, UserId),
                _ => throw new ArgumentException(message: "invalid image root type", paramName: nameof(imageRootType)),
            };
}
