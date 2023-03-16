namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class OccupationPersonEditor 
    : EditPersonItem<SavePersonOccupationsViewModel, PersonOccupationViewModel>
{
    protected RecentPersonOccupationsViewModel[] RecentPersonOccupations { get; private set; }
        = Array.Empty<RecentPersonOccupationsViewModel>();

    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonOccupation.Command(PersonId, ViewModel));
    }

    protected async Task OnLoad()
    {
        RecentPersonOccupations = await QueryRouter.Send(new GetRecentPersonOccupations());

        ViewModel = new SavePersonOccupationsViewModel(PersonId, await QueryRouter.Send(new GetPersonOccupations(PersonId)));
    }    

    protected void OnRecentOccupationChange(RecentPersonOccupationsViewModel recentOccupation)
    {
        ViewModel.Occupations = recentOccupation.Occupations
                                                .Select(occupation => new SavePersonOccupationViewModel(new Domain.Entities.PersonOccupation(occupation.Id, occupation.OccupationTypeId, ViewModel.PersonId)))
                                                .ToList();
        ViewModel.Positions = recentOccupation.Positions
                                              .Select(position => new SavePersonPositionViewModel(new Domain.Entities.PersonPosition(ViewModel.PersonId, position.Id, position.PositionType)))
                                              .ToList();
        ViewModel.Sports = recentOccupation.Sports
                                           .Select(sport => new SavePersonSportViewModel(new Domain.Entities.PersonSport(ViewModel.PersonId, sport.Id, sport.IsPrimary)))
                                           .ToList();
    }
}
