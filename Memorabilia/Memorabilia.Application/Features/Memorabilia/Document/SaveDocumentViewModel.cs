using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Document
{
    public class SaveDocumentViewModel : SaveItemViewModel
    {
        public SaveDocumentViewModel() { }

        public SaveDocumentViewModel(DocumentViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public bool HasPerson => People.Any();

        public bool HasTeam => Teams.Any();

        public override string ImagePath => "images/document.jpg";

        public override ItemType ItemType => ItemType.Document;

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType.Document.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
