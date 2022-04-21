using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonDraftEditor : ComponentBase
    {
        [Parameter]
        public List<SavePersonDraftViewModel> Drafts { get; set; } = new();

        private SavePersonDraftViewModel _viewModel = new();

        private void Add()
        {
            Drafts.Add(_viewModel);

            _viewModel = new SavePersonDraftViewModel();
        }

        private void Remove(int franchiseId, int year)
        {
            var draft = Drafts.SingleOrDefault(draft => draft.FranchiseId == franchiseId && draft.Year == year);

            if (draft == null)
                return;

            draft.IsDeleted = true;
        }
    }
}
