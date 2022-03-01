using Memorabilia.Application.Features.Image;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph.Image
{
    public class SaveAutographImagesViewModel : ViewModel
    {
        public SaveAutographImagesViewModel() { }

        public SaveAutographImagesViewModel(List<Domain.Entities.AutographImage> images)
        {
            Images = images.Select(image => new SaveImageViewModel(image)).ToList();
        }

        public List<SaveImageViewModel> Images { get; set; } = new();

        [Required]
        public int AutographId { get; set; }

        public override string PageTitle => "Autograph Images";
    }
}
