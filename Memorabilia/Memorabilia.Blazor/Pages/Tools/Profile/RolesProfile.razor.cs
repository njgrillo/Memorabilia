namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class RolesProfile : PersonProfile
{
    [Inject]
    public IProfileService ProfileService { get; set; }

    protected Dictionary<string, object> Parameters { get; set; } = new();
    protected List<ProfileType> ProfileTypes = new();

    protected override async Task OnParametersSetAsync()
    {
        if (Person == null)
            return;

        ProfileTypes = await ProfileService.GetProfileTypes(Person.Id);
        Parameters = new Dictionary<string, object>
        {
            { "Occupation", Occupation },
            { "Person", Person }
        };
    }

    private bool ProfileIsValid(string profileTypeName)
    {
        var occupation = Domain.Constants.Occupation.Find(Occupation.OccupationId);

        if (occupation == Domain.Constants.Occupation.Umpire)
            return profileTypeName == "Baseball";

        return true;
    }

    private Type GetComponent(string profileTypeName)
    {
        return Type.GetType($"Memorabilia.Blazor.Pages.Tools.Profile.{profileTypeName}{Occupation.OccupationName}Profile"); 

        //return profileTypeName switch
        //{
        //    "Baseball" => Type.GetType($"{typeof(BaseballAthleteProfile).FullName}"),
        //    "Basketball" => Type.GetType($"{typeof(BasketballAthleteProfile).FullName}"),
        //    "Football" => Type.GetType($"{typeof(FootballAthleteProfile).FullName}"),
        //    _ => throw new NotImplementedException(),
        //};
    }
}
