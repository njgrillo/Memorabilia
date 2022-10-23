namespace Memorabilia.Blazor.Controls.DropDowns;

public class AuthenticationCompanyDropDown : DropDown<AuthenticationCompany, int>
{
    protected override void OnInitialized()
    {
        Items = AuthenticationCompany.All;
        Label = "Authentication Company";
    }
}
