using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonOccupationSelector : ComponentBase
    {
        [Parameter]
        public List<SavePersonOccupationViewModel> Occupations { get; set; } = new();

        private SavePersonOccupationViewModel _viewModel = new ();

        private void Add()
        {
            Occupations.Add(_viewModel);

            _viewModel = new SavePersonOccupationViewModel();
        }

        private void Remove(int occupationId)
        {
            var occupation = Occupations.SingleOrDefault(occupation => occupation.OccupationId == occupationId);

            if (occupation == null)
                return;

            occupation.IsDeleted = true;
        }
    }
}
