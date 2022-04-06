using Memorabilia.Application.Features.Image;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls
{
    public partial class EditImages<TItem> : ComponentBase
    {
        [Inject]
        public IWebHostEnvironment Environment { get; set; }

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public ILogger<EditImages<TItem>> Logger { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public RenderFragment AdditionalButtons { get; set; }

        [Parameter]
        public string ContinueNavigationPath { get; set; }

        [Parameter]
        public string ExitNavigationPath { get; set; }

        [Parameter]
        public List<SaveImageViewModel> Images { get; set; } = new();

        [Parameter]
        public int MaximumAllowedFiles { get; set; }

        [Parameter]
        public long MaximumFileSize { get; set; }

        [Parameter]
        public TItem Model { get; set; }

        [Parameter]
        public EventCallback OnLoad { get; set; }

        [Parameter]
        public EventCallback OnSave { get; set; }

        [Parameter]
        public string PageTitle { get; set; }

        [Parameter]
        public string SaveButtonText { get; set; }

        [Parameter]
        public EventCallback<List<SaveImageViewModel>> ValueChanged { get; set; }

        private bool _continue;
        private IReadOnlyList<IBrowserFile> _files;

        protected void Cancel()
        {
            foreach (var image in Images.Where(image => image.IsNew))
            {
                if (File.Exists(image.FilePath))
                    File.Delete(image.FilePath);
            }

            Images = new List<SaveImageViewModel>();

            NavigationManager.NavigateTo(ExitNavigationPath);
        }

        protected async Task HandleValidSubmit()
        {
            await OnSave.InvokeAsync().ConfigureAwait(false);

            var url = _continue ? ContinueNavigationPath : ExitNavigationPath;

            NavigationManager.NavigateTo(url);
            Snackbar.Add("Images were saved successfully!", Severity.Success);
        }

        protected async Task LoadFiles(InputFileChangeEventArgs e)
        {
            _files = e.GetMultipleFiles(MaximumAllowedFiles);

            await Save().ConfigureAwait(false);
        }

        protected void PrimarySet(string filePath)
        {
            var image = Images.FirstOrDefault(i => i.FilePath == filePath);

            if (image == null)
                return;

            foreach (var memorabiliaImage in Images)
            {
                if (memorabiliaImage.FilePath == image.FilePath)
                    memorabiliaImage.ImageTypeId = Domain.Constants.ImageType.Primary.Id;

                if (memorabiliaImage.ImageTypeId == Domain.Constants.ImageType.Primary.Id && memorabiliaImage.FilePath != image.FilePath)
                    memorabiliaImage.ImageTypeId = Domain.Constants.ImageType.Secondary.Id;
            }
        }

        protected void Remove(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            var image = Images.FirstOrDefault(i => i.FilePath == filePath);

            if (image == null)
                return;

            Images.Remove(image);

            if (!image.IsPrimary)
                return;

            var primaryImage = Images.FirstOrDefault();

            if (primaryImage == null)
                return;

            primaryImage.ImageTypeId = Domain.Constants.ImageType.Primary.Id;
        }

        protected async Task Save()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);
            var images = new List<SaveImageViewModel>();
            var imageType = Domain.Constants.ImageType.Primary;

            foreach (var file in _files)
            {
                try
                {
                    var directory = Path.Combine(Environment.ContentRootPath,
                                                 "wwwroot/userimages",
                                                 userId.Value.ToString());

                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);

                    var fileName = Path.GetRandomFileName();
                    var path = Path.Combine(directory, fileName);

                    await using FileStream fs = new(path, FileMode.Create);
                    await file.OpenReadStream(MaximumFileSize).CopyToAsync(fs).ConfigureAwait(false);

                    images.Add(new SaveImageViewModel(new ImageViewModel(new Domain.Entities.Image($"wwwroot/userimages/{userId.Value}/{fileName}", imageType.Id)), file.Name));

                    imageType = Domain.Constants.ImageType.Secondary;
                }
                catch (Exception ex)
                {
                    Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
                }
            }

            Images = images;
        }
    }
}
