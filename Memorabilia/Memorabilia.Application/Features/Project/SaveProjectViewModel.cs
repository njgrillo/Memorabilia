namespace Memorabilia.Application.Features.Project;

public class SaveProjectViewModel : SaveViewModel
{
    public SaveProjectViewModel() { }

    public SaveProjectViewModel(ProjectViewModel viewModel)
    {
        EndDate = viewModel.EndDate;
        Id = viewModel.Id;
        Name = viewModel.Name;
        People = viewModel.People.Select(person => new SaveProjectPersonViewModel(person)).ToList();
        StartDate = viewModel.StartDate;
        UserId = viewModel.UserId;

        if (People.Any() && People.Select(person => person.ItemTypeId).Distinct().Count() == 1)
            ItemTypeId = People.First().ItemTypeId;
    }    

    public DateTime? EndDate { get; set; }

    public override string ExitNavigationPath => "Projects";

    public bool HasDefaultItemType => ItemTypeId > 0;

    public string ImageFileName => Domain.Constants.ImageFileName.ProjectTypes;

    public override string ItemTitle => "Project";

    public int ItemTypeId { get; set; }

    public override string PageTitle => "Project";

    public List<SaveProjectPersonViewModel> People { get; set; } = new();

    public override string RoutePrefix => "Projects";

    public DateTime? StartDate { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "User Id is required.")]
    public int UserId { get; set; }
}
