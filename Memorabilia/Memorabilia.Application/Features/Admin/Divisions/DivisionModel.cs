﻿namespace Memorabilia.Application.Features.Admin.Divisions;

public class DivisionModel
{
    private readonly Entity.Division _division;

    public DivisionModel() { }

    public DivisionModel(Entity.Division division)
    {
        _division = division;
    }

    public string Abbreviation 
        => _division.Abbreviation;

    public Constant.Conference Conference 
        => Constant.Conference.Find(ConferenceId ?? 0);

    public int? ConferenceId
        => _division.ConferenceId;

    public string ConferenceName 
        => Conference != null && 
          !Conference.Name.IsNullOrEmpty() 
               ? Conference.Name 
               : "N/A";

    public int Id 
        => _division.Id;

    public int? LeagueId 
        => _division.LeagueId;

    public string LeagueName 
        => Constant.League.Find(LeagueId ?? 0)?.Name;  

    public string Name 
        => _division.Name;       
}
