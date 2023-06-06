﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.PlayingCard;

public class PlayingCardViewModel : Model
{
    private readonly Entity.Memorabilia _memorabilia;

    public PlayingCardViewModel() { }

    public PlayingCardViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId => _memorabilia.Id;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public MemorabiliaSize Size => _memorabilia.Size;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
