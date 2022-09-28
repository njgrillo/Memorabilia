namespace Memorabilia.Application.Features.Admin
{
    public class SaveDomainViewModel : SaveViewModel
    {
        public SaveDomainViewModel() { }

        public SaveDomainViewModel(int id, string domainTypeName, string imagePath, string navigationPath)
        {
            Id = id;
            DomainTypeName = domainTypeName;
            ImagePath = imagePath;
            NavigationPath = navigationPath;
        }

        public SaveDomainViewModel(DomainViewModel viewModel)
        {
            Abbreviation = viewModel.Abbreviation;
            Id = viewModel.Id;
            Name = viewModel.Name;
        }

        public SaveDomainViewModel(DomainViewModel viewModel, string domainTypeName, string imagePath, string navigationPath)
        {
            Abbreviation = viewModel.Abbreviation;
            Id = viewModel.Id;
            Name = viewModel.Name;

            DomainTypeName = domainTypeName;
            ImagePath = imagePath;
            NavigationPath = navigationPath;
        }

        public string Abbreviation { get; set; }

        public string DomainTypeName { get; set; }        

        public string ImagePath { get; set; }        

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public string NavigationPath { get; set; }

        public virtual string PageFooterNavigationPath => NavigationPath;

        public override string PageTitle => $"{(EditModeType == Domain.Constants.EditModeType.Update ? "Edit" : "Add")} {DomainTypeName}";
    }
}
