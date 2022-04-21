using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls.Person
{
    public partial class MultiPersonSelector : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public bool CanFilterBySport { get; set; }

        [Parameter]
        public bool CanToggle { get; set; }

        [Parameter]
        public ItemType ItemType { get; set; }

        [Parameter]
        public List<SavePersonViewModel> People { get; set; } = new();

        [Parameter]
        public SavePersonViewModel SelectedPerson { get; set; }

        [Parameter]
        public EventCallback<SavePersonViewModel> SelectedPersonChanged { get; set; }

        [Parameter]
        public Domain.Constants.Sport Sport { get; set; }

        SavePersonViewModel _viewModel
        {
            get => SelectedPerson;
            set
            {
                SelectedPerson = value;
                SelectedPersonChanged.InvokeAsync(value);
            }
        }

        private bool _displayPeople;
        private bool _filterPeople = true;
        private bool _hasPeople;
        private string _itemTypeNameLabel => $"Associate {ItemType.Name} with People";
        private string _itemTypeNameFilterLabel => $"Filter by {Sport?.Name}";
        private IEnumerable<SavePersonViewModel> _people = Enumerable.Empty<SavePersonViewModel>();

        protected override async Task OnInitializedAsync()
        {
            _displayPeople = !CanToggle || SelectedPerson?.Id > 0 || People.Any();
            _hasPeople = SelectedPerson?.Id > 0 || People.Any();

            await LoadPeople().ConfigureAwait(false);
        }

        private void Add()
        {
            var person = People.SingleOrDefault(person => person.Id == _viewModel.Id);

            if (person != null)
                person.IsDeleted = false;
            else
                People.Add(_viewModel);

            _viewModel = new();
        }

        private async Task LoadPeople()
        {
            _people = (await QueryRouter.Send(new GetPeople.Query(Sport?.Id ?? null)).ConfigureAwait(false)).People.Select(person => new SavePersonViewModel(person));
        }

        private void PersonCheckboxClicked(bool isChecked)
        {
            _displayPeople = CanToggle && isChecked;

            if (!_displayPeople)
                SelectedPerson = null;

            _hasPeople = isChecked;
        }

        private async Task PersonFilterCheckboxClicked(bool isChecked)
        {
            _filterPeople = isChecked;

            var sportId = _filterPeople ? Sport.Id : (int?)null;
            var query = new GetPeople.Query(sportId);

            _people = (await QueryRouter.Send(query).ConfigureAwait(false)).People.Select(person => new SavePersonViewModel(person));
        }

        private void Remove(int personId)
        {
            var person = People.SingleOrDefault(person => person.Id == personId);

            if (person == null)
                return;

            person.IsDeleted = true;
        }

        private async Task<IEnumerable<SavePersonViewModel>> SearchPeople(string searchText)
        {
            if (searchText.IsNullOrEmpty())
                return Array.Empty<SavePersonViewModel>();

            var nonCulturalResults = _people.Where(person => CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.ProfileName,
                                                                                                            searchText,
                                                                                                            CompareOptions.IgnoreNonSpace) > -1);

            var culturalResults = _people.Where(person => person.ProfileName.Contains(searchText, StringComparison.OrdinalIgnoreCase));

            return await Task.FromResult(nonCulturalResults.Union(culturalResults).DistinctBy(person => person.Id)).ConfigureAwait(false);
        }
    }
}
