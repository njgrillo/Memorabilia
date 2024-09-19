namespace Memorabilia.Blazor.Pages.Admin.Management.Accomplishments.Records;

public partial class SingleSeasonFranchiseRecordEditor
{  
    [Parameter]
    public EventCallback<SingleSeasonFranchiseRecordEditModel> OnRecordAdded { get; set; }

    [Parameter]
    public EventCallback<SingleSeasonFranchiseRecordEditModel> OnRecordDeleted { get; set; }

    [Parameter]
    public PersonModel[] People { get; set; }
        = [];

    [Parameter]
    public List<SingleSeasonFranchiseRecordEditModel> SingleSeasonFranchiseRecords { get; set; }
        = [];

    private async Task Add()
    {
        await OnRecordAdded.InvokeAsync(SingleSeasonFranchiseRecords.First());
    }

    private async Task Delete(SingleSeasonFranchiseRecordEditModel SingleSeasonFranchiseRecord)
    {
        await OnRecordDeleted.InvokeAsync(SingleSeasonFranchiseRecord);
    }
}
