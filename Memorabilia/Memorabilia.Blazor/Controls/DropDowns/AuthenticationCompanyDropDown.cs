namespace Memorabilia.Blazor.Controls.DropDowns;

public class AuthenticationCompanyDropDown : DropDown<AuthenticationCompany, int>
{
    [Parameter]
    public bool UsePrivateSigningCompanies { get; set; }

    protected override void OnInitialized()
    {
        Items = UsePrivateSigningCompanies
            ? AuthenticationCompany.PrivateSigning
            : AuthenticationCompany.All;


        Label = "Authentication Company";
    }
}
