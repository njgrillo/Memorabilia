namespace Memorabilia.Blazor.Pages.Admin.Teams.Management.Accomplishments.FranchiseRecords;

public partial class CareerFranchiseRecordEditor
{
    [Parameter]
    public List<CareerFranchiseRecordEditModel> CareerFranchiseRecords { get; set; }
        = [];

    [Parameter]
    public EventCallback<CareerFranchiseRecordEditModel> OnRecordAdded { get; set; }

    [Parameter]
    public EventCallback<CareerFranchiseRecordEditModel> OnRecordDeleted { get; set; }

    [Parameter]
    public PersonModel[] People { get; set; }
        = [];

    private async Task Add()
    {    
        await OnRecordAdded.InvokeAsync(CareerFranchiseRecords.First());
    }

    private async Task Delete(CareerFranchiseRecordEditModel careerFranchiseRecord)
    {
        await OnRecordDeleted.InvokeAsync(careerFranchiseRecord);
    }
}
