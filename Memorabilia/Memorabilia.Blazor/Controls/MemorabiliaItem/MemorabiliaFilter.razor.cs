#nullable disable

namespace Memorabilia.Blazor.Controls.MemorabiliaItem;

public partial class MemorabiliaFilter : ComponentBase
{
    [Inject]
    public IAutographFilterPredicateBuilder AutographFilterPredicateBuilder { get; set; }

    [Inject]
    public IMemorabiliaFilterPredicateBuilder MemorabiliaFilterPredicateBuilder { get; set; } 

    [Parameter]
    public List<MemorabiliaItemViewModel> Items { get; set; }

    [Parameter]
    public List<MemorabiliaItemViewModel> Results { get; set; }

    [Parameter]
    public EventCallback<IEnumerable<int>> ResultsChanged { get; set; }

    private List<AutographViewModel> _autographs => Items.SelectMany(item => item.Autographs).ToList();

    private bool _hasFilter => _autographAcquiredDate.HasValue ||
                               _autographAcquisitionTypeIds.Any() ||
                               _autographConditionIds.Any() ||
                               _autographCostHigh.HasValue ||
                               _autographCostLow.HasValue ||
                               _autographEstimatedValueHigh.HasValue ||
                               _autographEstimatedValueLow.HasValue ||                               
                               _autographGrade.HasValue ||
                               _autographPerson?.Id > 0 ||
                               _brandIds.Any() ||
                               _colorIds.Any() ||
                               _franchiseIds.Any() ||
                               _gameStyleTypeIds.Any() ||
                               _hasAutographAuthentication ||                               
                               _hasAutographInscription ||
                               _itemTypeIds.Any() ||
                               _levelTypeIds.Any() ||
                               _memorabiliaAcquiredDate.HasValue ||
                               _memorabiliaAcquisitionTypeIds.Any() ||
                               _memorabiliaConditionIds.Any() ||
                               _memorabiliaCostHigh.HasValue ||
                               _memorabiliaCostLow.HasValue ||
                               _memorabiliaEstimatedValueHigh.HasValue ||
                               _memorabiliaEstimatedValueLow.HasValue ||
                               _memorabiliaGrade.HasValue ||
                               _memorabiliaPerson?.Id > 0 ||
                               _memorabiliaPurchaseTypeIds.Any() ||
                               _memorabiliaTeam?.Id > 0 ||
                               _noAutographImages ||
                               _privacyTypeIds.Any() ||
                               _sizeIds.Any() ||
                               _sportIds.Any() ||
                               _sportLeagueLevelIds.Any() ||
                               _spotIds.Any() ||
                               _writingInstrumentIds.Any();

    private static DateTime? _autographAcquiredDate;
    private IEnumerable<int> _autographAcquisitionTypeIds = Enumerable.Empty<int>();
    private IEnumerable<int> _autographConditionIds = Enumerable.Empty<int>();
    private static decimal? _autographCostHigh;
    private static decimal? _autographCostLow;
    private static decimal? _autographEstimatedValueHigh;
    private static decimal? _autographEstimatedValueLow;    
    private static int? _autographGrade;
    private static SavePersonViewModel _autographPerson;
    private IEnumerable<int> _brandIds = Enumerable.Empty<int>();
    private IEnumerable<int> _colorIds = Enumerable.Empty<int>();
    private IEnumerable<int> _franchiseIds = Enumerable.Empty<int>();
    private IEnumerable<int> _gameStyleTypeIds = Enumerable.Empty<int>();
    private static bool _hasAutographAuthentication;    
    private static bool _hasAutographInscription;
    private IEnumerable<int> _itemTypeIds = Enumerable.Empty<int>();
    private IEnumerable<int> _levelTypeIds = Enumerable.Empty<int>();
    private static DateTime? _memorabiliaAcquiredDate;
    private IEnumerable<int> _memorabiliaAcquisitionTypeIds = Enumerable.Empty<int>();
    private IEnumerable<int> _memorabiliaConditionIds = Enumerable.Empty<int>();
    private static decimal? _memorabiliaCostHigh;
    private static decimal? _memorabiliaCostLow;
    private static decimal? _memorabiliaEstimatedValueHigh;
    private static decimal? _memorabiliaEstimatedValueLow;
    private static int? _memorabiliaGrade;
    private static SavePersonViewModel _memorabiliaPerson;
    private IEnumerable<int> _memorabiliaPurchaseTypeIds = Enumerable.Empty<int>();
    private static SaveTeamViewModel _memorabiliaTeam;
    private static bool _noAutographImages;
    private IEnumerable<int> _privacyTypeIds = Enumerable.Empty<int>();
    private IEnumerable<int> _sizeIds = Enumerable.Empty<int>();
    private IEnumerable<int> _sportIds = Enumerable.Empty<int>();
    private IEnumerable<int> _sportLeagueLevelIds = Enumerable.Empty<int>();
    private IEnumerable<int> _spotIds = Enumerable.Empty<int>();
    private IEnumerable<int> _writingInstrumentIds = Enumerable.Empty<int>();

    protected async Task HandleValidSubmit()
    {
        await FilterResults();
    }

    protected override async Task OnInitializedAsync()
    {
        if (!_hasFilter)
            return;

        await FilterResults();
    }

    protected async Task ResetCriteria()
    {
        _autographAcquiredDate = null;
        _autographAcquisitionTypeIds = Enumerable.Empty<int>();
        _autographConditionIds = Enumerable.Empty<int>();
        _autographCostHigh = null;
        _autographCostLow= null;
        _autographEstimatedValueHigh = null;
        _autographEstimatedValueLow = null;        
        _autographGrade = null;
        _autographPerson = null;
        _brandIds = Enumerable.Empty<int>();
        _colorIds = Enumerable.Empty<int>();
        _franchiseIds = Enumerable.Empty<int>();
        _gameStyleTypeIds = Enumerable.Empty<int>();
        _hasAutographAuthentication = false;        
        _hasAutographInscription = false;
        _itemTypeIds = Enumerable.Empty<int>();
        _levelTypeIds = Enumerable.Empty<int>();
        _memorabiliaAcquiredDate = null;
        _memorabiliaAcquisitionTypeIds = Enumerable.Empty<int>();
        _memorabiliaConditionIds = Enumerable.Empty<int>();
        _memorabiliaCostHigh = null;
        _memorabiliaCostLow = null;
        _memorabiliaEstimatedValueHigh = null;
        _memorabiliaEstimatedValueLow = null;
        _memorabiliaGrade = null;
        _memorabiliaPerson = null;
        _memorabiliaPurchaseTypeIds = Enumerable.Empty<int>();
        _memorabiliaTeam = null;
        _noAutographImages = false;
        _privacyTypeIds = Enumerable.Empty<int>();
        _sizeIds = Enumerable.Empty<int>();
        _sportIds = Enumerable.Empty<int>();
        _sportLeagueLevelIds = Enumerable.Empty<int>();
        _spotIds = Enumerable.Empty<int>();
        _writingInstrumentIds = Enumerable.Empty<int>();

        await FilterResults();
    }

    private List<AutographViewModel> FilterAutographs()
    {
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographAcquiredDate, _autographAcquiredDate);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographAcquisitionType, _autographAcquisitionTypeIds.ToArray());
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographAuthentication, _hasAutographAuthentication);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographColor, _colorIds.ToArray());
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographCondition, _autographConditionIds.ToArray());
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographCost, new Range<decimal?>(_autographCostLow, _autographCostHigh));
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographEstimatedValue, new Range<decimal?>(_autographEstimatedValueLow, _autographEstimatedValueHigh));
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographGrade, _autographGrade);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographImage, _noAutographImages);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographInscription, _hasAutographInscription);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographPerson, _autographPerson?.Id);
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographSpot, _spotIds.ToArray());
        AutographFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.AutographWritingInstrument, _writingInstrumentIds.ToArray());

        return _autographs.AsQueryable().Where(AutographFilterPredicateBuilder.Predicate).ToList();
    }

    private List<MemorabiliaItemViewModel> FilterMemorabiliaItems()
    {
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaAcquiredDate, _memorabiliaAcquiredDate);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaAcquisitionType, _memorabiliaAcquisitionTypeIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaBrand, _brandIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaCondition, _memorabiliaConditionIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaCost, new Range<decimal?>(_memorabiliaCostLow, _memorabiliaCostHigh));
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaEstimatedValue, new Range<decimal?>(_memorabiliaEstimatedValueLow, _memorabiliaEstimatedValueHigh));
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaFranchise, _franchiseIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaGameStyleType, _gameStyleTypeIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaItemType, _itemTypeIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaLevelType, _levelTypeIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaPerson, _memorabiliaPerson?.Id);
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaPrivacyType, _privacyTypeIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaPurchaseType, _memorabiliaPurchaseTypeIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaSize, _sizeIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaSport, _sportIds.ToArray());
        MemorabiliaFilterPredicateBuilder.AppendPredicateAnd(FilterItemEnum.MemorabiliaSportLeagueLevel, _sportLeagueLevelIds.ToArray());
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
}
