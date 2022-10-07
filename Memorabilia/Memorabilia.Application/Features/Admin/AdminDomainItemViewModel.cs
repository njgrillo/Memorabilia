using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin;

public class AdminDomainItemViewModel
{
    public AdminDomainItemViewModel(AdminDomainItem adminDomainItem)
    {
        Description = adminDomainItem.Description;
        ImagePath = adminDomainItem.ImagePath;
        Page = adminDomainItem.Page;
        Title = adminDomainItem.Title;
    }

    public string Description { get; }

    public string ImagePath { get; }

    public string Page { get; }

    public string Title { get; }
}
