﻿namespace Memorabilia.Domain.Constants;

public sealed class Occupation : DomainItemConstant
{       
    public static readonly Occupation Actor = new(2, "Actor", string.Empty);
    public static readonly Occupation Actress = new(3, "Actress", string.Empty);
    public static readonly Occupation Athlete = new(1, "Athlete", string.Empty);
    public static readonly Occupation Broadcaster = new(5, "Broadcaster", string.Empty);
    public static readonly Occupation Celebrity = new(4, "Celebrity", string.Empty);
    public static readonly Occupation Coach = new(9, "Coach", string.Empty);
    public static readonly Occupation Comedian = new(6, "Comedian", string.Empty);
    public static readonly Occupation Commissioner = new(8, "Commissioner", string.Empty);        
    public static readonly Occupation LeaguePresident = new(12, "League President", string.Empty);       
    public static readonly Occupation Manager = new(7, "Manager", string.Empty);       

    public static readonly Occupation[] All =
    {
        Athlete,
        Actor,
        Actress,
        Broadcaster,
        Celebrity,  
        Coach,
        Comedian,
        Commissioner,
        LeaguePresident,
        Manager
    };

    public static readonly Occupation[] SportOccupations =
    {
        Athlete,
        Coach,
        Commissioner,
        LeaguePresident,
        Manager
    };

    private Occupation(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static Occupation Find(int id)
    {
        return All.SingleOrDefault(occupation => occupation.Id == id);
    }

    public static bool IsSportOccupation(int id)
    {
        return SportOccupations.Contains(Find(id));
    }
}
