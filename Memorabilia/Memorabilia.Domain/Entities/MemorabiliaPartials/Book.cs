namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetBook(string edition,
                        bool hardCover,
                        int[] personIds,
                        string publisher,
                        int[] sportIds,
                        int[] teamIds,
                        string title)
    {
        SetBook(edition, hardCover, publisher, title);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    private void SetBook(string edition, bool hardCover, string publisher, string title)
    {
        if (Book == null)
        {
            Book = new MemorabiliaBook(Id, edition, hardCover, publisher, title);
            return;
        }

        Book.Set(edition, hardCover, publisher, title);
    }
}
