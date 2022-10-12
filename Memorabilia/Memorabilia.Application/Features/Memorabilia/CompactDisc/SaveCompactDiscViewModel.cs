using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.CompactDisc;

public class SaveCompactDiscViewModel : SaveItemViewModel
{
    public SaveCompactDiscViewModel() { }

    public SaveCompactDiscViewModel(CompactDiscViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public bool HasPerson => People.Any();

    public override string ImagePath => Domain.Constants.ImagePath.CompactDisc;

    public override ItemType ItemType => ItemType.CompactDisc;
  
    public List<SavePersonViewModel> People { get; set; } = new();
}
