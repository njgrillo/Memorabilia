using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonAccomplishmentEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonAccomplishmentViewModel> Accomplishments { get; set; } = new();

        private SavePersonAccomplishmentViewModel _viewModel = new();

        private void Add()
        {
            Accomplishments.Add(_viewModel);

            _viewModel = new SavePersonAccomplishmentViewModel();
        }

        private void Remove(int accomplishmentTypeId, DateTime? date, int? year)
        {
            var accomplishment = Accomplishments.SingleOrDefault(accomplishment => accomplishment.AccomplishmentTypeId == accomplishmentTypeId 
                                                                 && ((accomplishment.Date.HasValue && accomplishment.Date == date) 
                                                                      || (accomplishment.Year.HasValue && accomplishment.Year == year)));

            if (accomplishment == null)
                return;

            accomplishment.IsDeleted = true;
        }
    }
}
