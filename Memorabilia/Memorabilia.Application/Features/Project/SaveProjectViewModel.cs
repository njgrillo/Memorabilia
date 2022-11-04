﻿namespace Memorabilia.Application.Features.Project;

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

    public string ImagePath => Domain.Constants.ImagePath.ProjectTypes;

    public override string ItemTitle => "Project";

    public int ItemTypeId { get; set; }

    public IEnumerable<Domain.Constants.ItemType> ItemTypes => Domain.Constants.ItemType.All;

    [Required]
    public string Name { get; set; }

    public override string PageTitle => "Project";

    public List<SaveProjectPersonViewModel> People { get; set; } = new();

    public IEnumerable<Domain.Constants.PriorityType> PriorityTypes => Domain.Constants.PriorityType.All;

    public override string RoutePrefix => "Projects";

    public DateTime? StartDate { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "User Id is required.")]
    public int UserId { get; set; }
}
