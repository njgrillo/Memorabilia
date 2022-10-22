namespace Memorabilia.Blazor.Controls.DropDowns;

public class BallotNumberDropDown : DropDown<BallotNumber, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = BallotNumber.All;
        Label = "Ballot";
    }
}
