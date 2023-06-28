namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class OccupationPersonEditor 
    : EditPersonItem<PersonOccupationsEditModel, PersonOccupationModel>
{
    protected RecentPersonOccupationsModel[] RecentPersonOccupations { get; private set; }
        = Array.Empty<RecentPersonOccupationsModel>();    

    protected override async Task OnInitializedAsync()
    {
        Entity.Person[] recentPeople = await QueryRouter.Send(new GetRecentPersonOccupations());

        RecentPersonOccupations = recentPeople.Select(recentPerson => new RecentPersonOccupationsModel(recentPerson))
                                              .ToArray();

        Entity.Person person = await QueryRouter.Send(new GetPerson(PersonId));

        EditModel = new PersonOccupationsEditModel(PersonId, new PersonOccupationModel(person));

        IsLoaded = true;
    }    

    protected void OnRecentOccupationChange(RecentPersonOccupationsModel recentOccupation)
    {
        EditModel.Occupations = recentOccupation.Occupations
                                                .Select(occupation => new PersonOccupationEditModel(new Entity.PersonOccupation(occupation.Id, occupation.OccupationTypeId, EditModel.PersonId)))
                                                .ToList();

        EditModel.Positions = recentOccupation.Positions
                                              .Select(position => new PersonPositionEditModel(new Entity.PersonPosition(EditModel.PersonId, position.Id, position.PositionType)))
                                              .ToList();

        EditModel.Sports = recentOccupation.Sports
                                           .Select(sport => new PersonSportEditModel(new Entity.PersonSport(EditModel.PersonId, sport.Id, sport.IsPrimary)))
                                           .ToList();
    }

    protected async Task Save()
    {
        await Save(new SavePersonOccupation.Command(PersonId, EditModel));
    }
}
