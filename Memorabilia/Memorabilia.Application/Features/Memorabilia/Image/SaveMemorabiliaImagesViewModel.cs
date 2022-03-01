using Memorabilia.Application.Features.Image;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Image
{
    public class SaveMemorabiliaImagesViewModel : ViewModel
    {
        public SaveMemorabiliaImagesViewModel() { }

        public SaveMemorabiliaImagesViewModel(List<Domain.Entities.MemorabiliaImage> images)
        {
            Images = images.Select(image => new SaveImageViewModel(image)).ToList();
        }

        public List<SaveImageViewModel> Images { get; set; } = new();

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => "Memorabilia Images";
    }
}
