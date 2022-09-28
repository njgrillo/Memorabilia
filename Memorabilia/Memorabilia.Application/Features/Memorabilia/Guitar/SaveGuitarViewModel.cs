using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Guitar
{
    public class SaveGuitarViewModel : SaveItemViewModel
    {
        public SaveGuitarViewModel() { }

        public SaveGuitarViewModel(GuitarViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public Brand Brand => Brand.Find(BrandId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public override string ImagePath => "images/guitar.jpg";

        public override ItemType ItemType => ItemType.Guitar;

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }
    }
}
