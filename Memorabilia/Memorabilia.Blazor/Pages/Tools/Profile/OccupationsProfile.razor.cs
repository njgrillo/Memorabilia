namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class OccupationsProfile : PersonProfile
{
    protected OccupationsProfileModel Model;

    protected override void OnParametersSet()
    {
        if (Person == null)
            return;

        Model = new OccupationsProfileModel(Person);
    }
}
