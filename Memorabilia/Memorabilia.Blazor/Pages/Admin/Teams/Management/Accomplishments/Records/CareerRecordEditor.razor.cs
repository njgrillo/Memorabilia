namespace Memorabilia.Blazor.Pages.Admin.Teams.Management.Accomplishments.Records;

public partial class CareerRecordEditor
{
    [Parameter]
    public List<CareerRecordEditModel> CareerRecords { get; set; }
        = [];

    [Parameter]
    public EventCallback<CareerRecordEditModel> OnRecordAdded { get; set; }

    [Parameter]
    public EventCallback<CareerRecordEditModel> OnRecordDeleted { get; set; }

    [Parameter]
    public PersonModel[] People { get; set; }
        = [];

    private async Task Add()
    {
        await OnRecordAdded.InvokeAsync(CareerRecords.First());
    }

    private async Task Delete(CareerRecordEditModel careerRecord)
    {
        await OnRecordDeleted.InvokeAsync(careerRecord);
    }
}
