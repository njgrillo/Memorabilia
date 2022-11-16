using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.PinFlag;

public class SavePinFlagViewModel : MemorabiliaItemEditViewModel
{
    public SavePinFlagViewModel() 
    {
        GameStyleTypeId = GameStyleType.None.Id;
    }

    public SavePinFlagViewModel(PinFlagViewModel viewModel)
    {
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        MemorabiliaId = viewModel.MemorabiliaId;            

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.PinFlag;

    public override ItemType ItemType => ItemType.PinFlag;

    public override Sport Sport => Sport.Golf;
}
