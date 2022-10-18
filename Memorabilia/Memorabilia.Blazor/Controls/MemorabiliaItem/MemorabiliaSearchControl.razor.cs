#nullable disable

namespace Memorabilia.Blazor.Controls.MemorabiliaItem;

public partial class MemorabiliaSearchControl : ComponentBase
{
    [Inject]
    public IAutographFilterPredicateBuilder AutographFilterPredicateBuilder { get; set; }

    [Inject]
    public IMemorabiliaFilterPredicateBuilder MemorabiliaFilterPredicateBuilder { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }    

    [Parameter]
    public List<MemorabiliaItemViewModel> Items { get; set; }

    [Parameter]
    public List<MemorabiliaItemViewModel> Results { get; set; }

    [Parameter]
    public EventCallback<IEnumerable<int>> ResultsChanged { get; set; }

    private List<AutographViewModel> _autographs => Items.SelectMany(item => item.Autographs).ToList();

    private bool _hasFilter => _autographAcquiredDate.HasValue ||
                               _autographAcquisitionTypeId > 0 ||
                               _autographConditionId > 0 ||
                               _autographCost.HasValue ||
                               _autographEstimatedValue.HasValue ||
                               _autographGrade.HasValue ||
                               _autographPerson?.Id > 0 ||
                               _brandId > 0 ||
                               _colorId > 0 ||
                               _franchiseId > 0 ||
                               _gameStyleTypeId > 0 ||
                               _hasAutographAuthentication ||                               
                               _hasAutographInscription ||
                               _itemTypeId > 0 ||
                               _levelTypeId > 0 ||
                               _memorabiliaAcquiredDate.HasValue ||
                               _memorabiliaAcquisitionTypeId > 0 ||
                               _memorabiliaConditionId > 0 ||
                               _memorabiliaCost.HasValue ||
                               _memorabiliaEstimatedValue.HasValue ||
                               _memorabiliaGrade.HasValue ||
                               _memorabiliaPerson?.Id > 0 ||
                               _memorabiliaPurchaseTypeId > 0 ||
                               _memorabiliaTeam?.Id > 0 ||
                               _noAutographImages ||
                               _privacyTypeId > 0 ||
                               _sizeId > 0 ||
                               _sportId > 0 ||
                               _sportLeagueLevelId > 0 ||
                               _spotId > 0 ||
                               _writingInstrumentId > 0;

    private static DateTime? _autographAcquiredDate;
    private static int _autographAcquisitionTypeId;
    private static int _autographConditionId;
    private static decimal? _autographCost;
    private static decimal? _autographEstimatedValue;
    private static int? _autographGrade;
    private static SavePersonViewModel _autographPerson;
    private static int _brandId;
    private static int _colorId;
    private static int _franchiseId;
    private static int _gameStyleTypeId;
    private static bool _hasAutographAuthentication;    
    private static bool _hasAutographInscription;
    private static int _itemTypeId;
    private static int _levelTypeId;
    private static DateTime? _memorabiliaAcquiredDate;
    private static int _memorabiliaAcquisitionTypeId;
    private static int _memorabiliaConditionId;
    private static decimal? _memorabiliaCost;
    private static decimal? _memorabiliaEstimatedValue;
    private static int? _memorabiliaGrade;
    private static SavePersonViewModel _memorabiliaPerson;
    private static int _memorabiliaPurchaseTypeId;
    private static SaveTeamViewModel _memorabiliaTeam;
    private static bool _noAutographImages;
    private IEnumerable<SavePersonViewModel> _people = Enumerable.Empty<SavePersonViewModel>();
    private static int _privacyTypeId;
    private static int _sizeId;
    private static int _sportId;
    private static int _sportLeagueLevelId;
    private static int _spotId;
    private IEnumerable<SaveTeamViewModel> _teams = Enumerable.Empty<SaveTeamViewModel>();
    private static int _writingInstrumentId;

    protected async Task HandleValidSubmit()
    {
        await FilterResults();
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadPeople();
        await LoadTeams();

        if (!_hasFilter)
            return;

        await FilterResults();
    }

    protected async Task ResetCriteria()
    {
        _autographAcquiredDate = null;
        _autographAcquisitionTypeId = 0;
        _autographConditionId = 0;
        _autographCost = null;
        _autographEstimatedValue = null;
        _autographGrade = null;
        _autographPerson = null;
        _brandId = 0;
        _colorId = 0;
        _franchiseId = 0;
        _gameStyleTypeId = 0;
        _hasAutographAuthentication = false;        
        _hasAutographInscription = false;
        _itemTypeId = 0;
        _levelTypeId = 0;
        _memorabiliaAcquiredDate = null;
        _memorabiliaAcquisitionTypeId = 0;
        _memorabiliaConditionId = 0;
        _memorabiliaCost = null;
        _memorabiliaEstimatedValue = null;
        _memorabiliaGrade = null;
        _memorabiliaPerson = null;
        _memorabiliaPurchaseTypeId = 0;
        _memorabiliaTeam = null;
        _noAutographImages = false;
        _privacyTypeId = 0;
        _sizeId = 0;
        _sportId = 0;
        _sportLeagueLevelId = 0;
        _spotId = 0;
        _writingInstrumentId = 0;

        await FilterResults();
    }

    private List<AutographViewModel> FilterAutographs()
    {
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographAcquiredDate, _autographAcquiredDate);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographAcquisitionType, _autographAcquisitionTypeId);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographAuthentication, _hasAutographAuthentication);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographColor, _colorId);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographCondition, _autographConditionId);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographCost, _autographCost);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographEstimatedValue, _autographEstimatedValue);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographGrade, _autographGrade);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographImage, _noAutographImages);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographInscription, _hasAutographInscription);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographPerson, _autographPerson?.Id);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographSpot, _spotId);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographWritingInstrument, _writingInstrumentId);

        return _autographs.AsQueryable().Where(AutographFilterPredicateBuilder.Predicate).ToList();
    }

    private List<MemorabiliaItemViewModel> FilterMemorabiliaItems()
    {
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaAcquiredDate, _memorabiliaAcquiredDate);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaAcquisitionType, _memorabiliaAcquisitionTypeId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaBrand, _brandId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaCondition, _memorabiliaConditionId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaCost, _memorabiliaCost);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaEstimatedValue, _memorabiliaEstimatedValue);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaFranchise, _franchiseId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaGameStyleType, _gameStyleTypeId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaItemType, _itemTypeId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaLevelType, _levelTypeId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaPerson, _memorabiliaPerson?.Id);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaPrivacyType, _privacyTypeId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaPurchaseType, _memorabiliaPurchaseTypeId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaSize, _sizeId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaSport, _sportId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaSportLeagueLevel, _sportLeagueLevelId);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaTeam, _memorabiliaTeam?.Id);

        return Items.AsQueryable().Where(MemorabiliaFilterPredicateBuilder.Predicate).ToList();
    }

    private async Task FilterResults()
    {
        var filteredMemorabilaItems = FilterMemorabiliaItems();
        var autographResults = FilterAutographs();
        var memorabiliaIds = autographResults.Select(x => x.MemorabiliaId).ToArray();

        Results = filteredMemorabilaItems.Where(item => memorabiliaIds.Contains(item.Id)).ToList();

        await ResultsChanged.InvokeAsync(Results.Select(result => result.Id));

        _autographPerson = null;
        _memorabiliaPerson = null;
    }

    private async Task LoadPeople()
    {
        _people = (await QueryRouter.Send(new GetPeople())).People.Select(person => new SavePersonViewModel(person));
    }

    private async Task LoadTeams()
    {
        _teams = (await QueryRouter.Send(new GetTeams())).Teams.Select(team => new SaveTeamViewModel(team));
    }

    private async Task<IEnumerable<SavePersonViewModel>> SearchPeople(string value)
    {
        if (value.IsNullOrEmpty())
            return Array.Empty<SavePersonViewModel>();

        var nonCulturalResults = _people.Where(person => CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.ProfileName,
                                                                                                        value,
                                                                                                        CompareOptions.IgnoreNonSpace) > -1);

        var culturalResults = _people.Where(person => person.ProfileName.Contains(value, StringComparison.OrdinalIgnoreCase));

        return await Task.FromResult(nonCulturalResults.Union(culturalResults).DistinctBy(person => person.Id));
    }

    private async Task<IEnumerable<SaveTeamViewModel>> SearchTeams(string value)
    {
        if (value.IsNullOrEmpty())
            return Array.Empty<SaveTeamViewModel>();

        return await Task.FromResult(_teams.Where(team => team.DisplayName.Contains(value, StringComparison.InvariantCultureIgnoreCase)));
    }
}
