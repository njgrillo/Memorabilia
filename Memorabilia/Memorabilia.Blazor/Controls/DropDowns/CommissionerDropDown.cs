namespace Memorabilia.Blazor.Controls.DropDowns;

public class CommissionerDropDown : DropDown<CommissionerModel, int>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items = new CommissionersModel(await Mediator.Send(new GetCommissioners(SportLeagueLevel?.Id)))
                                                     .Commissioners
                                                     .ToArray();
        Label = "Commissioner";
    }

    protected override string GetItemDisplayText(CommissionerModel item)
        => $"{item.Person.DisplayName} ({item.BeginYear} - {(item.EndYear.HasValue ? item.EndYear : "current")})";
}
