using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Bookplate;

public class SaveBookplateViewModel : MemorabiliaItemEditViewModel
{
    public SaveBookplateViewModel() { }

    public SaveBookplateViewModel(BookplateViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
    }

    public override string ImageFileName => Constant.ImageFileName.Bookplate;

    public override ItemType ItemType => ItemType.Bookplate;
}
