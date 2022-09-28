

using Memorabilia.Application.Features.Admin.Pewters;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Pewters
{
    public partial class EditPewter : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public IWebHostEnvironment Environment { get; set; }

        [Inject]
        public ILogger<EditPewter> Logger { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool _hasImage;
        private SavePewterViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SavePewter.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SavePewterViewModel(await QueryRouter.Send(new GetPewter.Query(Id)).ConfigureAwait(false));
            _hasImage = !_viewModel.ImagePath.IsNullOrEmpty();
        }

        private async Task LoadFile(InputFileChangeEventArgs e)
        {
            var file = e.File;

            try
            {
                var directory = Path.Combine(Environment.ContentRootPath, "wwwroot/siteimages/pewters");

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var fileName = Path.GetRandomFileName();
                var path = Path.Combine(directory, fileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.OpenReadStream(5120000).CopyToAsync(fs);

                _viewModel.ImagePath = $"wwwroot/siteimages/pewters/{fileName}";
                _hasImage = true;
            }
            catch (Exception ex)
            {
                Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
            }
        }

        private void Remove()
        {
            _viewModel.ImagePath = null;
            _hasImage = false;
        }
    }
}
