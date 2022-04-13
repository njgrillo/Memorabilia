using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Services.Tools.Profile;
using Memorabilia.Application.Features.Tools.Profile.Baseball;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Tools
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

            return await Task.FromResult(_people.Where(person => person.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ConfigureAwait(false);
        }

        private async Task SelectedPersonChanged(PersonViewModel person)
        {
            var profiles = await ProfileService.GetProfileTypes(person.Id).ConfigureAwait(false);
            var profile = profiles.FirstOrDefault();

            NavigationManager.NavigateTo($"Tools/{profile.Name}Profile/{person.Id}");
        }
    }
}
