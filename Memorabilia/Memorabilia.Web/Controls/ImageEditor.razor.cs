using Framework.Extension;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls
{
    public partial class ImageEditor : ComponentBase
    {
        [Parameter]
        public bool CanRemove { get; set; }

        [Parameter]
        public string FileName { get; set; }

        [Parameter]
        public bool HasPrimary { get; set; }

        [Parameter]
        public string ImageFilePath { get; set; }

        [Parameter]
        public ImageType ImageType { get; set; }

        [Parameter]
        public bool IsPrimary { get; set; }

        [Parameter]
        public EventCallback<string> OnPrimarySet { get; set; }

        [Parameter]
        public EventCallback<string> OnRemove { get; set; }

        private string _imageFilePath
        {
            get
            {
                if (ImageFilePath.IsNullOrEmpty() || !File.Exists(ImageFilePath))
                    return "images/imagenotavailable.png";

                return $"data:image/jpeg;base64,{Convert.ToBase64String(File.ReadAllBytes(ImageFilePath))}";
            }
        }

        protected async Task Remove(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            await OnRemove.InvokeAsync(filePath).ConfigureAwait(false);
        }

        protected async Task SetPrimary(string filePath)
        {
            await OnPrimarySet.InvokeAsync(filePath).ConfigureAwait(false);
        }
    }
}
