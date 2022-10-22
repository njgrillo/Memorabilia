namespace Memorabilia.Blazor.Controls.DropDowns;

public class AuthenticationCompanyDropDown : DropDown<AuthenticationCompany, int>
{
    protected override async Task OnInitializedAsync()
    {
        Items = AuthenticationCompany.All;
        Label = "Authentication Company";
    }
}
