using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Positions;

public class SavePositionViewModel : SaveViewModel
{
    public SavePositionViewModel() { }

    public SavePositionViewModel(PositionViewModel viewModel)
    {
        Abbreviation = viewModel.Abbreviation;
        Id = viewModel.Id;
        Name = viewModel.Name;
        SportId = viewModel.SportId;
    }

    [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
    public string Abbreviation { get; set; }

    public override string ExitNavigationPath => AdminDomainItem.Positions.Page;

    public string ImageFileName => AdminDomainItem.Positions.ImageFileName;

    public override string ItemTitle => AdminDomainItem.Positions.Item;

    [Required]
    [StringLength(50, ErrorMessage = "Name is too long.")]
    [MinLength(1, ErrorMessage = "Name is too short.")]
    public override string Name { get; set; }

    public override string RoutePrefix => AdminDomainItem.Positions.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport is required.")]
    public int SportId { get; set; }
}
