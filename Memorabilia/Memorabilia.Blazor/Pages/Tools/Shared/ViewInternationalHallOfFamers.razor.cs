namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewInternationalHallOfFamers 
    : ViewSportTools<InternationalHallOfFameModel>
{
    private InternationalHallOfFamesModel Model 
        = new();

    private async Task OnInputChange(int internationalHallOfFameTypeId)
    {
        Model = new(await Mediator.Send(new GetInternationalHallOfFames(internationalHallOfFameTypeId, Sport)), Sport)
                {
                    InternationalHallOfFameTypeId = internationalHallOfFameTypeId
                };
    }
}
