using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.CompactDisc
{
    public class SaveCompactDiscViewModel : SaveItemViewModel
    {
        public SaveCompactDiscViewModel() { }

        public SaveCompactDiscViewModel(CompactDiscViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public bool HasPerson => People.Any();

        public override string ImagePath => "images/compactdisc.jpg";

        public override ItemType ItemType => ItemType.CompactDisc;

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType.CompactDisc.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();
    }
}
