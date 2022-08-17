using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonSportEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonSportViewModel> Sports { get; set; } = new();

        private SavePersonSportViewModel _viewModel = new();

        private void Add()
        {
            if (_viewModel.SportId == 0)
                return;

            Sports.Add(_viewModel);

            _viewModel = new SavePersonSportViewModel();
        }

        private void Remove(int SportId)
        {
            var sport = Sports.SingleOrDefault(sport => sport.SportId == SportId);

            if (sport == null)
                return;

            sport.IsDeleted = true;
        }
    }
}
