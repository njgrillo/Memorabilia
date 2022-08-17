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

        [Parameter]
        public List<int> SportIds { get; set; } = new();

        private bool _canAdd = true;
        private bool _canEditFranchise = true;
        private bool _canUpdate;
        private SavePersonDraftViewModel _viewModel = new();

        protected override void OnInitialized()
        {
            _viewModel = new SavePersonDraftViewModel(SportIds);
        }

        private void Add()
        {
            Drafts.Add(_viewModel);

            _viewModel = new SavePersonDraftViewModel(SportIds);
        }

        private void Edit(SavePersonDraftViewModel draft)
        {
            _viewModel.FranchiseId = draft.FranchiseId;
            _viewModel.Year = draft.Year;
            _viewModel.Round = draft.Round;
            _viewModel.Pick = draft.Pick;
            _viewModel.Overall = draft.Overall;

            _canAdd = false;
            _canEditFranchise = false;
            _canUpdate = true;
        }

        private void Remove(int franchiseId, int? year)
        {
            var draft = Drafts.SingleOrDefault(draft => draft.FranchiseId == franchiseId && draft.Year == year);

            if (draft == null)
                return;

            draft.IsDeleted = true;
        }

        private void Update()
        {
            var draft = Drafts.Single(draft => draft.FranchiseId == _viewModel.FranchiseId);

            draft.FranchiseId = _viewModel.FranchiseId;
            draft.Year = _viewModel.Year;
            draft.Round = _viewModel.Round;
            draft.Pick = _viewModel.Pick;
            draft.Overall = _viewModel.Overall;

            _viewModel = new SavePersonDraftViewModel(SportIds);

            _canAdd = true;
            _canEditFranchise = true;
            _canUpdate = false;
        }
    }
}
