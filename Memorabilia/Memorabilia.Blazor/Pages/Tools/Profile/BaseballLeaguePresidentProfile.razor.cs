namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class BaseballLeaguePresidentProfile
{
    private string _expandToggleText
        = "Expand All";

    private bool _isExpanded;

    private void ToggleExpand()
    {
        _isExpanded = !_isExpanded;

        _expandToggleText =
            _isExpanded
                ? "Collapse All"
                : "Expand All";
    }
}
