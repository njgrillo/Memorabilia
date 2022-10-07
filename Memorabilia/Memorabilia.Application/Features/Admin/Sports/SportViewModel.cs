using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sports;

public class SportViewModel
{
    private readonly Sport _sport;

    public SportViewModel() { }

    public SportViewModel(Sport sport)
    {
        _sport = sport;
    }

    public string AlternateName => _sport.AlternateName;

    public int Id => _sport.Id;

    public string ImagePath => _sport.ImagePath;

    public DateTime? LastModifiedDate => _sport.LastModifiedDate;

    public string Name => _sport.Name;
}
