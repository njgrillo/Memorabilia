﻿namespace Memorabilia.Domain.Constants;

public sealed class GloveType : DomainItemConstant
{
    public static readonly GloveType Baseball = new(1, "Baseball Glove");
    public static readonly GloveType Batting = new(2, "Batting Glove");
    public static readonly GloveType Football = new(3, "Football Glove");
    public static readonly GloveType Hockey = new(4, "Hockey Glove");
    public static readonly GloveType Boxing = new(5, "Boxing Glove");
    public static readonly GloveType MMA = new(5, "MMA Glove", "MMA");

    public static readonly GloveType[] All =
    {
        Baseball,
        Batting,
        Boxing,
        Football,
        Hockey,            
        MMA
    };

    private GloveType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static GloveType Find(int id)
    {
        return All.SingleOrDefault(gloveType => gloveType.Id == id);
    }
}
