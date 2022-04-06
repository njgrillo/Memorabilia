using Demo.Framework.Web;
using Memorabilia.Application.Features.Memorabilia.Card;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Cards
{
    public partial class EditCard : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }            

        private bool _displayNumbered;
        private SaveCardViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            var viewModel = await QueryRouter.Send(new GetCard.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveCardViewModel(viewModel);
            _displayNumbered = _viewModel.IsNumbered;
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveCard.Command(_viewModel)).ConfigureAwait(false);
        }

        private void NumberedCheckboxClicked(bool isChecked)
        {
            _displayNumbered = isChecked;

            if (!_displayNumbered)
            {
                _viewModel.Denominator = null;
                _viewModel.Numerator = null;
            }
        }

        private void SetDefaults()
        {
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Size.Standard.Id;
        }
    }
}
