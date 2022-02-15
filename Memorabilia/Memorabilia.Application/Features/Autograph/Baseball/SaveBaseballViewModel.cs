using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Autograph.Baseball
{
    public class SaveBaseballViewModel : SaveViewModel
    {
        public SaveBaseballViewModel() { }

        public SaveBaseballViewModel(BaseballViewModel viewModel)
        {
            AutographId = viewModel.AutographId;
            SpotId = viewModel.SpotId;
        }

        public int AutographId { get; set; }

        public string ImagePath { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Spot is required.")]
        public int SpotId { get; set; }        
    }
}
