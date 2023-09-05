﻿namespace Memorabilia.Repository.Implementations;

public class MemorabiliaForSaleRepository
    : MemorabiliaRepository<Entity.MemorabiliaForSale>, IMemorabiliaForSaleRepository
{
    public MemorabiliaForSaleRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<Entity.MemorabiliaForSale[]> GetAll(int[] ids)
        => await Items.Where(item => ids.Contains(item.Id))
                      .ToArrayAsync();

    public async Task<PagedResult<Entity.MemorabiliaForSale>> GetAllForSale(int userId,
                                                                            PageInfo pageInfo,
                                                                            MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabiliaForSale in Context.MemorabiliaForSale
            join memorabilia in Context.Memorabilia on memorabiliaForSale.MemorabiliaId equals memorabilia.Id
            join memorabiliaTransactionSale in Context.MemorabiliaTransactionSale on memorabilia.Id equals memorabiliaTransactionSale.MemorabiliaId into mts
            from memorabiliaTransactionSale in mts.DefaultIfEmpty()
            join memorabiliaTransactionTrade in Context.MemorabiliaTransactionTrade on memorabilia.Id equals memorabiliaTransactionTrade.MemorabiliaId into mtt
            from memorabiliaTransactionTrade in mtt.DefaultIfEmpty()
            where memorabilia.UserId == userId
              && (memorabiliaSearchCriteria.IncludeSold || memorabiliaTransactionSale == null)
              && (memorabiliaSearchCriteria.IncludeTraded || (memorabiliaTransactionTrade == null || memorabiliaTransactionTrade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
              && (!memorabiliaSearchCriteria.AcquiredDateBegin.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AcquiredDateBegin))
              && (!memorabiliaSearchCriteria.AcquiredDateEnd.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AcquiredDateEnd))
              && (!memorabiliaSearchCriteria.AcquisitionTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabiliaSearchCriteria.AcquisitionTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia.Autographs.Any(autograph => !autograph.Authentications.Any())) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Any())))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Autographs.Any(autograph => !autograph.Images.Any())) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Autographs.Any(autograph => autograph.Images.Any())))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia.Autographs.Any(autograph => !autograph.Inscriptions.Any())) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Any())))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.People.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && !memorabilia.Images.Any()) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Images.Any()))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (!memorabiliaSearchCriteria.People.Any() || memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.None || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.ForSale && memorabilia.ForSale != null) || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.NotForSale && memorabilia.ForSale == null))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (!memorabiliaSearchCriteria.Teams.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && !memorabilia.ForTrade))
            orderby memorabilia.CreateDate
            select new Entity.MemorabiliaForSale(memorabilia);

        return await query.ToPagedResult(pageInfo);
    }
}
