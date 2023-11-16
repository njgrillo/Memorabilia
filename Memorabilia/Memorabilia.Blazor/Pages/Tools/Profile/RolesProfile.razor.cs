using Memorabilia.Application.Services.Tools.Profile;

namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class RolesProfile : PersonProfile
{
    [Inject]
    public IProfileService ProfileService { get; set; }

    protected Dictionary<string, object> Parameters { get; set; } 
        = [];

    protected ProfileType[] ProfileTypes 
        = [];

    protected override void OnParametersSet()
    {
        if (Person == null)
            return;

        ProfileTypes = ProfileService.GetProfileTypes(Person, Occupation);

        Parameters = new Dictionary<string, object>
        {
            { "Occupation", Occupation },
            { "Person", Person }
        };
    }

    private Type GetComponent(string profileTypeName)
        => Type.GetType($"Memorabilia.Blazor.Pages.Tools.Profile.{profileTypeName}{Occupation.OccupationName}Profile");
}
