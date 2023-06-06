using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Document;

public class SaveDocumentViewModel : MemorabiliaItemEditViewModel
{
    public SaveDocumentViewModel() { }

    public SaveDocumentViewModel(DocumentViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string ImageFileName => Constant.ImageFileName.Document;

    public override ItemType ItemType => ItemType.Document;
}
