using Memorabilia.Application.Features.Image;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia.Image
{
    public class SaveMemorabiliaImagesViewModel : ViewModel
    {
        public SaveMemorabiliaImagesViewModel() { }

        public SaveMemorabiliaImagesViewModel(List<SaveImageViewModel> images)
        {
            Images = images;
        }

        public List<SaveImageViewModel> Images { get; set; } = new();

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => "Memorabilia Images";
    }
}
