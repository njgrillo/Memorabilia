﻿using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Memorabilia.Ticket;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Tickets
{
    public partial class EditTicket : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveTicketViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetTicket.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Size == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveTicketViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveTicket.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedPersonChanged(SavePersonViewModel person)
        {
            _viewModel.Person = person;
        }

        private void SetDefaults()
        {
            _viewModel.GameStyleTypeId = GameStyleType.None.Id;
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Size.Standard.Id;
        }
    }
}
