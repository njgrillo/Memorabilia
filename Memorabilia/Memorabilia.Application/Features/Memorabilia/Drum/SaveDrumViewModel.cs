using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Drum;

public class SaveDrumViewModel : SaveItemViewModel
{
    public SaveDrumViewModel() { }

    public SaveDrumViewModel(DrumViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public Brand Brand => Brand.Find(BrandId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; }

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public bool HasPerson => People.Any();

    public override string ImagePath => Domain.Constants.ImagePath.Drum;

    public override ItemType ItemType => ItemType.Drum;

    public List<SavePersonViewModel> People { get; set; } = new();
}
