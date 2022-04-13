using Demo.Framework.Web;
using Memorabilia.Application.Features.Admin.Commissioners;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Application.Features.Memorabilia.Baseball;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Baseballs
{
    public partial class EditBaseball : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private CommissionerViewModel[] _commissioners;
        private SaveBaseballViewModel _viewModel = new ();

        protected async Task OnLoad()
        {
            await LoadCommissioners().ConfigureAwait(false);

            var viewModel = await QueryRouter.Send(new GetBaseball.Query(MemorabiliaId)).ConfigureAwait(false);

            if (viewModel.Brand == null)
            {
                SetDefaults();
                return;
            }

            _viewModel = new SaveBaseballViewModel(viewModel)
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {    
            await CommandRouter.Send(new SaveBaseball.Command(_viewModel)).ConfigureAwait(false);
        }

        private async Task LoadCommissioners()
        {
            _commissioners = (await QueryRouter.Send(new GetCommissioners.Query(_viewModel.SportLeagueLevel.Id)).ConfigureAwait(false)).Commissioners.ToArray();
        }        

        private void SelectedPersonChanged(SavePersonViewModel person)
        {
            _viewModel.Person = person;
        }

        private void SetDefaults()
        {
            _viewModel.BaseballTypeId = BaseballType.Official.Id;
            _viewModel.BrandId = Brand.Rawlings.Id;
            _viewModel.GameStyleTypeId = GameStyleType.None.Id;
            _viewModel.LevelTypeId = LevelType.Professional.Id;
            _viewModel.MemorabiliaId = MemorabiliaId;
            _viewModel.SizeId = Size.Standard.Id;
        }
    }
}
