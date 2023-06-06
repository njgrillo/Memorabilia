using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.CompactDisc;

public class SaveCompactDiscViewModel : MemorabiliaItemEditViewModel
{
    public SaveCompactDiscViewModel() { }

    public SaveCompactDiscViewModel(CompactDiscViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
    }

    public override string ImageFileName => Constant.ImageFileName.CompactDisc;

    public override ItemType ItemType => ItemType.CompactDisc;
}
