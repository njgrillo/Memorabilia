﻿using Memorabilia.Application.Services.Filters;

namespace Memorabilia.Blazor.Pages.Project;

public partial class ImportProjectPersonDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int BaseballTypeId { get; set; }

    [Parameter]
    public int? Year { get; set; }

    protected int? BeginYear;
    protected int? EndYear;

    protected BaseballType BaseballType
        => BaseballType.Find(BaseballTypeId);

    protected bool CanImportByYearRange
        => BaseballType?.CanImportByYearRange() ?? false;

    private bool Filter(Entity.Person person)
        => PersonFilterService.Filter(person, _search);

    protected int MaxYear
        => DateTime.UtcNow.Year;

    protected Entity.Person[] People { get; set; } 
        = [];

    private string _search;

    private string SelectAllButtonText
        => People != null && People.Length == SelectedPeople.Count
            ? "Deselect All"
            : "Select All";
    
    private List<Entity.Person> SelectedPeople 
        = []; 

    public void Cancel()
    {
        MudDialog.Cancel();
    } 

    public void Import()
    {
        MudDialog.Close(DialogResult.Ok(SelectedPeople.ToArray()));
    }


    protected void OnSelectAll()
    {
        SelectedPeople = People.Length == SelectedPeople.Count
            ? []
            : People.ToList();
    }

    protected void PersonSelected(Entity.Person person)
    {
        if (!SelectedPeople.Contains(person))
        {
            SelectedPeople.Add(person);
            return;
        }

        SelectedPeople.Remove(person);
    }

    protected async Task Search()
    {
        var parameters = new Dictionary<string, object>();
        var baseballType = BaseballType.Find(BaseballTypeId);

        if (baseballType == BaseballType.GoldWorldSeries || baseballType == BaseballType.WorldSeries)
            parameters.Add("IsWorldSeries", true);

        if (baseballType == BaseballType.AllStar)
        {
            parameters.Add("IsAllStar", true);
            parameters.Add("SportId", Sport.Baseball.Id);
        }            

        if (baseballType == BaseballType.GoldGlove)
            parameters.Add("AwardTypeId", AwardType.GoldGlove.Id);

        parameters.Add("BeginYear", Year ?? BeginYear);

        if (EndYear.HasValue)
            parameters.Add("EndYear", EndYear.Value);

        People = (await Mediator.Send(new GetImportProjectPersons(parameters))).DistinctBy(person => person.Id)
                                                                               .ToArray();
    }
}
