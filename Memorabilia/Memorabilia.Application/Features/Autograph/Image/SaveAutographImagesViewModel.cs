using Memorabilia.Application.Features.Image;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Autograph.Image
{
    public class SaveAutographImagesViewModel : ViewModel
    {
        public SaveAutographImagesViewModel() { }

        public SaveAutographImagesViewModel(List<SaveImageViewModel> images)
        {
            Images = images;
        }

        public List<SaveImageViewModel> Images { get; set; } = new();

        [Required]
        public int AutographId { get; set; }

        public override string PageTitle => "Autograph Images";
    }
}
