namespace Memorabilia.Blazor.Controls.DropDowns;

public class BallotNumberDropDown : DropDown<BallotNumber, int>
{
    protected override void OnInitialized()
    {
        Items = BallotNumber.All;
        Label = "Ballot";
    }
}
