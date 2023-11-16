﻿namespace Memorabilia.Blazor.Pages.Admin.Management.Accomplishments;

public partial class EditAccomplishmentManagement
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public AccomplishmentManagementValidator Validator { get; set; }

    [Parameter]
    public int AccomplishmentTypeId { get; set; }

    protected AccomplishmentManagementEditModel EditModel { get; set; }
        = new();

    protected ValidationResult ValidationResult { get; set; }

    protected Alert[] ValidationResultAlerts
        => ValidationResult != null
            ? ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : [];

    private bool _loaded;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ValidationResult != null && !ValidationResult.IsValid)
        {
            await JSRuntime.ScrollToAlert();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await Load();
    }

    protected async Task OnSave()
    {
        var command = new SaveAccomplishmentManagement.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Accomplishment Detail was saved successfully!", Severity.Success);

        await Load();
    }

    private async Task Load()
    {
        if (AccomplishmentTypeId == 0)
            return;

        Entity.AccomplishmentDetail accomplishmentDetail = await Mediator.Send(new GetAccomplishmentManagement(AccomplishmentTypeId));

        if (accomplishmentDetail == null)
        {
            EditModel.AccomplishmentType = AccomplishmentType.Find(AccomplishmentTypeId);
            _loaded = true;
            return;
        }

        EditModel = accomplishmentDetail.ToEditModel();

        _loaded = true;
    }
}
