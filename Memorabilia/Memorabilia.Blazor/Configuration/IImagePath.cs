namespace Memorabilia.Blazor.Configuration;

public interface IImagePath
{
    string DomainImageRootPath { get; set; }

    string MemorabiliaImageRootPath { get; set; }

    string PersonImageRootPath { get; set; }

    string PewterImageRootPath { get; set; }
}
