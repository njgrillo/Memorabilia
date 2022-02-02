using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia.Image
{
    public class SaveMemorabiliaImagesViewModel : ViewModel
    {
        public SaveMemorabiliaImagesViewModel() { }

        public SaveMemorabiliaImagesViewModel(List<string> filePaths)
        {
            FilePaths = filePaths;
        }

        public List<string> FilePaths { get; set; } = new();

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => "Memorabilia Images";
    }
}
