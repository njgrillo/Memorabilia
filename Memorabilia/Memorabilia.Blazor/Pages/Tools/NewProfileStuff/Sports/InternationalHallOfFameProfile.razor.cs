using Memorabilia.Domain.Entities;

namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class InternationalHallOfFameProfile : SportProfile
{
    private InternationalHallOfFame[] InternationalHallOfFames;

    protected override void OnParametersSet()
    {
        InternationalHallOfFames = Person.InternationalHallOfFames
                                         .OrderBy(hof => hof.InternationalHallOfFameType.Name)
                                         .ToArray();
    }
}
