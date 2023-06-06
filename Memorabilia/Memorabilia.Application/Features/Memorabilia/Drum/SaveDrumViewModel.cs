using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Drum;

public class SaveDrumViewModel : MemorabiliaItemEditViewModel
{
    public SaveDrumViewModel() 
    { 
        BrandId = Brand.Muslady.Id;
    }

    public SaveDrumViewModel(DrumViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
    }

    public override string ImageFileName => Constant.ImageFileName.Drum;

    public override ItemType ItemType => ItemType.Drum;
}
