namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class OccupationPersonEditor 
    : EditPersonItem<PersonOccupationsEditModel, PersonOccupationModel>
{
    protected RecentPersonOccupationsModel[] RecentPersonOccupations { get; private set; }
        = Array.Empty<RecentPersonOccupationsModel>();

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonOccupation.Command(PersonId, ViewModel));
    }

    protected async Task OnLoad()
    {
        Entity.Person[] recentPeople = await QueryRouter.Send(new GetRecentPersonOccupations());

        RecentPersonOccupations = recentPeople.Select(recentPerson => new RecentPersonOccupationsModel(recentPerson))
                                              .ToArray();

        Entity.Person person = await QueryRouter.Send(new GetPerson(PersonId));

        ViewModel = new PersonOccupationsEditModel(PersonId, new PersonOccupationModel(person));
    }    

    protected void OnRecentOccupationChange(RecentPersonOccupationsModel recentOccupation)
    {
        ViewModel.Occupations = recentOccupation.Occupations
                                                .Select(occupation => new PersonOccupationEditModel(new Domain.Entities.PersonOccupation(occupation.Id, occupation.OccupationTypeId, ViewModel.PersonId)))
                                                .ToList();

        ViewModel.Positions = recentOccupation.Positions
                                              .Select(position => new PersonPositionEditModel(new Domain.Entities.PersonPosition(ViewModel.PersonId, position.Id, position.PositionType)))
                                              .ToList();

        ViewModel.Sports = recentOccupation.Sports
                                           .Select(sport => new PersonSportEditModel(new Domain.Entities.PersonSport(ViewModel.PersonId, sport.Id, sport.IsPrimary)))
                                           .ToList();
    }
}
