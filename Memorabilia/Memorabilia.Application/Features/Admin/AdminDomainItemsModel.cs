namespace Memorabilia.Application.Features.Admin;

public class AdminDomainItemsModel
{
    public AdminDomainItemsModel()
    {
        Items = Constant.AdminDomainItem.All.Select(adminDomainItem => new AdminDomainItemModel(adminDomainItem));
    }

    public IEnumerable<AdminDomainItemModel> Items { get; set; }

    public static string Title 
        => "Domain Items";
}
