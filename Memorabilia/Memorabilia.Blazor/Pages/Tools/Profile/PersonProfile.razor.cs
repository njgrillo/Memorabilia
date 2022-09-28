#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Profile
{
    public partial class PersonProfile : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IProfileService ProfileService { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public PersonViewModel SelectedPerson { get; set; }

        private IEnumerable<PersonViewModel> _people = Enumerable.Empty<PersonViewModel>();

        private PersonViewModel _viewModel
        {
            get => SelectedPerson;
            set
            {
                SelectedPerson = value;
                SelectedPersonChanged(value);
            }
        }

        protected async Task OnLoad()
        {
            await LoadPeople().ConfigureAwait(false);
        }

        private async Task LoadPeople()
        {
            _people = (await QueryRouter.Send(new GetPeople.Query()).ConfigureAwait(false)).People;
        }

        private async Task<IEnumerable<PersonViewModel>> SearchPeople(string searchText)
        {
            if (searchText.IsNullOrEmpty())
                return Array.Empty<PersonViewModel>();

            var nonCulturalResults = _people.Where(person => CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.ProfileName,
                                                                                                            searchText,
                                                                                                            CompareOptions.IgnoreNonSpace) > -1);

            var culturalResults = _people.Where(person => person.ProfileName.Contains(searchText, StringComparison.OrdinalIgnoreCase));

            return await Task.FromResult(nonCulturalResults.Union(culturalResults).DistinctBy(person => person.Id)).ConfigureAwait(false);
        }

        private async Task SelectedPersonChanged(PersonViewModel person)
        {
            var profiles = await ProfileService.GetProfileTypes(person.Id).ConfigureAwait(false);
            var profile = profiles.FirstOrDefault();

            NavigationManager.NavigateTo($"Tools/{profile.Name}Profile/{person.Id}");
        }
    }
}
