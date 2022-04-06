using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Domain.Constants;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.PinFlag
{
    public class SavePinFlagViewModel : SaveItemViewModel
    {
        public SavePinFlagViewModel() { }

        public SavePinFlagViewModel(PinFlagViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;            

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public bool HasPerson => Person?.Id > 0;

        public override string ImagePath => "images/pinflag.jpg";

        public override ItemType ItemType => ItemType.PinFlag;

        public SavePersonViewModel Person { get; set; }
    }
}
