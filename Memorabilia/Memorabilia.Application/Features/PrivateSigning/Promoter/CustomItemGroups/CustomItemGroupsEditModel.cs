namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

public class CustomItemGroupsEditModel : EditModel
{
    public CustomItemGroupsEditModel() { }

    public CustomItemGroupsEditModel(Entity.PrivateSigningCustomItemGroup[] customItemGroups, int userId)
    {
        CustomItemGroups =
            customItemGroups.Select(group => new CustomItemGroupEditModel(group))
                            .ToList();

        UserId = userId;
    }

    public List<CustomItemGroupEditModel> CustomItemGroups { get; set; }
        = [];

    public int UserId { get; set; }
}
