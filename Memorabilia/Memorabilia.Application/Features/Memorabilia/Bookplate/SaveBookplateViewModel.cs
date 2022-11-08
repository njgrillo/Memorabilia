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

    public override string ImageFileName => Domain.Constants.ImageFileName.Bookplate;

    public override ItemType ItemType => ItemType.Bookplate;
    
    public SavePersonViewModel Person { get; set; }
}
