namespace Memorabilia.Application.Features.Admin
{
    public class DomainEntityCommand : DomainCommand, ICommand
    {
        private readonly SaveDomainViewModel _viewModel;

        public DomainEntityCommand(SaveDomainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public string Abbreviation => _viewModel.Abbreviation;

        public int Id => _viewModel.Id;

        public bool IsDeleted => _viewModel.IsDeleted;

        public bool IsModified => _viewModel.IsModified;

        public bool IsNew => _viewModel.IsNew;

        public string Name => _viewModel.Name;
    }
}
