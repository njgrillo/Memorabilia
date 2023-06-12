namespace Memorabilia.Application.Features.Memorabilia.Book;

public class BookEditModel : MemorabiliaItemEditModel
{
    public BookEditModel() { }

    public BookEditModel(BookModel model)
    {
        Edition = model.Book?.Edition; 
        HardCover = model.Book?.HardCover ?? true;
        MemorabiliaId = model.MemorabiliaId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        Publisher = model.Book?.Publisher;

        SportIds = model.Sports
                        .Select(x => x.SportId)
                        .ToList();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();

        Title = model.Book?.Title;
    }

    public string Edition { get; set; }

    public bool HardCover { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.Book;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Book;

    public string Publisher { get; set; }

    public string Title { get; set; }
}
