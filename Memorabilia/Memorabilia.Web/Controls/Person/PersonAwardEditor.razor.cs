using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Domain.Extensions;
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
        private string _years;

        private void Add()
        {
            foreach (var year in _years.ToIntArray())
            {
                Awards.Add(new SavePersonAwardViewModel() { AwardTypeId = _viewModel.AwardTypeId, Year = year });
            }           

            _viewModel = new SavePersonAwardViewModel();
            _years = string.Empty;
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
