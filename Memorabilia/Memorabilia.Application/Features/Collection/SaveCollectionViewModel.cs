namespace Memorabilia.Application.Features.Collection;

public class SaveCollectionViewModel : SaveViewModel
{
    public SaveCollectionViewModel() { }

    public SaveCollectionViewModel(CollectionViewModel viewModel)
    {
        Description = viewModel.Description;
        Id = viewModel.Id;
        Items = viewModel.Memorabilia
                         .Select(item => new SaveCollectionMemorabiliaViewModel(new CollectionMemorabiliaViewModel(item)))
                         .ToList();
        Name = viewModel.Name;
    }

    public string Description { get; set; }

    public List<SaveCollectionMemorabiliaViewModel> Items { get; set; } = new();

    public override string ItemTitle => "Collection";

    public override string PageTitle => "Collection";

    public override string RoutePrefix => "Collections";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "User Id is required.")]
    public int UserId { get; set; }
}
