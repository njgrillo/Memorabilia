﻿using Memorabilia.Application.Validators.ProposeTrade;

namespace Memorabilia.Web.Extensions;

public static class ValidatorServiceCollectionExtensions
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddSingleton<AccomplishmentManagementValidator>();
        services.AddSingleton<AccoladeValidator>();
        services.AddSingleton<AllStarManagementValidator>();
        services.AddSingleton<AuthenticationValidator>();
        services.AddSingleton<AutographValidator>();
        services.AddSingleton<AwardManagementValidator>();
        services.AddSingleton<BammerValidator>();
        services.AddSingleton<BaseballValidator>();
        services.AddSingleton<BasketballValidator>();
        services.AddSingleton<BatValidator>();
        services.AddSingleton<BobbleheadValidator>();
        services.AddSingleton<BookValidator>();
        services.AddSingleton<CanvasValidator>();
        services.AddSingleton<CardValidator>();
        services.AddSingleton<CerealBoxValidator>();
        services.AddSingleton<CollectionValidator>();
        services.AddSingleton<DocumentValidator>();
        services.AddSingleton<DrumValidator>();
        services.AddSingleton<FigureValidator>();
        services.AddSingleton<FirstDayCoverValidator>();
        services.AddSingleton<FootballValidator>();
        services.AddSingleton<GloveValidator>();
        services.AddSingleton<GolfballValidator>();
        services.AddSingleton<GuitarValidator>();
        services.AddSingleton<HallOfFameValidator>();
        services.AddSingleton<HatValidator>();
        services.AddSingleton<HeadBandValidator>();
        services.AddSingleton<HelmetValidator>();
        services.AddSingleton<HockeyStickValidator>();
        services.AddSingleton<IndexCardValidator>();
        services.AddSingleton<InscriptionValidator>();
        services.AddSingleton<JerseyValidator>();
        services.AddSingleton<JerseyNumberValidator>();
        services.AddSingleton<LithographValidator>();
        services.AddSingleton<MagazineValidator>();
        services.AddSingleton<MemorabiliaItemValidator>();
        services.AddSingleton<MemorabiliaTransactionValidator>();
        services.AddSingleton<PaintingValidator>();
        services.AddSingleton<PantValidator>();
        services.AddSingleton<PersonValidator>();
        services.AddSingleton<PhotoValidator>();
        services.AddSingleton<PinFlagValidator>();
        services.AddSingleton<PlayingCardValidator>();
        services.AddSingleton<PosterValidator>();
        services.AddSingleton<ProjectValidator>();
        services.AddSingleton<ProposeTradeValidator>();
        services.AddSingleton<PuckValidator>();
        services.AddSingleton<PylonValidator>();
        services.AddSingleton<ShirtValidator>();
        services.AddSingleton<ShoeValidator>();
        services.AddSingleton<SoccerballValidator>();
        services.AddSingleton<SportServiceValidator>();
        services.AddSingleton<TeamValidator>();
        services.AddSingleton<TennisballValidator>();
        services.AddSingleton<TennisRacketValidator>();
        services.AddSingleton<ThroughTheMailValidator>();
        services.AddSingleton<TicketValidator>();
        services.AddSingleton<TrunkValidator>();
        services.AddSingleton<UserValidator>();
        services.AddSingleton<WristBandValidator>();
    }
}
