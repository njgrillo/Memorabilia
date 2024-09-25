namespace Memorabilia.Blazor.Pages.Admin.People.Management.Accomplishments.Records;

public partial class SingleSeasonRecordEditor
{
    [Parameter]
    public EventCallback<SingleSeasonRecordEditModel> OnRecordAdded { get; set; }

    [Parameter]
    public EventCallback<SingleSeasonRecordEditModel> OnRecordDeleted { get; set; }

    [Parameter]
    public PersonModel[] People { get; set; }
        = [];

    [Parameter]
    public List<SingleSeasonRecordEditModel> SingleSeasonRecords { get; set; }
        = [];

    private async Task Add()
    {
        await OnRecordAdded.InvokeAsync(SingleSeasonRecords.First());
    }

    private async Task Delete(SingleSeasonRecordEditModel SingleSeasonRecord)
    {
        await OnRecordDeleted.InvokeAsync(SingleSeasonRecord);
    }
}
