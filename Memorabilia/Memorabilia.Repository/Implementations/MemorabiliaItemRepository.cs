namespace Memorabilia.Repository.Implementations;

public class MemorabiliaItemRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<Entity.Memorabilia>(context, memoryCache), IMemorabiliaItemRepository
{
    public override async Task Add(Entity.Memorabilia item, 
                                   CancellationToken cancellationToken = default)
        => await base.Add(item, cancellationToken);

    public override async Task<Entity.Memorabilia> Get(int id)
        => await Items.SingleOrDefaultAsync(memorabilia => memorabilia.Id == id);

    public int[] GetAcquisitionTypeIds(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId 
                                   && memorabilia.MemorabiliaAcquisition.Acquisition != null
                                   && memorabilia.Sale == null 
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .Select(memorabilia => memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId)
                .ToArray();

    public async Task<Entity.Memorabilia[]> GetAll(int userId)
    {
        var query =
            from memorabilia in Context.Memorabilia
            join memorabiliaTransactionSale in Context.MemorabiliaTransactionSale on memorabilia.Id equals memorabiliaTransactionSale.MemorabiliaId into mts
            from memorabiliaTransactionSale in mts.DefaultIfEmpty()
            join memorabiliaTransactionTrade in Context.MemorabiliaTransactionTrade on memorabilia.Id equals memorabiliaTransactionTrade.MemorabiliaId into mtt
            from memorabiliaTransactionTrade in mtt.DefaultIfEmpty()
            where memorabilia.UserId == userId
               && (memorabiliaTransactionSale == null && (memorabiliaTransactionTrade == null || memorabiliaTransactionTrade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
            select new Entity.Memorabilia(memorabilia);

        return await query.ToArrayAsync();
    }

    public async Task<Entity.Memorabilia[]> GetAll(int[] ids)
    {
        Entity.Memorabilia[] items = await Items.Where(memorabilia => ids.Contains(memorabilia.Id)
                                                                   && memorabilia.Sale == null
                                                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id)
                                                      )
                                                .ToArrayAsync();

        return items;
    }

    public async Task<PagedResult<Entity.Memorabilia>> GetAll(int userId,
                                                              PageInfo pageInfo,
                                                              MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabilia in Context.Memorabilia
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
              && (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.None || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithAutographs && memorabilia.Autographs.Count != 0) || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithoutAutographs && memorabilia.Autographs.Count == 0))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count != 0)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Autographs.Any(autograph => autograph.Images.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Autographs.Any(autograph => autograph.Images.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.People.Count == 0 || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Count == 0 || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Images.Count == 0) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Images.Count != 0))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (memorabiliaSearchCriteria.People.Count == 0 || memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.None || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.ForSale && memorabilia.ForSale != null) || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.NotForSale && memorabilia.ForSale == null))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (memorabiliaSearchCriteria.Teams.Count == 0 || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && !memorabilia.ForTrade))
            orderby memorabilia.CreateDate descending
            select new Entity.Memorabilia(memorabilia);

        return await query.ToPagedResult(pageInfo);
    }    

    public async Task<PagedResult<Entity.Memorabilia>> GetAllByCollection(int collectionId,
                                                                          PageInfo pageInfo,
                                                                          MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabilia in Context.Memorabilia
            join collectionMemorabilia in Context.CollectionMemorabilia on memorabilia.Id equals collectionMemorabilia.MemorabiliaId
            join memorabiliaTransactionSale in Context.MemorabiliaTransactionSale on memorabilia.Id equals memorabiliaTransactionSale.MemorabiliaId into mts
            from memorabiliaTransactionSale in mts.DefaultIfEmpty()
            join memorabiliaTransactionTrade in Context.MemorabiliaTransactionTrade on memorabilia.Id equals memorabiliaTransactionTrade.MemorabiliaId into mtt
            from memorabiliaTransactionTrade in mtt.DefaultIfEmpty()
            where collectionMemorabilia.CollectionId == collectionId
              && (memorabiliaSearchCriteria.IncludeSold || memorabiliaTransactionSale == null)
              && (memorabiliaSearchCriteria.IncludeTraded || (memorabiliaTransactionTrade == null || memorabiliaTransactionTrade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
              && (!memorabiliaSearchCriteria.AcquiredDateBegin.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AcquiredDateBegin))
              && (!memorabiliaSearchCriteria.AcquiredDateEnd.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AcquiredDateEnd))
              && (!memorabiliaSearchCriteria.AcquisitionTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabiliaSearchCriteria.AcquisitionTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count != 0)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Autographs.Any(autograph => autograph.Images.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Autographs.Any(autograph => autograph.Images.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.People.Count == 0 || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Count == 0 || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Images.Count == 0) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Images.Count != 0))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (memorabiliaSearchCriteria.People.Count == 0 || memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.None || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.ForSale && memorabilia.ForSale != null) || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.NotForSale && memorabilia.ForSale == null))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (memorabiliaSearchCriteria.Teams.Count == 0 || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && !memorabilia.ForTrade))
            orderby memorabilia.CreateDate
            select new Entity.Memorabilia(memorabilia);

        return await query.ToPagedResult(pageInfo);
    }    

    public async Task<Entity.Memorabilia[]> GetAllForHelmetProject(int itemTypeId,
                                                                   int? teamId,
                                                                   int? typeId, 
                                                                   int? sizeId, 
                                                                   int? finishId, 
                                                                   int userId)
        => await Items.Where(memorabilia => memorabilia.UserId == userId
                                         && memorabilia.ItemTypeId == itemTypeId
                                         && (teamId == null || memorabilia.Teams.Any(team => team.TeamId == (int)teamId))
                                         && (typeId == null || (memorabilia.Helmet != null && memorabilia.Helmet.HelmetTypeId == typeId.Value))
                                         && (finishId == null || (memorabilia.Helmet != null && memorabilia.Helmet.HelmetFinishId == finishId.Value))
                                         && (sizeId == null || (memorabilia.Size != null && memorabilia.Size.SizeId == sizeId.Value))
                                         && memorabilia.Sale == null 
                                         && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id)
                            )
                      .ToArrayAsync();    

    public async Task<Entity.Memorabilia[]> GetAllForTeamProject(int itemTypeId,
                                                                 int? teamId, 
                                                                 int? teamYear,
                                                                 int userId)
        => await Items.Where(memorabilia => memorabilia.UserId == userId
                                         && memorabilia.ItemTypeId == itemTypeId
                                         && (teamId == null || memorabilia.Teams.Any(team => team.TeamId == (int)teamId))
                                         && memorabilia.Sale == null
                                         && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id)
                            )
                      .ToArrayAsync();

    public async Task<PagedResult<Entity.Memorabilia>> GetAllForTrade(int userId,
                                                                      PageInfo pageInfo,
                                                                      MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabilia in Context.Memorabilia
            join memorabiliaTransactionSale in Context.MemorabiliaTransactionSale on memorabilia.Id equals memorabiliaTransactionSale.MemorabiliaId into mts
            from memorabiliaTransactionSale in mts.DefaultIfEmpty()
            join memorabiliaTransactionTrade in Context.MemorabiliaTransactionTrade on memorabilia.Id equals memorabiliaTransactionTrade.MemorabiliaId into mtt
            from memorabiliaTransactionTrade in mtt.DefaultIfEmpty()
            where memorabilia.UserId == userId
              && memorabilia.ForTrade
              && (memorabiliaSearchCriteria.IncludeSold || memorabiliaTransactionSale == null)
              && (memorabiliaSearchCriteria.IncludeTraded || (memorabiliaTransactionTrade == null || memorabiliaTransactionTrade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
              && (!memorabiliaSearchCriteria.AcquiredDateBegin.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AcquiredDateBegin))
              && (!memorabiliaSearchCriteria.AcquiredDateEnd.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AcquiredDateEnd))
              && (!memorabiliaSearchCriteria.AcquisitionTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabiliaSearchCriteria.AcquisitionTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count != 0)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Autographs.Any(autograph => autograph.Images.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Autographs.Any(autograph => autograph.Images.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.People.Count == 0 || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Count == 0 || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Images.Count == 0) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Images.Count != 0))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (memorabiliaSearchCriteria.People.Count == 0 || memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.None || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.ForSale && memorabilia.ForSale != null) || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.NotForSale && memorabilia.ForSale == null))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (memorabiliaSearchCriteria.Teams.Count == 0 || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && !memorabilia.ForTrade))
            orderby memorabilia.CreateDate
            select new Entity.Memorabilia(memorabilia);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<PagedResult<Entity.Memorabilia>> GetAllHistory(int memorabiliaId, PageInfo pageInfo)
    {
        var query = context.Set<Entity.Memorabilia>()
                           .TemporalAll()
                           .Where(order => order.Id == memorabiliaId)
                           .Select(x => new Entity.Memorabilia(x));

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<PagedResult<Entity.Memorabilia>> GetAllPurchased(int userId, 
                                                                       PageInfo pageInfo,
                                                                       MemorabiliaSearchCriteria memorabiliaSearchCriteria = null)
    {
        var query =
            from memorabilia in Context.Memorabilia
            join memorabiliaTransactionSale in Context.MemorabiliaTransactionSale on memorabilia.Id equals memorabiliaTransactionSale.MemorabiliaId into mts
            from memorabiliaTransactionSale in mts.DefaultIfEmpty()
            join memorabiliaTransactionTrade in Context.MemorabiliaTransactionTrade on memorabilia.Id equals memorabiliaTransactionTrade.MemorabiliaId into mtt
            from memorabiliaTransactionTrade in mtt.DefaultIfEmpty()
            where memorabilia.UserId == userId
              && (memorabiliaSearchCriteria.IncludeSold || memorabiliaTransactionSale == null)
              && (memorabiliaSearchCriteria.IncludeTraded || (memorabiliaTransactionTrade == null || memorabiliaTransactionTrade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
              && ((memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId == Constant.AcquisitionType.Purchase.Id && memorabilia.Autographs.Count == 0)
                  || (memorabilia.Autographs.Count != 0 && memorabilia.MemorabiliaAcquisition != null && (memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredWithAutograph ?? false)))
              && (!memorabiliaSearchCriteria.AcquiredDateBegin.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AcquiredDateBegin))
              && (!memorabiliaSearchCriteria.AcquiredDateEnd.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AcquiredDateEnd))
              && (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.None || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithAutographs && memorabilia.Autographs.Count != 0) || (memorabiliaSearchCriteria.AutographFilter == Constant.AutographFilter.WithoutAutographs && memorabilia.Autographs.Count == 0))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate >= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateBegin.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.AcquiredDate <= memorabiliaSearchCriteria.AutographSearchCriteria.AcquiredDateEnd.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.AcquisitionTypeIds.Contains(autograph.Acquisition.AcquisitionTypeId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.NotAuthenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.AuthenticationFilter == Constant.AuthenticationFilter.Authenticated && memorabilia.Autographs.Any(autograph => autograph.Authentications.Count != 0)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ColorIds.Contains(autograph.ColorId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.ConditionIds.Contains(autograph.ConditionId)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost >= memorabiliaSearchCriteria.AutographSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.Acquisition.Cost <= memorabiliaSearchCriteria.AutographSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue >= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueLow.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.Autographs.Any(autograph => autograph.EstimatedValue <= memorabiliaSearchCriteria.AutographSearchCriteria.EstimatedValueHigh.Value))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.FranchiseId).Any(franchiseId => memorabiliaSearchCriteria.AutographSearchCriteria.FranchiseIds.Contains(franchiseId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.Grade.HasValue || memorabilia.Autographs.Any(autograph => autograph.Grade == memorabiliaSearchCriteria.AutographSearchCriteria.Grade.Value))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Autographs.Any(autograph => autograph.Images.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Autographs.Any(autograph => autograph.Images.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.NoInscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count == 0)) || (memorabiliaSearchCriteria.AutographSearchCriteria.InscriptionFilter == Constant.InscriptionFilter.Inscription && memorabilia.Autographs.Any(autograph => autograph.Inscriptions.Count != 0)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.People.Count == 0 || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.PersonIds.Contains(autograph.PersonId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.None || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.NotPersonalized && memorabilia.Autographs.Any(autograph => autograph.Personalization == null)) || (memorabiliaSearchCriteria.AutographSearchCriteria.PersonalizationFilter == Constant.PersonalizationFilter.Personalized && memorabilia.Autographs.Any(autograph => autograph.Personalization != null)))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Sports.Select(sport => sport.SportId).Any(sportId => memorabiliaSearchCriteria.AutographSearchCriteria.SportIds.Contains(sportId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id).Any(sportLeagueLevelId => memorabiliaSearchCriteria.AutographSearchCriteria.SportLeagueLevelIds.Contains(sportLeagueLevelId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.SpotIds.Contains(autograph.Spot.SpotId)))
              && (memorabiliaSearchCriteria.AutographSearchCriteria.Teams.Count == 0 || memorabilia.Autographs.Any(autograph => autograph.Person.Teams.Select(team => team.TeamId).Any(teamId => memorabiliaSearchCriteria.AutographSearchCriteria.TeamIds.Contains(teamId))))
              && (!memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Any() || memorabilia.Autographs.Any(autograph => memorabiliaSearchCriteria.AutographSearchCriteria.WritingInstrumentIds.Contains(autograph.WritingInstrumentId)))
              && (!memorabiliaSearchCriteria.BrandIds.Any() || (memorabilia.Brand != null && memorabiliaSearchCriteria.BrandIds.Contains(memorabilia.Brand.BrandId)))
              && (!memorabiliaSearchCriteria.ConditionIds.Any() || (memorabilia.ConditionId.HasValue && memorabiliaSearchCriteria.ConditionIds.Contains(memorabilia.ConditionId.Value)))
              && (!memorabiliaSearchCriteria.CostLow.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost >= memorabiliaSearchCriteria.CostLow.Value))
              && (!memorabiliaSearchCriteria.CostHigh.HasValue || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.Cost <= memorabiliaSearchCriteria.CostHigh.Value))
              && (!memorabiliaSearchCriteria.EstimatedValueLow.HasValue || memorabilia.EstimatedValue >= memorabiliaSearchCriteria.EstimatedValueLow.Value)
              && (!memorabiliaSearchCriteria.EstimatedValueHigh.HasValue || memorabilia.EstimatedValue <= memorabiliaSearchCriteria.EstimatedValueHigh.Value)
              && (!memorabiliaSearchCriteria.FranchiseIds.Any() || memorabilia.Teams.Select(team => team.Team.Franchise.Id).Any(franchiseId => memorabiliaSearchCriteria.FranchiseIds.Contains(franchiseId)))
              && (!memorabiliaSearchCriteria.GameStyleTypeIds.Any() || (memorabilia.Game != null && memorabiliaSearchCriteria.GameStyleTypeIds.Contains(memorabilia.Game.GameStyleTypeId)))
              && (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.None || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.NoImages && memorabilia.Images.Count == 0) || (memorabiliaSearchCriteria.ImageFilter == Constant.ImageFilter.Images && memorabilia.Images.Count != 0))
              && (!memorabiliaSearchCriteria.ItemTypeIds.Any() || memorabiliaSearchCriteria.ItemTypeIds.Contains(memorabilia.ItemTypeId))
              && (!memorabiliaSearchCriteria.LevelTypeIds.Any() || (memorabilia.LevelType != null && memorabiliaSearchCriteria.LevelTypeIds.Contains(memorabilia.LevelType.LevelTypeId)))
              && (memorabiliaSearchCriteria.People.Count == 0 || memorabilia.People.Any(person => memorabiliaSearchCriteria.PersonIds.Contains(person.PersonId)))
              && (!memorabiliaSearchCriteria.PurchaseTypeIds.Any() || (memorabilia.MemorabiliaAcquisition != null && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue && memorabiliaSearchCriteria.PurchaseTypeIds.Contains(memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)))
              && (!memorabiliaSearchCriteria.PrivacyTypeIds.Any() || memorabiliaSearchCriteria.PrivacyTypeIds.Contains(memorabilia.PrivacyTypeId))
              && (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.None || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.ForSale && memorabilia.ForSale != null) || (memorabiliaSearchCriteria.SaleFilter == Constant.SaleFilter.NotForSale && memorabilia.ForSale == null))
              && (!memorabiliaSearchCriteria.SizeIds.Any() || (memorabilia.Size != null && memorabiliaSearchCriteria.SizeIds.Contains(memorabilia.Size.SizeId)))
              && (!memorabiliaSearchCriteria.SportIds.Any() || memorabilia.Sports.Any(sport => memorabiliaSearchCriteria.SportIds.Contains(sport.SportId)))
              && (!memorabiliaSearchCriteria.SportLeagueLevelIds.Any() || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.SportLeagueLevelIds.Contains(team.Team.Franchise.SportLeagueLevel.Id)))
              && (memorabiliaSearchCriteria.Teams.Count == 0 || memorabilia.Teams.Any(team => memorabiliaSearchCriteria.TeamIds.Contains(team.TeamId)))
              && (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.None || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.ForTrade && memorabilia.ForTrade) || (memorabiliaSearchCriteria.TradeFilter == Constant.TradeFilter.NotForTrade && !memorabilia.ForTrade))
            orderby memorabilia.MemorabiliaAcquisition.Acquisition.AcquiredDate descending
            select new Entity.Memorabilia(memorabilia);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<Entity.Memorabilia[]> GetAllUnsigned(int userId)
        => await Items.Where(memorabilia => memorabilia.UserId == userId 
                                         && memorabilia.Autographs.Count == 0
                                         && memorabilia.Sale == null
                                         && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                            .ToArrayAsync();

    public int[] GetBrandIds(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId 
                                   && memorabilia.Brand != null
                                   && memorabilia.Sale == null
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .Select(memorabilia => memorabilia.Brand.BrandId)
                .ToArray();

    public int[] GetConditionIds(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId 
                                   && memorabilia.ConditionId.HasValue
                                   && memorabilia.Sale == null
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .Select(memorabilia => memorabilia.ConditionId.Value)
                .ToArray();

    public decimal GetCostTotal(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId 
                                   && memorabilia.MemorabiliaAcquisition.Acquisition != null
                                   && memorabilia.Sale == null
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .Sum(memorabilia => memorabilia.MemorabiliaAcquisition.Acquisition.Cost ?? 0);

    public decimal GetEstimatedValueTotal(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId
                                   && memorabilia.Sale == null
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .Sum(memorabilia => memorabilia.EstimatedValue ?? 0);

    public int[] GetFranchiseIds(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId 
                                   && memorabilia.Teams.Count != 0
                                   && memorabilia.Sale == null
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .SelectMany(memorabilia => memorabilia.Teams.Select(team => team.Team.Franchise.Id))
                .ToArray();

    public int[] GetPurchaseTypeIds(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId 
                                   && memorabilia.MemorabiliaAcquisition.Acquisition != null 
                                   && memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.HasValue
                                   && memorabilia.Sale == null
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .Select(memorabilia => memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId.Value)
                .ToArray();

    public int[] GetItemTypeIds(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId
                                   && memorabilia.Sale == null
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .Select(memorabilia => memorabilia.ItemTypeId)
                .ToArray();

    public int[] GetSizeIds(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId 
                                   && memorabilia.Size != null
                                   && memorabilia.Sale == null
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .Select(memorabilia => memorabilia.Size.SizeId)
                .ToArray();

    public int[] GetSportIds(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId 
                                   && memorabilia.Sports.Count != 0
                                   && memorabilia.Sale == null
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id))
                .SelectMany(memorabilia => memorabilia.Sports.Select(sport => sport.SportId))
                .ToArray();

    public int[] GetSportLeagueLevelIds(int userId)
        => Items.Where(memorabilia => memorabilia.UserId == userId 
                                   && memorabilia.Teams.Count != 0
                                   && memorabilia.Sale == null 
                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id)     )
                .SelectMany(memorabilia => memorabilia.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.Id))
                .ToArray();

    public async Task<bool> HasItemsForSale(int userId)
    {
        Entity.Memorabilia[] items = await Items.Where(memorabilia => memorabilia.UserId == userId
                                                                   && memorabilia.ForSale != null
                                                                   && memorabilia.Sale == null
                                                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id)
                                                      )
                                                .ToArrayAsync() ?? [];

        return items.HasAny();
    }

    public async Task<bool> HasItemsForTrade(int userId)
    {
        Entity.Memorabilia[] items = await Items.Where(memorabilia => memorabilia.UserId == userId
                                                                   && memorabilia.ForTrade
                                                                   && memorabilia.Sale == null
                                                                   && (memorabilia.Trade == null || memorabilia.Trade.TransactionTradeTypeId != Constant.TransactionTradeType.Sent.Id)
                                                      )
                                                .ToArrayAsync() ?? [];

        return items.HasAny();
    }
}
