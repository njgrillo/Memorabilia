namespace Memorabilia.Application.Features.Collection;

public class CollectionEditModel : EditModel
{
    public CollectionEditModel() { }

    public CollectionEditModel(Entity.Collection collection)
    {
        Description = collection.Description;
        Id = collection.Id;
        Items = collection.Memorabilia
                          .Select(item => new CollectionMemorabiliaEditModel(new CollectionMemorabiliaModel(item)))
                          .ToList();
        Name = collection.Name;
        UserId = collection.UserId;
    }

    public CollectionEditModel(CollectionModel viewModel)
    {
        Description = viewModel.Description;
        Id = viewModel.Id;
        Items = viewModel.Memorabilia
                         .Select(item => new CollectionMemorabiliaEditModel(new CollectionMemorabiliaModel(item)))
                         .ToList();
        Name = viewModel.Name;
        UserId = viewModel.UserId;
    }

    public string Description { get; set; }

    public List<CollectionMemorabiliaEditModel> Items { get; set; } = new();

    public override string ItemTitle => "Collection";

    public override string PageTitle => "Collection";

    public override string RoutePrefix => "Collections";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "User Id is required.")]
    public int UserId { get; set; }
}
