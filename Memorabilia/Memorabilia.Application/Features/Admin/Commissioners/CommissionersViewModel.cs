namespace Memorabilia.Application.Features.Admin.Commissioners
{
    public class CommissionersViewModel : ViewModel
    {
        public CommissionersViewModel() { }

        public CommissionersViewModel(IEnumerable<Domain.Entities.Commissioner> commissioners)
        {
            Commissioners = commissioners.Select(commissioner => new CommissionerViewModel(commissioner)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public List<CommissionerViewModel> Commissioners { get; set; } = new();

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public override string ItemTitle => "Commissioner";

        public override string PageTitle => "Commissioners";

        public override string RoutePrefix => "Commissioners";
    }
}
