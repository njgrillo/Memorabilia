using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Bookplate;

public class SaveBookplateViewModel : SaveItemViewModel
{
    public SaveBookplateViewModel() { }

    public SaveBookplateViewModel(BookplateViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public bool HasPerson => Person?.Id > 0;

    public override string ImagePath => Domain.Constants.ImagePath.Bookplate;

    public override ItemType ItemType => ItemType.Bookplate;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} {ItemType.Bookplate.Name} Details";

    public SavePersonViewModel Person { get; set; }
}
