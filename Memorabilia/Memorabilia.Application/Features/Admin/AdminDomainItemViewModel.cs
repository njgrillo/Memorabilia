using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin;

public class AdminDomainItemViewModel
{
    public AdminDomainItemViewModel(AdminDomainItem adminDomainItem)
    {
        Description = adminDomainItem.Description;
        ImageFileName = adminDomainItem.ImageFileName; 
        Page = adminDomainItem.Page;
        Title = adminDomainItem.Title;
    }

    public string Description { get; }

    public string ImageFileName { get; }

    public string Page { get; }

    public string Title { get; }
}
