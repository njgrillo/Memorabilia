USE [Memorabilia]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DECLARE @KeepExistingValues INT = 1
DECLARE @LoadInitialValues INT = 0

--AutographAuthentication - FK - AutographId, AuthenticationCompanyId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AutographAuthentication')
BEGIN
	IF OBJECT_ID('tempdb..#TempAutographAuthenticationTable') IS NOT NULL DROP TABLE #TempAutographAuthenticationTable; 

	SELECT * 
	INTO #TempAutographAuthenticationTable
	FROM [dbo].[AutographAuthentication]

	DROP TABLE [dbo].[AutographAuthentication]
END

--AutographImage Drop - FK - AutographId, ImageTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AutographImage')
BEGIN
	IF OBJECT_ID('tempdb..#TempAutographImageTable') IS NOT NULL DROP TABLE #TempAutographImageTable; 

	SELECT * 
	INTO #TempAutographImageTable
	FROM [dbo].[AutographImage]

	DROP TABLE [dbo].[AutographImage]
END

--AutographSpot Drop - FK - AutographId, SpotId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AutographSpot')
BEGIN
	IF OBJECT_ID('tempdb..#TempAutographSpotTable') IS NOT NULL DROP TABLE #TempAutographSpotTable; 

	SELECT * 
	INTO #TempAutographSpotTable
	FROM [dbo].[AutographSpot]

	DROP TABLE [dbo].[AutographSpot]
END

--AutographThroughTheMail Drop - FK - AutographId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AutographThroughTheMail')
BEGIN
	IF OBJECT_ID('tempdb..#TempAutographThroughTheMailTable') IS NOT NULL DROP TABLE #TempAutographThroughTheMailTable; 

	SELECT * 
	INTO #TempAutographThroughTheMailTable
	FROM [dbo].[AutographThroughTheMail]

	DROP TABLE [dbo].[AutographThroughTheMail]
END

--Event Drop - FK - AcquisitionTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Event')
BEGIN
	IF OBJECT_ID('tempdb..#TempEventTable') IS NOT NULL DROP TABLE #TempEventTable; 

	SELECT * 
	INTO #TempEventTable
	FROM [dbo].[Event]

	DROP TABLE [dbo].[Event]
END

--HallOfFame Drop - FK - FranchiseId, LevelTypeId, PersonId, SportId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'HallOfFame')
BEGIN
	IF OBJECT_ID('tempdb..#TempHallOfFameTable') IS NOT NULL DROP TABLE #TempHallOfFameTable; 

	SELECT * 
	INTO #TempHallOfFameTable
	FROM [dbo].[HallOfFame]

	DROP TABLE [dbo].[HallOfFame]
END

--Inscription Drop - FK - AutographId, InscriptionTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Inscription')
BEGIN
	IF OBJECT_ID('tempdb..#TempInscriptionTable') IS NOT NULL DROP TABLE #TempInscriptionTable; 

	SELECT * 
	INTO #TempInscriptionTable
	FROM [dbo].[Inscription]

	DROP TABLE [dbo].[Inscription]
END

--ItemTypeBrand - FK - BrandId, ItemTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeBrand')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeBrandTable') IS NOT NULL DROP TABLE #TempItemTypeBrandTable; 

	SELECT * 
	INTO #TempItemTypeBrandTable
	FROM [dbo].[ItemTypeBrand]

	DROP TABLE [dbo].[ItemTypeBrand]
END

--ItemTypeGameStyleType - FK - GameStyleTypeId, ItemTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeGameStyleType')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeGameStyleTypeTable') IS NOT NULL DROP TABLE #TempItemTypeGameStyleTypeTable; 

	SELECT * 
	INTO #TempItemTypeGameStyleTypeTable
	FROM [dbo].[ItemTypeGameStyleType]

	DROP TABLE [dbo].[ItemTypeGameStyleType]
END

--ItemTypeLevel - FK - ItemTypeId, LevelTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeLevel')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeLevelTable') IS NOT NULL DROP TABLE #TempItemTypeLevelTable; 

	SELECT * 
	INTO #TempItemTypeLevelTable
	FROM [dbo].[ItemTypeLevel]

	DROP TABLE [dbo].[ItemTypeLevel]
END

--ItemTypeSize - FK - ItemTypeId, SizeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeSize')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeSizeTable') IS NOT NULL DROP TABLE #TempItemTypeSizeTable; 

	SELECT * 
	INTO #TempItemTypeSizeTable
	FROM [dbo].[ItemTypeSize]

	DROP TABLE [dbo].[ItemTypeSize]
END

--ItemTypeSport - FK - ItemTypeId, SportId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeSport')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeSportTable') IS NOT NULL DROP TABLE #TempItemTypeSportTable; 

	SELECT * 
	INTO #TempItemTypeSportTable
	FROM [dbo].[ItemTypeSport]

	DROP TABLE [dbo].[ItemTypeSport]
END

--ItemTypeSpot - FK - ItemTypeId, SpotId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeSpot')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeSpotTable') IS NOT NULL DROP TABLE #TempItemTypeSpotTable; 

	SELECT * 
	INTO #TempItemTypeSpotTable
	FROM [dbo].[ItemTypeSpot]

	DROP TABLE [dbo].[ItemTypeSpot]
END

--MemorabiliaAcquisition Drop - FK - MemorabiliaId, AcquisitionId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaAcquisition')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaAcquisitionTable') IS NOT NULL DROP TABLE #TempMemorabiliaAcquisitionTable; 

	SELECT * 
	INTO #TempMemorabiliaAcquisitionTable
	FROM [dbo].[MemorabiliaAcquisition]

	DROP TABLE [dbo].[MemorabiliaAcquisition]
END

--MemorabiliaBaseball Drop - FK - MemorabiliaId, BaseballTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaBaseball')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaBaseballTable') IS NOT NULL DROP TABLE #TempMemorabiliaBaseballTable; 

	SELECT * 
	INTO #TempMemorabiliaBaseballTable
	FROM [dbo].[MemorabiliaBaseball]

	DROP TABLE [dbo].[MemorabiliaBaseball]
END

--MemorabiliaBasketball Drop - FK - MemorabiliaId, BasketballTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaBasketball')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaBasketballTable') IS NOT NULL DROP TABLE #TempMemorabiliaBasketballTable; 

	SELECT * 
	INTO #TempMemorabiliaBasketballTable
	FROM [dbo].[MemorabiliaBasketball]

	DROP TABLE [dbo].[MemorabiliaBasketball]
END

--MemorabiliaBat Drop - FK - MemorabiliaId, BatTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaBat')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaBatTable') IS NOT NULL DROP TABLE #TempMemorabiliaBatTable; 

	SELECT * 
	INTO #TempMemorabiliaBatTable
	FROM [dbo].[MemorabiliaBat]

	DROP TABLE [dbo].[MemorabiliaBat]
END

--MemorabiliaBook Drop - FK - MemorabiliaId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaBook')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaBookTable') IS NOT NULL DROP TABLE #TempMemorabiliaBookTable; 

	SELECT * 
	INTO #TempMemorabiliaBookTable
	FROM [dbo].[MemorabiliaBook]

	DROP TABLE [dbo].[MemorabiliaBook]
END

--MemorabiliaBrand Drop - FK - MemorabiliaId, BrandId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaBrand')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaBrandTable') IS NOT NULL DROP TABLE #TempMemorabiliaBrandTable; 

	SELECT * 
	INTO #TempMemorabiliaBrandTable
	FROM [dbo].[MemorabiliaBrand]

	DROP TABLE [dbo].[MemorabiliaBrand]
END

--MemorabiliaCanvas Drop  - FK - MemorabiliaId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaCanvas')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaCanvasTable') IS NOT NULL DROP TABLE #TempMemorabiliaCanvasTable; 

	SELECT * 
	INTO #TempMemorabiliaCanvasTable
	FROM [dbo].[MemorabiliaCanvas]

	DROP TABLE [dbo].[MemorabiliaCanvas]
END

--MemorabiliaCard Drop - FK - MemorabiliaId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaCard')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaCardTable') IS NOT NULL DROP TABLE #TempMemorabiliaCardTable; 

	SELECT * 
	INTO #TempMemorabiliaCardTable
	FROM [dbo].[MemorabiliaCard]

	DROP TABLE [dbo].[MemorabiliaCard]
END

--MemorabiliaCommissioner Drop - FK - MemorabiliaId, CommissionerId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaCommissioner')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaCommissionerTable') IS NOT NULL DROP TABLE #TempMemorabiliaCommissionerTable; 

	SELECT * 
	INTO #TempMemorabiliaCommissionerTable
	FROM [dbo].[MemorabiliaCommissioner]

	DROP TABLE [dbo].[MemorabiliaCommissioner]
END

--MemorabiliaFigure Drop - FK - MemorabiliaId, FigureTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaFigure')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaFigureTable') IS NOT NULL DROP TABLE #TempMemorabiliaFigureTable; 

	SELECT * 
	INTO #TempMemorabiliaFigureTable
	FROM [dbo].[MemorabiliaFigure]

	DROP TABLE [dbo].[MemorabiliaFigure]
END

--MemorabiliaFootball Drop - FK - MemorabiliaId, FootballTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaFootball')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaFootballTable') IS NOT NULL DROP TABLE #TempMemorabiliaFootballTable; 

	SELECT * 
	INTO #TempMemorabiliaFootballTable
	FROM [dbo].[MemorabiliaFootball]

	DROP TABLE [dbo].[MemorabiliaFootball]
END

--MemorabiliaGame Drop - FK - MemorabiliaId, GameStyleTypeId, PersonId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaGame')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaGameTable') IS NOT NULL DROP TABLE #TempMemorabiliaGameTable; 

	SELECT * 
	INTO #TempMemorabiliaGameTable
	FROM [dbo].[MemorabiliaGame]

	DROP TABLE [dbo].[MemorabiliaGame]
END

--MemorabiliaHelmet Drop - FK - MemorabiliaId, HelmetQualityTypeId, HelmetTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaHelmet')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaHelmetTable') IS NOT NULL DROP TABLE #TempMemorabiliaHelmetTable; 

	SELECT * 
	INTO #TempMemorabiliaHelmetTable
	FROM [dbo].[MemorabiliaHelmet]

	DROP TABLE [dbo].[MemorabiliaHelmet]
END

--MemorabiliaImage Drop - FK - MemorabiliaId, ImageTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaImage')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaImageTable') IS NOT NULL DROP TABLE #TempMemorabiliaImageTable; 

	SELECT * 
	INTO #TempMemorabiliaImageTable
	FROM [dbo].[MemorabiliaImage]

	DROP TABLE [dbo].[MemorabiliaImage]
END

--MemorabiliaJersey Drop  - FK - MemorabiliaId, JerseyQualityTypeId, JerseyStyleTypeId, JerseyTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaJersey')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaJerseyTable') IS NOT NULL DROP TABLE #TempMemorabiliaJerseyTable; 

	SELECT * 
	INTO #TempMemorabiliaJerseyTable
	FROM [dbo].[MemorabiliaJersey]

	DROP TABLE [dbo].[MemorabiliaJersey]
END

--MemorabiliaLevelType Drop - FK - MemorabiliaId, LevelTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaLevelType')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaLevelTypeTable') IS NOT NULL DROP TABLE #TempMemorabiliaLevelTypeTable; 

	SELECT * 
	INTO #TempMemorabiliaLevelTypeTable
	FROM [dbo].[MemorabiliaLevelType]

	DROP TABLE [dbo].[MemorabiliaLevelType]
END

--MemorabiliaLithograph Drop  - FK - MemorabiliaId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaLithograph')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaLithographTable') IS NOT NULL DROP TABLE #TempMemorabiliaLithographTable; 

	SELECT * 
	INTO #TempMemorabiliaLithographTable
	FROM [dbo].[MemorabiliaLithograph]

	DROP TABLE [dbo].[MemorabiliaLithograph]
END

--MemorabilaMagazine Drop  - FK - MemorabiliaId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaMagazine')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaMagazineTable') IS NOT NULL DROP TABLE #TempMemorabiliaMagazineTable; 

	SELECT * 
	INTO #TempMemorabiliaMagazineTable
	FROM [dbo].[MemorabiliaMagazine]

	DROP TABLE [dbo].[MemorabiliaMagazine]
END

--MemorabiliaOrientation Drop - FK - MemorabiliaId, OrientationId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaOrientation')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaOrientationTable') IS NOT NULL DROP TABLE #TempMemorabiliaOrientationTable; 

	SELECT * 
	INTO #TempMemorabiliaOrientationTable
	FROM [dbo].[MemorabiliaOrientation]

	DROP TABLE [dbo].[MemorabiliaOrientation]
END

--MemorabiliaPerson Drop - FK - MemorabiliaId, PersonId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaPerson')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaPersonTable') IS NOT NULL DROP TABLE #TempMemorabiliaPersonTable; 

	SELECT * 
	INTO #TempMemorabiliaPersonTable
	FROM [dbo].[MemorabiliaPerson]

	DROP TABLE [dbo].[MemorabiliaPerson]
END

--MemorabiliaPhoto Drop  - FK - MemorabiliaId, PhotoTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaPhoto')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaPhotoTable') IS NOT NULL DROP TABLE #TempMemorabiliaPhotoTable; 

	SELECT * 
	INTO #TempMemorabiliaPhotoTable
	FROM [dbo].[MemorabiliaPhoto]

	DROP TABLE [dbo].[MemorabiliaPhoto]
END

--MemorabiliaSize Drop  - FK - MemorabiliaId, SizeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaSize')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaSizeTable') IS NOT NULL DROP TABLE #TempMemorabiliaSizeTable; 

	SELECT * 
	INTO #TempMemorabiliaSizeTable
	FROM [dbo].[MemorabiliaSize]

	DROP TABLE [dbo].[MemorabiliaSize]
END

--MemorabiliaSport Drop - FK - MemorabiliaId, SportId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaSport')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaSportTable') IS NOT NULL DROP TABLE #TempMemorabiliaSportTable; 

	SELECT * 
	INTO #TempMemorabiliaSportTable
	FROM [dbo].[MemorabiliaSport]

	DROP TABLE [dbo].[MemorabiliaSport]
END

--MemorabiliaTeam Drop - FK - MemorabiliaId, TeamId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaTeam')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaTeamTable') IS NOT NULL DROP TABLE #TempMemorabiliaTeamTable; 

	SELECT * 
	INTO #TempMemorabiliaTeamTable
	FROM [dbo].[MemorabiliaTeam]

	DROP TABLE [dbo].[MemorabiliaTeam]
END

--Personalization Drop - FK - AutographId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Personalization')
BEGIN
	IF OBJECT_ID('tempdb..#TempPersonalizationTable') IS NOT NULL DROP TABLE #TempPersonalizationTable; 

	SELECT * 
	INTO #TempPersonalizationTable
	FROM [dbo].[Personalization]

	DROP TABLE [dbo].[Personalization]
END

--PersonOccupation Drop - FK - PersonId, OccupationId, OccupationTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PersonOccupation')
BEGIN
	IF OBJECT_ID('tempdb..#TempPersonOccupationTable') IS NOT NULL DROP TABLE #TempPersonOccupationTable; 

	SELECT * 
	INTO #TempPersonOccupationTable
	FROM [dbo].[PersonOccupation]

	DROP TABLE [dbo].[PersonOccupation]
END

--PersonTeam Drop - FK - PersonId, TeamId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PersonTeam')
BEGIN
	IF OBJECT_ID('tempdb..#TempPersonTeamTable') IS NOT NULL DROP TABLE #TempPersonTeamTable; 

	SELECT * 
	INTO #TempPersonTeamTable
	FROM [dbo].[PersonTeam]

	DROP TABLE [dbo].[PersonTeam]
END

--Pewter Drop - FK - FranchiseId, SizeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Pewter')
BEGIN
	IF OBJECT_ID('tempdb..#TempPewterTable') IS NOT NULL DROP TABLE #TempPewterTable; 

	SELECT * 
	INTO #TempPewterTable
	FROM [dbo].[Pewter]

	DROP TABLE [dbo].[Pewter]
END

--TeamConference Drop - FK - ConferenceId, TeamId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'TeamConference')
BEGIN
	IF OBJECT_ID('tempdb..#TempTeamConferenceTable') IS NOT NULL DROP TABLE #TempTeamConferenceTable; 

	SELECT * 
	INTO #TempTeamConferenceTable
	FROM [dbo].[TeamConference]

	DROP TABLE [dbo].[TeamConference]
END

--TeamDivision Drop - FK - DivisionId, TeamId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'TeamDivision')
BEGIN
	IF OBJECT_ID('tempdb..#TempTeamDivisionTable') IS NOT NULL DROP TABLE #TempTeamDivisionTable; 

	SELECT * 
	INTO #TempTeamDivisionTable
	FROM [dbo].[TeamDivision]

	DROP TABLE [dbo].[TeamDivision]
END

--TeamLeague Drop - FK - LeagueId, TeamId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'TeamLeague')
BEGIN
	IF OBJECT_ID('tempdb..#TempTeamLeagueTable') IS NOT NULL DROP TABLE #TempTeamLeagueTable; 

	SELECT * 
	INTO #TempTeamLeagueTable
	FROM [dbo].[TeamLeague]

	DROP TABLE [dbo].[TeamLeague]
END

--WishList Drop - FK - ItemTypeId, PersonId, UserId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'WishList')
BEGIN
	IF OBJECT_ID('tempdb..#TempWishListTable') IS NOT NULL DROP TABLE #TempWishListTable; 

	SELECT * 
	INTO #TempWishListTable
	FROM [dbo].[WishList]

	DROP TABLE [dbo].[WishList]
END

--Autograph Drop - FK - AcquisitionId, ColorId, ConditionId, MemorabiliaId, PersonId,  WritingInstrumentId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Autograph')
BEGIN
	IF OBJECT_ID('tempdb..#TempAutographTable') IS NOT NULL DROP TABLE #TempAutographTable; 

	SELECT * 
	INTO #TempAutographTable
	FROM [dbo].[Autograph]

	DROP TABLE [dbo].[Autograph]
END

--Memorabilia Drop - FK - ConditionId, ItemTypeId, PrivacyTypeId, UserId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Memorabilia')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaTable') IS NOT NULL DROP TABLE #TempMemorabiliaTable; 

	SELECT * 
	INTO #TempMemorabiliaTable
	FROM [dbo].[Memorabilia]

	DROP TABLE [dbo].[Memorabilia]
END

--Start Dropping Domain Tables
--Acquisition Drop - FK - AcquisitionTypeId, PurchaseTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Acquisition')
BEGIN
	IF OBJECT_ID('tempdb..#TempAcquisitionTable') IS NOT NULL DROP TABLE #TempAcquisitionTable; 

	SELECT * 
	INTO #TempAcquisitionTable
	FROM [dbo].[Acquisition]

	DROP TABLE [dbo].[Acquisition]
END

--AcquisitionType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AcquisitionType')
BEGIN
	IF OBJECT_ID('tempdb..#TempAcquisitionTypeTable') IS NOT NULL DROP TABLE #TempAcquisitionTypeTable; 

	SELECT * 
	INTO #TempAcquisitionTypeTable
	FROM [dbo].[AcquisitionType]

	DROP TABLE [dbo].[AcquisitionType]
END

--AuthenticationCompany Drop 
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AuthenticationCompany')
BEGIN
	IF OBJECT_ID('tempdb..#TempAuthenticationCompanyTable') IS NOT NULL DROP TABLE #TempAuthenticationCompanyTable; 

	SELECT * 
	INTO #TempAuthenticationCompanyTable
	FROM [dbo].[AuthenticationCompany]

	DROP TABLE [dbo].[AuthenticationCompany]
END

--BaseballType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BaseballType')
BEGIN
	IF OBJECT_ID('tempdb..#TempBaseballTypeTable') IS NOT NULL DROP TABLE #TempBaseballTypeTable; 

	SELECT * 
	INTO #TempBaseballTypeTable
	FROM [dbo].[BaseballType]

	DROP TABLE [dbo].[BaseballType]
END

--BasketballType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BasketballType')
BEGIN
	IF OBJECT_ID('tempdb..#TempBasketballTypeTable') IS NOT NULL DROP TABLE #TempBasketballTypeTable; 

	SELECT * 
	INTO #TempBasketballTypeTable
	FROM [dbo].[BasketballType]

	DROP TABLE [dbo].[BasketballType]
END

--BatType Drop 
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BatType')
BEGIN
	IF OBJECT_ID('tempdb..#TempBatTypeTable') IS NOT NULL DROP TABLE #TempBatTypeTable; 

	SELECT * 
	INTO #TempBatTypeTable
	FROM [dbo].[BatType]

	DROP TABLE [dbo].[BatType]
END

--Brand Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Brand')
BEGIN
	IF OBJECT_ID('tempdb..#TempBrandTable') IS NOT NULL DROP TABLE #TempBrandTable; 

	SELECT * 
	INTO #TempBrandTable
	FROM [dbo].[Brand]

	DROP TABLE [dbo].[Brand]
END

--CardType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CardType')
BEGIN
	IF OBJECT_ID('tempdb..#TempCardTypeTable') IS NOT NULL DROP TABLE #TempCardTypeTable; 

	SELECT * 
	INTO #TempCardTypeTable
	FROM [dbo].[CardType]

	DROP TABLE [dbo].[CardType]
END

--Color Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Color')
BEGIN
	IF OBJECT_ID('tempdb..#TempColorTable') IS NOT NULL DROP TABLE #TempColorTable; 

	SELECT * 
	INTO #TempColorTable
	FROM [dbo].[Color]

	DROP TABLE [dbo].[Color]
END

--Commissioner Drop - PersonId, SportId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Commissioner')
BEGIN
	IF OBJECT_ID('tempdb..#TempCommissionerTable') IS NOT NULL DROP TABLE #TempCommissionerTable; 

	SELECT * 
	INTO #TempCommissionerTable
	FROM [dbo].[Commissioner]

	DROP TABLE [dbo].[Commissioner]
END

--Condition Drop 
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Condition')
BEGIN
	IF OBJECT_ID('tempdb..#TempConditionTable') IS NOT NULL DROP TABLE #TempConditionTable; 

	SELECT * 
	INTO #TempConditionTable
	FROM [dbo].[Condition]

	DROP TABLE [dbo].[Condition]
END

--Division Drop - ConferenceId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Division')
BEGIN
	IF OBJECT_ID('tempdb..#TempDivisionTable') IS NOT NULL DROP TABLE #TempDivisionTable; 

	SELECT * 
	INTO #TempDivisionTable
	FROM [dbo].[Division]

	DROP TABLE [dbo].[Division]
END

--FigureSpecialtyType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FigureSpecialtyType')
BEGIN
	IF OBJECT_ID('tempdb..#TempFigureSpecialtyTypeTable') IS NOT NULL DROP TABLE #TempFigureSpecialtyTypeTable; 

	SELECT * 
	INTO #TempFigureSpecialtyTypeTable
	FROM [dbo].[FigureSpecialtyType]

	DROP TABLE [dbo].[FigureSpecialtyType]
END

--FigureType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FigureType')
BEGIN
	IF OBJECT_ID('tempdb..#TempFigureTypeTable') IS NOT NULL DROP TABLE #TempFigureTypeTable; 

	SELECT * 
	INTO #TempFigureTypeTable
	FROM [dbo].[FigureType]

	DROP TABLE [dbo].[FigureType]
END

--FootballType
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FootballType')
BEGIN
	IF OBJECT_ID('tempdb..#TempFootballTypeTable') IS NOT NULL DROP TABLE #TempFootballTypeTable; 

	SELECT * 
	INTO #TempFootballTypeTable
	FROM [dbo].[FootballType]

	DROP TABLE [dbo].[FootballType]
END

--GameStyleType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GameStyleType')
BEGIN
	IF OBJECT_ID('tempdb..#TempGameStyleTypeTable') IS NOT NULL DROP TABLE #TempGameStyleTypeTable; 

	SELECT * 
	INTO #TempGameStyleTypeTable
	FROM [dbo].[GameStyleType]

	DROP TABLE [dbo].[GameStyleType]
END

--GloveType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GloveType')
BEGIN
	IF OBJECT_ID('tempdb..#TempGloveTypeTable') IS NOT NULL DROP TABLE #TempGloveTypeTable; 

	SELECT * 
	INTO #TempGloveTypeTable
	FROM [dbo].[GloveType]

	DROP TABLE [dbo].[GloveType]
END

--HelmetFinish Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'HelmetFinish')
BEGIN
	IF OBJECT_ID('tempdb..#TempHelmetFinishTable') IS NOT NULL DROP TABLE #TempHelmetFinishTable; 

	SELECT * 
	INTO #TempHelmetFinishTable
	FROM [dbo].[HelmetFinish]

	DROP TABLE [dbo].[HelmetFinish]
END

--HelmetQualityType Drop 
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'HelmetQualityType')
BEGIN
	IF OBJECT_ID('tempdb..#TempHelmetQualityTypeTable') IS NOT NULL DROP TABLE #TempHelmetQualityTypeTable; 

	SELECT * 
	INTO #TempHelmetQualityTypeTable
	FROM [dbo].[HelmetQualityType]

	DROP TABLE [dbo].[HelmetQualityType]
END

--HelmetType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'HelmetType')
BEGIN
	IF OBJECT_ID('tempdb..#TempHelmetTypeTable') IS NOT NULL DROP TABLE #TempHelmetTypeTable; 

	SELECT * 
	INTO #TempHelmetTypeTable
	FROM [dbo].[HelmetType]

	DROP TABLE [dbo].[HelmetType]
END

--ItemType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemType')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeTable') IS NOT NULL DROP TABLE #TempItemTypeTable; 

	SELECT * 
	INTO #TempItemTypeTable
	FROM [dbo].[ItemType]

	DROP TABLE [dbo].[ItemType]
END

--ImageType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ImageType')
BEGIN
	IF OBJECT_ID('tempdb..#TempImageTypeTable') IS NOT NULL DROP TABLE #TempImageTypeTable; 

	SELECT * 
	INTO #TempImageTypeTable
	FROM [dbo].[ImageType]

	DROP TABLE [dbo].[ImageType]
END

--InscriptionType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'InscriptionType')
BEGIN
	IF OBJECT_ID('tempdb..#TempInscriptionTypeTable') IS NOT NULL DROP TABLE #TempInscriptionTypeTable; 

	SELECT * 
	INTO #TempInscriptionTypeTable
	FROM [dbo].[InscriptionType]

	DROP TABLE [dbo].[InscriptionType]
END

--JerseyQualityType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'JerseyQualityType')
BEGIN
	IF OBJECT_ID('tempdb..#TempJerseyQualityTypeTable') IS NOT NULL DROP TABLE #TempJerseyQualityTypeTable; 

	SELECT * 
	INTO #TempJerseyQualityTypeTable
	FROM [dbo].[JerseyQualityType]

	DROP TABLE [dbo].[JerseyQualityType]
END

--JerseyStyleType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'JerseyStyleType')
BEGIN
	IF OBJECT_ID('tempdb..#TempJerseyStyleTypeTable') IS NOT NULL DROP TABLE #TempJerseyStyleTypeTable; 

	SELECT * 
	INTO #TempJerseyStyleTypeTable
	FROM [dbo].[JerseyStyleType]

	DROP TABLE [dbo].[JerseyStyleType]
END

--JerseyType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'JerseyType')
BEGIN
	IF OBJECT_ID('tempdb..#TempJerseyTypeTable') IS NOT NULL DROP TABLE #TempJerseyTypeTable; 

	SELECT * 
	INTO #TempJerseyTypeTable
	FROM [dbo].[JerseyType]

	DROP TABLE [dbo].[JerseyType]
END

--League Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'League')
BEGIN
	IF OBJECT_ID('tempdb..#TempLeagueTable') IS NOT NULL DROP TABLE #TempLeagueTable; 

	SELECT * 
	INTO #TempLeagueTable
	FROM [dbo].[League]

	DROP TABLE [dbo].[League]
END

--MagazineType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MagazineType')
BEGIN
	IF OBJECT_ID('tempdb..#TempMagazineTypeTable') IS NOT NULL DROP TABLE #TempMagazineTypeTable; 

	SELECT * 
	INTO #TempMagazineTypeTable
	FROM [dbo].[MagazineType]

	DROP TABLE [dbo].[MagazineType]
END

--Occupation Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Occupation')
BEGIN
	IF OBJECT_ID('tempdb..#TempOccupationTable') IS NOT NULL DROP TABLE #TempOccupationTable; 

	SELECT * 
	INTO #TempOccupationTable
	FROM [dbo].[Occupation]

	DROP TABLE [dbo].[Occupation]
END

--OccupationType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'OccupationType')
BEGIN
	IF OBJECT_ID('tempdb..#TempOccupationTypeTable') IS NOT NULL DROP TABLE #TempOccupationTypeTable; 

	SELECT * 
	INTO #TempOccupationTypeTable
	FROM [dbo].[OccupationType]

	DROP TABLE [dbo].[OccupationType]
END

--Orientation Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Orientation')
BEGIN
	IF OBJECT_ID('tempdb..#TempOrientationTable') IS NOT NULL DROP TABLE #TempOrientationTable; 

	SELECT * 
	INTO #TempOrientationTable
	FROM [dbo].[Orientation]

	DROP TABLE [dbo].[Orientation]
END

--Person Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Person')
BEGIN
	IF OBJECT_ID('tempdb..#TempPersonTable') IS NOT NULL DROP TABLE #TempPersonTable; 

	SELECT * 
	INTO #TempPersonTable
	FROM [dbo].[Person]

	DROP TABLE [dbo].[Person]
END

--PhotoType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PhotoType')
BEGIN
	IF OBJECT_ID('tempdb..#TempPhotoTypeTable') IS NOT NULL DROP TABLE #TempPhotoTypeTable; 

	SELECT * 
	INTO #TempPhotoTypeTable
	FROM [dbo].[PhotoType]

	DROP TABLE [dbo].[PhotoType]
END

--PrivacyType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PrivacyType')
BEGIN
	IF OBJECT_ID('tempdb..#TempPrivacyTypeTable') IS NOT NULL DROP TABLE #TempPrivacyTypeTable; 

	SELECT * 
	INTO #TempPrivacyTypeTable
	FROM [dbo].[PrivacyType]

	DROP TABLE [dbo].[PrivacyType]
END

--PurchaseType Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PurchaseType')
BEGIN
	IF OBJECT_ID('tempdb..#TempPurchaseTypeTable') IS NOT NULL DROP TABLE #TempPurchaseTypeTable; 

	SELECT * 
	INTO #TempPurchaseTypeTable
	FROM [dbo].[PurchaseType]

	DROP TABLE [dbo].[PurchaseType]
END

--Size Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Size')
BEGIN
	IF OBJECT_ID('tempdb..#TempSizeTable') IS NOT NULL DROP TABLE #TempSizeTable; 

	SELECT * 
	INTO #TempSizeTable
	FROM [dbo].[Size]

	DROP TABLE [dbo].[Size]
END

--Spot Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Spot')
BEGIN
	IF OBJECT_ID('tempdb..#TempSpotTable') IS NOT NULL DROP TABLE #TempSpotTable; 

	SELECT * 
	INTO #TempSpotTable
	FROM [dbo].[Spot]

	DROP TABLE [dbo].[Spot]
END

--Team Drop - FK - FranchiseId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Team')
BEGIN
	IF OBJECT_ID('tempdb..#TempTeamTable') IS NOT NULL DROP TABLE #TempTeamTable; 

	SELECT * 
	INTO #TempTeamTable
	FROM [dbo].[Team]

	DROP TABLE [dbo].[Team]
END

--User Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'User')
BEGIN
	IF OBJECT_ID('tempdb..#TempUserTable') IS NOT NULL DROP TABLE #TempUserTable; 

	SELECT * 
	INTO #TempUserTable
	FROM [dbo].[User]

	DROP TABLE [dbo].[User]
END

--WritingInstrument Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'WritingInstrument')
BEGIN
	IF OBJECT_ID('tempdb..#TempWritingInstrumentTable') IS NOT NULL DROP TABLE #TempWritingInstrumentTable; 

	SELECT * 
	INTO #TempWritingInstrumentTable
	FROM [dbo].[WritingInstrument]

	DROP TABLE [dbo].[WritingInstrument]
END

--Conference Drop - FK - LevelTypeId, SportId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Conference')
BEGIN
	IF OBJECT_ID('tempdb..#TempConferenceTable') IS NOT NULL DROP TABLE #TempConferenceTable; 

	SELECT * 
	INTO #TempConferenceTable
	FROM [dbo].[Conference]

	DROP TABLE [dbo].[Conference]
END

--Franchise Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Franchise')
BEGIN
	IF OBJECT_ID('tempdb..#TempFranchiseTable') IS NOT NULL DROP TABLE #TempFranchiseTable; 

	SELECT * 
	INTO #TempFranchiseTable
	FROM [dbo].[Franchise]

	DROP TABLE [dbo].[Franchise]
END

--SportLeagueLevel Drop - FK - SportId, LevelTypeId
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SportLeagueLevel')
BEGIN
	IF OBJECT_ID('tempdb..#TempSportLeagueLevelTable') IS NOT NULL DROP TABLE #TempSportLeagueLevelTable; 

	SELECT * 
	INTO #TempSportLeagueLevelTable
	FROM [dbo].[SportLeagueLevel]

	DROP TABLE [dbo].[SportLeagueLevel]
END

--LevelType Drop 
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'LevelType')
BEGIN
	IF OBJECT_ID('tempdb..#TempLevelTypeTable') IS NOT NULL DROP TABLE #TempLevelTypeTable; 

	SELECT * 
	INTO #TempLevelTypeTable
	FROM [dbo].[LevelType]

	DROP TABLE [dbo].[LevelType]
END

--Role Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Role')
BEGIN
	IF OBJECT_ID('tempdb..#TempRoleTable') IS NOT NULL DROP TABLE #TempRoleTable; 

	SELECT * 
	INTO #TempRoleTable
	FROM [dbo].[Role]

	DROP TABLE [dbo].[Role]
END

--Sport Drop
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Sport')
BEGIN
	IF OBJECT_ID('tempdb..#TempSportTable') IS NOT NULL DROP TABLE #TempSportTable; 

	SELECT * 
	INTO #TempSportTable
	FROM [dbo].[Sport]

	DROP TABLE [dbo].[Sport]
END

--End Dropping Domain Tables

--Start Creating Domain Tables
--LevelType Create
CREATE TABLE [dbo].[LevelType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_LevelType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[LevelType] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[LevelType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempLevelTypeTable
END

SET IDENTITY_INSERT [dbo].[LevelType] OFF

--Sport Create
CREATE TABLE [dbo].[Sport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AlternateName] [nvarchar](50) NULL,
	[ImagePath] [varchar](200) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Sport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Sport] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Sport] (Id, Name, AlternateName, ImagePath, CreateDate, LastModifiedDate)
	VALUES (1, 'Baseball', NULL, NULL, GETUTCDATE(), NULL)
		 , (2, 'Basketball', NULL, NULL, GETUTCDATE(), NULL)
		 , (3, 'Football', NULL, NULL, GETUTCDATE(), NULL)
		 , (4, 'Hockey', NULL, NULL, GETUTCDATE(), NULL)
		 , (5, 'Soccer', 'Futbol', NULL, GETUTCDATE(), NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Sport] (Id, Name, AlternateName, ImagePath, CreateDate, LastModifiedDate)
	SELECT * 
	FROM #TempSportTable
END

SET IDENTITY_INSERT [dbo].[Sport] OFF

--SportLeagueLevel Create
CREATE TABLE [dbo].[SportLeagueLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SportId] [int] NOT NULL,
	[LevelTypeId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
 CONSTRAINT [PK_SportLeagueLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[SportLeagueLevel]  WITH CHECK ADD  CONSTRAINT [FK_SportLeagueLevel_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
ALTER TABLE [dbo].[SportLeagueLevel] CHECK CONSTRAINT [FK_SportLeagueLevel_Sport]

ALTER TABLE [dbo].[SportLeagueLevel]  WITH CHECK ADD  CONSTRAINT [FK_SportLeagueLevel_LevelType] FOREIGN KEY([LevelTypeId])
REFERENCES [dbo].[LevelType] ([Id])
ALTER TABLE [dbo].[SportLeagueLevel] CHECK CONSTRAINT [FK_SportLeagueLevel_LevelType]

SET IDENTITY_INSERT [dbo].[SportLeagueLevel] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[SportLeagueLevel] (Id, SportId, LevelTypeId, [Name], Abbreviation)
	SELECT * 
	FROM #TempSportLeagueLevelTable
END

SET IDENTITY_INSERT [dbo].[SportLeagueLevel] OFF

--Person Create
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Suffix] [nvarchar](25) NULL,
	[Nickname] [nvarchar] (50) NULL,
	[LegalName] [nvarchar](225) NOT NULL,
	[DisplayName] [nvarchar] (225) NOT NULL,
	[BirthDate] [datetime] NULL,
	[DeathDate] [datetime] NULL,
	[ImagePath] [varchar](200) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Person] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Person] (Id, FirstName, LastName, MiddleName, Suffix, Nickname, LegalName, DisplayName, BirthDate, DeathDate, ImagePath, CreateDate, LastModifiedDate)
	SELECT * 
	FROM #TempPersonTable
END

SET IDENTITY_INSERT [dbo].[Person] OFF

--Conference Create
CREATE TABLE [dbo].[Conference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SportLeagueLevelId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,	
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_Conference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Conference]  WITH CHECK ADD  CONSTRAINT [FK_Conference_SportLeagueLevel] FOREIGN KEY([SportLeagueLevelId])
REFERENCES [dbo].[SportLeagueLevel] ([Id])
ALTER TABLE [dbo].[Conference] CHECK CONSTRAINT [FK_Conference_SportLeagueLevel]

SET IDENTITY_INSERT [dbo].[Conference] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Conference] (Id, SportLeagueLevelId, [Name], Abbreviation, ImagePath)
	SELECT * 
	FROM #TempConferenceTable
END

SET IDENTITY_INSERT [dbo].[Conference] OFF

--AcquisitionType Create
CREATE TABLE [dbo].[AcquisitionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_AcquisitionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[AcquisitionType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[AcquisitionType] (Id, Name, Abbreviation)
	VALUES (1, 'Private Signing', NULL)
		 , (2, 'Public Signing', NULL)
		 , (3, 'In Person', 'IP')
		 , (4, 'Through the Mail', 'TTM')
		 , (5, 'Trade', NULL)
		 , (6, 'Purchase', NULL)
		 , (7, 'Gift', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[AcquisitionType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempAcquisitionTypeTable
END

SET IDENTITY_INSERT [dbo].[AcquisitionType] OFF

--AuthenticationCompany Create
CREATE TABLE [dbo].[AuthenticationCompany](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_AuthenticationCompany] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[AuthenticationCompany] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[AuthenticationCompany] (Id, Name, Abbreviation)
	VALUES (1, 'James Spence Authentication', 'JSA')
		 , (2, 'Beckett Authentication Services', 'BAS')
		 , (3, 'Professional Sports Authenticator', 'PSA')
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[AuthenticationCompany] (Id, [Name], Abbreviation)
	SELECT * 
	FROM #TempAuthenticationCompanyTable
END

SET IDENTITY_INSERT [dbo].[AuthenticationCompany] OFF

--BaseballType Create
CREATE TABLE [dbo].[BaseballType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_BaseballType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[BaseballType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[BaseballType] (Id, Name, Abbreviation)
	VALUES (1, 'Black Baseball', 'ROMLBBG')
		 , (2, 'All Star', NULL)
		 , (3, 'World Series', NULL)
		 , (4, 'Offical Major League Baseball', 'ROMLB')
		 , (5, 'Other', NULL)
		 , (6, 'None', NULL)
		 , (7, 'American League', NULL)
		 , (8, 'National League', NULL)
		 , (9, 'Father''s Day', NULL)
		 , (10, 'Mother''s', NULL)
		 , (11, 'Cy Young', NULL)
		 , (12, 'Commemorative', NULL)
		 , (13, 'Home Run Derby', NULL)
		 , (14, 'Gold', 'ROMLBG')
		 , (15, 'Gold Glove', 'RGGBB')
		 , (16, 'Spring Training', NULL)
		 , (17, 'Gold World Series',  NULL)
		 , (18, 'Team Anniversary', NULL)
		 , (19, 'All Star Future''s Game', NULL)
		 , (20, 'Opening Day', NULL)
		 , (21, 'Post Season', NULL)
		 , (22, 'Hall of Fame', NULL)
	     , (23, 'Memorial Day', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[BaseballType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempBaseballTypeTable
END

SET IDENTITY_INSERT [dbo].[BaseballType] OFF

--BasketballType Create
CREATE TABLE [dbo].[BasketballType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_BasketballType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[BasketballType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[BasketballType] (Id, Name, Abbreviation)
	VALUES (1, 'Official', NULL)
		 , (2, 'Finals', NULL)
		 , (3, 'Commemorative', NULL)
		 , (4, 'Other', NULL)
	     , (5, 'None', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[BasketballType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempBasketballTypeTable
END

SET IDENTITY_INSERT [dbo].[BasketballType] OFF

--BatType Create
CREATE TABLE [dbo].[BatType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_BatType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[BatType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[BatType] (Id, Name, Abbreviation)
	VALUES (1, 'Big Stick', NULL)
		 , (2, 'Game Model', NULL)
		 , (3, 'Commemorative', NULL)
		 , (4, 'None', NULL)
		 , (5, 'Other', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[BatType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempBatTypeTable
END

SET IDENTITY_INSERT [dbo].[BatType] OFF

--Brand Create
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Brand] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Brand] (Id, Name, Abbreviation)
	VALUES (1, 'Rawlings', NULL)
		 , (2, 'Nike', NULL)
		 , (3, 'Reebok', 'RBK')
		 , (4, 'Adidas', NULL)
		 , (5, 'Majestic', NULL)
		 , (6, 'Wilson', NULL)
		 , (7, 'Other', NULL)
		 , (8, 'None', NULL)
		 , (9, 'Spinneybeck', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Brand] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempBrandTable
END

SET IDENTITY_INSERT [dbo].[Brand] OFF

--CardType Create
CREATE TABLE [dbo].[CardType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_CardType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[CardType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[CardType] (Id, Name, Abbreviation)
	VALUES (1, 'Trading', NULL)
		 , (2, 'Playing', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[CardType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempCardTypeTable
END

SET IDENTITY_INSERT [dbo].[CardType] OFF

--Color Create
CREATE TABLE [dbo].[Color](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Color] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Color] (Id, Name, Abbreviation)
	VALUES (1, 'Blue', NULL)
		 , (2, 'Black', NULL)
		 , (3, 'Silver', NULL)
		 , (4, 'ld', NULL)
		 , (5, 'Red', NULL)
		 , (6, 'Orange', NULL)
		 , (7, 'Other', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Color] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempColorTable
END

SET IDENTITY_INSERT [dbo].[Color] OFF

--Commissioner Create
CREATE TABLE [dbo].[Commissioner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[SportLeagueLevelId] [int] NOT NULL,
	[BeginYear] [int] NULL,
	[EndYear] [int] NULL,	
 CONSTRAINT [PK_Commissioner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Commissioner]  WITH CHECK ADD  CONSTRAINT [FK_Commissioner_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ALTER TABLE [dbo].[Commissioner] CHECK CONSTRAINT [FK_Commissioner_Person]

ALTER TABLE [dbo].[Commissioner]  WITH CHECK ADD  CONSTRAINT [FK_Commissioner_SportLeagueLevel] FOREIGN KEY([SportLeagueLevelId])
REFERENCES [dbo].[SportLeagueLevel] ([Id])
ALTER TABLE [dbo].[Commissioner] CHECK CONSTRAINT [FK_Commissioner_SportLeagueLevel]

SET IDENTITY_INSERT [dbo].[Commissioner] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Commissioner] (Id, PersonId, SportLeagueLevelId, BeginYear, EndYear)
	SELECT * 
	FROM #TempCommissionerTable
END

SET IDENTITY_INSERT [dbo].[Commissioner] OFF

--Condition Create
CREATE TABLE [dbo].[Condition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Condition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Condition] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Condition] (Id, Name, Abbreviation)
	VALUES (1, 'Pristine', NULL)
		 , (2, 'Gem Mint', NULL)
		 , (3, 'Mint', NULL)
		 , (4, 'Near Mint', NULL)
		 , (5, 'Excellent', NULL)
		 , (6, 'Fair', NULL)
		 , (7, 'Poor', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Condition] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempConditionTable
END

SET IDENTITY_INSERT [dbo].[Condition] OFF

--League Create
CREATE TABLE [dbo].[League](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SportLeagueLevelId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_League] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[League]  WITH CHECK ADD  CONSTRAINT [FK_League_SportLeagueLevel] FOREIGN KEY([SportLeagueLevelId])
REFERENCES [dbo].[SportLeagueLevel] ([Id])
ALTER TABLE [dbo].[League] CHECK CONSTRAINT [FK_League_SportLeagueLevel]

SET IDENTITY_INSERT [dbo].[League] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[League] (Id, SportLeagueLevelId, [Name], Abbreviation, ImagePath)
	SELECT * 
	FROM #TempLeagueTable
END

SET IDENTITY_INSERT [dbo].[League] OFF

--Division Create
CREATE TABLE [dbo].[Division](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConferenceId] [int] NULL,
	[LeagueId] [int] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Division]  WITH CHECK ADD  CONSTRAINT [FK_Division_Conference] FOREIGN KEY([ConferenceId])
REFERENCES [dbo].[Conference] ([Id])
ALTER TABLE [dbo].[Division] CHECK CONSTRAINT [FK_Division_Conference]

ALTER TABLE [dbo].[Division]  WITH CHECK ADD  CONSTRAINT [FK_Division_League] FOREIGN KEY([LeagueId])
REFERENCES [dbo].[League] ([Id])
ALTER TABLE [dbo].[Division] CHECK CONSTRAINT [FK_Division_League]

SET IDENTITY_INSERT [dbo].[Division] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Division] (Id, ConferenceId, LeagueId, [Name], Abbreviation, ImagePath)
	SELECT * 
	FROM #TempDivisionTable
END

SET IDENTITY_INSERT [dbo].[Division] OFF

--FigureSpecialtyType Create
CREATE TABLE [dbo].[FigureSpecialtyType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_FigureSpecialtyType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[FigureSpecialtyType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[FigureSpecialtyType] (Id, [Name], Abbreviation)
	VALUES (1, 'Classic Doubles', NULL)
		 , (2, 'Cooperstown Collection', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[FigureSpecialtyType] (Id, [Name], Abbreviation)
	SELECT * 
	FROM #TempFigureSpecialtyTypeTable
END

SET IDENTITY_INSERT [dbo].[FigureSpecialtyType] OFF

--FigureType Create
CREATE TABLE [dbo].[FigureType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_FigureType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[FigureType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[FigureType] (Id, Name, Abbreviation)
	VALUES (1, 'Starting Lineup', 'SLU')
		 , (2, 'Funko Pop', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[FigureType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempFigureTypeTable
END

SET IDENTITY_INSERT [dbo].[FigureType] OFF

--FootballType Create
CREATE TABLE [dbo].[FootballType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_FootballType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[FootballType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[FootballType] (Id, Name, Abbreviation)
	VALUES (1, 'Duke', NULL)
		 , (2, 'Duke Replica', NULL)
		 , (3, 'Commemorative', NULL)
		 , (4, 'Other', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[FootballType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempFootballTypeTable
END

SET IDENTITY_INSERT [dbo].[FootballType] OFF

--Franchise Create
CREATE TABLE [dbo].[Franchise](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SportLeagueLevelId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[FoundYear] [int] NOT NULL,
	[ImagePath] [varchar](200) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Franchise] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Franchise]  WITH CHECK ADD  CONSTRAINT [FK_Franchise_SportLeagueLevel] FOREIGN KEY([SportLeagueLevelId])
REFERENCES [dbo].[SportLeagueLevel] ([Id])
ALTER TABLE [dbo].[Franchise] CHECK CONSTRAINT [FK_Franchise_SportLeagueLevel]

SET IDENTITY_INSERT [dbo].[Franchise] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Franchise] (Id, SportLeagueLevelId, Name, Location, FoundYear, ImagePath, CreateDate)
	VALUES (1, 1, 'Orioles', 'Baltimore', 1901, NULL, GETUTCDATE())
		 , (2, 1, 'Red Sox', 'Boston', 1901, NULL, GETUTCDATE())
		 , (3, 1, 'Yankees', 'New York', 1901, NULL, GETUTCDATE())
		 , (4, 1, 'Rays', 'Tampa Bay', 1998, NULL, GETUTCDATE())
		 , (5, 1, 'Blue Jays', 'Toronto', 1977, NULL, GETUTCDATE())
		 , (6, 1, 'White Sox', 'Chicago', 1901, NULL, GETUTCDATE())
		 , (7, 1, 'Guardians', 'Cleveland', 1901, NULL, GETUTCDATE())
		 , (8, 1, 'Tigers', 'Detroit', 1901, NULL, GETUTCDATE())
		 , (9, 1, 'Twins', 'Minnesota', 1901, NULL, GETUTCDATE())
		 , (10, 1, 'Royals', 'Kansas City', 1969, NULL, GETUTCDATE())
		 , (11, 1, 'Astros', 'Houston', 1962, NULL, GETUTCDATE())
		 , (12, 1, 'Angels', 'Los Angeles', 1961, NULL, GETUTCDATE())
		 , (13, 1, 'Athletics', 'Oakland', 1901, NULL, GETUTCDATE())
		 , (14, 1, 'Mariners', 'Seattle', 1977, NULL, GETUTCDATE())
		 , (15, 1, 'Rangers', 'Texas', 1961, NULL, GETUTCDATE())
		 , (16, 1, 'Braves', 'Atlanta', 1871, NULL, GETUTCDATE())
		 , (17, 1, 'Marlins', 'Miami', 1993, NULL, GETUTCDATE())
		 , (18, 1, 'Mets', 'New York', 1962, NULL, GETUTCDATE())
		 , (19, 1, 'Phillies', 'Philadelphia', 1883, NULL, GETUTCDATE())
		 , (20, 1, 'Nationals', 'Washington', 1969, NULL, GETUTCDATE())
		 , (21, 1, 'Brewers', 'Milwaukee', 1969, NULL, GETUTCDATE())
		 , (22, 1, 'Reds', 'Cincinnati', 1882, NULL, GETUTCDATE())
		 , (23, 1, 'Pirates', 'Pittsburgh', 1882, NULL, GETUTCDATE())
		 , (24, 1, 'Cubs', 'Chicago', 1874, NULL, GETUTCDATE())
		 , (25, 1, 'Cardinals', 'St. Louis', 1882, NULL, GETUTCDATE())
		 , (26, 1, 'Dodgers', 'Los Angeles', 1884, NULL, GETUTCDATE())
		 , (27, 1, 'Giants', 'San Francisco', 1883, NULL, GETUTCDATE())
		 , (28, 1, 'Diamondbacks', 'Arizona', 1998, NULL, GETUTCDATE())
		 , (29, 1, 'Rockies', 'Colorado', 1993, NULL, GETUTCDATE())
		 , (30, 1, 'Padres', 'San Diego Padres', 1969, NULL, GETUTCDATE())
END

IF @KeepExistingValues = 1
BEGIN	
	INSERT INTO [dbo].[Franchise] (Id, SportLeagueLevelId, Name, Location, FoundYear, ImagePath, CreateDate, LastModifiedDate)
	SELECT * 
	FROM #TempFranchiseTable
END

SET IDENTITY_INSERT [dbo].[Franchise] OFF

--GameStyleType Create
CREATE TABLE [dbo].[GameStyleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_GameStyleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[GameStyleType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[GameStyleType] (Id, Name, Abbreviation)
	VALUES (1, 'Game Used', NULL)
		 , (2, 'Game Worn', NULL)
		 , (3, 'Game Issued', NULL)
		 , (4, 'None', NULL)
		 , (5, 'Other', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[GameStyleType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempGameStyleTypeTable
END

SET IDENTITY_INSERT [dbo].[GameStyleType] OFF

--GloveType Create
CREATE TABLE [dbo].[GloveType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_GloveType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[GloveType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[GloveType] (Id, Name, Abbreviation)
	VALUES (1, 'Baseball Glove', NULL)
		 , (2, 'Batting Glove', NULL)
		 , (3, 'Football Glove', NULL)
		 , (4, 'Hockey Glove', NULL)
		 , (5, 'Boxing Glove', NULL)
		 , (6, 'MMA Glove', 'MMA')
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[GloveType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempGloveTypeTable
END

SET IDENTITY_INSERT [dbo].[GloveType] OFF

--HelmetFinish Create
CREATE TABLE [dbo].[HelmetFinish](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_HelmetFinish] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[HelmetFinish] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[HelmetFinish] (Id, [Name], Abbreviation)
	VALUES (1, 'Pewter', NULL)
		 , (2, 'Chrome', NULL)
		 , (3, '24k Gold Plated', NULL)
		 , (4, 'Sterling Silver', NULL)
		 , (5, 'Bronze', NULL)
		 , (6, 'Blaze', NULL)
		 , (7, 'Ice', NULL)
		 , (8, 'Flash', NULL)
		 , (9, 'Custom', NULL)
		 , (10, 'Drip', NULL)
		 , (11, 'Ripped', NULL)
		 , (12, 'Other', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[HelmetFinish] (Id, [Name], Abbreviation)
	SELECT * 
	FROM #TempHelmetFinishTable
END

SET IDENTITY_INSERT [dbo].[HelmetFinish] OFF

--HelmetQualityType Create
CREATE TABLE [dbo].[HelmetQualityType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_HelmetQualityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[HelmetQualityType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[HelmetQualityType] (Id, Name, Abbreviation)
	VALUES (1, 'Authentic', 'AUTH')
		 , (2, 'Replica', 'REP')
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[HelmetQualityType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempHelmetQualityTypeTable
END

SET IDENTITY_INSERT [dbo].[HelmetQualityType] OFF

--HelmetType Create
CREATE TABLE [dbo].[HelmetType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_HelmetType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[HelmetType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[HelmetType] (Id, Name, Abbreviation)
	VALUES (1, 'Flex', NULL)
		 , (2, 'Hydro', NULL)
		 , (3, 'Speed', NULL)
		 , (4, 'Revolution', NULL)
		 , (5, 'F7', NULL)
		 , (6, 'Other', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[HelmetType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempHelmetTypeTable
END

SET IDENTITY_INSERT [dbo].[HelmetType] OFF

--ImageType Create
CREATE TABLE [dbo].[ImageType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_ImageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[ImageType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[ImageType] (Id, Name, Abbreviation)
	VALUES (1, 'Primary', NULL)
		 , (2, 'Secondary', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[ImageType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempImageTypeTable
END

SET IDENTITY_INSERT [dbo].[ImageType] OFF

--InscriptionType Create
CREATE TABLE [dbo].[InscriptionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_InscriptionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[InscriptionType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[InscriptionType] (Id, Name, Abbreviation)
	VALUES (1, 'Hall of Fame', 'HOF')
		 , (2, 'Most Valuable Player', 'MVP')
		 , (3, 'Number', NULL)
		 , (4, 'Rookie of the Year', 'ROY')
		 , (5, 'Cy Young', 'CY')
		 , (6, 'Bible Verse', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[InscriptionType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempInscriptionTypeTable
END

SET IDENTITY_INSERT [dbo].[InscriptionType] OFF

--ItemType Create
CREATE TABLE [dbo].[ItemType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_ItemType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[ItemType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[ItemType] (Id, Name, Abbreviation)
	VALUES (1, 'Baseball', NULL)
		 , (2, 'Basketball', NULL)
		 , (3, 'Bat', NULL)
		 , (4, 'Book', NULL)
		 , (5, 'First Day Cover', NULL)
		 , (6, 'Canvas', NULL)
		 , (7, 'Trading Card', NULL)
		 , (8, 'Figure', NULL)
		 , (9, 'Football', NULL)
		 , (10, 'Glove', NULL)
		 , (11, 'Helmet', NULL)
		 , (12, 'Jersey', NULL)
		 , (13, 'Jersey Number', NULL)
		 , (14, 'Magazine', NULL)
		 , (15, 'Other', NULL)
		 , (16, 'Painting', NULL)
		 , (17, 'Photo', NULL)
		 , (18, 'Puck', NULL)
		 , (19, 'Pylon', NULL)
		 , (20, 'Soccer Ball', NULL)
		 , (21, 'Hockey Stick', NULL)
		 , (22, 'Ticket Stub', NULL)
		 , (23, 'Hat', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[ItemType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempItemTypeTable
END

SET IDENTITY_INSERT [dbo].[ItemType] OFF

--JerseyQualityType Create
CREATE TABLE [dbo].[JerseyQualityType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_JerseyQualityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[JerseyQualityType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[JerseyQualityType] (Id, Name, Abbreviation)
	VALUES (1, 'Authentic', NULL)
		 , (2, 'Replica', NULL)
		 , (3, 'China', NULL)
		 , (4, 'Custom', NULL)
		 , (5, 'Other', NULL)
		 , (6, 'Unknown', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[JerseyQualityType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempJerseyQualityTypeTable
END

SET IDENTITY_INSERT [dbo].[JerseyQualityType] OFF

--JerseyStyleType Create
CREATE TABLE [dbo].[JerseyStyleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_JerseyStyleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[JerseyStyleType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[JerseyStyleType] (Id, Name, Abbreviation)
	VALUES (1, 'Home', NULL)
		 , (2, 'Away', NULL)
		 , (3, 'Alternate', NULL)
		 , (4, 'World Series', NULL)
		 , (5, 'All Star', NULL)
		 , (6, 'Pro Bowl', NULL)
		 , (7, 'Finals', NULL)
		 , (8, 'Throwback', NULL)
		 , (9, 'Other', NULL)
		 , (10, 'Unknown', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[JerseyStyleType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempJerseyStyleTypeTable
END

SET IDENTITY_INSERT [dbo].[JerseyStyleType] OFF

--JerseyType Create
CREATE TABLE [dbo].[JerseyType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_JerseyType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[JerseyType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[JerseyType] (Id, Name, Abbreviation)
	VALUES (1, 'Stitched', NULL)
		 , (2, 'Screen Printed', NULL)
		 , (3, 'Other', NULL)
		 , (4, 'None', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[JerseyType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempJerseyTypeTable
END

SET IDENTITY_INSERT [dbo].[JerseyType] OFF

--MagazineType Create
CREATE TABLE [dbo].[MagazineType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_MagazineType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[MagazineType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[MagazineType] (Id, Name, Abbreviation)
	VALUES (1, 'Standard Publication', NULL)
		 , (2, 'Program', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MagazineType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempMagazineTypeTable
END

SET IDENTITY_INSERT [dbo].[MagazineType] OFF

--Occupation Create
CREATE TABLE [dbo].[Occupation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
 CONSTRAINT [PK_Occupation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Occupation] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Occupation] (Id, Name, Abbreviation)
	VALUES (1, 'Athlete', NULL)
		 , (2, 'Actor', NULL)
		 , (3, 'Actress', NULL)
		 , (4, 'Celebrity', NULL)
		 , (5, 'Broadcaster', NULL)
		 , (6, 'Comedian', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Occupation] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempOccupationTable
END

SET IDENTITY_INSERT [dbo].[Occupation] OFF

--Occupation Type Create
CREATE TABLE [dbo].[OccupationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_OccupationType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[OccupationType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[OccupationType] (Id, [Name], Abbreviation)
	VALUES (1, 'Primary', NULL)
		 , (2, 'Secondary', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[OccupationType] (Id, [Name], Abbreviation)
	SELECT * 
	FROM #TempOccupationTypeTable
END

SET IDENTITY_INSERT [dbo].[OccupationType] OFF

--Orientation Create
CREATE TABLE [dbo].[Orientation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
 CONSTRAINT [PK_Orientation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Orientation] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Orientation] (Id, Name, Abbreviation)
	VALUES (1, 'Portrait', NULL)
		 , (2, 'Landscape', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Orientation] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempOrientationTable
END

SET IDENTITY_INSERT [dbo].[Orientation] OFF

--PhotoType Create
CREATE TABLE [dbo].[PhotoType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
 CONSTRAINT [PK_PhotoType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[PhotoType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[PhotoType] (Id, Name, Abbreviation)
	VALUES (1, 'Glossy', NULL)
		 , (2, 'Matte', NULL)
		 , (3, 'Unknown', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[PhotoType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempPhotoTypeTable
END

SET IDENTITY_INSERT [dbo].[PhotoType] OFF

--PrivacyType Create
CREATE TABLE [dbo].[PrivacyType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](75) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_PrivacyType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[PrivacyType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[PrivacyType] (Id, Name, Abbreviation)
	VALUES (1, 'Public', NULL)
		 , (2, 'Private', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[PrivacyType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempPrivacyTypeTable
END

SET IDENTITY_INSERT [dbo].[PrivacyType] OFF

--PurchaseType Create
CREATE TABLE [dbo].[PurchaseType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_PurchaseType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[PurchaseType] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[PurchaseType] (Id, Name, Abbreviation)
	VALUES (1, 'eBay', NULL)
		 , (2, 'Amazon', NULL)
		 , (3, 'Other', NULL)
		 , (4, 'Retail Store', NULL)
		 , (5, 'Facebook', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[PurchaseType] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempPurchaseTypeTable
END

SET IDENTITY_INSERT [dbo].[PurchaseType] OFF

--Role Create
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](75) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Role] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Role] (Id, Name)
	VALUES (1, 'Super Admin')
		 , (2, 'Admin')
		 , (3, 'User')
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Role] (Id, Name)
	SELECT * 
	FROM #TempRoleTable
END

SET IDENTITY_INSERT [dbo].[Role] OFF

--Size Create
CREATE TABLE [dbo].[Size](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Size] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Size] (Id, Name, Abbreviation)
	VALUES (1, 'Mini', NULL)
		 , (2, 'Full', NULL)
		 , (3, 'Large', 'L')
		 , (4, 'Small', 'S')
		 , (5, 'Standard', NULL)
		 , (6, 'Oversized', NULL)
		 , (7, 'Other', NULL)
		 , (8, 'None', NULL)
		 , (9, 'Medium', 'M')
		 , (10, 'Extra Large', 'XL')

END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Size] (Id, Name, Abbreviation)
	SELECT * 
	FROM #TempSizeTable
END

SET IDENTITY_INSERT [dbo].[Size] OFF

--Spot Create
CREATE TABLE [dbo].[Spot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Spot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Spot] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[Spot] (Id, Name, Abbreviation)
	VALUES (1, 'Sweet Spot', 'SS')
		 , (2, 'Side Panel', 'SP')
		 , (3, 'On Cloth', NULL)
		 , (4, 'On Number', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Spot] (Id, Name, Abbreviation)
SELECT * 
FROM #TempSpotTable
END

SET IDENTITY_INSERT [dbo].[Spot] OFF

--Team Create
CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FranchiseId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[Nickname] [nvarchar](25) NULL,
	[Abbreviation] [varchar](10) NULL,
	[BeginYear] [int] NULL,
	[EndYear] [int] NULL,
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Franchise] FOREIGN KEY([FranchiseId])
REFERENCES [dbo].[Franchise] ([Id])
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Franchise]

SET IDENTITY_INSERT [dbo].[Team] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Team] (Id, FranchiseId, Name, Location, Nickname, Abbreviation, BeginYear, EndYear, ImagePath)
	SELECT * 
	FROM #TempTeamTable
END

SET IDENTITY_INSERT [dbo].[Team] OFF

--User - Create
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]

SET IDENTITY_INSERT [dbo].[User] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[User] (Id, EmailAddress, FirstName, LastName, Password, Phone, Username, RoleId, CreateDate)
	VALUES (1, 'njgrillo@gmail.com', 'Nick', 'Grillo', 'E7!@ff893@@', NULL, 'njgrillo', 1, GETUTCDATE())
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[User] (Id, EmailAddress, FirstName, LastName, Password, Phone, Username, RoleId, CreateDate, UpdateDate)
	SELECT * 
	FROM #TempUserTable
END

SET IDENTITY_INSERT [dbo].[User] OFF

--WritingInstrument Create
CREATE TABLE [dbo].[WritingInstrument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_WritingInstrument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[WritingInstrument] ON

IF @LoadInitialValues = 1
BEGIN
	INSERT INTO  [dbo].[WritingInstrument] (Id, Name, Abbreviation)
	VALUES (1, 'Ballpoint Pen', NULL)
		 , (2, 'Paint Pen', NULL)
		 , (3, 'Sharpie', NULL)
END

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[WritingInstrument] (Id, [Name], Abbreviation)
	SELECT * 
	FROM #TempWritingInstrumentTable
END

SET IDENTITY_INSERT [dbo].[WritingInstrument] OFF
--End Creating Domain Tables

--Memorabilia Create
CREATE TABLE [dbo].[Memorabilia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[ConditionId] [int] NULL,
	[EstimatedValue] [decimal](12, 2) NULL,
	[PrivacyTypeId] int NOT NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Memorabilia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Memorabilia]  WITH CHECK ADD  CONSTRAINT [FK_Memorabilia_Condition] FOREIGN KEY([ConditionId])
REFERENCES [dbo].[Condition] ([Id])
ALTER TABLE [dbo].[Memorabilia] CHECK CONSTRAINT [FK_Memorabilia_Condition]

ALTER TABLE [dbo].[Memorabilia]  WITH CHECK ADD  CONSTRAINT [FK_Memorabilia_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
ALTER TABLE [dbo].[Memorabilia] CHECK CONSTRAINT [FK_Memorabilia_ItemType]

ALTER TABLE [dbo].[Memorabilia]  WITH CHECK ADD  CONSTRAINT [FK_Memorabilia_PrivacyType] FOREIGN KEY([PrivacyTypeId])
REFERENCES [dbo].[PrivacyType] ([Id])
ALTER TABLE [dbo].[Memorabilia] CHECK CONSTRAINT [FK_Memorabilia_PrivacyType]

ALTER TABLE [dbo].[Memorabilia]  WITH CHECK ADD  CONSTRAINT [FK_Memorabilia_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ALTER TABLE [dbo].[Memorabilia] CHECK CONSTRAINT [FK_Memorabilia_User]

CREATE INDEX IX_Memorabilia_UserId ON Memorabilia (UserId)

SET IDENTITY_INSERT [dbo].[Memorabilia] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Memorabilia] (Id, ItemTypeId, ConditionId, EstimatedValue, PrivacyTypeId, UserId, CreateDate, LastModifiedDate)
	SELECT * 
	FROM #TempMemorabiliaTable
END

SET IDENTITY_INSERT [dbo].[Memorabilia] OFF

--Acquisition Create
CREATE TABLE [dbo].[Acquisition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AcquisitionTypeId] [int] NOT NULL,
	[AcquiredDate] [datetime] NULL,
	[PurchaseTypeId] [int] NULL,
	[Cost] [decimal](12, 2) NULL,
	[AcquiredWithAutograph] [bit] NULL
 CONSTRAINT [PK_Acquisition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Acquisition]  WITH CHECK ADD  CONSTRAINT [FK_Acquisition_AcquisitionType] FOREIGN KEY([AcquisitionTypeId])
REFERENCES [dbo].[AcquisitionType] ([Id])
ALTER TABLE [dbo].[Acquisition] CHECK CONSTRAINT [FK_Acquisition_AcquisitionType]

ALTER TABLE [dbo].[Acquisition]  WITH CHECK ADD  CONSTRAINT [FK_Acquisition_PurchaseType] FOREIGN KEY([PurchaseTypeId])
REFERENCES [dbo].[PurchaseType] ([Id])
ALTER TABLE [dbo].[Acquisition] CHECK CONSTRAINT [FK_Acquisition_PurchaseType]

SET IDENTITY_INSERT [dbo].[Acquisition] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Acquisition] (Id, AcquisitionTypeId, AcquiredDate, PurchaseTypeId, Cost, PurchasedWithAutograph)
	SELECT * 
	FROM #TempAcquisitionTable
END

SET IDENTITY_INSERT [dbo].[Acquisition] OFF

--Autograph Create
CREATE TABLE [dbo].[Autograph](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[ConditionId] [int] NOT NULL,
	[WritingInstrumentId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[AcquisitionId] [int] NULL,
	[EstimatedValue] decimal(12, 2) NULL,
	[Grade] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Autograph] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Color] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Color] ([Id])
ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Color]

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Condition] FOREIGN KEY([ConditionId])
REFERENCES [dbo].[Condition] ([Id])
ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Condition]

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Memorabilia]

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Person]

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_WritingInstrument] FOREIGN KEY([WritingInstrumentId])
REFERENCES [dbo].[WritingInstrument] ([Id])
ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_WritingInstrument]

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Acquisition] FOREIGN KEY([AcquisitionId])
REFERENCES [dbo].[Acquisition] ([Id])
ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Acquisition]

CREATE INDEX IX_Autograph_MemorabiliaId ON Autograph (MemorabiliaId)

SET IDENTITY_INSERT [dbo].[Autograph] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Autograph] (Id, MemorabiliaId, PersonId, ConditionId, WritingInstrumentId, ColorId, AcquisitionId, EstimatedValue, Grade, CreateDate, LastModifiedDate)
	SELECT * 
	FROM #TempAutographTable
END

SET IDENTITY_INSERT [dbo].[Autograph] OFF

--AutographAuthentication Create
CREATE TABLE [dbo].[AutographAuthentication](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutographId] [int] NOT NULL,
	[AuthenticationCompanyId] [int] NOT NULL,
	[Verification] [varchar](50) NULL,
	[HasHologram] [bit] NULL,
	[HasLetter] [bit] NULL,
	[Witnessed] [bit] NULL,
 CONSTRAINT [PK_AutographAuthentication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[AutographAuthentication]  WITH CHECK ADD  CONSTRAINT [FK_AutographAuthentication_AuthenticationCompany] FOREIGN KEY([AuthenticationCompanyId])
REFERENCES [dbo].[AuthenticationCompany] ([Id])
ALTER TABLE [dbo].[AutographAuthentication] CHECK CONSTRAINT [FK_AutographAuthentication_AuthenticationCompany]

ALTER TABLE [dbo].[AutographAuthentication]  WITH CHECK ADD  CONSTRAINT [FK_AutographAuthentication_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
ALTER TABLE [dbo].[AutographAuthentication] CHECK CONSTRAINT [FK_AutographAuthentication_Autograph]

SET IDENTITY_INSERT [dbo].[AutographAuthentication] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[AutographAuthentication] (Id, AutographId, AuthenticationCompanyId, Verification, HasHologram, HasLetter, Witnessed)
	SELECT * 
	FROM #TempAutographAuthenticationTable
END

SET IDENTITY_INSERT [dbo].[AutographAuthentication] OFF

--AutographImage Create
CREATE TABLE [dbo].[AutographImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutographId] [int] NOT NULL,
	[FilePath] nvarchar(500) NOT NULL,
	[UploadDate] [datetime] NOT NULL,
	[ImageTypeId] [int] NOT NULL,
 CONSTRAINT [PK_AutographImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[AutographImage]  WITH CHECK ADD  CONSTRAINT [FK_AutographImage_ImageType] FOREIGN KEY([ImageTypeId])
REFERENCES [dbo].[ImageType] ([Id])
ALTER TABLE [dbo].[AutographImage] CHECK CONSTRAINT [FK_AutographImage_ImageType]

ALTER TABLE [dbo].[AutographImage]  WITH CHECK ADD  CONSTRAINT [FK_AutographImage_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
ALTER TABLE [dbo].[AutographImage] CHECK CONSTRAINT [FK_AutographImage_Autograph]

SET IDENTITY_INSERT [dbo].[AutographImage] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[AutographImage] (Id, AutographId, FilePath, UploadDate, ImageTypeId)
	SELECT * 
	FROM #TempAutographImageTable
END

SET IDENTITY_INSERT [dbo].[AutographImage] OFF

--AutographSpot Create
CREATE TABLE [dbo].[AutographSpot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutographId] [int] NOT NULL,
	[SpotId] [int] NOT NULL,
 CONSTRAINT [PK_AutographSpot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[AutographSpot]  WITH CHECK ADD  CONSTRAINT [FK_AutographSpot_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
ALTER TABLE [dbo].[AutographSpot] CHECK CONSTRAINT [FK_AutographSpot_Autograph]

ALTER TABLE [dbo].[AutographSpot]  WITH CHECK ADD  CONSTRAINT [FK_AutographSpot_Spot] FOREIGN KEY([SpotId])
REFERENCES [dbo].[Spot] ([Id])
ALTER TABLE [dbo].[AutographSpot] CHECK CONSTRAINT [FK_AutographSpot_Spot]

SET IDENTITY_INSERT [dbo].[AutographSpot] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[AutographSpot] (Id, AutographId, SpotId)
	SELECT * 
	FROM #TempAutographSpotTable
END

SET IDENTITY_INSERT [dbo].[AutographSpot] OFF

--AutographThroughTheMail Create
CREATE TABLE [dbo].[AutographThroughTheMail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutographId] [int] NOT NULL,
	[SentDate] [datetime] NULL,
	[ReceivedDate] [datetime] NULL,
 CONSTRAINT [PK_AutographThroughTheMail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[AutographThroughTheMail]  WITH CHECK ADD  CONSTRAINT [FK_AutographThroughTheMail_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
ALTER TABLE [dbo].[AutographThroughTheMail] CHECK CONSTRAINT [FK_AutographThroughTheMail_Autograph]

SET IDENTITY_INSERT [dbo].[AutographThroughTheMail] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[AutographThroughTheMail] (Id, AutographId, SentDate, ReceivedDate)
	SELECT * 
	FROM #TempAutographThroughTheMailTable
END

SET IDENTITY_INSERT [dbo].[AutographThroughTheMail] OFF

--Event Create
CREATE TABLE [dbo].[Event](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AcquisitionTypeId] [int] NOT NULL,
	[EventDate] [datetime] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_AcquisitionType] FOREIGN KEY([AcquisitionTypeId])
REFERENCES [dbo].[AcquisitionType] ([Id])
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_AcquisitionType]

SET IDENTITY_INSERT [dbo].[Event] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Event] (Id, AcquisitionTypeId, EventDate)
	SELECT * 
	FROM #TempEventTable
END

SET IDENTITY_INSERT [dbo].[Event] OFF

--HallOfFame Create
CREATE TABLE [dbo].[HallOfFame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[SportLeagueLevelId] [int] NOT NULL,
	[FranchiseId] [int] NULL,
	[InductionYear] [int] NULL,
	[VotePercentage] [decimal](5, 2) NULL,
 CONSTRAINT [PK_HallOfFame] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[HallOfFame]  WITH CHECK ADD  CONSTRAINT [FK_HallOfFame_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ALTER TABLE [dbo].[HallOfFame] CHECK CONSTRAINT [FK_HallOfFame_Person]

ALTER TABLE [dbo].[HallOfFame]  WITH CHECK ADD  CONSTRAINT [FK_HallOfFame_SportLeagueLevel] FOREIGN KEY([SportLeagueLevelId])
REFERENCES [dbo].[SportLeagueLevel] ([Id])
ALTER TABLE [dbo].[HallOfFame] CHECK CONSTRAINT [FK_HallOfFame_SportLeagueLevel]

ALTER TABLE [dbo].[HallOfFame]  WITH CHECK ADD  CONSTRAINT [FK_HallOfFame_Franchise] FOREIGN KEY([FranchiseId])
REFERENCES [dbo].[Franchise] ([Id])
ALTER TABLE [dbo].[HallOfFame] CHECK CONSTRAINT [FK_HallOfFame_Franchise]

SET IDENTITY_INSERT [dbo].[HallOfFame] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[HallOfFame] (Id, PersonId, SportLeagueLevelId, FranchiseId, InductionYear, VotePercentage)
	SELECT * 
	FROM #TempHallOfFameTable
END

SET IDENTITY_INSERT [dbo].[HallOfFame] OFF

--Inscription Create
CREATE TABLE [dbo].[Inscription](
	[Id] [int] IDENTITY(1,1) NOT NULL,	
	[AutographId] [int] NOT NULL,
	[InscriptionTypeId] [int] NOT NULL,
	[InscriptionText] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Inscription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Autograph]

ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_InscriptionType] FOREIGN KEY([InscriptionTypeId])
REFERENCES [dbo].[InscriptionType] ([Id])
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_InscriptionType]

SET IDENTITY_INSERT [dbo].[Inscription] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Inscription] (Id, AutographId, InscriptionTypeId, InscriptionText)
	SELECT * 
	FROM #TempInscriptionTable
END

SET IDENTITY_INSERT [dbo].[Inscription] OFF

--ItemTypeBrand Create
CREATE TABLE [dbo].[ItemTypeBrand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeBrand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ItemTypeBrand]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeBrand_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
ALTER TABLE [dbo].[ItemTypeBrand] CHECK CONSTRAINT [FK_ItemTypeBrand_ItemType]

ALTER TABLE [dbo].[ItemTypeBrand]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeBrand_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
ALTER TABLE [dbo].[ItemTypeBrand] CHECK CONSTRAINT [FK_ItemTypeBrand_Brand]  

SET IDENTITY_INSERT [dbo].[ItemTypeBrand] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[ItemTypeBrand] (Id, ItemTypeId, BrandId)
	SELECT * 
	FROM #TempItemTypeBrandTable
END

SET IDENTITY_INSERT [dbo].[ItemTypeBrand] OFF

--ItemTypeGameStyleType Create
CREATE TABLE [dbo].[ItemTypeGameStyleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[GameStyleTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeGameStyleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ItemTypeGameStyleType]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeGameStyleType_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
ALTER TABLE [dbo].[ItemTypeGameStyleType] CHECK CONSTRAINT [FK_ItemTypeGameStyleType_ItemType]

ALTER TABLE [dbo].[ItemTypeGameStyleType]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeGameStyleType_GameStyleType] FOREIGN KEY([GameStyleTypeId])
REFERENCES [dbo].[GameStyleType] ([Id])
ALTER TABLE [dbo].[ItemTypeGameStyleType] CHECK CONSTRAINT [FK_ItemTypeGameStyleType_GameStyleType]
  
SET IDENTITY_INSERT [dbo].[ItemTypeGameStyleType] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[ItemTypeGameStyleType] (Id, ItemTypeId, GameStyleTypeId)
	SELECT * 
	FROM #TempItemTypeGameStyleTypeTable
END

SET IDENTITY_INSERT [dbo].[ItemTypeGameStyleType] OFF

--ItemTypeLevel Create
CREATE TABLE [dbo].[ItemTypeLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[LevelTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ItemTypeLevel]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeLevel_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
ALTER TABLE [dbo].[ItemTypeLevel] CHECK CONSTRAINT [FK_ItemTypeLevel_ItemType]

ALTER TABLE [dbo].[ItemTypeLevel]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeLevel_LevelType] FOREIGN KEY([LevelTypeId])
REFERENCES [dbo].[LevelType] ([Id])
ALTER TABLE [dbo].[ItemTypeLevel] CHECK CONSTRAINT [FK_ItemTypeLevel_LevelType]  

SET IDENTITY_INSERT [dbo].[ItemTypeLevel] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[ItemTypeLevel] (Id, ItemTypeId, LevelTypeId)
	SELECT * 
	FROM #TempItemTypeLevelTable
END

SET IDENTITY_INSERT [dbo].[ItemTypeLevel] OFF

--ItemTypeSize Create
CREATE TABLE [dbo].[ItemTypeSize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeSize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ItemTypeSize]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSize_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
ALTER TABLE [dbo].[ItemTypeSize] CHECK CONSTRAINT [FK_ItemTypeSize_ItemType]

ALTER TABLE [dbo].[ItemTypeSize]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSize_Size] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([Id])
ALTER TABLE [dbo].[ItemTypeSize] CHECK CONSTRAINT [FK_ItemTypeSize_Size]

SET IDENTITY_INSERT [dbo].[ItemTypeSize] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[ItemTypeSize] (Id, ItemTypeId, SizeId)
	SELECT * 
	FROM #TempItemTypeSizeTable
END

SET IDENTITY_INSERT [dbo].[ItemTypeSize] OFF

--ItemTypeSport Create
CREATE TABLE [dbo].[ItemTypeSport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[SportId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeSport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ItemTypeSport]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSport_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
ALTER TABLE [dbo].[ItemTypeSport] CHECK CONSTRAINT [FK_ItemTypeSport_ItemType]

ALTER TABLE [dbo].[ItemTypeSport]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSport_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
ALTER TABLE [dbo].[ItemTypeSport] CHECK CONSTRAINT [FK_ItemTypeSport_Sport]

SET IDENTITY_INSERT [dbo].[ItemTypeSport] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[ItemTypeSport] (Id, ItemTypeId, SportId)
	SELECT * 
	FROM #TempItemTypeSportTable
END

SET IDENTITY_INSERT [dbo].[ItemTypeSport] OFF

--ItemTypeSpot Create
CREATE TABLE [dbo].[ItemTypeSpot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[SpotId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeSpot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ItemTypeSpot]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSpot_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
ALTER TABLE [dbo].[ItemTypeSpot] CHECK CONSTRAINT [FK_ItemTypeSpot_ItemType]

ALTER TABLE [dbo].[ItemTypeSpot]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSpot_Spot] FOREIGN KEY([SpotId])
REFERENCES [dbo].[Spot] ([Id])
ALTER TABLE [dbo].[ItemTypeSpot] CHECK CONSTRAINT [FK_ItemTypeSpot_Spot]  

SET IDENTITY_INSERT [dbo].[ItemTypeSpot] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[ItemTypeSpot] (Id, ItemTypeId, SpotId)
	SELECT * 
	FROM #TempItemTypeSpotTable
END

SET IDENTITY_INSERT [dbo].[ItemTypeSpot] OFF

--MemorabiliaAcquisition Create
CREATE TABLE [dbo].[MemorabiliaAcquisition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[AcquisitionId] [int] NOT NULL
 CONSTRAINT [PK_MemorabiliaAcquisition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaAcquisition]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaAcquisition_Acquisition] FOREIGN KEY([AcquisitionId])
REFERENCES [dbo].[Acquisition] ([Id])
ALTER TABLE [dbo].[MemorabiliaAcquisition] CHECK CONSTRAINT [FK_MemorabiliaAcquisition_Acquisition]

ALTER TABLE [dbo].[MemorabiliaAcquisition]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaAcquisition_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaAcquisition] CHECK CONSTRAINT [FK_MemorabiliaAcquisition_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaAcquisition] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaAcquisition] (Id, MemorabiliaId, AcquisitionId)
	SELECT * 
	FROM #TempMemorabiliaAcquisitionTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaAcquisition] OFF

--MemorabiliaBaseball Create
CREATE TABLE [dbo].[MemorabiliaBaseball](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[BaseballTypeId] [int] NOT NULL,
	[Year] [int] NULL,
	[Anniversary] varchar(5) NULL,
 CONSTRAINT [PK_MemorabiliaBaseball] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaBaseball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBaseball_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaBaseball] CHECK CONSTRAINT [FK_MemorabiliaBaseball_Memorabilia]

ALTER TABLE [dbo].[MemorabiliaBaseball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBaseball_BaseballType] FOREIGN KEY([BaseballTypeId])
REFERENCES [dbo].[BaseballType] ([Id])
ALTER TABLE [dbo].[MemorabiliaBaseball] CHECK CONSTRAINT [FK_MemorabiliaBaseball_BaseballType]

SET IDENTITY_INSERT [dbo].[MemorabiliaBaseball] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaBaseball] (Id, MemorabiliaId, BaseballTypeId, [Year], Anniversary)
	SELECT * 
	FROM #TempMemorabiliaBaseballTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaBaseball] OFF

--MemorabiliaBasketball Create
CREATE TABLE [dbo].[MemorabiliaBasketball](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[BasketballTypeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaBasketball] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaBasketball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBasketball_BasketballType] FOREIGN KEY([BasketballTypeId])
REFERENCES [dbo].[BasketballType] ([Id])
ALTER TABLE [dbo].[MemorabiliaBasketball] CHECK CONSTRAINT [FK_MemorabiliaBasketball_BasketballType]

ALTER TABLE [dbo].[MemorabiliaBasketball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBasketball_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaBasketball] CHECK CONSTRAINT [FK_MemorabiliaBasketball_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaBasketball] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaBasketball] (Id, MemorabiliaId, BasketballTypeId)
	SELECT * 
	FROM #TempMemorabiliaBasketballTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaBasketball] OFF

--MemorabiliaBat Create
CREATE TABLE [dbo].[MemorabiliaBat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[BatTypeId] [int] NULL,
	[Length] [int] NULL,
	[ColorId] [int] NULL
 CONSTRAINT [PK_MemorabiliaBat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaBat]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBat_BatType] FOREIGN KEY([BatTypeId])
REFERENCES [dbo].[BatType] ([Id])
ALTER TABLE [dbo].[MemorabiliaBat] CHECK CONSTRAINT [FK_MemorabiliaBat_BatType]

ALTER TABLE [dbo].[MemorabiliaBat]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBat_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaBat] CHECK CONSTRAINT [FK_MemorabiliaBat_Memorabilia]

ALTER TABLE [dbo].[MemorabiliaBat]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBat_Color] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Color] ([Id])
ALTER TABLE [dbo].[MemorabiliaBat] CHECK CONSTRAINT [FK_MemorabiliaBat_Color]

SET IDENTITY_INSERT [dbo].[MemorabiliaBat] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaBat] (Id, MemorabiliaId, BatTypeId, [Length], ColorId)
	SELECT * 
	FROM #TempMemorabiliaBatTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaBat] OFF

--MemorabiliaBook Create
CREATE TABLE [dbo].[MemorabiliaBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Publisher] [varchar](200) NULL,
	[Edition] [varchar](5) NULL,
	[HardCover] [bit] NOT NULL
 CONSTRAINT [PK_MemorabiliaBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaBook]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBook_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaBook] CHECK CONSTRAINT [FK_MemorabiliaBook_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaBook] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaBook] (Id, MemorabiliaId, Publisher, Edition, HardCover)
	SELECT * 
	FROM #TempMemorabiliaBookTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaBook] OFF

--MemorabiliaBrand Create
CREATE TABLE [dbo].[MemorabiliaBrand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaBrand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaBrand]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBrand_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
ALTER TABLE [dbo].[MemorabiliaBrand] CHECK CONSTRAINT [FK_MemorabiliaBrand_Brand]

ALTER TABLE [dbo].[MemorabiliaBrand]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBrand_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaBrand] CHECK CONSTRAINT [FK_MemorabiliaBrand_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaBrand] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaBrand] (Id, MemorabiliaId, BrandId)
	SELECT * 
	FROM #TempMemorabiliaBrandTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaBrand] OFF

--MemorabiliaCanvas Create
CREATE TABLE [dbo].[MemorabiliaCanvas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[Framed] [bit] NOT NULL,
	[Stretched] [bit] NOT NULL,
 CONSTRAINT [PK_MemorabiliaCanvas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaCanvas]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaCanvas_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaCanvas] CHECK CONSTRAINT [FK_MemorabiliaCanvas_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaCanvas] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaCanvas] (Id, MemorabiliaId, Framed, Stretched)
	SELECT * 
	FROM #TempMemorabiliaCanvasTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaLCanvas] OFF

--MemorabiliaCard Create
CREATE TABLE [dbo].[MemorabiliaCard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[Year] [int] NULL,
	[Numerator] [int] NULL,
	[Denominator] [int] NULL,
	[Licensed] [bit] NOT NULL,
	[Custom] [bit] NOT NULL,
 CONSTRAINT [PK_MemorabiliaCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaCard]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaCard_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaCard] CHECK CONSTRAINT [FK_MemorabiliaCard_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaCard] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaCard] (Id, MemorabiliaId, [Year], Numerator, Denominator, Licensed, [Custom])
	SELECT * 
	FROM #TempMemorabiliaCardTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaCard] OFF

--MemorabiliaCommissioner Create
CREATE TABLE [dbo].[MemorabiliaCommissioner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[CommissionerId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaCommissioner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaCommissioner]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaCommissioner_Commissioner] FOREIGN KEY([CommissionerId])
REFERENCES [dbo].[Commissioner] ([Id])
ALTER TABLE [dbo].[MemorabiliaCommissioner] CHECK CONSTRAINT [FK_MemorabiliaCommissioner_Commissioner]

ALTER TABLE [dbo].[MemorabiliaCommissioner]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaCommissioner_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaCommissioner] CHECK CONSTRAINT [FK_MemorabiliaCommissioner_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaCommissioner] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaCommissioner] (Id, MemorabiliaId, CommissionerId)
	SELECT * 
	FROM #TempMemorabiliaCommissionerTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaCommissioner] OFF

--MemorabiliaFigure Create
CREATE TABLE [dbo].[MemorabiliaFigure](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[FigureTypeId] [int] NULL,
	[FigureSpecialtyTypeId] [int] NULL,
	[Year] [int] NULL,
 CONSTRAINT [PK_MemorabiliaFigure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaFigure]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaFigure_FigureType] FOREIGN KEY([FigureTypeId])
REFERENCES [dbo].[FigureType] ([Id])
ALTER TABLE [dbo].[MemorabiliaFigure] CHECK CONSTRAINT [FK_MemorabiliaFigure_FigureType]

ALTER TABLE [dbo].[MemorabiliaFigure]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaFigure_FigureSpecialtyType] FOREIGN KEY([FigureSpecialtyTypeId])
REFERENCES [dbo].[FigureType] ([Id])
ALTER TABLE [dbo].[MemorabiliaFigure] CHECK CONSTRAINT [FK_MemorabiliaFigure_FigureSpecialtyType]

ALTER TABLE [dbo].[MemorabiliaFigure]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaFigure_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaFigure] CHECK CONSTRAINT [FK_MemorabiliaFigure_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaFigure] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaFigure] (Id, MemorabiliaId, FigureTypeId)
	SELECT * 
	FROM #TempMemorabiliaFigureTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaFigure] OFF

--MemorabiliaFootball Create
CREATE TABLE [dbo].[MemorabiliaFootball](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[FootballTypeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaFootball] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaFootball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaFootball_FootballType] FOREIGN KEY([FootballTypeId])
REFERENCES [dbo].[FootballType] ([Id])
ALTER TABLE [dbo].[MemorabiliaFootball] CHECK CONSTRAINT [FK_MemorabiliaFootball_FootballType]

ALTER TABLE [dbo].[MemorabiliaFootball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaFootball_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaFootball] CHECK CONSTRAINT [FK_MemorabiliaFootball_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaFootball] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaFootball] (Id, MemorabiliaId, FootballTypeId)
	SELECT * 
	FROM #TempMemorabiliaFootballTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaFootball] OFF

--MemorabiliaGame Create
CREATE TABLE [dbo].[MemorabiliaGame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[GameStyleTypeId] [int] NOT NULL,
	[PersonId] [int] NULL,
	[GameDate] [datetime] NULL,
 CONSTRAINT [PK_MemorabiliaGame] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaGame]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaGame_GameStyleType] FOREIGN KEY([GameStyleTypeId])
REFERENCES [dbo].[GameStyleType] ([Id])
ALTER TABLE [dbo].[MemorabiliaGame] CHECK CONSTRAINT [FK_MemorabiliaGame_GameStyleType]

ALTER TABLE [dbo].[MemorabiliaGame]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaGame_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ALTER TABLE [dbo].[MemorabiliaGame] CHECK CONSTRAINT [FK_MemorabiliaGame_Person]

ALTER TABLE [dbo].[MemorabiliaGame]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaGame_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaGame] CHECK CONSTRAINT [FK_MemorabiliaGame_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaGame] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaGame] (Id, MemorabiliaId, GameStyleTypeId, PersonId, GameDate)
	SELECT * 
	FROM #TempMemorabiliaGameTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaGame] OFF

--MemorabiliaHelmet Create
CREATE TABLE [dbo].[MemorabiliaHelmet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[HelmetQualityTypeId] [int] NULL,
	[HelmetTypeId] [int] NULL,
	[HelmetFinishId] [int] NULL,
	[Throwback] [bit] NOT NULL,
 CONSTRAINT [PK_MemorabiliaHelmet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaHelmet]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaHelmet_HelmetQualityType] FOREIGN KEY([HelmetQualityTypeId])
REFERENCES [dbo].[HelmetQualityType] ([Id])
ALTER TABLE [dbo].[MemorabiliaHelmet] CHECK CONSTRAINT [FK_MemorabiliaHelmet_HelmetQualityType]

ALTER TABLE [dbo].[MemorabiliaHelmet]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaHelmet_HelmetType] FOREIGN KEY([HelmetTypeId])
REFERENCES [dbo].[HelmetType] ([Id])
ALTER TABLE [dbo].[MemorabiliaHelmet] CHECK CONSTRAINT [FK_MemorabiliaHelmet_HelmetType]

ALTER TABLE [dbo].[MemorabiliaHelmet]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaHelmet_HelmetFinish] FOREIGN KEY([HelmetFinishId])
REFERENCES [dbo].[HelmetFinish] ([Id])
ALTER TABLE [dbo].[MemorabiliaHelmet] CHECK CONSTRAINT [FK_MemorabiliaHelmet_HelmetFinish]

ALTER TABLE [dbo].[MemorabiliaHelmet]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaHelmet_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaHelmet] CHECK CONSTRAINT [FK_MemorabiliaHelmet_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaHelmet] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaHelmet] (Id, MemorabiliaId, HelmetQualityTypeId, HelmetTypeId, HelmetFinishId, Throwback)
	SELECT * 
	FROM #TempMemorabiliaHelmetTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaHelmet] OFF

--MemorabiliaImage Create
CREATE TABLE [dbo].[MemorabiliaImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[FilePath] nvarchar(500) NOT NULL,
	[UploadDate] [datetime] NOT NULL,
	[ImageTypeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaImage]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaImage_ImageType] FOREIGN KEY([ImageTypeId])
REFERENCES [dbo].[ImageType] ([Id])
ALTER TABLE [dbo].[MemorabiliaImage] CHECK CONSTRAINT [FK_MemorabiliaImage_ImageType]

ALTER TABLE [dbo].[MemorabiliaImage]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaImage_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaImage] CHECK CONSTRAINT [FK_MemorabiliaImage_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaImage] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaImage] (Id, MemorabiliaId, FilePath, UploadDate, ImageTypeId)
	SELECT * 
	FROM #TempMemorabiliaImageTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaImage] OFF

--MemorabiliaJersey Create
CREATE TABLE [dbo].[MemorabiliaJersey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[JerseyQualityTypeId] [int] NOT NULL,
	[JerseyStyleTypeId] [int] NOT NULL,
	[JerseyTypeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaJersey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaJersey]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaJersey_JerseyQualityType] FOREIGN KEY([JerseyQualityTypeId])
REFERENCES [dbo].[JerseyQualityType] ([Id])
ALTER TABLE [dbo].[MemorabiliaJersey] CHECK CONSTRAINT [FK_MemorabiliaJersey_JerseyQualityType]

ALTER TABLE [dbo].[MemorabiliaJersey]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaJersey_JerseyStyleType] FOREIGN KEY([JerseyStyleTypeId])
REFERENCES [dbo].[JerseyStyleType] ([Id])
ALTER TABLE [dbo].[MemorabiliaJersey] CHECK CONSTRAINT [FK_MemorabiliaJersey_JerseyStyleType]

ALTER TABLE [dbo].[MemorabiliaJersey]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaJersey_JerseyType] FOREIGN KEY([JerseyTypeId])
REFERENCES [dbo].[JerseyType] ([Id])
ALTER TABLE [dbo].[MemorabiliaJersey] CHECK CONSTRAINT [FK_MemorabiliaJersey_JerseyType]

ALTER TABLE [dbo].[MemorabiliaJersey]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaJersey_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaJersey] CHECK CONSTRAINT [FK_MemorabiliaJersey_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaJersey] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaJersey] (Id, MemorabiliaId, JerseyQualityTypeId, JerseyStyleTypeId, JerseyTypeId)
	SELECT * 
	FROM #TempMemorabiliaJerseyTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaJersey] OFF

--MemorabiliaLevelType Create
CREATE TABLE [dbo].[MemorabiliaLevelType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[LevelTypeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaLevelType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaLevelType]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaLevelType_LevelType] FOREIGN KEY([LevelTypeId])
REFERENCES [dbo].[LevelType] ([Id])
ALTER TABLE [dbo].[MemorabiliaLevelType] CHECK CONSTRAINT [FK_MemorabiliaLevelType_LevelType]

ALTER TABLE [dbo].[MemorabiliaLevelType]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaLevelType_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaImage] CHECK CONSTRAINT [FK_MemorabiliaImage_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaLevelType] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaLevelType] (Id, MemorabiliaId, LevelTypeId)
	SELECT * 
	FROM #TempMemorabiliaLevelTypeTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaLevelType] OFF

--MemorabiliaLithograph Create
CREATE TABLE [dbo].[MemorabiliaLithograph](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[Framed] [bit] NOT NULL,
	[Matted] [bit] NOT NULL,
 CONSTRAINT [PK_MemorabiliaLithograph] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaLithograph]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaLithograph_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaLithograph] CHECK CONSTRAINT [FK_MemorabiliaLithograph_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaLithograph] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaLithograph] (Id, MemorabiliaId, Framed, Matted)
	SELECT * 
	FROM #TempMemorabiliaLithographTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaLithograph] OFF

--MemorabilaMagazine Create
CREATE TABLE [dbo].[MemorabiliaMagazine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Framed] [bit] NULL,
 CONSTRAINT [PK_MemorabiliaMagazine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaMagazine]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaMagazine_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaMagazine] CHECK CONSTRAINT [FK_MemorabiliaMagazine_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaMagazine] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaMagazine] (Id, MemorabiliaId, [Date], Framed)
	SELECT * 
	FROM #TempMemorabiliaMagazineTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaMagazine] OFF

--MemorabiliaOrientation Create
CREATE TABLE [dbo].[MemorabiliaOrientation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[OrientationId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaOrientation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaOrientation]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaOrientation_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaOrientation] CHECK CONSTRAINT [FK_MemorabiliaOrientation_Memorabilia]

ALTER TABLE [dbo].[MemorabiliaOrientation]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaOrientation_Orientation] FOREIGN KEY([OrientationId])
REFERENCES [dbo].[Orientation] ([Id])
ALTER TABLE [dbo].[MemorabiliaOrientation] CHECK CONSTRAINT [FK_MemorabiliaOrientation_Orientation]

SET IDENTITY_INSERT [dbo].[MemorabiliaOrientation] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaOrientation] (Id, MemorabiliaId, OrientationId)
	SELECT * 
	FROM #TempMemorabiliaOrientationTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaOrientation] OFF

--MemorabiliaPerson Create
CREATE TABLE [dbo].[MemorabiliaPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaPerson]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaPerson_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaPerson] CHECK CONSTRAINT [FK_MemorabiliaPerson_Memorabilia]

ALTER TABLE [dbo].[MemorabiliaPerson]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaPerson_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ALTER TABLE [dbo].[MemorabiliaPerson] CHECK CONSTRAINT [FK_MemorabiliaPerson_Person]

SET IDENTITY_INSERT [dbo].[MemorabiliaPerson] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaPerson] (Id, MemorabiliaId, PersonId)
	SELECT * 
	FROM #TempMemorabiliaPersonTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaPerson] OFF

--MemorabiliaPhoto Create
CREATE TABLE [dbo].[MemorabiliaPhoto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[PhotoTypeId] [int] NOT NULL,
	[Framed] [bit] NOT NULL,
	[Matted] [bit] NOT NULL,
 CONSTRAINT [PK_MemorabiliaPhoto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaPhoto]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaPhoto_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaPhoto] CHECK CONSTRAINT [FK_MemorabiliaPhoto_Memorabilia]

ALTER TABLE [dbo].[MemorabiliaPhoto]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaPhoto_PhotoType] FOREIGN KEY([PhotoTypeId])
REFERENCES [dbo].[PhotoType] ([Id])
ALTER TABLE [dbo].[MemorabiliaPhoto] CHECK CONSTRAINT [FK_MemorabiliaPhoto_PhotoType]

SET IDENTITY_INSERT [dbo].[MemorabiliaPhoto] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaPhoto] (Id, MemorabiliaId, PhotoTypeId, Framed)
	SELECT * 
	FROM #TempMemorabiliaPhotoTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaPhoto] OFF

--MemorabiliaSize Create
CREATE TABLE [dbo].[MemorabiliaSize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaSize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaSize]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaSize_Size] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([Id])
ALTER TABLE [dbo].[MemorabiliaSize] CHECK CONSTRAINT [FK_MemorabiliaSize_Size]

ALTER TABLE [dbo].[MemorabiliaSize]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaSize_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaSize] CHECK CONSTRAINT [FK_MemorabiliaSize_Memorabilia]

SET IDENTITY_INSERT [dbo].[MemorabiliaSize] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaSize] (Id, MemorabiliaId, SizeId)
	SELECT * 
	FROM #TempMemorabiliaSizeTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaSize] OFF

--MemorabiliaSport Create
CREATE TABLE [dbo].[MemorabiliaSport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[SportId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaSport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaSport]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaSport_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaSport] CHECK CONSTRAINT [FK_MemorabiliaSport_Memorabilia]

ALTER TABLE [dbo].[MemorabiliaSport]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaSport_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
ALTER TABLE [dbo].[MemorabiliaSport] CHECK CONSTRAINT [FK_MemorabiliaSport_Sport]

SET IDENTITY_INSERT [dbo].[MemorabiliaSport] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaSport] (Id, MemorabiliaId, SportId)
	SELECT * 
	FROM #TempMemorabiliaSportTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaSport] OFF

--MemorabiliaTeam Create
CREATE TABLE [dbo].[MemorabiliaTeam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaTeam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MemorabiliaTeam]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaTeam_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
ALTER TABLE [dbo].[MemorabiliaTeam] CHECK CONSTRAINT [FK_MemorabiliaTeam_Memorabilia]

ALTER TABLE [dbo].[MemorabiliaTeam]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaTeam_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ALTER TABLE [dbo].[MemorabiliaTeam] CHECK CONSTRAINT [FK_MemorabiliaTeam_Team]

SET IDENTITY_INSERT [dbo].[MemorabiliaTeam] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[MemorabiliaTeam] (Id, MemorabiliaId, TeamId)
	SELECT * 
	FROM #TempMemorabiliaTeamTable
END

SET IDENTITY_INSERT [dbo].[MemorabiliaTeam] OFF

--Personalization Create
CREATE TABLE [dbo].[Personalization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutographId] [int] NOT NULL,
	[Text] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Personalization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Personalization]  WITH CHECK ADD  CONSTRAINT [FK_Personalization_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
ALTER TABLE [dbo].[Personalization] CHECK CONSTRAINT [FK_Personalization_Autograph]

SET IDENTITY_INSERT [dbo].[Personalization] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Personalization] (Id, AutographId, [Text])
	SELECT * 
	FROM #TempPersonalizationTable
END

SET IDENTITY_INSERT [dbo].[Personalization] OFF

--PersonOccupation Create
CREATE TABLE [dbo].[PersonOccupation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[OccupationId] [int] NOT NULL,
	[OccupationTypeId] [int] NOT NULL,
 CONSTRAINT [PK_PersonOccupation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[PersonOccupation]  WITH CHECK ADD  CONSTRAINT [FK_PersonOccupation_Occupation] FOREIGN KEY([OccupationId])
REFERENCES [dbo].[Occupation] ([Id])
ALTER TABLE [dbo].[PersonOccupation] CHECK CONSTRAINT [FK_PersonOccupation_Occupation]

ALTER TABLE [dbo].[PersonOccupation]  WITH CHECK ADD  CONSTRAINT [FK_PersonOccupation_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ALTER TABLE [dbo].[PersonOccupation] CHECK CONSTRAINT [FK_PersonOccupation_Person]

ALTER TABLE [dbo].[PersonOccupation]  WITH CHECK ADD  CONSTRAINT [FK_PersonOccupation_OccupationType] FOREIGN KEY([OccupationTypeId])
REFERENCES [dbo].[OccupationType] ([Id])
ALTER TABLE [dbo].[PersonOccupation] CHECK CONSTRAINT [FK_PersonOccupation_OccupationType]

SET IDENTITY_INSERT [dbo].[PersonOccupation] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[PersonOccupation] (Id, PersonId, OccupationId, OccupationTypeId)
	SELECT * 
	FROM #TempPersonOccupationTable
END

SET IDENTITY_INSERT [dbo].[PersonOccupation] OFF

--PersonTeam Create
CREATE TABLE [dbo].[PersonTeam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[BeginYear] [int] NULL,
	[EndYear] [int] NULL,
 CONSTRAINT [PK_PersonTeam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[PersonTeam]  WITH CHECK ADD  CONSTRAINT [FK_PersonTeam_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ALTER TABLE [dbo].[PersonTeam] CHECK CONSTRAINT [FK_PersonTeam_Team]

ALTER TABLE [dbo].[PersonTeam]  WITH CHECK ADD  CONSTRAINT [FK_PersonTeam_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ALTER TABLE [dbo].[PersonTeam] CHECK CONSTRAINT [FK_PersonTeam_Person]

SET IDENTITY_INSERT [dbo].[PersonTeam] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[PersonTeam] (Id, PersonId, TeamId, BeginYear, EndYear)
	SELECT * 
	FROM #TempPersonTeamTable
END

SET IDENTITY_INSERT [dbo].[PersonTeam] OFF

--Pewter Create
CREATE TABLE [dbo].[Pewter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FranchiseId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
	[ImageTypeId] [int] NULL,
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_Pewter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Pewter]  WITH CHECK ADD  CONSTRAINT [FK_Pewter_Franchise] FOREIGN KEY([FranchiseId])
REFERENCES [dbo].[Franchise] ([Id])
ALTER TABLE [dbo].[Pewter] CHECK CONSTRAINT [FK_Pewter_Franchise]

ALTER TABLE [dbo].[Pewter]  WITH CHECK ADD  CONSTRAINT [FK_Pewter_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ALTER TABLE [dbo].[Pewter] CHECK CONSTRAINT [FK_Pewter_Team]

ALTER TABLE [dbo].[Pewter]  WITH CHECK ADD  CONSTRAINT [FK_Pewter_Size] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([Id])
ALTER TABLE [dbo].[Pewter] CHECK CONSTRAINT [FK_Pewter_Size]

ALTER TABLE [dbo].[Pewter]  WITH CHECK ADD  CONSTRAINT [FK_Pewter_ImageType] FOREIGN KEY([ImageTypeId])
REFERENCES [dbo].[ImageType] ([Id])
ALTER TABLE [dbo].[Pewter] CHECK CONSTRAINT [FK_Pewter_ImageType]

SET IDENTITY_INSERT [dbo].[Pewter] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[Pewter] (Id, FranchiseId, TeamId, SizeId, ImageTypeId, ImagePath)
	SELECT * 
	FROM #TempPewterTable
END

SET IDENTITY_INSERT [dbo].[Pewter] OFF


--TeamConference Create
CREATE TABLE [dbo].[TeamConference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[ConferenceId] [int] NOT NULL,
	[BeginYear] [int] NULL,
	[EndYear] [int] NULL
 CONSTRAINT [PK_TeamConference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[TeamConference]  WITH CHECK ADD  CONSTRAINT [FK_TeamConference_Conference] FOREIGN KEY([ConferenceId])
REFERENCES [dbo].[Conference] ([Id])
ALTER TABLE [dbo].[TeamConference] CHECK CONSTRAINT [FK_TeamConference_Conference]

ALTER TABLE [dbo].[TeamConference]  WITH CHECK ADD  CONSTRAINT [FK_TeamConference_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ALTER TABLE [dbo].[TeamConference] CHECK CONSTRAINT [FK_TeamConference_Team]

SET IDENTITY_INSERT [dbo].[TeamConference] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[TeamConference] (Id, TeamId, ConferenceId, BeginYear, EndYear)
	SELECT * 
	FROM #TempTeamConferenceTable
END

SET IDENTITY_INSERT [dbo].[TeamConference] OFF

--TeamDivision Create
CREATE TABLE [dbo].[TeamDivision](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[DivisionId] [int] NOT NULL,
	[BeginYear] [int] NULL,
	[EndYear] [int] NULL,
 CONSTRAINT [PK_TeamDivision] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[TeamDivision]  WITH CHECK ADD  CONSTRAINT [FK_TeamDivision_Division] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Division] ([Id])
ALTER TABLE [dbo].[TeamDivision] CHECK CONSTRAINT [FK_TeamDivision_Division]

ALTER TABLE [dbo].[TeamDivision]  WITH CHECK ADD  CONSTRAINT [FK_TeamDivision_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ALTER TABLE [dbo].[TeamDivision] CHECK CONSTRAINT [FK_TeamDivision_Team]

SET IDENTITY_INSERT [dbo].[TeamDivision] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[TeamDivision] (Id, TeamId, DivisionId, BeginYear, EndYear)
	SELECT * 
	FROM #TempTeamDivisionTable
END

SET IDENTITY_INSERT [dbo].[TeamDivision] OFF

--TeamLeague Create
CREATE TABLE [dbo].[TeamLeague](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[LeagueId] [int] NOT NULL,
	[BeginYear] [int] NULL,
	[EndYear] [int] NULL,
 CONSTRAINT [PK_TeamLeague] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[TeamLeague]  WITH CHECK ADD  CONSTRAINT [FK_TeamLeague_League] FOREIGN KEY([LeagueId])
REFERENCES [dbo].[League] ([Id])
ALTER TABLE [dbo].[TeamLeague] CHECK CONSTRAINT [FK_TeamLeague_League]

ALTER TABLE [dbo].[TeamLeague]  WITH CHECK ADD  CONSTRAINT [FK_TeamLeague_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
ALTER TABLE [dbo].[TeamLeague] CHECK CONSTRAINT [FK_TeamLeague_Team]

SET IDENTITY_INSERT [dbo].[TeamLeague] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[TeamLeague] (Id, TeamId, LeagueId, BeginYear, EndYear)
	SELECT * 
	FROM #TempTeamLeagueTable
END

SET IDENTITY_INSERT [dbo].[TeamLeague] OFF

--WishList Create
CREATE TABLE [dbo].[WishList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[PersonId] [int] NULL,
	[Rank] [int] NULL,
	[IsUpgrade] [int] NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_WishList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_ItemType]

ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_Person]

ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_User]

SET IDENTITY_INSERT [dbo].[WishList] ON

IF @KeepExistingValues = 1
BEGIN
	INSERT INTO [dbo].[WishList] (Id, ItemTypeId, PersonId, [Rank], IsUpgrade, UserId, CreateDate, LastModifiedDate)
	SELECT * 
	FROM #TempWishListTable
END

SET IDENTITY_INSERT [dbo].[WishList] OFF