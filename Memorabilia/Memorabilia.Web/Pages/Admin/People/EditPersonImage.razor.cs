using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPersonImage : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public IWebHostEnvironment Environment { get; set; }

        [Inject]
        public ILogger<EditPersonImage> Logger { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        private bool _hasImage;
        private SavePersonImageViewModel _viewModel = new();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SavePersonImage.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = new SavePersonImageViewModel(await QueryRouter.Send(new GetPersonImage.Query(PersonId)).ConfigureAwait(false));
            _hasImage = !_viewModel.ImagePath.IsNullOrEmpty();
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePersonImage.Command(_viewModel)).ConfigureAwait(false);
        }

        private async Task LoadFile(InputFileChangeEventArgs e)
        {
            var file = e.File;

            try
            {
                var directory = Path.Combine(Environment.ContentRootPath, "wwwroot/siteimages/people");

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var fileName = Path.GetRandomFileName();
                var path = Path.Combine(directory, fileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.OpenReadStream(5120000).CopyToAsync(fs);

                _viewModel.ImagePath = $"wwwroot/siteimages/people/{fileName}";
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
