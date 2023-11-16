namespace Memorabilia.Repository.Implementations;

public class MemorabiliaTransactionRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<MemorabiliaTransaction>(context, memoryCache), IMemorabiliaTransactionRepository
{
    private IQueryable<MemorabiliaTransaction> SaleTransactions
        => Items.Include(transaction => transaction.Sales);

    private IQueryable<MemorabiliaTransaction> TradeTransactions
        => Items.Include(transaction => transaction.Trades);

    public async Task<PagedResult<MemorabiliaTransaction>> GetAllPartialTrades(PageInfo pageInfo,
                                                                               int userId,
                                                                               MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabiliaTransaction in Context.MemorabiliaTransaction
            join memorabiliaTransactionTrade in Context.MemorabiliaTransactionTrade on memorabiliaTransaction.Id equals memorabiliaTransactionTrade.MemorabiliaTransactionId into mtt
            from memorabiliaTransactionTrade in mtt.DefaultIfEmpty()
            join memorabilia in Context.Memorabilia on memorabiliaTransactionTrade.MemorabiliaId equals memorabilia.Id into m
            from memorabilia in m.DefaultIfEmpty()
            where memorabiliaTransaction.UserId == userId
              && memorabiliaTransaction.TransactionTypeId == Constant.TransactionType.PartialTrade.Id
              && (!memorabiliaSearchCriteria.AcquiredDateBegin.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AcquiredDateBegin))
              && (!memorabiliaSearchCriteria.AcquiredDateEnd.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AcquiredDateEnd))
              && (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.None || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithAutographs && memorabilia != null && memorabilia.Autographs.Count != 0) || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithoutAutographs && memorabilia != null && memorabilia.Autographs.Count == 0))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count != 0)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Images.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Images.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.People.Count == 0 || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Count == 0 || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia != null && memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia != null && memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia != null && memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia != null && memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia != null && memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia != null && memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia != null && memorabilia.Images.Count == 0) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia != null && memorabilia.Images.Count != 0))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabilia != null && memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia != null && memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (memorabiliaSearchCriteria.People.Count == 0 || memorabilia != null && memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabilia != null && memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia != null && memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia != null && memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia != null && memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (memorabiliaSearchCriteria.Teams.Count == 0 || memorabilia != null && memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia != null && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && memorabilia != null && !memorabilia.ForTrade))
            orderby memorabiliaTransaction.TransactionDate descending
            group new { }
            by new
            {
                memorabiliaTransaction.Id,
                memorabiliaTransaction.TransactionTypeId,
                memorabiliaTransaction.TransactionDate,
                memorabiliaTransaction.UserId
            } into groupedList
            select new MemorabiliaTransaction(
                groupedList.Key.Id,
                groupedList.Key.TransactionTypeId,
                groupedList.Key.TransactionDate,
                groupedList.Key.UserId
                );

        PagedResult<MemorabiliaTransaction> result 
            = await query.ToPagedResult(pageInfo);

        int[] memorabiliaTransactionIds = result.Data
                                                .Select(memorabiliaTransaction => memorabiliaTransaction.Id)
                                                .ToArray();

        if (memorabiliaTransactionIds.IsNullOrEmpty())
            return result;

        MemorabiliaTransaction[] memorabiliaTransactions 
            = await TradeTransactions.Where(memorabiliaTransaction => memorabiliaTransactionIds.Contains(memorabiliaTransaction.Id))
                                     .ToArrayAsync();

        foreach (MemorabiliaTransaction item in result.Data)
        {
            MemorabiliaTransaction memorabiliaTransaction
                = memorabiliaTransactions.SingleOrDefault(memorabiliaTransaction => memorabiliaTransaction.Id == item.Id);

            if (memorabiliaTransaction == null)
                continue;

            item.Trades = memorabiliaTransaction.Trades;
        }

        return result;
    }

    public async Task<PagedResult<MemorabiliaTransaction>> GetAllSales(PageInfo pageInfo,
                                                                       int userId,
                                                                       MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabiliaTransaction in Context.MemorabiliaTransaction
            join memorabiliaTransactionSale in Context.MemorabiliaTransactionSale on memorabiliaTransaction.Id equals memorabiliaTransactionSale.MemorabiliaTransactionId into mts
            from memorabiliaTransactionSale in mts.DefaultIfEmpty()
            join memorabilia in Context.Memorabilia on memorabiliaTransactionSale.MemorabiliaId equals memorabilia.Id into m
            from memorabilia in m.DefaultIfEmpty()
            where memorabiliaTransaction.UserId == userId
              && memorabiliaTransaction.TransactionTypeId == Constant.TransactionType.Sale.Id
              && (!memorabiliaSearchCriteria.AcquiredDateBegin.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AcquiredDateBegin))
              && (!memorabiliaSearchCriteria.AcquiredDateEnd.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AcquiredDateEnd))
              && (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.None || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithAutographs && memorabilia != null && memorabilia.Autographs.Count != 0) || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithoutAutographs && memorabilia != null && memorabilia.Autographs.Count == 0))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count != 0)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Images.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Images.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.People.Count == 0 || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Count == 0 || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia != null && memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia != null && memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia != null && memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia != null && memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia != null && memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia != null && memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia != null && memorabilia.Images.Count == 0) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia != null && memorabilia.Images.Count != 0))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabilia != null && memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia != null && memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (memorabiliaSearchCriteria.People.Count == 0 || memorabilia != null && memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabilia != null && memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia != null && memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia != null && memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia != null && memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (memorabiliaSearchCriteria.Teams.Count == 0 || memorabilia != null && memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia != null && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && memorabilia != null && !memorabilia.ForTrade))
            orderby memorabiliaTransaction.TransactionDate descending
            group new { }
            by new
            {
                memorabiliaTransaction.Id,
                memorabiliaTransaction.TransactionTypeId,
                memorabiliaTransaction.TransactionDate,
                memorabiliaTransaction.UserId
            } into groupedList
            select new MemorabiliaTransaction(
                groupedList.Key.Id,
                groupedList.Key.TransactionTypeId,
                groupedList.Key.TransactionDate,
                groupedList.Key.UserId
                );

        PagedResult<MemorabiliaTransaction> result
            = await query.ToPagedResult(pageInfo);

        int[] memorabiliaTransactionIds = result.Data
                                                .Select(memorabiliaTransaction => memorabiliaTransaction.Id)
                                                .ToArray();

        if (memorabiliaTransactionIds.IsNullOrEmpty())
            return result;

        MemorabiliaTransaction[] memorabiliaTransactions
            = await SaleTransactions.Where(memorabiliaTransaction => memorabiliaTransactionIds.Contains(memorabiliaTransaction.Id))
                                    .ToArrayAsync();

        foreach (MemorabiliaTransaction item in result.Data)
        {
            MemorabiliaTransaction memorabiliaTransaction
                = memorabiliaTransactions.SingleOrDefault(memorabiliaTransaction => memorabiliaTransaction.Id == item.Id);

            if (memorabiliaTransaction == null)
                continue;

            item.Sales = memorabiliaTransaction.Sales;
        }

        return result;
    }    

    public async Task<PagedResult<MemorabiliaTransaction>> GetAllTrades(PageInfo pageInfo,
                                                                        int userId,
                                                                        MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabiliaTransaction in Context.MemorabiliaTransaction
            join memorabiliaTransactionTrade in Context.MemorabiliaTransactionTrade on memorabiliaTransaction.Id equals memorabiliaTransactionTrade.MemorabiliaTransactionId into mtt
            from memorabiliaTransactionTrade in mtt.DefaultIfEmpty()
            join memorabilia in Context.Memorabilia on memorabiliaTransactionTrade.MemorabiliaId equals memorabilia.Id into m
            from memorabilia in m.DefaultIfEmpty()
            where memorabiliaTransaction.UserId == userId
              && memorabiliaTransaction.TransactionTypeId == Constant.TransactionType.Trade.Id
              && (!memorabiliaSearchCriteria.AcquiredDateBegin.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AcquiredDateBegin))
              && (!memorabiliaSearchCriteria.AcquiredDateEnd.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AcquiredDateEnd))
              && (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.None || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithAutographs && memorabilia != null && memorabilia.Autographs.Count != 0) || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithoutAutographs && memorabilia != null && memorabilia.Autographs.Count == 0))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count != 0)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Images.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Images.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.People.Count == 0 || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Count == 0 || memorabilia != null && memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia != null && memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia != null && memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia != null && memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia != null && memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia != null && memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia != null && memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia != null && memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia != null && memorabilia.Images.Count == 0) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia != null && memorabilia.Images.Count != 0))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabilia != null && memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia != null && memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (memorabiliaSearchCriteria.People.Count == 0 || memorabilia != null && memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia != null && memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabilia != null && memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia != null && memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia != null && memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia != null && memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (memorabiliaSearchCriteria.Teams.Count == 0 || memorabilia != null && memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia != null && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && memorabilia != null && !memorabilia.ForTrade))
            orderby memorabiliaTransaction.TransactionDate descending
            group new { }
            by new
            {
                memorabiliaTransaction.Id,
                memorabiliaTransaction.TransactionTypeId,
                memorabiliaTransaction.TransactionDate,
                memorabiliaTransaction.UserId
            } into groupedList
            select new MemorabiliaTransaction(
                groupedList.Key.Id,
                groupedList.Key.TransactionTypeId,
                groupedList.Key.TransactionDate,
                groupedList.Key.UserId
                );

        PagedResult<MemorabiliaTransaction> result
            = await query.ToPagedResult(pageInfo);

        int[] memorabiliaTransactionIds = result.Data
                                                .Select(memorabiliaTransaction => memorabiliaTransaction.Id)
                                                .ToArray();

        if (memorabiliaTransactionIds.IsNullOrEmpty())
            return result;

        MemorabiliaTransaction[] memorabiliaTransactions
            = await TradeTransactions.Where(memorabiliaTransaction => memorabiliaTransactionIds.Contains(memorabiliaTransaction.Id))
                                     .ToArrayAsync();

        foreach (MemorabiliaTransaction item in result.Data)
        {
            MemorabiliaTransaction memorabiliaTransaction
                = memorabiliaTransactions.SingleOrDefault(memorabiliaTransaction => memorabiliaTransaction.Id == item.Id);

            if (memorabiliaTransaction == null)
                continue;

            item.Trades = memorabiliaTransaction.Trades;
        }

        return result;
    }    
}
