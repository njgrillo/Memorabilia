using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Commissioners;

public class SaveCommissionerViewModel : SaveViewModel
{
    public SaveCommissionerViewModel() { }

    public SaveCommissionerViewModel(CommissionerViewModel viewModel)
    {
        BeginYear = viewModel.BeginYear;
        EndYear = viewModel.EndYear;
        Id = viewModel.Id;
        Person = new PersonViewModel(viewModel.Person);
        SportLeagueLevelId = viewModel.SportLeagueLevelId;
    }

    public int? BeginYear { get; set; }

    public int? EndYear { get; set; }

    public override string ExitNavigationPath => AdminDomainItem.Commissioners.Page;

    public string ImagePath => AdminDomainItem.Commissioners.ImagePath;

    public override string ItemTitle => AdminDomainItem.Commissioners.Item;    

    [Required]
    public PersonViewModel Person { get; set; }

    public override string RoutePrefix => AdminDomainItem.Commissioners.Page;

    [Required]
    public int SportLeagueLevelId { get; set; }
}
