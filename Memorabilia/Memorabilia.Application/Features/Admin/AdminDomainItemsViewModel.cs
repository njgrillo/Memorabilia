using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin;

public class AdminDomainItemsViewModel
{
    public AdminDomainItemsViewModel()
    {
        Items = AdminDomainItem.All.Select(adminDomainItem => new AdminDomainItemViewModel(adminDomainItem));
    }

    public IEnumerable<AdminDomainItemViewModel> Items { get; set; }

    public string Title => "Domain Items";
}
