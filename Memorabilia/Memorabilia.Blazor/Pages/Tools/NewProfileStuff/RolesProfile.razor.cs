using Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class RolesProfile
{
    [Inject]
    public IProfileService ProfileService { get; set; }

    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Domain.Entities.PersonOccupation Occupation { get; set; }

    protected Dictionary<string, object> Parameters { get; set; } = new();
    protected List<ProfileType> ProfileTypes = new();

    protected override async Task OnParametersSetAsync()
    {
        if (Person == null)
            return;

        ProfileTypes = await ProfileService.GetProfileTypes(Person.Id);
        Parameters = new Dictionary<string, object>
        {
            { "Person", Person }
        };
    }

    private Type GetComponent(string profileTypeName)
    {
        return profileTypeName switch
        {
            "Baseball" => Type.GetType($"{typeof(BaseballProfileNew).FullName}"),
            "Basketball" => Type.GetType($"{typeof(BasketballProfileNew).FullName}"),
            "Football" => Type.GetType($"{typeof(FootballProfileNew).FullName}"),
            _ => throw new NotImplementedException(),
        };
    }
}
