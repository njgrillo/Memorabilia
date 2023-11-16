namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigningAuthentication
{
    [Parameter]
    public List<PrivateSigningAuthenticationCompanyEditModel> AuthenticationCompanies { get; set; }
        = [];

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningAuthenticationCompanyEditModel EditModel { get; set; }
        = new();

    private void Add()
    {
        if (EditModel.AuthenticationCompanyId == 0)
            return;

        AuthenticationCompanies.Add(EditModel);

        EditModel = new();
    }

    private void Edit(PrivateSigningAuthenticationCompanyEditModel editModel)
    {
        EditModel.AuthenticationCompanyId = editModel.AuthenticationCompanyId;
        EditModel.Cost = editModel.Cost;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PrivateSigningAuthenticationCompanyEditModel editModel
            = AuthenticationCompanies.Single(company => company.AuthenticationCompanyId == EditModel.AuthenticationCompanyId);

        editModel.Cost = EditModel.Cost;

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}
