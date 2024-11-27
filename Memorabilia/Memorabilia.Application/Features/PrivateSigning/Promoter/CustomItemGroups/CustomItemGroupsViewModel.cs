namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

public class CustomItemGroupsViewModel : Model
{
    public CustomItemGroupsViewModel() { }

    public CustomItemGroupsViewModel(Entity.PrivateSigningCustomItemGroup[] customItemGroups)
    {
        CustomItemGroups
            = customItemGroups.Select(group => new CustomItemGroupViewModel(group))
                              .ToList();
    }

    public List<CustomItemGroupViewModel> CustomItemGroups { get; set; }
        = [];
}
