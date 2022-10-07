using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Pewters;

public class SavePewterViewModel : SaveViewModel
{
    public SavePewterViewModel() { }

    public SavePewterViewModel(PewterViewModel viewModel)
    {
        FranchiseId = viewModel.FranchiseId;
        Id = viewModel.Id;
        ImagePath = viewModel.ImagePath;
        SizeId = viewModel.SizeId;
        TeamId = viewModel.TeamId;
    }

    public override string ExitNavigationPath => AdminDomainItem.Pewters.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Franchise is required.")]
    public int FranchiseId { get; set; }

    public Franchise[] Franchises => Franchise.GetAll(SportLeagueLevel);

    [Required]
    public string ImagePath { get; set; } 

    public override string ItemTitle => AdminDomainItem.Pewters.Item;

    public string PageImagePath => AdminDomainItem.Pewters.ImagePath;

    public override string RoutePrefix => AdminDomainItem.Pewters.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; }

    public Domain.Constants.SportLeagueLevel SportLeagueLevel => Domain.Constants.SportLeagueLevel.NationalFootballLeague;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Team is required.")]
    public int TeamId { get; set; }
}
