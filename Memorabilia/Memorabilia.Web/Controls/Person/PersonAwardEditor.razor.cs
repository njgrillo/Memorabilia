using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonAwardEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonAwardViewModel> Awards { get; set; } = new();

        private SavePersonAwardViewModel _viewModel = new();

        private void Add()
        {
            Awards.Add(_viewModel);

            _viewModel = new SavePersonAwardViewModel();
        }

        private void Remove(int awardTypeId, int year)
        {
            var award = Awards.SingleOrDefault(award => award.AwardTypeId == awardTypeId && award.Year == year);

            if (award == null)
                return;

            award.IsDeleted = true;
        }
    }
}
