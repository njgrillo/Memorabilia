﻿namespace Memorabilia.Application.Features.Memorabilia.PlayingCard;

public class PlayingCardModel : Model
{
    private readonly Entity.Memorabilia _memorabilia;

    public PlayingCardModel() { }

    public PlayingCardModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId 
        => _memorabilia.Id;

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;

    public Entity.MemorabiliaSize Size 
        => _memorabilia.Size;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;

    public IEnumerable<Entity.MemorabiliaTeam> Teams 
        => _memorabilia.Teams;
}
