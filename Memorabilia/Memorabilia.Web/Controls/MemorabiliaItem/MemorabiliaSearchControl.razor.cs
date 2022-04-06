using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Application.Features.Autograph;
using Memorabilia.Application.Features.Memorabilia;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls.MemorabiliaItem
{
    public partial class MemorabiliaSearchControl : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public List<MemorabiliaItemViewModel> Items { get; set; }

        [Parameter]
        public List<MemorabiliaItemViewModel> Results { get; set; }

        [Parameter]
        public EventCallback<List<MemorabiliaItemViewModel>> ResultsChanged { get; set; }

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
        private IEnumerable<SavePersonViewModel> _people = Enumerable.Empty<SavePersonViewModel>();
        private static int _privacyTypeId;
        private static int _sizeId;
        private static int _sportId;
        private static int _sportLeagueLevelId;
        private static int _spotId;
        private IEnumerable<SaveTeamViewModel> _teams = Enumerable.Empty<SaveTeamViewModel>();
        private static int _writingInstrumentId;   

        private readonly static Expression<Func<AutographViewModel, bool>> _autographAcquiredDateExpression =
            autograph => autograph.AcquisitionDate == _autographAcquiredDate;
        private readonly static Expression<Func<AutographViewModel, bool>> _autographAcquisitionTypeExpression =
            autograph => autograph.AcquisitionTypeId == _autographAcquisitionTypeId;
        private readonly static Expression<Func<AutographViewModel, bool>> _autographConditionExpression =
            autograph => autograph.ConditionId == _autographConditionId;
        private readonly static Expression<Func<AutographViewModel, bool>> _autographCostExpression =
            autograph => autograph.Cost == _autographCost;
        private readonly static Expression<Func<AutographViewModel, bool>> _autographEstimatedValueExpression =
            autograph => autograph.EstimatedValue == _autographEstimatedValue;
        private readonly static Expression<Func<AutographViewModel, bool>> _autographGradeExpression =
            autograph => autograph.Grade == _autographGrade;
        private readonly static Expression<Func<AutographViewModel, bool>> _autographPersonExpression =
            autograph => autograph.PersonId == _autographPerson.Id;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _brandExpression =
            item => item.BrandId == _brandId;
        private readonly static Expression<Func<AutographViewModel, bool>> _colorExpression =
            autograph => autograph.ColorId == _colorId;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _franchiseExpression =
            item => item.Franchises.Select(franchise => franchise.Id).Contains(_franchiseId);
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _gameStyleTypeExpression =
            item => item.GameStyleTypeId == _gameStyleTypeId;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _itemTypeExpression =
            item => item.ItemTypeId == _itemTypeId;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _levelTypeExpression =
            item => item.LevelTypeId == _levelTypeId;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _memorabiliaAcquisitionTypeExpression =
            item => item.Acquisition.AcquisitionTypeId == _memorabiliaAcquisitionTypeId;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _memorabiliaAcquiredDateExpression =
            item => item.Acquisition.AcquiredDate == _memorabiliaAcquiredDate;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _memorabiliaConditionExpression =
            item => item.ConditionId == _memorabiliaConditionId;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _memorabiliaCostExpression =
            item => item.Acquisition.Cost == _memorabiliaCost;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _memorabiliaEstimatedValueExpression =
            item => item.EstimatedValue == _memorabiliaEstimatedValue;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _memorabiliaPersonExpression =
            item => item.People.Select(person => person.PersonId).Contains(_memorabiliaPerson.Id);
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _memorabiliaPurchaseTypeExpression =
            item => item.PurchaseTypeId == _memorabiliaPurchaseTypeId;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _memorabiliaTeamExpression =
            item => item.Teams.Select(team => team.TeamId).Contains(_memorabiliaTeam.Id);
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _privacyTypeExpression =
            item => item.PrivacyTypeId == _privacyTypeId;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _sizeExpression =
            item => item.SizeId == _sizeId;
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _sportExpression =
            item => item.Sports.Select(sport => sport.SportId).Contains(_sportId);
        private readonly static Expression<Func<MemorabiliaItemViewModel, bool>> _sportLeagueLevelExpression =
            item => item.SportLeagueLevels.Select(sportLeagueLevel => sportLeagueLevel.Id).Contains(_sportLeagueLevelId);
        private readonly static Expression<Func<AutographViewModel, bool>> _spotExpression =
            autograph => autograph.SpotId == _spotId;
        private readonly static Expression<Func<AutographViewModel, bool>> _writingInstrumentExpression =
            autograph => autograph.WritingInstrumentId == _writingInstrumentId;

        protected async Task HandleValidSubmit()
        {
            await FilterResults().ConfigureAwait(false);
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadPeople().ConfigureAwait(false);
            await LoadTeams().ConfigureAwait(false);

            if (!_hasFilter)
                return;
            
            await FilterResults().ConfigureAwait(false);            
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
            _privacyTypeId = 0;
            _sizeId = 0;
            _sportId = 0;
            _sportLeagueLevelId = 0;
            _spotId = 0;
            _writingInstrumentId = 0;

            await FilterResults().ConfigureAwait(false);
        }

        private List<AutographViewModel> FilterAutographs()
        {
            var predicate = PredicateBuilder.True<AutographViewModel>();

            if (_autographAcquiredDate.HasValue)
                predicate = predicate.And(_autographAcquiredDateExpression);

            if (_autographAcquisitionTypeId > 0)
                predicate = predicate.And(_autographAcquisitionTypeExpression);

            if (_autographConditionId > 0)
                predicate = predicate.And(_autographConditionExpression);

            if (_autographCost.HasValue)
                predicate = predicate.And(_autographCostExpression);

            if (_autographEstimatedValue.HasValue)
                predicate = predicate.And(_autographEstimatedValueExpression);

            if (_autographGrade.HasValue)
                predicate = predicate.And(_autographGradeExpression);

            if (_autographPerson?.Id > 0)
                predicate = predicate.And(_autographPersonExpression);

            if (_colorId > 0)
                predicate = predicate.And(_colorExpression);

            if (_spotId > 0)
                predicate = predicate.And(_spotExpression);

            if (_writingInstrumentId > 0)
                predicate = predicate.And(_writingInstrumentExpression);

            return _autographs.AsQueryable().Where(predicate).ToList();
        }

        private List<MemorabiliaItemViewModel> FilterMemorabiliaItems()
        {
            var predicate = PredicateBuilder.True<MemorabiliaItemViewModel>();

            if (_brandId > 0)
                predicate = predicate.And(_brandExpression);

            if (_franchiseId > 0)
                predicate = predicate.And(_franchiseExpression);

            if (_gameStyleTypeId > 0)
                predicate = predicate.And(_gameStyleTypeExpression);

            if (_itemTypeId > 0)
                predicate = predicate.And(_itemTypeExpression);

            if (_levelTypeId > 0)
                predicate = predicate.And(_levelTypeExpression);

            if (_memorabiliaAcquiredDate.HasValue)
                predicate = predicate.And(_memorabiliaAcquiredDateExpression);

            if (_memorabiliaAcquisitionTypeId > 0)
                predicate = predicate.And(_memorabiliaAcquisitionTypeExpression);

            if (_memorabiliaConditionId > 0)
                predicate = predicate.And(_memorabiliaConditionExpression);

            if (_memorabiliaCost.HasValue)
                predicate = predicate.And(_memorabiliaCostExpression);

            if (_memorabiliaEstimatedValue.HasValue)
                predicate = predicate.And(_memorabiliaEstimatedValueExpression);

            if (_memorabiliaPerson?.Id > 0)
                predicate = predicate.And(_memorabiliaPersonExpression);

            if (_memorabiliaPurchaseTypeId > 0)
                predicate = predicate.And(_memorabiliaPurchaseTypeExpression);

            if (_memorabiliaTeam?.Id > 0)
                predicate = predicate.And(_memorabiliaTeamExpression);

            if (_privacyTypeId > 0)
                predicate = predicate.And(_privacyTypeExpression);

            if (_sizeId > 0)
                predicate = predicate.And(_sizeExpression);

            if (_sportId > 0)
                predicate = predicate.And(_sportExpression);

            if (_sportLeagueLevelId > 0)
                predicate = predicate.And(_sportLeagueLevelExpression);

            return Items.AsQueryable().Where(predicate).ToList();
        }

        private async Task FilterResults()
        {
            var filteredMemorabilaItems = FilterMemorabiliaItems();
            var autographResults = FilterAutographs();
            var memorabiliaIds = autographResults.Select(x => x.MemorabiliaId).ToArray();

            Results = filteredMemorabilaItems.Where(item => memorabiliaIds.Contains(item.Id)).ToList();

            await ResultsChanged.InvokeAsync(Results).ConfigureAwait(false);
        }

        private async Task LoadPeople()
        {
            _people = (await QueryRouter.Send(new GetPeople.Query()).ConfigureAwait(false)).People.Select(person => new SavePersonViewModel(person));
        }

        private async Task LoadTeams()
        {
            _teams = (await QueryRouter.Send(new GetTeams.Query()).ConfigureAwait(false)).Teams.Select(team => new SaveTeamViewModel(team));
        }

        private async Task<IEnumerable<SavePersonViewModel>> SearchPeople(string value)
        {
            if (value.IsNullOrEmpty())
                return Array.Empty<SavePersonViewModel>();

            return _people.Where(person => person.DisplayName.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        private async Task<IEnumerable<SaveTeamViewModel>> SearchTeams(string value)
        {
            if (value.IsNullOrEmpty())
                return Array.Empty<SaveTeamViewModel>();

            return _teams.Where(team => team.DisplayName.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
