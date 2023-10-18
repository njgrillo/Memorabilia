namespace Memorabilia.Domain.Entities;

public class Project : DomainIdEntity
{
    public Project() { }

    public Project(string name, 
        DateTime? startDate, 
        DateTime? endDate, 
        int userId,
        int projectTypeId)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        UserId = userId;
        ProjectTypeId = projectTypeId;        
    }

    public virtual ProjectBaseball Baseball { get; set; }

    public virtual ProjectCard Card { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ProjectHallOfFame HallOfFame { get; set; }

    public virtual ProjectHelmet Helmet { get; set; }

    public virtual ProjectItem Item { get; set; }

    public virtual List<ProjectMemorabiliaTeam> MemorabiliaTeams { get; set; }
        = new();

    public string Name { get; set; }

    public virtual List<ProjectPerson> People { get; set; } 
        = new();

    public int ProjectTypeId { get; set; }

    public DateTime? StartDate { get; set; }

    public virtual ProjectTeam Team { get; set; }

    public int UserId { get; set; }

    public virtual ProjectWorldSeries WorldSeries { get; set; }

    public void RemoveMemorabiliaTeams(params int[] ids)
    {
        if (ids == null || ids.Length == 0)
            return;

        MemorabiliaTeams.RemoveAll(item => ids.Contains(item.Id));
    }

    public void RemovePeople(params int[] personIds)
    {
        if (personIds == null || personIds.Length == 0)
            return;

        People.RemoveAll(person => personIds.Contains(person.Id));
    }

    public void Set(string name, 
        DateTime? startDate, 
        DateTime? endDate,
        int projectTypeId)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        ProjectTypeId = projectTypeId;
    }

    public void SetBaseball(int baseballTypeId, int? teamId, int? year)
    {
        if (Baseball == null)
        {
            Baseball = new ProjectBaseball(Id, baseballTypeId, teamId, year);
            return;
        }

        Baseball.Set(baseballTypeId, teamId, year);            
    }

    public void SetCard(int brandId, int? teamId, int? year)
    {
        if (Card == null)
        {
            Card = new ProjectCard(Id, brandId, teamId, year);
            return;
        }

        Card.Set(brandId, teamId, year);
    }

    public void SetHallOfFame(int sportLeagueLevelId, int? year, int? itemTypeId)
    {
        if (HallOfFame == null)
        {
            HallOfFame = new ProjectHallOfFame(Id, sportLeagueLevelId, year, itemTypeId);
            return;
        }

        HallOfFame.Set(sportLeagueLevelId, year, itemTypeId);
    }

    public void SetHelmet(int helmetTypeId, int? helmetFinishId, int? sizeId)
    {
        if (Helmet == null)
        {
            Helmet = new ProjectHelmet(Id, helmetTypeId, helmetFinishId, sizeId);
            return;
        }

        Helmet.Set(helmetTypeId, helmetFinishId, sizeId);
    }

    public void SetItem(int itemTypeId, bool multiSignedItem)
    {
        if (Item == null)
        {
            Item = new ProjectItem(Id, itemTypeId, multiSignedItem);
            return;
        }

        Item.Set(itemTypeId, multiSignedItem);
    }

    public void SetMemorabliaTeam(int id,
        int teamId,
        int? itemTypeId,
        bool upgrade,
        int? rank,
        decimal? estimatedCost,
        int? priorityTypeId,
        int? projectStatusTypeId,
        int? memorabiliaId)
    {
        var item = id > 0
            ? MemorabiliaTeams.SingleOrDefault(memorabliaTeam => memorabliaTeam.Id == id)
            : MemorabiliaTeams.SingleOrDefault(memorabliaTeam => memorabliaTeam.TeamId == teamId && memorabliaTeam.ItemTypeId == itemTypeId);

        if (item == null)
        {
            MemorabiliaTeams.Add(new ProjectMemorabiliaTeam(Id,
                teamId,
                itemTypeId,
                upgrade,
                rank,
                estimatedCost,
                priorityTypeId,
                projectStatusTypeId,
                memorabiliaId));

            return;
        }

        item.Set(teamId,
            itemTypeId,
            upgrade,
            rank,
            priorityTypeId,
            projectStatusTypeId,
            estimatedCost,
            memorabiliaId);
    }

    public void SetPerson(int id, 
        int personId, 
        int? itemTypeId, 
        bool upgrade, 
        int? rank, 
        int? priorityTypeId,
        int? projectStatusTypeId,
        decimal? estimatedCost,
        int? memorabiliaId, 
        int? autographId)
    {
        var person = id > 0 
            ? People.SingleOrDefault(person => person.Id == id)
            : People.SingleOrDefault(person => person.PersonId == personId && person.ItemTypeId == itemTypeId);

        if (person == null)
        {
            People.Add(new ProjectPerson(Id, 
                personId, 
                itemTypeId, 
                upgrade, 
                rank, 
                priorityTypeId,
                projectStatusTypeId,
                estimatedCost,
                memorabiliaId,
                autographId));

            return;
        }

        person.Set(personId, 
            itemTypeId, 
            upgrade, 
            rank, 
            priorityTypeId,
            projectStatusTypeId,
            estimatedCost,
            memorabiliaId,
            autographId);
    }

    public void SetTeam(int teamId, int? year)
    {
        if (Team == null)
        {
            Team = new ProjectTeam(Id, teamId, year);
            return;
        }

        Team.Set(teamId, year);
    }

    public void SetWorldSeries(int teamId, int? year, int? itemTypeId)
    {
        if (WorldSeries == null)
        {
            WorldSeries = new ProjectWorldSeries(Id, teamId, year, itemTypeId);
            return;
        }

        WorldSeries.Set(teamId, year, itemTypeId);
    }
}
