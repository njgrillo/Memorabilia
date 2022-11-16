using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Guitar;

public class SaveGuitarViewModel : MemorabiliaItemEditViewModel
{
    public SaveGuitarViewModel() 
    {
        BrandId = Brand.Fender.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveGuitarViewModel(GuitarViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.Guitar;

    public override ItemType ItemType => ItemType.Guitar;
}
