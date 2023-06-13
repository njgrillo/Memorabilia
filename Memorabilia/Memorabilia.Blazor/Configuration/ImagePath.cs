namespace Memorabilia.Blazor.Configuration;

public class ImagePath : IImagePath
{
    public string DomainImageRootPath { get; set; }

    public string MemorabiliaImageRootPath { get; set; }

    public string PersonImageRootPath { get; set; }

    public string PewterImageRootPath { get; set; }
}
