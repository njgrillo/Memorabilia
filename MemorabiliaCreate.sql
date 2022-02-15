USE [Memorabilia]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SportLeagueLevel')
BEGIN
	IF OBJECT_ID('tempdb..#TempSportLeagueLevelTable') IS NOT NULL DROP TABLE #TempSportLeagueLevelTable; 

	SELECT * 
	INTO #TempSportLeagueLevelTable
	FROM [dbo].[SportLeagueLevel]

	DROP TABLE [dbo].[SportLeagueLevel]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AutographSpot')
BEGIN
	IF OBJECT_ID('tempdb..#TempAutographSpotTable') IS NOT NULL DROP TABLE #TempAutographSpotTable; 

	SELECT * 
	INTO #TempAutographSpotTable
	FROM [dbo].[AutographSpot]

	DROP TABLE [dbo].[AutographSpot]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaAcquisition')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaAcquisitionTable') IS NOT NULL DROP TABLE #TempMemorabiliaAcquisitionTable; 

	SELECT * 
	INTO #TempMemorabiliaAcquisitionTable
	FROM [dbo].[MemorabiliaAcquisition]

	DROP TABLE [dbo].[MemorabiliaAcquisition]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaBasketball')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaBasketballTable') IS NOT NULL DROP TABLE #TempMemorabiliaBasketballTable; 

	SELECT * 
	INTO #TempMemorabiliaBasketballTable
	FROM [dbo].[MemorabiliaBasketball]

	DROP TABLE [dbo].[MemorabiliaBasketball]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaBat')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaBatTable') IS NOT NULL DROP TABLE #TempMemorabiliaBatTable; 

	SELECT * 
	INTO #TempMemorabiliaBatTable
	FROM [dbo].[MemorabiliaBat]

	DROP TABLE [dbo].[MemorabiliaBat]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaCard')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaCardTable') IS NOT NULL DROP TABLE #TempMemorabiliaCardTable; 

	SELECT * 
	INTO #TempMemorabiliaCardTable
	FROM [dbo].[MemorabiliaCard]

	DROP TABLE [dbo].[MemorabiliaCard]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaFootball')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaFootballTable') IS NOT NULL DROP TABLE #TempMemorabiliaFootballTable; 

	SELECT * 
	INTO #TempMemorabiliaFootballTable
	FROM [dbo].[MemorabiliaFootball]

	DROP TABLE [dbo].[MemorabiliaFootball]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaGame')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaGameTable') IS NOT NULL DROP TABLE #TempMemorabiliaGameTable; 

	SELECT * 
	INTO #TempMemorabiliaGameTable
	FROM [dbo].[MemorabiliaGame]

	DROP TABLE [dbo].[MemorabiliaGame]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaImage')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaImageTable') IS NOT NULL DROP TABLE #TempMemorabiliaImageTable; 

	SELECT * 
	INTO #TempMemorabiliaImageTable
	FROM [dbo].[MemorabiliaImage]

	DROP TABLE [dbo].[MemorabiliaImage]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AutographImage')
BEGIN
	IF OBJECT_ID('tempdb..#TempAutographImageTable') IS NOT NULL DROP TABLE #TempAutographImageTable; 

	SELECT * 
	INTO #TempAutographImageTable
	FROM [dbo].[AutographImage]

	DROP TABLE [dbo].[AutographImage]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaJersey')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaJerseyTable') IS NOT NULL DROP TABLE #TempMemorabiliaJerseyTable; 

	SELECT * 
	INTO #TempMemorabiliaJerseyTable
	FROM [dbo].[MemorabiliaJersey]

	DROP TABLE [dbo].[MemorabiliaJersey]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaLevelType')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaLevelTypeTable') IS NOT NULL DROP TABLE #TempMemorabiliaLevelTypeTable; 

	SELECT * 
	INTO #TempMemorabiliaLevelTypeTable
	FROM [dbo].[MemorabiliaLevelType]

	DROP TABLE [dbo].[MemorabiliaLevelType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaMagazine')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaMagazineTable') IS NOT NULL DROP TABLE #TempMemorabiliaMagazineTable; 

	SELECT * 
	INTO #TempMemorabiliaMagazineTable
	FROM [dbo].[MemorabiliaMagazine]

	DROP TABLE [dbo].[MemorabiliaMagazine]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaOrientation')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaOrientationTable') IS NOT NULL DROP TABLE #TempMemorabiliaOrientationTable; 

	SELECT * 
	INTO #TempMemorabiliaOrientationTable
	FROM [dbo].[MemorabiliaOrientation]

	DROP TABLE [dbo].[MemorabiliaOrientation]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaPhoto')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaPhotoTable') IS NOT NULL DROP TABLE #TempMemorabiliaPhotoTable; 

	SELECT * 
	INTO #TempMemorabiliaPhotoTable
	FROM [dbo].[MemorabiliaPhoto]

	DROP TABLE [dbo].[MemorabiliaPhoto]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Personalization')
BEGIN
	IF OBJECT_ID('tempdb..#TempPersonalizationTable') IS NOT NULL DROP TABLE #TempPersonalizationTable; 

	SELECT * 
	INTO #TempPersonalizationTable
	FROM [dbo].[Personalization]

	DROP TABLE [dbo].[Personalization]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PersonOccupation')
BEGIN
	IF OBJECT_ID('tempdb..#TempPersonOccupationTable') IS NOT NULL DROP TABLE #TempPersonOccupationTable; 

	SELECT * 
	INTO #TempPersonOccupationTable
	FROM [dbo].[PersonOccupation]

	DROP TABLE [dbo].[PersonOccupation]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PersonTeam')
BEGIN
	IF OBJECT_ID('tempdb..#TempPersonTeamTable') IS NOT NULL DROP TABLE #TempPersonTeamTable; 

	SELECT * 
	INTO #TempPersonTeamTable
	FROM [dbo].[PersonTeam]

	DROP TABLE [dbo].[PersonTeam]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'TeamConference')
BEGIN
	IF OBJECT_ID('tempdb..#TempTeamConferenceTable') IS NOT NULL DROP TABLE #TempTeamConferenceTable; 

	SELECT * 
	INTO #TempTeamConferenceTable
	FROM [dbo].[TeamConference]

	DROP TABLE [dbo].[TeamConference]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'TeamDivision')
BEGIN
	IF OBJECT_ID('tempdb..#TempTeamDivisionTable') IS NOT NULL DROP TABLE #TempTeamDivisionTable; 

	SELECT * 
	INTO #TempTeamDivisionTable
	FROM [dbo].[TeamDivision]

	DROP TABLE [dbo].[TeamDivision]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'TeamLeague')
BEGIN
	IF OBJECT_ID('tempdb..#TempTeamLeagueTable') IS NOT NULL DROP TABLE #TempTeamLeagueTable; 

	SELECT * 
	INTO #TempTeamLeagueTable
	FROM [dbo].[TeamLeague]

	DROP TABLE [dbo].[TeamLeague]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'WishList')
BEGIN
	IF OBJECT_ID('tempdb..#TempWishListTable') IS NOT NULL DROP TABLE #TempWishListTable; 

	SELECT * 
	INTO #TempWishListTable
	FROM [dbo].[WishList]

	DROP TABLE [dbo].[WishList]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaBaseball')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaBaseballTable') IS NOT NULL DROP TABLE #TempMemorabiliaBaseballTable; 

	SELECT * 
	INTO #TempMemorabiliaBaseballTable
	FROM [dbo].[MemorabiliaBaseball]

	DROP TABLE [dbo].[MemorabiliaBaseball]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaBrand')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaBrandTable') IS NOT NULL DROP TABLE #TempMemorabiliaBrandTable; 

	SELECT * 
	INTO #TempMemorabiliaBrandTable
	FROM [dbo].[MemorabiliaBrand]

	DROP TABLE [dbo].[MemorabiliaBrand]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaCommissioner')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaCommissionerTable') IS NOT NULL DROP TABLE #TempMemorabiliaCommissionerTable; 

	SELECT * 
	INTO #TempMemorabiliaCommissionerTable
	FROM [dbo].[MemorabiliaCommissioner]

	DROP TABLE [dbo].[MemorabiliaCommissioner]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaSize')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaSizeTable') IS NOT NULL DROP TABLE #TempMemorabiliaSizeTable; 

	SELECT * 
	INTO #TempMemorabiliaSizeTable
	FROM [dbo].[MemorabiliaSize]

	DROP TABLE [dbo].[MemorabiliaSize]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeGameStyleType')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeGameStyleTypeTable') IS NOT NULL DROP TABLE #TempItemTypeGameStyleTypeTable; 

	SELECT * 
	INTO #TempItemTypeGameStyleTypeTable
	FROM [dbo].[ItemTypeGameStyleType]

	DROP TABLE [dbo].[ItemTypeGameStyleType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeLevel')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeLevelTable') IS NOT NULL DROP TABLE #TempItemTypeLevelTable; 

	SELECT * 
	INTO #TempItemTypeLevelTable
	FROM [dbo].[ItemTypeLevel]

	DROP TABLE [dbo].[ItemTypeLevel]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeBrand')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeBrandTable') IS NOT NULL DROP TABLE #TempItemTypeBrandTable; 

	SELECT * 
	INTO #TempItemTypeBrandTable
	FROM [dbo].[ItemTypeBrand]

	DROP TABLE [dbo].[ItemTypeBrand]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeSize')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeSizeTable') IS NOT NULL DROP TABLE #TempItemTypeSizeTable; 

	SELECT * 
	INTO #TempItemTypeSizeTable
	FROM [dbo].[ItemTypeSize]

	DROP TABLE [dbo].[ItemTypeSize]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeSport')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeSportTable') IS NOT NULL DROP TABLE #TempItemTypeSportTable; 

	SELECT * 
	INTO #TempItemTypeSportTable
	FROM [dbo].[ItemTypeSport]

	DROP TABLE [dbo].[ItemTypeSport]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemTypeSpot')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeSpotTable') IS NOT NULL DROP TABLE #TempItemTypeSpotTable; 

	SELECT * 
	INTO #TempItemTypeSpotTable
	FROM [dbo].[ItemTypeSpot]

	DROP TABLE [dbo].[ItemTypeSpot]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'WritingInstrumentBrand')
BEGIN
	IF OBJECT_ID('tempdb..#TempWritingInstrumentBrandTable') IS NOT NULL DROP TABLE #TempWritingInstrumentBrandTable; 

	SELECT * 
	INTO #TempWritingInstrumentBrandTable
	FROM [dbo].[WritingInstrumentBrand]

	DROP TABLE [dbo].[WritingInstrumentBrand]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AutographAuthentication')
BEGIN
	IF OBJECT_ID('tempdb..#TempAutographAuthenticationTable') IS NOT NULL DROP TABLE #TempAutographAuthenticationTable; 

	SELECT * 
	INTO #TempAutographAuthenticationTable
	FROM [dbo].[AutographAuthentication]

	DROP TABLE [dbo].[AutographAuthentication]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Inscription')
BEGIN
	IF OBJECT_ID('tempdb..#TempInscriptionTable') IS NOT NULL DROP TABLE #TempInscriptionTable; 

	SELECT * 
	INTO #TempInscriptionTable
	FROM [dbo].[Inscription]

	DROP TABLE [dbo].[Inscription]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Autograph')
BEGIN
	IF OBJECT_ID('tempdb..#TempAutographTable') IS NOT NULL DROP TABLE #TempAutographTable; 

	SELECT * 
	INTO #TempAutographTable
	FROM [dbo].[Autograph]

	DROP TABLE [dbo].[Autograph]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Event')
BEGIN
	IF OBJECT_ID('tempdb..#TempEventTable') IS NOT NULL DROP TABLE #TempEventTable; 

	SELECT * 
	INTO #TempEventTable
	FROM [dbo].[Event]

	DROP TABLE [dbo].[Event]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'HallOfFame')
BEGIN
	IF OBJECT_ID('tempdb..#TempHallOfFameTable') IS NOT NULL DROP TABLE #TempHallOfFameTable; 

	SELECT * 
	INTO #TempHallOfFameTable
	FROM [dbo].[HallOfFame]

	DROP TABLE [dbo].[HallOfFame]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaPerson')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaPersonTable') IS NOT NULL DROP TABLE #TempMemorabiliaPersonTable; 

	SELECT * 
	INTO #TempMemorabiliaPersonTable
	FROM [dbo].[MemorabiliaPerson]

	DROP TABLE [dbo].[MemorabiliaPerson]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaTeam')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaTeamTable') IS NOT NULL DROP TABLE #TempMemorabiliaTeamTable; 

	SELECT * 
	INTO #TempMemorabiliaTeamTable
	FROM [dbo].[MemorabiliaTeam]

	DROP TABLE [dbo].[MemorabiliaTeam]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MemorabiliaSport')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaSportTable') IS NOT NULL DROP TABLE #TempMemorabiliaSportTable; 

	SELECT * 
	INTO #TempMemorabiliaSportTable
	FROM [dbo].[MemorabiliaSport]

	DROP TABLE [dbo].[MemorabiliaSport]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Memorabilia')
BEGIN
	IF OBJECT_ID('tempdb..#TempMemorabiliaTable') IS NOT NULL DROP TABLE #TempMemorabiliaTable; 

	SELECT * 
	INTO #TempMemorabiliaTable
	FROM [dbo].[Memorabilia]

	DROP TABLE [dbo].[Memorabilia]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SportDivision')
BEGIN
	IF OBJECT_ID('tempdb..#TempSportDivisionTable') IS NOT NULL DROP TABLE #TempSportDivisionTable; 

	SELECT * 
	INTO #TempSportDivisionTable
	FROM [dbo].[SportDivision]

	DROP TABLE [dbo].[SportDivision]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SportLeague')
BEGIN
	IF OBJECT_ID('tempdb..#TempSportLeagueTable') IS NOT NULL DROP TABLE #TempSportLeagueTable; 

	SELECT * 
	INTO #TempSportLeagueTable
	FROM [dbo].[SportLeague]

	DROP TABLE [dbo].[SportLeague]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'League')
BEGIN
	IF OBJECT_ID('tempdb..#TempLeagueTable') IS NOT NULL DROP TABLE #TempLeagueTable; 

	SELECT * 
	INTO #TempLeagueTable
	FROM [dbo].[League]

	DROP TABLE [dbo].[League]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AuthenticationCompany')
BEGIN
	IF OBJECT_ID('tempdb..#TempAuthenticationCompanyTable') IS NOT NULL DROP TABLE #TempAuthenticationCompanyTable; 

	SELECT * 
	INTO #TempAuthenticationCompanyTable
	FROM [dbo].[AuthenticationCompany]

	DROP TABLE [dbo].[AuthenticationCompany]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GameStyleType')
BEGIN
	IF OBJECT_ID('tempdb..#TempGameStyleTypeTable') IS NOT NULL DROP TABLE #TempGameStyleTypeTable; 

	SELECT * 
	INTO #TempGameStyleTypeTable
	FROM [dbo].[GameStyleType]

	DROP TABLE [dbo].[GameStyleType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BaseballType')
BEGIN
	IF OBJECT_ID('tempdb..#TempBaseballTypeTable') IS NOT NULL DROP TABLE #TempBaseballTypeTable; 

	SELECT * 
	INTO #TempBaseballTypeTable
	FROM [dbo].[BaseballType]

	DROP TABLE [dbo].[BaseballType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BasketballType')
BEGIN
	IF OBJECT_ID('tempdb..#TempBasketballTypeTable') IS NOT NULL DROP TABLE #TempBasketballTypeTable; 

	SELECT * 
	INTO #TempBasketballTypeTable
	FROM [dbo].[BasketballType]

	DROP TABLE [dbo].[BasketballType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'BatType')
BEGIN
	IF OBJECT_ID('tempdb..#TempBatTypeTable') IS NOT NULL DROP TABLE #TempBatTypeTable; 

	SELECT * 
	INTO #TempBatTypeTable
	FROM [dbo].[BatType]

	DROP TABLE [dbo].[BatType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'CardType')
BEGIN
	IF OBJECT_ID('tempdb..#TempCardTypeTable') IS NOT NULL DROP TABLE #TempCardTypeTable; 

	SELECT * 
	INTO #TempCardTypeTable
	FROM [dbo].[CardType]

	DROP TABLE [dbo].[CardType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Color')
BEGIN
	IF OBJECT_ID('tempdb..#TempColorTable') IS NOT NULL DROP TABLE #TempColorTable; 

	SELECT * 
	INTO #TempColorTable
	FROM [dbo].[Color]

	DROP TABLE [dbo].[Color]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Commissioner')
BEGIN
	IF OBJECT_ID('tempdb..#TempCommissionerTable') IS NOT NULL DROP TABLE #TempCommissionerTable; 

	SELECT * 
	INTO #TempCommissionerTable
	FROM [dbo].[Commissioner]

	DROP TABLE [dbo].[Commissioner]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Condition')
BEGIN
	IF OBJECT_ID('tempdb..#TempConditionTable') IS NOT NULL DROP TABLE #TempConditionTable; 

	SELECT * 
	INTO #TempConditionTable
	FROM [dbo].[Condition]

	DROP TABLE [dbo].[Condition]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Division')
BEGIN
	IF OBJECT_ID('tempdb..#TempDivisionTable') IS NOT NULL DROP TABLE #TempDivisionTable; 

	SELECT * 
	INTO #TempDivisionTable
	FROM [dbo].[Division]

	DROP TABLE [dbo].[Division]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FigureType')
BEGIN
	IF OBJECT_ID('tempdb..#TempFigureTypeTable') IS NOT NULL DROP TABLE #TempFigureTypeTable; 

	SELECT * 
	INTO #TempFigureTypeTable
	FROM [dbo].[FigureType]

	DROP TABLE [dbo].[FigureType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'FootballType')
BEGIN
	IF OBJECT_ID('tempdb..#TempFootballTypeTable') IS NOT NULL DROP TABLE #TempFootballTypeTable; 

	SELECT * 
	INTO #TempFootballTypeTable
	FROM [dbo].[FootballType]

	DROP TABLE [dbo].[FootballType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'HelmetQualityType')
BEGIN
	IF OBJECT_ID('tempdb..#TempHelmetQualityTypeTable') IS NOT NULL DROP TABLE #TempHelmetQualityTypeTable; 

	SELECT * 
	INTO #TempHelmetQualityTypeTable
	FROM [dbo].[HelmetQualityType]

	DROP TABLE [dbo].[HelmetQualityType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GloveType')
BEGIN
	IF OBJECT_ID('tempdb..#TempGloveTypeTable') IS NOT NULL DROP TABLE #TempGloveTypeTable; 

	SELECT * 
	INTO #TempGloveTypeTable
	FROM [dbo].[GloveType]

	DROP TABLE [dbo].[GloveType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'HelmetType')
BEGIN
	IF OBJECT_ID('tempdb..#TempHelmetTypeTable') IS NOT NULL DROP TABLE #TempHelmetTypeTable; 

	SELECT * 
	INTO #TempHelmetTypeTable
	FROM [dbo].[HelmetType]

	DROP TABLE [dbo].[HelmetType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'InscriptionType')
BEGIN
	IF OBJECT_ID('tempdb..#TempInscriptionTypeTable') IS NOT NULL DROP TABLE #TempInscriptionTypeTable; 

	SELECT * 
	INTO #TempInscriptionTypeTable
	FROM [dbo].[InscriptionType]

	DROP TABLE [dbo].[InscriptionType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ItemType')
BEGIN
	IF OBJECT_ID('tempdb..#TempItemTypeTable') IS NOT NULL DROP TABLE #TempItemTypeTable; 

	SELECT * 
	INTO #TempItemTypeTable
	FROM [dbo].[ItemType]

	DROP TABLE [dbo].[ItemType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Conference')
BEGIN
	IF OBJECT_ID('tempdb..#TempConferenceTable') IS NOT NULL DROP TABLE #TempConferenceTable; 

	SELECT * 
	INTO #TempConferenceTable
	FROM [dbo].[Conference]

	DROP TABLE [dbo].[Conference]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'LevelType')
BEGIN
	IF OBJECT_ID('tempdb..#TempLevelTypeTable') IS NOT NULL DROP TABLE #TempLevelTypeTable; 

	SELECT * 
	INTO #TempLevelTypeTable
	FROM [dbo].[LevelType]

	DROP TABLE [dbo].[LevelType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'JerseyQualityType')
BEGIN
	IF OBJECT_ID('tempdb..#TempJerseyQualityTypeTable') IS NOT NULL DROP TABLE #TempJerseyQualityTypeTable; 

	SELECT * 
	INTO #TempJerseyQualityTypeTable
	FROM [dbo].[JerseyQualityType]

	DROP TABLE [dbo].[JerseyQualityType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'JerseyStyleType')
BEGIN
	IF OBJECT_ID('tempdb..#TempJerseyStyleTypeTable') IS NOT NULL DROP TABLE #TempJerseyStyleTypeTable; 

	SELECT * 
	INTO #TempJerseyStyleTypeTable
	FROM [dbo].[JerseyStyleType]

	DROP TABLE [dbo].[JerseyStyleType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'JerseyType')
BEGIN
	IF OBJECT_ID('tempdb..#TempJerseyTypeTable') IS NOT NULL DROP TABLE #TempJerseyTypeTable; 

	SELECT * 
	INTO #TempJerseyTypeTable
	FROM [dbo].[JerseyType]

	DROP TABLE [dbo].[JerseyType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'MagazineType')
BEGIN
	IF OBJECT_ID('tempdb..#TempMagazineTypeTable') IS NOT NULL DROP TABLE #TempMagazineTypeTable; 

	SELECT * 
	INTO #TempMagazineTypeTable
	FROM [dbo].[MagazineType]

	DROP TABLE [dbo].[MagazineType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Occupation')
BEGIN
	IF OBJECT_ID('tempdb..#TempOccupationTable') IS NOT NULL DROP TABLE #TempOccupationTable; 

	SELECT * 
	INTO #TempOccupationTable
	FROM [dbo].[Occupation]

	DROP TABLE [dbo].[Occupation]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Orientation')
BEGIN
	IF OBJECT_ID('tempdb..#TempOrientationTable') IS NOT NULL DROP TABLE #TempOrientationTable; 

	SELECT * 
	INTO #TempOrientationTable
	FROM [dbo].[Orientation]

	DROP TABLE [dbo].[Orientation]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Person')
BEGIN
	IF OBJECT_ID('tempdb..#TempPersonTable') IS NOT NULL DROP TABLE #TempPersonTable; 

	SELECT * 
	INTO #TempPersonTable
	FROM [dbo].[Person]

	DROP TABLE [dbo].[Person]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PhotoType')
BEGIN
	IF OBJECT_ID('tempdb..#TempPhotoTypeTable') IS NOT NULL DROP TABLE #TempPhotoTypeTable; 

	SELECT * 
	INTO #TempPhotoTypeTable
	FROM [dbo].[PhotoType]

	DROP TABLE [dbo].[PhotoType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Size')
BEGIN
	IF OBJECT_ID('tempdb..#TempSizeTable') IS NOT NULL DROP TABLE #TempSizeTable; 

	SELECT * 
	INTO #TempSizeTable
	FROM [dbo].[Size]

	DROP TABLE [dbo].[Size]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Sport')
BEGIN
	IF OBJECT_ID('tempdb..#TempSportTable') IS NOT NULL DROP TABLE #TempSportTable; 

	SELECT * 
	INTO #TempSportTable
	FROM [dbo].[Sport]

	DROP TABLE [dbo].[Sport]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Spot')
BEGIN
	IF OBJECT_ID('tempdb..#TempSpotTable') IS NOT NULL DROP TABLE #TempSpotTable; 

	SELECT * 
	INTO #TempSpotTable
	FROM [dbo].[Spot]

	DROP TABLE [dbo].[Spot]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Team')
BEGIN
	IF OBJECT_ID('tempdb..#TempTeamTable') IS NOT NULL DROP TABLE #TempTeamTable; 

	SELECT * 
	INTO #TempTeamTable
	FROM [dbo].[Team]

	DROP TABLE [dbo].[Team]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'User')
BEGIN
	IF OBJECT_ID('tempdb..#TempUserTable') IS NOT NULL DROP TABLE #TempUserTable; 

	SELECT * 
	INTO #TempUserTable
	FROM [dbo].[User]

	DROP TABLE [dbo].[User]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'WritingInstrument')
BEGIN
	IF OBJECT_ID('tempdb..#TempWritingInstrumentTable') IS NOT NULL DROP TABLE #TempWritingInstrumentTable; 

	SELECT * 
	INTO #TempWritingInstrumentTable
	FROM [dbo].[WritingInstrument]

	DROP TABLE [dbo].[WritingInstrument]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Brand')
BEGIN
	IF OBJECT_ID('tempdb..#TempBrandTable') IS NOT NULL DROP TABLE #TempBrandTable; 

	SELECT * 
	INTO #TempBrandTable
	FROM [dbo].[Brand]

	DROP TABLE [dbo].[Brand]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Franchise')
BEGIN
	IF OBJECT_ID('tempdb..#TempFranchiseTable') IS NOT NULL DROP TABLE #TempFranchiseTable; 

	SELECT * 
	INTO #TempFranchiseTable
	FROM [dbo].[Franchise]

	DROP TABLE [dbo].[Franchise]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Role')
BEGIN
	IF OBJECT_ID('tempdb..#TempRoleTable') IS NOT NULL DROP TABLE #TempRoleTable; 

	SELECT * 
	INTO #TempRoleTable
	FROM [dbo].[Role]

	DROP TABLE [dbo].[Role]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PrivacyType')
BEGIN
	IF OBJECT_ID('tempdb..#TempPrivacyTypeTable') IS NOT NULL DROP TABLE #TempPrivacyTypeTable; 

	SELECT * 
	INTO #TempPrivacyTypeTable
	FROM [dbo].[PrivacyType]

	DROP TABLE [dbo].[PrivacyType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Acquisition')
BEGIN
	IF OBJECT_ID('tempdb..#TempAcquisitionTable') IS NOT NULL DROP TABLE #TempAcquisitionTable; 

	SELECT * 
	INTO #TempAcquisitionTable
	FROM [dbo].[Acquisition]

	DROP TABLE [dbo].[Acquisition]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'AcquisitionType')
BEGIN
	IF OBJECT_ID('tempdb..#TempAcquisitionTypeTable') IS NOT NULL DROP TABLE #TempAcquisitionTypeTable; 

	SELECT * 
	INTO #TempAcquisitionTypeTable
	FROM [dbo].[AcquisitionType]

	DROP TABLE [dbo].[AcquisitionType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ImageType')
BEGIN
	IF OBJECT_ID('tempdb..#TempImageTypeTable') IS NOT NULL DROP TABLE #TempImageTypeTable; 

	SELECT * 
	INTO #TempImageTypeTable
	FROM [dbo].[ImageType]

	DROP TABLE [dbo].[ImageType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'OccupationType')
BEGIN
	IF OBJECT_ID('tempdb..#TempOccupationTypeTable') IS NOT NULL DROP TABLE #TempOccupationTypeTable; 

	SELECT * 
	INTO #TempOccupationTypeTable
	FROM [dbo].[OccupationType]

	DROP TABLE [dbo].[OccupationType]
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'PurchaseType')
BEGIN
	IF OBJECT_ID('tempdb..#TempPurchaseTypeTable') IS NOT NULL DROP TABLE #TempPurchaseTypeTable; 

	SELECT * 
	INTO #TempPurchaseTypeTable
	FROM [dbo].[PurchaseType]

	DROP TABLE [dbo].[PurchaseType]
END

--Domain Tables
CREATE TABLE [dbo].[AcquisitionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_AcquisitionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[AcquisitionType] ON

--INSERT INTO  [dbo].[AcquisitionType] (Id, Name, Abbreviation)
--VALUES (1, 'Private Signing', NULL)
--     , (2, 'Public Signing', NULL)
--	 , (3, 'In Person', 'IP')
--	 , (4, 'Through the Mail', 'TTM')
--	 , (5, 'Trade', NULL)
--	 , (6, 'Purchase', NULL)
--	 , (7, 'Gift', NULL)

INSERT INTO [dbo].[AcquisitionType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempAcquisitionTypeTable

SET IDENTITY_INSERT [dbo].[AcquisitionType] OFF

CREATE TABLE [dbo].[AuthenticationCompany](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_AuthenticationCompany] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[AuthenticationCompany] ON

INSERT INTO  [dbo].[AuthenticationCompany] (Id, Name, Abbreviation)
VALUES (1, 'James Spence Authentication', 'JSA')
     , (2, 'Beckett Authentication Services', 'BAS')
	 , (3, 'Professional Sports Authenticator', 'PSA')

SET IDENTITY_INSERT [dbo].[AuthenticationCompany] OFF

CREATE TABLE [dbo].[GameStyleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_GameStyleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[GameStyleType] ON

--INSERT INTO  [dbo].[GameStyleType] (Id, Name, Abbreviation)
--VALUES (1, 'Game Used', NULL)
--     , (2, 'Game Worn', NULL)
--     , (3, 'Game Issued', NULL)
--	 , (4, 'None', NULL)
--	 , (5, 'Other', NULL)

INSERT INTO [dbo].[GameStyleType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempGameStyleTypeTable

SET IDENTITY_INSERT [dbo].[GameStyleType] OFF

CREATE TABLE [dbo].[BaseballType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_BaseballType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[BaseballType] ON

--INSERT INTO  [dbo].[BaseballType] (Id, Name, Abbreviation)
--VALUES (1, 'Black Baseball', 'ROMLBBG')
--     , (2, 'All Star', NULL)
--	 , (3, 'World Series', NULL)
--	 , (4, 'Offical Major League Baseball', 'ROMLB')
--	 , (5, 'Other', NULL)
--	 , (6, 'None', NULL)
--	 , (7, 'American League', NULL)
--	 , (8, 'National League', NULL)
--	 , (9, 'Father''s Day', NULL)
--	 , (10, 'Mother''s', NULL)
--	 , (11, 'Cy Young', NULL)
--	 , (12, 'Commemorative', NULL)
--	 , (13, 'Home Run Derby', NULL)
--	 , (14, 'Gold', 'ROMLBG')
--	 , (15, 'Gold Glove', 'RGGBB')
--	 , (16, 'Spring Training', NULL)
--	 , (17, 'Gold World Series',  NULL)
--	 , (18, 'Team Anniversary', NULL)
--	 , (19, 'All Star Future''s Game', NULL)
--	 , (20, 'Opening Day', NULL)
--	 , (21, 'Post Season', NULL)
--	 , (22, 'Hall of Fame', NULL)
--   , (23, 'Memorial Day', NULL)

INSERT INTO [dbo].[BaseballType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempBaseballTypeTable

SET IDENTITY_INSERT [dbo].[BaseballType] OFF

CREATE TABLE [dbo].[BasketballType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_BasketballType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[BasketballType] ON

--INSERT INTO  [dbo].[BasketballType] (Id, Name, Abbreviation)
--VALUES (1, 'Official', NULL)
--     , (2, 'Finals', NULL)
--	 , (3, 'Commemorative', NULL)
--	 , (4, 'Other', NULL)
--   , (5, 'None', NULL)

INSERT INTO [dbo].[BasketballType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempBasketballTypeTable

SET IDENTITY_INSERT [dbo].[BasketballType] OFF

CREATE TABLE [dbo].[BatType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_BatType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[BatType] ON

--INSERT INTO  [dbo].[BatType] (Id, Name, Abbreviation)
--VALUES (1, 'Big Stick', NULL)
--     , (2, 'Game Model', NULL)
--	 , (3, 'Commemorative', NULL)
--	 , (4, 'None', NULL)
--	 , (5, 'Other', NULL)

INSERT INTO [dbo].[BatType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempBatTypeTable

SET IDENTITY_INSERT [dbo].[BatType] OFF

CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Brand] ON

--INSERT INTO  [dbo].[Brand] (Id, Name, Abbreviation)
--VALUES (1, 'Rawlings', NULL)
--     , (2, 'Nike', NULL)
--	 , (3, 'Reebok', 'RBK')
--	 , (4, 'Adidas', NULL)
--	 , (5, 'Majestic', NULL)
--	 , (6, 'Wilson', NULL)

INSERT INTO [dbo].[Brand] (Id, Name, Abbreviation)
SELECT * 
FROM #TempBrandTable

SET IDENTITY_INSERT [dbo].[Brand] OFF

CREATE TABLE [dbo].[CardType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_CardType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[CardType] ON

INSERT INTO  [dbo].[CardType] (Id, Name, Abbreviation)
VALUES (1, 'Trading', NULL)
     , (2, 'Playing', NULL)

SET IDENTITY_INSERT [dbo].[CardType] OFF

CREATE TABLE [dbo].[Color](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Color] ON

--INSERT INTO  [dbo].[Color] (Id, Name, Abbreviation)
--VALUES (1, 'Blue', NULL)
--     , (2, 'Black', NULL)
--	 , (3, 'Silver', NULL)
--	 , (4, 'Gold', NULL)
--	 , (5, 'Red', NULL)
--	 , (6, 'Orange', NULL)
--	 , (7, 'Other', NULL)

INSERT INTO [dbo].[Color] (Id, Name, Abbreviation)
SELECT * 
FROM #TempColorTable

SET IDENTITY_INSERT [dbo].[Color] OFF

CREATE TABLE [dbo].[Condition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Condition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Condition] ON

INSERT INTO  [dbo].[Condition] (Id, Name, Abbreviation)
VALUES (1, 'Pristine', NULL)
     , (2, 'Gem Mint', NULL)
	 , (3, 'Mint', NULL)
	 , (4, 'Near Mint', NULL)
	 , (5, 'Excellent', NULL)
	 , (6, 'Fair', NULL)
	 , (7, 'Poor', NULL)

SET IDENTITY_INSERT [dbo].[Condition] OFF

CREATE TABLE [dbo].[FigureType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_FigureType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[FigureType] ON

INSERT INTO  [dbo].[FigureType] (Id, Name, Abbreviation)
VALUES (1, 'Starting Lineup', 'SLU')
     , (2, 'Funko Pop', NULL)

SET IDENTITY_INSERT [dbo].[FigureType] OFF

CREATE TABLE [dbo].[FootballType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_FootballType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[FootballType] ON

--INSERT INTO  [dbo].[FootballType] (Id, Name, Abbreviation)
--VALUES (1, 'Duke', NULL)
--     , (2, 'Duke Replica', NULL)
--	 , (3, 'Commemorative', NULL)
--	 , (4, 'Other', NULL)

INSERT INTO [dbo].[FootballType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempFootballTypeTable

SET IDENTITY_INSERT [dbo].[FootballType] OFF

CREATE TABLE [dbo].[Franchise](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SportId] [int] NOT NULL,
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
GO

SET IDENTITY_INSERT [dbo].[Franchise] ON

--INSERT INTO  [dbo].[Franchise] (Id, SportId, Name, Location, FoundYear, ImagePath, CreateDate)
--VALUES (1, 1, 'Orioles', 'Baltimore', 1901, NULL, GETUTCDATE())
--     , (2, 1, 'Red Sox', 'Boston', 1901, NULL, GETUTCDATE())
--	 , (3, 1, 'Yankees', 'New York', 1901, NULL, GETUTCDATE())
--	 , (4, 1, 'Rays', 'Tampa Bay', 1998, NULL, GETUTCDATE())
--	 , (5, 1, 'Blue Jays', 'Toronto', 1977, NULL, GETUTCDATE())
--	 , (6, 1, 'White Sox', 'Chicago', 1901, NULL, GETUTCDATE())
--	 , (7, 1, 'Guardians', 'Cleveland', 1901, NULL, GETUTCDATE())
--	 , (8, 1, 'Tigers', 'Detroit', 1901, NULL, GETUTCDATE())
--	 , (9, 1, 'Twins', 'Minnesota', 1901, NULL, GETUTCDATE())
--	 , (10, 1, 'Royals', 'Kansas City', 1969, NULL, GETUTCDATE())
--	 , (11, 1, 'Astros', 'Houston', 1962, NULL, GETUTCDATE())
--	 , (12, 1, 'Angels', 'Los Angeles', 1961, NULL, GETUTCDATE())
--	 , (13, 1, 'Athletics', 'Oakland', 1901, NULL, GETUTCDATE())
--	 , (14, 1, 'Mariners', 'Seattle', 1977, NULL, GETUTCDATE())
--	 , (15, 1, 'Rangers', 'Texas', 1961, NULL, GETUTCDATE())
--	 , (16, 1, 'Braves', 'Atlanta', 1871, NULL, GETUTCDATE())
--	 , (17, 1, 'Marlins', 'Miami', 1993, NULL, GETUTCDATE())
--	 , (18, 1, 'Mets', 'New York', 1962, NULL, GETUTCDATE())
--	 , (19, 1, 'Phillies', 'Philadelphia', 1883, NULL, GETUTCDATE())
--	 , (20, 1, 'Nationals', 'Washington', 1969, NULL, GETUTCDATE())
--	 , (21, 1, 'Brewers', 'Milwaukee', 1969, NULL, GETUTCDATE())
--	 , (22, 1, 'Reds', 'Cincinnati', 1882, NULL, GETUTCDATE())
--	 , (23, 1, 'Pirates', 'Pittsburgh', 1882, NULL, GETUTCDATE())
--	 , (24, 1, 'Cubs', 'Chicago', 1874, NULL, GETUTCDATE())
--	 , (25, 1, 'Cardinals', 'St. Louis', 1882, NULL, GETUTCDATE())
--	 , (26, 1, 'Dodgers', 'Los Angeles', 1884, NULL, GETUTCDATE())
--	 , (27, 1, 'Giants', 'San Francisco', 1883, NULL, GETUTCDATE())
--	 , (28, 1, 'Diamondbacks', 'Arizona', 1998, NULL, GETUTCDATE())
--	 , (29, 1, 'Rockies', 'Colorado', 1993, NULL, GETUTCDATE())
--	 , (30, 1, 'Padres', 'San Diego', 1969, NULL, GETUTCDATE())

INSERT INTO [dbo].[Franchise] (Id, SportId, Name, Location, FoundYear, ImagePath, CreateDate, LastModifiedDate)
SELECT * 
FROM #TempFranchiseTable

SET IDENTITY_INSERT [dbo].[Franchise] OFF

CREATE TABLE [dbo].[HelmetQualityType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_HelmetQualityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[HelmetQualityType] ON

INSERT INTO  [dbo].[HelmetQualityType] (Id, Name, Abbreviation)
VALUES (1, 'Authentic', 'AUTH')
     , (2, 'Replica', 'REP')

SET IDENTITY_INSERT [dbo].[HelmetQualityType] OFF

CREATE TABLE [dbo].[GloveType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_GloveType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[GloveType] ON

INSERT INTO  [dbo].[GloveType] (Id, Name, Abbreviation)
VALUES (1, 'Baseball Glove', NULL)
     , (2, 'Batting Glove', NULL)
	 , (3, 'Football Glove', NULL)
	 , (4, 'Hockey Glove', NULL)
	 , (5, 'Boxing Glove', NULL)
	 , (6, 'MMA Glove', 'MMA')

SET IDENTITY_INSERT [dbo].[GloveType] OFF

CREATE TABLE [dbo].[HelmetType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_HelmetType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[HelmetType] ON

--INSERT INTO  [dbo].[HelmetType] (Id, Name, Abbreviation)
--VALUES (1, 'Pewter', NULL)
--     , (2, 'Chrome', NULL)
--	 , (3, 'Throwback', NULL)
--	 , (4, '24k Gold Plated', NULL)
--	 , (5, 'Sterling Silver', NULL)
--	 , (6, 'Bronze', NULL)
--	 , (7, 'Revolution', NULL)
--	 , (8, 'Speed', NULL)
--	 , (9, 'Blaze', NULL)
--	 , (10, 'Ice', NULL)
--	 , (11, 'Flash', NULL)

INSERT INTO [dbo].[HelmetType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempHelmetTypeTable

SET IDENTITY_INSERT [dbo].[HelmetType] OFF

CREATE TABLE [dbo].[ImageType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_ImageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[ImageType] ON

--INSERT INTO  [dbo].[ImageType] (Id, Name, Abbreviation)
--VALUES (1, 'Primary', NULL)
--     , (2, 'Secondary', NULL)

INSERT INTO [dbo].[ImageType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempImageTypeTable

SET IDENTITY_INSERT [dbo].[ImageType] OFF

CREATE TABLE [dbo].[InscriptionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_InscriptionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[InscriptionType] ON

--INSERT INTO  [dbo].[InscriptionType] (Id, Name, Abbreviation)
--VALUES (1, 'Hall of Fame', 'HOF')
--     , (2, 'Most Valuable Player', 'MVP')
--	 , (3, 'Number', NULL)
--	 , (4, 'Rookie of the Year', 'ROY')
--	 , (5, 'Cy Young', 'CY')
--	 , (6, 'Bible Verse', NULL)

INSERT INTO [dbo].[InscriptionType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempInscriptionTypeTable

SET IDENTITY_INSERT [dbo].[InscriptionType] OFF

CREATE TABLE [dbo].[ItemType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_ItemType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[ItemType] ON

--INSERT INTO  [dbo].[ItemType] (Id, Name, Abbreviation)
--VALUES (1, 'Baseball', NULL)
--     , (2, 'Basketball', NULL)
--	 , (3, 'Bat', NULL)
--	 , (4, 'Book', NULL)
--	 , (5, 'Cachet', NULL)
--	 , (6, 'Canvas', NULL)
--	 , (7, 'Card', NULL)
--	 , (8, 'Figure', NULL)
--	 , (9, 'Football', NULL)
--	 , (10, 'Glove', NULL)
--	 , (11, 'Helmet', NULL)
--	 , (12, 'Jersey', NULL)
--	 , (13, 'Jersey Number', NULL)
--	 , (14, 'Magazine', NULL)
--	 , (15, 'Other', NULL)
--	 , (16, 'Painting', NULL)
--	 , (17, 'Photo', NULL)
--	 , (18, 'Puck', NULL)
--	 , (19, 'Pylon', NULL)
--	 , (20, 'Soccer Ball', NULL)
--	 , (21, 'Hockey Stick', NULL)
--	 , (22, 'Ticket Stub', NULL)

INSERT INTO [dbo].[ItemType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempItemTypeTable

SET IDENTITY_INSERT [dbo].[ItemType] OFF

CREATE TABLE [dbo].[JerseyQualityType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_JerseyQualityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[JerseyQualityType] ON

--INSERT INTO  [dbo].[JerseyQualityType] (Id, Name, Abbreviation)
--VALUES (1, 'Authentic', NULL)
--     , (2, 'Replica', NULL)
--	 , (3, 'China', NULL)
--	 , (4, 'Custom', NULL)
--	 , (5, 'Other', NULL)
--	 , (6, 'Unknown', NULL)

INSERT INTO [dbo].[JerseyQualityType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempJerseyQualityTypeTable

SET IDENTITY_INSERT [dbo].[JerseyQualityType] OFF

CREATE TABLE [dbo].[LevelType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_LevelType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[LevelType] ON

INSERT INTO [dbo].[LevelType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempLevelTypeTable

SET IDENTITY_INSERT [dbo].[LevelType] OFF

CREATE TABLE [dbo].[JerseyStyleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_JerseyStyleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[JerseyStyleType] ON

--INSERT INTO  [dbo].[JerseyStyleType] (Id, Name, Abbreviation)
--VALUES (1, 'Home', NULL)
--     , (2, 'Away', NULL)
--	 , (3, 'Alternate', NULL)
--	 , (4, 'World Series', NULL)
--	 , (5, 'All Star', NULL)
--	 , (6, 'Pro Bowl', NULL)
--	 , (7, 'Finals', NULL)
--	 , (8, 'Throwback', NULL)

INSERT INTO [dbo].[JerseyStyleType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempJerseyStyleTypeTable

SET IDENTITY_INSERT [dbo].[JerseyStyleType] OFF

CREATE TABLE [dbo].[JerseyType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_JerseyType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[JerseyType] ON

--INSERT INTO  [dbo].[JerseyType] (Id, Name, Abbreviation)
--VALUES (1, 'Stitched', NULL)
--     , (2, 'Screen Printed', NULL)
--	 , (3, 'Other', NULL)
--	 , (4, 'None', NULL)

INSERT INTO [dbo].[JerseyType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempJerseyTypeTable

SET IDENTITY_INSERT [dbo].[JerseyType] OFF

CREATE TABLE [dbo].[MagazineType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_MagazineType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[MagazineType] ON

INSERT INTO  [dbo].[MagazineType] (Id, Name, Abbreviation)
VALUES (1, 'Standard Publication', NULL)
     , (2, 'Program', NULL)

SET IDENTITY_INSERT [dbo].[MagazineType] OFF

CREATE TABLE [dbo].[Occupation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
 CONSTRAINT [PK_Occupation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Occupation] ON

--INSERT INTO  [dbo].[Occupation] (Id, Name, Abbreviation)
--VALUES (1, 'Athlete', NULL)
--     , (2, 'Actor', NULL)
--	 , (3, 'Actress', NULL)
--	 , (4, 'Celebrity', NULL)
--	 , (5, 'Broadcaster', NULL)
--	 , (6, 'Comedian', NULL)

INSERT INTO [dbo].[Occupation] (Id, Name, Abbreviation)
SELECT * 
FROM #TempOccupationTable

SET IDENTITY_INSERT [dbo].[Occupation] OFF

CREATE TABLE [dbo].[Orientation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
 CONSTRAINT [PK_Orientation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Orientation] ON

INSERT INTO  [dbo].[Orientation] (Id, Name, Abbreviation)
VALUES (1, 'Portrait', NULL)
     , (2, 'Landscape', NULL)

--INSERT INTO [dbo].[Orientation] (Id, Name, Abbreviation)
--SELECT * 
--FROM #TempOrientationTable

SET IDENTITY_INSERT [dbo].[Orientation] OFF

CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Suffix] [nvarchar](25) NULL,
	[Nickname] [nvarchar] (50) NULL,
	[FullName] [nvarchar] (125) NULL,
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
GO

SET IDENTITY_INSERT [dbo].[Person] ON

INSERT INTO [dbo].[Person] (Id, FirstName, LastName, Suffix, Nickname, FullName, BirthDate, DeathDate, ImagePath, CreateDate, LastModifiedDate)
SELECT * 
FROM #TempPersonTable

SET IDENTITY_INSERT [dbo].[Person] OFF

CREATE TABLE [dbo].[PhotoType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
 CONSTRAINT [PK_PhotoType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[PhotoType] ON

INSERT INTO  [dbo].[PhotoType] (Id, Name, Abbreviation)
VALUES (1, 'Glossy', NULL)
     , (2, 'Matte', NULL)
	 , (3, 'Unknown', NULL)

--INSERT INTO [dbo].[PhotoType] (Id, Name, Abbreviation)
--SELECT * 
--FROM #TempPhotoTypeTable

SET IDENTITY_INSERT [dbo].[PhotoType] OFF

CREATE TABLE [dbo].[PrivacyType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](75) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_PrivacyType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[PrivacyType] ON

--INSERT INTO  [dbo].[PrivacyType] (Id, Name, Abbreviation)
--VALUES (1, 'Public', NULL)
--     , (2, 'Private', NULL)

INSERT INTO [dbo].[PrivacyType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempPrivacyTypeTable

SET IDENTITY_INSERT [dbo].[PrivacyType] OFF

CREATE TABLE [dbo].[OccupationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_OccupationType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[OccupationType] ON

--INSERT INTO  [dbo].[OccupationType] (Id, [Name], Abbreviation)
--VALUES (1, 'Primary', NULL)
--     , (2, 'Secondary', NULL)

INSERT INTO [dbo].[OccupationType] (Id, [Name], Abbreviation)
SELECT * 
FROM #TempOccupationTypeTable

SET IDENTITY_INSERT [dbo].[OccupationType] OFF

CREATE TABLE [dbo].[PurchaseType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_PurchaseType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[PurchaseType] ON

--INSERT INTO  [dbo].[PurchaseType] (Id, Name, Abbreviation)
--VALUES (1, 'eBay', NULL)
--     , (2, 'Amazon', NULL)
--	 , (3, 'Other', NULL)
--	 , (4, 'Retail Store', NULL)
--	 , (5, 'Facebook', NULL)

INSERT INTO [dbo].[PurchaseType] (Id, Name, Abbreviation)
SELECT * 
FROM #TempPurchaseTypeTable

SET IDENTITY_INSERT [dbo].[PurchaseType] OFF

CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](75) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Role] ON

INSERT INTO  [dbo].[Role] (Id, Name)
VALUES (1, 'Super Admin')
     , (2, 'Admin')
	 , (3, 'User')

SET IDENTITY_INSERT [dbo].[Role] OFF

CREATE TABLE [dbo].[Size](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Size] ON

--INSERT INTO  [dbo].[Size] (Id, Name, Abbreviation)
--VALUES (1, 'Mini', NULL)
--     , (2, 'Full', NULL)
--	 , (3, 'Large', 'L')
--	 , (4, 'Small', 'S')
--	 , (5, 'Standard', NULL)
--	 , (6, 'Oversized', NULL)

INSERT INTO [dbo].[Size] (Id, Name, Abbreviation)
SELECT * 
FROM #TempSizeTable

SET IDENTITY_INSERT [dbo].[Size] OFF

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
GO

SET IDENTITY_INSERT [dbo].[Sport] ON

--INSERT INTO  [dbo].[Sport] (Id, Name, AlternateName, ImagePath, CreateDate, LastModifiedDate)
--VALUES (1, 'Baseball', NULL, NULL, GETUTCDATE(), NULL)
--     , (2, 'Basketball', NULL, NULL, GETUTCDATE(), NULL)
--	 , (3, 'Football', NULL, NULL, GETUTCDATE(), NULL)
--	 , (4, 'Hockey', NULL, NULL, GETUTCDATE(), NULL)
--	 , (5, 'Soccer', 'Futbol', NULL, GETUTCDATE(), NULL)

INSERT INTO [dbo].[Sport] (Id, Name, AlternateName, ImagePath, CreateDate, LastModifiedDate)
SELECT * 
FROM #TempSportTable

SET IDENTITY_INSERT [dbo].[Sport] OFF

CREATE TABLE [dbo].[Spot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_Spot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Spot] ON

--INSERT INTO  [dbo].[Spot] (Id, Name, Abbreviation)
--VALUES (1, 'Sweet Spot', 'SS')
--     , (2, 'Side Panel', 'SP')
--	 , (3, 'On Cloth', NULL)
--	 , (4, 'On Number', NULL)

INSERT INTO [dbo].[Spot] (Id, Name, Abbreviation)
SELECT * 
FROM #TempSpotTable

SET IDENTITY_INSERT [dbo].[Spot] OFF

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
GO

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Franchise] FOREIGN KEY([FranchiseId])
REFERENCES [dbo].[Franchise] ([Id])
GO

ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Franchise]
GO

SET IDENTITY_INSERT [dbo].[Team] ON

INSERT INTO [dbo].[Team] (Id, FranchiseId, Name, Location, Nickname, Abbreviation, BeginYear, EndYear, ImagePath)
SELECT * 
FROM #TempTeamTable

SET IDENTITY_INSERT [dbo].[Team] OFF

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
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO

SET IDENTITY_INSERT [dbo].[User] ON

INSERT INTO  [dbo].[User] (Id, EmailAddress, FirstName, LastName, Password, Phone, Username, RoleId, CreateDate)
VALUES (1, 'njgrillo@gmail.com', 'Nick', 'Grillo', 'E7!@ff893@@', NULL, 'njgrillo', 1, GETUTCDATE())

SET IDENTITY_INSERT [dbo].[User] OFF

CREATE TABLE [dbo].[WritingInstrument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_WritingInstrument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[WritingInstrument] ON

INSERT INTO  [dbo].[WritingInstrument] (Id, Name, Abbreviation)
VALUES (1, 'Ballpoint Pen', NULL)
     , (2, 'Paint Pen', NULL)
	 , (3, 'Sharpie', NULL)

SET IDENTITY_INSERT [dbo].[WritingInstrument] OFF

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
GO

ALTER TABLE [dbo].[PersonOccupation]  WITH CHECK ADD  CONSTRAINT [FK_PersonOccupation_Occupation] FOREIGN KEY([OccupationId])
REFERENCES [dbo].[Occupation] ([Id])
GO

ALTER TABLE [dbo].[PersonOccupation] CHECK CONSTRAINT [FK_PersonOccupation_Occupation]
GO

ALTER TABLE [dbo].[PersonOccupation]  WITH CHECK ADD  CONSTRAINT [FK_PersonOccupation_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[PersonOccupation] CHECK CONSTRAINT [FK_PersonOccupation_Person]
GO

ALTER TABLE [dbo].[PersonOccupation]  WITH CHECK ADD  CONSTRAINT [FK_PersonOccupation_OccupationType] FOREIGN KEY([OccupationTypeId])
REFERENCES [dbo].[OccupationType] ([Id])
GO

ALTER TABLE [dbo].[PersonOccupation] CHECK CONSTRAINT [FK_PersonOccupation_OccupationType]
GO

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
GO

ALTER TABLE [dbo].[PersonTeam]  WITH CHECK ADD  CONSTRAINT [FK_PersonTeam_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[PersonTeam] CHECK CONSTRAINT [FK_PersonTeam_Team]
GO

ALTER TABLE [dbo].[PersonTeam]  WITH CHECK ADD  CONSTRAINT [FK_PersonTeam_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[PersonTeam] CHECK CONSTRAINT [FK_PersonTeam_Person]
GO

CREATE TABLE [dbo].[League](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_League] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ItemTypeLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[LevelTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemTypeLevel]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeLevel_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeLevel] CHECK CONSTRAINT [FK_ItemTypeLevel_ItemType]
GO

ALTER TABLE [dbo].[ItemTypeLevel]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeLevel_LevelType] FOREIGN KEY([LevelTypeId])
REFERENCES [dbo].[LevelType] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeLevel] CHECK CONSTRAINT [FK_ItemTypeLevel_LevelType]
GO  

SET IDENTITY_INSERT [dbo].[ItemTypeLevel] ON

INSERT INTO [dbo].[ItemTypeLevel] (Id, ItemTypeId, LevelTypeId)
SELECT * 
FROM #TempItemTypeLevelTable

SET IDENTITY_INSERT [dbo].[ItemTypeLevel] OFF

CREATE TABLE [dbo].[ItemTypeGameStyleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[GameStyleTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeGameStyleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemTypeGameStyleType]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeGameStyleType_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeGameStyleType] CHECK CONSTRAINT [FK_ItemTypeGameStyleType_ItemType]
GO

ALTER TABLE [dbo].[ItemTypeGameStyleType]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeGameStyleType_GameStyleType] FOREIGN KEY([GameStyleTypeId])
REFERENCES [dbo].[GameStyleType] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeGameStyleType] CHECK CONSTRAINT [FK_ItemTypeGameStyleType_GameStyleType]
GO  

SET IDENTITY_INSERT [dbo].[ItemTypeGameStyleType] ON

INSERT INTO [dbo].[ItemTypeGameStyleType] (Id, ItemTypeId, GameStyleTypeId)
SELECT * 
FROM #TempItemTypeGameStyleTypeTable

SET IDENTITY_INSERT [dbo].[ItemTypeGameStyleType] OFF

CREATE TABLE [dbo].[ItemTypeSpot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[SpotId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeSpot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemTypeSpot]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSpot_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeSpot] CHECK CONSTRAINT [FK_ItemTypeSpot_ItemType]
GO

ALTER TABLE [dbo].[ItemTypeSpot]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSpot_Spot] FOREIGN KEY([SpotId])
REFERENCES [dbo].[Spot] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeSpot] CHECK CONSTRAINT [FK_ItemTypeSpot_Spot]
GO  

SET IDENTITY_INSERT [dbo].[ItemTypeSpot] ON

INSERT INTO [dbo].[ItemTypeSpot] (Id, ItemTypeId, SpotId)
SELECT * 
FROM #TempItemTypeSpotTable

SET IDENTITY_INSERT [dbo].[ItemTypeSpot] OFF

CREATE TABLE [dbo].[ItemTypeSport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[SportId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeSport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemTypeSport]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSport_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeSport] CHECK CONSTRAINT [FK_ItemTypeSport_ItemType]
GO

ALTER TABLE [dbo].[ItemTypeSport]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSport_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeSport] CHECK CONSTRAINT [FK_ItemTypeSport_Sport]
GO

SET IDENTITY_INSERT [dbo].[ItemTypeSport] ON

INSERT INTO [dbo].[ItemTypeSport] (Id, ItemTypeId, SportId)
SELECT * 
FROM #TempItemTypeSportTable

SET IDENTITY_INSERT [dbo].[ItemTypeSport] OFF

CREATE TABLE [dbo].[ItemTypeSize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeSize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemTypeSize]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSize_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeSize] CHECK CONSTRAINT [FK_ItemTypeSize_ItemType]
GO

ALTER TABLE [dbo].[ItemTypeSize]  WITH CHECK ADD  CONSTRAINT [FK_ItemTypeSize_Size] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([Id])
GO

ALTER TABLE [dbo].[ItemTypeSize] CHECK CONSTRAINT [FK_ItemTypeSize_Size]
GO

SET IDENTITY_INSERT [dbo].[ItemTypeSize] ON

INSERT INTO [dbo].[ItemTypeSize] (Id, ItemTypeId, SizeId)
SELECT * 
FROM #TempItemTypeSizeTable

SET IDENTITY_INSERT [dbo].[ItemTypeSize] OFF

CREATE TABLE [dbo].[ItemTypeBrand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemTypeId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_ItemTypeBrand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[ItemTypeBrand] ON

INSERT INTO [dbo].[ItemTypeBrand] (Id, ItemTypeId, BrandId)
SELECT * 
FROM #TempItemTypeBrandTable

SET IDENTITY_INSERT [dbo].[ItemTypeBrand] OFF

CREATE TABLE [dbo].[Conference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SportId] [int] NOT NULL,
	[LevelTypeId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,	
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_Conference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Conference]  WITH CHECK ADD  CONSTRAINT [FK_Conference_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
GO

ALTER TABLE [dbo].[Conference] CHECK CONSTRAINT [FK_Conference_Sport]
GO

ALTER TABLE [dbo].[Conference]  WITH CHECK ADD  CONSTRAINT [FK_Conference_LevelType] FOREIGN KEY([LevelTypeId])
REFERENCES [dbo].[LevelType] ([Id])
GO

ALTER TABLE [dbo].[Conference] CHECK CONSTRAINT [FK_Conference_LevelType]
GO

CREATE TABLE [dbo].[Division](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConferenceId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](10) NULL,
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Division]  WITH CHECK ADD  CONSTRAINT [FK_Division_Conference] FOREIGN KEY([ConferenceId])
REFERENCES [dbo].[Conference] ([Id])
GO

ALTER TABLE [dbo].[Division] CHECK CONSTRAINT [FK_Division_Conference]
GO

CREATE TABLE [dbo].[TeamConference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[ConferenceId] [int] NOT NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_TeamConference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TeamConference]  WITH CHECK ADD  CONSTRAINT [FK_TeamConference_Conference] FOREIGN KEY([ConferenceId])
REFERENCES [dbo].[Conference] ([Id])
GO

ALTER TABLE [dbo].[TeamConference] CHECK CONSTRAINT [FK_TeamConference_Conference]
GO

ALTER TABLE [dbo].[TeamConference]  WITH CHECK ADD  CONSTRAINT [FK_TeamConference_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[TeamConference] CHECK CONSTRAINT [FK_TeamConference_Team]
GO

CREATE TABLE [dbo].[TeamDivision](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[DivisionId] [int] NOT NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_TeamDivision] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TeamDivision]  WITH CHECK ADD  CONSTRAINT [FK_TeamDivision_Division] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Division] ([Id])
GO

ALTER TABLE [dbo].[TeamDivision] CHECK CONSTRAINT [FK_TeamDivision_Division]
GO

ALTER TABLE [dbo].[TeamDivision]  WITH CHECK ADD  CONSTRAINT [FK_TeamDivision_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[TeamDivision] CHECK CONSTRAINT [FK_TeamDivision_Team]
GO

CREATE TABLE [dbo].[TeamLeague](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[LeagueId] [int] NOT NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_TeamLeague] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TeamLeague]  WITH CHECK ADD  CONSTRAINT [FK_TeamLeague_League] FOREIGN KEY([LeagueId])
REFERENCES [dbo].[League] ([Id])
GO

ALTER TABLE [dbo].[TeamLeague] CHECK CONSTRAINT [FK_TeamLeague_League]
GO

ALTER TABLE [dbo].[TeamLeague]  WITH CHECK ADD  CONSTRAINT [FK_TeamLeague_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[TeamLeague] CHECK CONSTRAINT [FK_TeamLeague_Team]
GO

CREATE TABLE [dbo].[Commissioner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[SportId] [int] NOT NULL,
	[BeginYear] [int] NULL,
	[EndYear] [int] NULL,	
 CONSTRAINT [PK_Commissioner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Commissioner]  WITH CHECK ADD  CONSTRAINT [FK_Commissioner_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[Commissioner] CHECK CONSTRAINT [FK_Commissioner_Person]
GO

ALTER TABLE [dbo].[Commissioner]  WITH CHECK ADD  CONSTRAINT [FK_Commissioner_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
GO

ALTER TABLE [dbo].[Commissioner] CHECK CONSTRAINT [FK_Commissioner_Sport]
GO

SET IDENTITY_INSERT [dbo].[Commissioner] ON

INSERT INTO [dbo].[Commissioner] (Id, PersonId, SportId, BeginYear, EndYear)
SELECT * 
FROM #TempCommissionerTable

SET IDENTITY_INSERT [dbo].[Commissioner] OFF

CREATE TABLE [dbo].[Event](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AcquisitionTypeId] [int] NOT NULL,
	[EventDate] [datetime] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_AcquisitionType] FOREIGN KEY([AcquisitionTypeId])
REFERENCES [dbo].[AcquisitionType] ([Id])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_AcquisitionType]
GO

CREATE TABLE [dbo].[HallOfFame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[SportId] [int] NOT NULL,
	[LevelTypeId] [int] NOT NULL,
	[FranchiseId] [int] NULL,
	[InductionYear] [int] NULL,
	[VoteCount] [int] NULL,
 CONSTRAINT [PK_HallOfFame] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HallOfFame]  WITH CHECK ADD  CONSTRAINT [FK_HallOfFame_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[HallOfFame] CHECK CONSTRAINT [FK_HallOfFame_Person]
GO

ALTER TABLE [dbo].[HallOfFame]  WITH CHECK ADD  CONSTRAINT [FK_HallOfFame_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
GO

ALTER TABLE [dbo].[HallOfFame] CHECK CONSTRAINT [FK_HallOfFame_Sport]
GO

ALTER TABLE [dbo].[HallOfFame]  WITH CHECK ADD  CONSTRAINT [FK_HallOfFame_LevelType] FOREIGN KEY([LevelTypeId])
REFERENCES [dbo].[LevelType] ([Id])
GO

ALTER TABLE [dbo].[HallOfFame] CHECK CONSTRAINT [FK_HallOfFame_LevelType]
GO

ALTER TABLE [dbo].[HallOfFame]  WITH CHECK ADD  CONSTRAINT [FK_HallOfFame_Franchise] FOREIGN KEY([FranchiseId])
REFERENCES [dbo].[Franchise] ([Id])
GO

ALTER TABLE [dbo].[HallOfFame] CHECK CONSTRAINT [FK_HallOfFame_Franchise]
GO


CREATE TABLE [dbo].[SportDivision](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SportId] [int] NULL,
	[DivisionId] [int] NULL,
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_SportDivision] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SportDivision]  WITH CHECK ADD  CONSTRAINT [FK_SportDivision_Division] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Division] ([Id])
GO

ALTER TABLE [dbo].[SportDivision] CHECK CONSTRAINT [FK_SportDivision_Division]
GO

ALTER TABLE [dbo].[SportDivision]  WITH CHECK ADD  CONSTRAINT [FK_SportDivision_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
GO

ALTER TABLE [dbo].[SportDivision] CHECK CONSTRAINT [FK_SportDivision_Sport]
GO

CREATE TABLE [dbo].[SportLeague](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SportId] [int] NULL,
	[LeagueId] [int] NULL,
	[ImagePath] [varchar](200) NULL,
 CONSTRAINT [PK_SportLeague] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SportLeague]  WITH CHECK ADD  CONSTRAINT [FK_SportLeague_League] FOREIGN KEY([LeagueId])
REFERENCES [dbo].[League] ([Id])
GO

ALTER TABLE [dbo].[SportLeague] CHECK CONSTRAINT [FK_SportLeague_League]
GO

ALTER TABLE [dbo].[SportLeague]  WITH CHECK ADD  CONSTRAINT [FK_SportLeague_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
GO

ALTER TABLE [dbo].[SportLeague] CHECK CONSTRAINT [FK_SportLeague_Sport]
GO

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
GO

ALTER TABLE [dbo].[Memorabilia]  WITH CHECK ADD  CONSTRAINT [FK_Memorabilia_Condition] FOREIGN KEY([ConditionId])
REFERENCES [dbo].[Condition] ([Id])
GO

ALTER TABLE [dbo].[Memorabilia] CHECK CONSTRAINT [FK_Memorabilia_Condition]
GO

ALTER TABLE [dbo].[Memorabilia]  WITH CHECK ADD  CONSTRAINT [FK_Memorabilia_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
GO

ALTER TABLE [dbo].[Memorabilia] CHECK CONSTRAINT [FK_Memorabilia_ItemType]
GO

ALTER TABLE [dbo].[Memorabilia]  WITH CHECK ADD  CONSTRAINT [FK_Memorabilia_PrivacyType] FOREIGN KEY([PrivacyTypeId])
REFERENCES [dbo].[PrivacyType] ([Id])
GO

ALTER TABLE [dbo].[Memorabilia] CHECK CONSTRAINT [FK_Memorabilia_PrivacyType]
GO

ALTER TABLE [dbo].[Memorabilia]  WITH CHECK ADD  CONSTRAINT [FK_Memorabilia_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Memorabilia] CHECK CONSTRAINT [FK_Memorabilia_User]
GO

SET IDENTITY_INSERT [dbo].[Memorabilia] ON

INSERT INTO [dbo].[Memorabilia] (Id, ItemTypeId, ConditionId, EstimatedValue, PrivacyTypeId, UserId, CreateDate, LastModifiedDate)
SELECT * 
FROM #TempMemorabiliaTable

SET IDENTITY_INSERT [dbo].[Memorabilia] OFF

CREATE TABLE [dbo].[MemorabiliaBasketball](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[BasketballTypeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaBasketball] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaBasketball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBasketball_BasketballType] FOREIGN KEY([BasketballTypeId])
REFERENCES [dbo].[BasketballType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaBasketball] CHECK CONSTRAINT [FK_MemorabiliaBasketball_BasketballType]
GO

ALTER TABLE [dbo].[MemorabiliaBasketball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBasketball_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaBasketball] CHECK CONSTRAINT [FK_MemorabiliaBasketball_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaBasketball] ON

INSERT INTO [dbo].[MemorabiliaBasketball] (Id, MemorabiliaId, BasketballTypeId)
SELECT * 
FROM #TempMemorabiliaBasketballTable

SET IDENTITY_INSERT [dbo].[MemorabiliaBasketball] OFF

CREATE TABLE [dbo].[MemorabiliaBrand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaBrand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaBrand]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBrand_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaBrand] CHECK CONSTRAINT [FK_MemorabiliaBrand_Brand]
GO

ALTER TABLE [dbo].[MemorabiliaBrand]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBrand_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaBrand] CHECK CONSTRAINT [FK_MemorabiliaBrand_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaBrand] ON

INSERT INTO [dbo].[MemorabiliaBrand] (Id, MemorabiliaId, BrandId)
SELECT * 
FROM #TempMemorabiliaBrandTable

SET IDENTITY_INSERT [dbo].[MemorabiliaBrand] OFF

CREATE TABLE [dbo].[MemorabiliaCommissioner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[CommissionerId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaCommissioner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaCommissioner]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaCommissioner_Commissioner] FOREIGN KEY([CommissionerId])
REFERENCES [dbo].[Commissioner] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaCommissioner] CHECK CONSTRAINT [FK_MemorabiliaCommissioner_Commissioner]
GO

ALTER TABLE [dbo].[MemorabiliaCommissioner]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaCommissioner_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaCommissioner] CHECK CONSTRAINT [FK_MemorabiliaCommissioner_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaCommissioner] ON

INSERT INTO [dbo].[MemorabiliaCommissioner] (Id, MemorabiliaId, CommissionerId)
SELECT * 
FROM #TempMemorabiliaCommissionerTable

SET IDENTITY_INSERT [dbo].[MemorabiliaCommissioner] OFF

CREATE TABLE [dbo].[MemorabiliaFootball](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[FootballTypeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaFootball] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaFootball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaFootball_FootballType] FOREIGN KEY([FootballTypeId])
REFERENCES [dbo].[FootballType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaFootball] CHECK CONSTRAINT [FK_MemorabiliaFootball_FootballType]
GO

ALTER TABLE [dbo].[MemorabiliaFootball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaFootball_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaFootball] CHECK CONSTRAINT [FK_MemorabiliaFootball_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaFootball] ON

INSERT INTO [dbo].[MemorabiliaFootball] (Id, MemorabiliaId, FootballTypeId)
SELECT * 
FROM #TempMemorabiliaFootballTable

SET IDENTITY_INSERT [dbo].[MemorabiliaFootball] OFF

CREATE TABLE [dbo].[MemorabiliaOrientation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[OrientationId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaOrientation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaOrientation]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaOrientation_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaOrientation] CHECK CONSTRAINT [FK_MemorabiliaOrientation_Memorabilia]
GO

ALTER TABLE [dbo].[MemorabiliaOrientation]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaOrientation_Orientation] FOREIGN KEY([OrientationId])
REFERENCES [dbo].[Orientation] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaOrientation] CHECK CONSTRAINT [FK_MemorabiliaOrientation_Orientation]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaOrientation] ON

INSERT INTO [dbo].[MemorabiliaOrientation] (Id, MemorabiliaId, OrientationId)
SELECT * 
FROM #TempMemorabiliaOrientationTable

SET IDENTITY_INSERT [dbo].[MemorabiliaOrientation] OFF

CREATE TABLE [dbo].[MemorabiliaPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaPerson]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaPerson_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaPerson] CHECK CONSTRAINT [FK_MemorabiliaPerson_Memorabilia]
GO

ALTER TABLE [dbo].[MemorabiliaPerson]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaPerson_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaPerson] CHECK CONSTRAINT [FK_MemorabiliaPerson_Person]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaPerson] ON

INSERT INTO [dbo].[MemorabiliaPerson] (Id, MemorabiliaId, PersonId)
SELECT * 
FROM #TempMemorabiliaPersonTable

SET IDENTITY_INSERT [dbo].[MemorabiliaPerson] OFF

CREATE TABLE [dbo].[MemorabiliaPhoto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[PhotoTypeId] [int] NOT NULL,
	[Framed] [bit] NOT NULL,
 CONSTRAINT [PK_MemorabiliaPhoto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaPhoto]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaPhoto_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaPhoto] CHECK CONSTRAINT [FK_MemorabiliaPhoto_Memorabilia]
GO

ALTER TABLE [dbo].[MemorabiliaPhoto]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaPhoto_PhotoType] FOREIGN KEY([PhotoTypeId])
REFERENCES [dbo].[PhotoType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaPhoto] CHECK CONSTRAINT [FK_MemorabiliaPhoto_PhotoType]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaPhoto] ON

INSERT INTO [dbo].[MemorabiliaPhoto] (Id, MemorabiliaId, PhotoTypeId, Framed)
SELECT * 
FROM #TempMemorabiliaPhotoTable

SET IDENTITY_INSERT [dbo].[MemorabiliaPhoto] OFF

CREATE TABLE [dbo].[MemorabiliaSize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaSize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaSize]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaSize_Size] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaSize] CHECK CONSTRAINT [FK_MemorabiliaSize_Size]
GO

ALTER TABLE [dbo].[MemorabiliaSize]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaSize_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaSize] CHECK CONSTRAINT [FK_MemorabiliaSize_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaSize] ON

INSERT INTO [dbo].[MemorabiliaSize] (Id, MemorabiliaId, SizeId)
SELECT * 
FROM #TempMemorabiliaSizeTable

SET IDENTITY_INSERT [dbo].[MemorabiliaSize] OFF

CREATE TABLE [dbo].[MemorabiliaTeam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaTeam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaTeam]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaTeam_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaTeam] CHECK CONSTRAINT [FK_MemorabiliaTeam_Memorabilia]
GO

ALTER TABLE [dbo].[MemorabiliaTeam]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaTeam_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaTeam] CHECK CONSTRAINT [FK_MemorabiliaTeam_Team]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaTeam] ON

INSERT INTO [dbo].[MemorabiliaTeam] (Id, MemorabiliaId, TeamId)
SELECT * 
FROM #TempMemorabiliaTeamTable

SET IDENTITY_INSERT [dbo].[MemorabiliaTeam] OFF

CREATE TABLE [dbo].[MemorabiliaSport](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[SportId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaSport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaSport]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaSport_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaSport] CHECK CONSTRAINT [FK_MemorabiliaSport_Memorabilia]
GO

ALTER TABLE [dbo].[MemorabiliaSport]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaSport_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaSport] CHECK CONSTRAINT [FK_MemorabiliaSport_Sport]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaSport] ON

INSERT INTO [dbo].[MemorabiliaSport] (Id, MemorabiliaId, SportId)
SELECT * 
FROM #TempMemorabiliaSportTable

SET IDENTITY_INSERT [dbo].[MemorabiliaSport] OFF

CREATE TABLE [dbo].[Acquisition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AcquisitionTypeId] [int] NOT NULL,
	[AcquiredDate] [datetime] NULL,
	[PurchaseTypeId] [int] NULL,
	[Cost] [decimal](12, 2) NULL,
 CONSTRAINT [PK_Acquisition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Acquisition]  WITH CHECK ADD  CONSTRAINT [FK_Acquisition_AcquisitionType] FOREIGN KEY([AcquisitionTypeId])
REFERENCES [dbo].[AcquisitionType] ([Id])
GO

ALTER TABLE [dbo].[Acquisition] CHECK CONSTRAINT [FK_Acquisition_AcquisitionType]
GO

ALTER TABLE [dbo].[Acquisition]  WITH CHECK ADD  CONSTRAINT [FK_Acquisition_PurchaseType] FOREIGN KEY([PurchaseTypeId])
REFERENCES [dbo].[PurchaseType] ([Id])
GO

ALTER TABLE [dbo].[Acquisition] CHECK CONSTRAINT [FK_Acquisition_PurchaseType]
GO

SET IDENTITY_INSERT [dbo].[Acquisition] ON

INSERT INTO [dbo].[Acquisition] (Id, AcquisitionTypeId, AcquiredDate, PurchaseTypeId, Cost)
SELECT * 
FROM #TempAcquisitionTable

SET IDENTITY_INSERT [dbo].[Acquisition] OFF

CREATE TABLE [dbo].[Autograph](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
	[ConditionId] [int] NOT NULL,
	[WritingInstrumentId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[AcquisitionId] [int] NOT NULL,
	[EstimatedValue] decimal(12, 2) NULL,
	[Grade] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Autograph] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Color] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Color] ([Id])
GO

ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Color]
GO

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Condition] FOREIGN KEY([ConditionId])
REFERENCES [dbo].[Condition] ([Id])
GO

ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Condition]
GO

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Memorabilia]
GO

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Person]
GO

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_WritingInstrument] FOREIGN KEY([WritingInstrumentId])
REFERENCES [dbo].[WritingInstrument] ([Id])
GO

ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_WritingInstrument]
GO

ALTER TABLE [dbo].[Autograph]  WITH CHECK ADD  CONSTRAINT [FK_Autograph_Acquisition] FOREIGN KEY([AcquisitionId])
REFERENCES [dbo].[Acquisition] ([Id])
GO

ALTER TABLE [dbo].[Autograph] CHECK CONSTRAINT [FK_Autograph_Acquisition]
GO

CREATE TABLE [dbo].[Personalization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutographId] [int] NOT NULL,
	[Text] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Personalization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Personalization]  WITH CHECK ADD  CONSTRAINT [FK_Personalization_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
GO

ALTER TABLE [dbo].[Personalization] CHECK CONSTRAINT [FK_Personalization_Autograph]
GO

CREATE TABLE [dbo].[AutographAuthentication](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutographId] [int] NOT NULL,
	[AuthenticationCompanyId] [int] NOT NULL,
	[Verification] [varchar](50) NULL,
	[HasHologram] [bit] NULL,
	[HasLetter] [bit] NULL,
 CONSTRAINT [PK_AutographAuthentication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AutographAuthentication]  WITH CHECK ADD  CONSTRAINT [FK_AutographAuthentication_AuthenticationCompany] FOREIGN KEY([AuthenticationCompanyId])
REFERENCES [dbo].[AuthenticationCompany] ([Id])
GO

ALTER TABLE [dbo].[AutographAuthentication] CHECK CONSTRAINT [FK_AutographAuthentication_AuthenticationCompany]
GO

ALTER TABLE [dbo].[AutographAuthentication]  WITH CHECK ADD  CONSTRAINT [FK_AutographAuthentication_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
GO

ALTER TABLE [dbo].[AutographAuthentication] CHECK CONSTRAINT [FK_AutographAuthentication_Autograph]
GO

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
GO

ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_ItemType] FOREIGN KEY([ItemTypeId])
REFERENCES [dbo].[ItemType] ([Id])
GO

ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_ItemType]
GO

ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_Person]
GO

ALTER TABLE [dbo].[WishList]  WITH CHECK ADD  CONSTRAINT [FK_WishList_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[WishList] CHECK CONSTRAINT [FK_WishList_User]
GO

CREATE TABLE [dbo].[WritingInstrumentBrand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WritingInstrumentId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_WritingInstrumentBrand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WritingInstrumentBrand]  WITH CHECK ADD  CONSTRAINT [FK_WritingInstrumentBrand_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO

ALTER TABLE [dbo].[WritingInstrumentBrand] CHECK CONSTRAINT [FK_WritingInstrumentBrand_Brand]
GO

ALTER TABLE [dbo].[WritingInstrumentBrand]  WITH CHECK ADD  CONSTRAINT [FK_WritingInstrumentBrand_WritingInstrument] FOREIGN KEY([WritingInstrumentId])
REFERENCES [dbo].[WritingInstrument] ([Id])
GO

ALTER TABLE [dbo].[WritingInstrumentBrand] CHECK CONSTRAINT [FK_WritingInstrumentBrand_WritingInstrument]
GO

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
GO

ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
GO

ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Autograph]
GO

ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_InscriptionType] FOREIGN KEY([InscriptionTypeId])
REFERENCES [dbo].[InscriptionType] ([Id])
GO

ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_InscriptionType]
GO

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
GO

ALTER TABLE [dbo].[MemorabiliaBaseball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBaseball_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaBaseball] CHECK CONSTRAINT [FK_MemorabiliaBaseball_Memorabilia]
GO

ALTER TABLE [dbo].[MemorabiliaBaseball]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBaseball_BaseballType] FOREIGN KEY([BaseballTypeId])
REFERENCES [dbo].[BaseballType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaBaseball] CHECK CONSTRAINT [FK_MemorabiliaBaseball_BaseballType]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaBaseball] ON

INSERT INTO [dbo].[MemorabiliaBaseball] (Id, MemorabiliaId, BaseballTypeId, [Year], Anniversary)
SELECT * 
FROM #TempMemorabiliaBaseballTable

SET IDENTITY_INSERT [dbo].[MemorabiliaBaseball] OFF

CREATE TABLE [dbo].[MemorabiliaAcquisition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[AcquisitionId] [int] NOT NULL
 CONSTRAINT [PK_MemorabiliaAcquisition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaAcquisition]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaAcquisition_Acquisition] FOREIGN KEY([AcquisitionId])
REFERENCES [dbo].[Acquisition] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaAcquisition] CHECK CONSTRAINT [FK_MemorabiliaAcquisition_Acquisition]
GO

ALTER TABLE [dbo].[MemorabiliaAcquisition]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaAcquisition_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaAcquisition] CHECK CONSTRAINT [FK_MemorabiliaAcquisition_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaAcquisition] ON

INSERT INTO [dbo].[MemorabiliaAcquisition] (Id, MemorabiliaId, AcquisitionId)
SELECT * 
FROM #TempMemorabiliaAcquisitionTable

SET IDENTITY_INSERT [dbo].[MemorabiliaAcquisition] OFF

CREATE TABLE [dbo].[MemorabiliaBat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[BatTypeId] [int] NOT NULL,
	[Length] [int] NULL
 CONSTRAINT [PK_MemorabiliaBat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaBat]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBat_BatType] FOREIGN KEY([BatTypeId])
REFERENCES [dbo].[BatType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaBat] CHECK CONSTRAINT [FK_MemorabiliaBat_BatType]
GO

ALTER TABLE [dbo].[MemorabiliaBat]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaBat_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaBat] CHECK CONSTRAINT [FK_MemorabiliaBat_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaBat] ON

INSERT INTO [dbo].[MemorabiliaBat] (Id, MemorabiliaId, BatTypeId, [Length])
SELECT * 
FROM #TempMemorabiliaBatTable

SET IDENTITY_INSERT [dbo].[MemorabiliaBat] OFF

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
GO

ALTER TABLE [dbo].[AutographImage]  WITH CHECK ADD  CONSTRAINT [FK_AutographImage_ImageType] FOREIGN KEY([ImageTypeId])
REFERENCES [dbo].[ImageType] ([Id])
GO

ALTER TABLE [dbo].[AutographImage] CHECK CONSTRAINT [FK_AutographImage_ImageType]
GO

ALTER TABLE [dbo].[AutographImage]  WITH CHECK ADD  CONSTRAINT [FK_AutographImage_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
GO

ALTER TABLE [dbo].[AutographImage] CHECK CONSTRAINT [FK_AutographImage_Autograph]
GO

SET IDENTITY_INSERT [dbo].[AutographImage] ON

INSERT INTO [dbo].[AutographImage] (Id, AutographId, FilePath, UploadDate, ImageTypeId)
SELECT * 
FROM #TempAutographImageTable

SET IDENTITY_INSERT [dbo].[AutographImage] OFF

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
GO

ALTER TABLE [dbo].[MemorabiliaImage]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaImage_ImageType] FOREIGN KEY([ImageTypeId])
REFERENCES [dbo].[ImageType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaImage] CHECK CONSTRAINT [FK_MemorabiliaImage_ImageType]
GO

ALTER TABLE [dbo].[MemorabiliaImage]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaImage_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaImage] CHECK CONSTRAINT [FK_MemorabiliaImage_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaImage] ON

INSERT INTO [dbo].[MemorabiliaImage] (Id, MemorabiliaId, FilePath, UploadDate, ImageTypeId)
SELECT * 
FROM #TempMemorabiliaImageTable

SET IDENTITY_INSERT [dbo].[MemorabiliaImage] OFF

CREATE TABLE [dbo].[MemorabiliaLevelType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[LevelTypeId] [int] NOT NULL,
 CONSTRAINT [PK_MemorabiliaLevelType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaLevelType]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaLevelType_LevelType] FOREIGN KEY([LevelTypeId])
REFERENCES [dbo].[LevelType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaLevelType] CHECK CONSTRAINT [FK_MemorabiliaLevelType_LevelType]
GO

ALTER TABLE [dbo].[MemorabiliaLevelType]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaLevelType_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaImage] CHECK CONSTRAINT [FK_MemorabiliaImage_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaLevelType] ON

INSERT INTO [dbo].[MemorabiliaLevelType] (Id, MemorabiliaId, LevelTypeId)
SELECT * 
FROM #TempMemorabiliaLevelTypeTable

SET IDENTITY_INSERT [dbo].[MemorabiliaLevelType] OFF

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
GO

ALTER TABLE [dbo].[MemorabiliaJersey]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaJersey_JerseyQualityType] FOREIGN KEY([JerseyQualityTypeId])
REFERENCES [dbo].[JerseyQualityType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaJersey] CHECK CONSTRAINT [FK_MemorabiliaJersey_JerseyQualityType]
GO

ALTER TABLE [dbo].[MemorabiliaJersey]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaJersey_JerseyStyleType] FOREIGN KEY([JerseyStyleTypeId])
REFERENCES [dbo].[JerseyStyleType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaJersey] CHECK CONSTRAINT [FK_MemorabiliaJersey_JerseyStyleType]
GO

ALTER TABLE [dbo].[MemorabiliaJersey]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaJersey_JerseyType] FOREIGN KEY([JerseyTypeId])
REFERENCES [dbo].[JerseyType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaJersey] CHECK CONSTRAINT [FK_MemorabiliaJersey_JerseyType]
GO

ALTER TABLE [dbo].[MemorabiliaJersey]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaJersey_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaJersey] CHECK CONSTRAINT [FK_MemorabiliaJersey_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaJersey] ON

INSERT INTO [dbo].[MemorabiliaJersey] (Id, MemorabiliaId, JerseyQualityTypeId, JerseyStyleTypeId, JerseyTypeId)
SELECT * 
FROM #TempMemorabiliaJerseyTable

SET IDENTITY_INSERT [dbo].[MemorabiliaJersey] OFF

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
GO

ALTER TABLE [dbo].[MemorabiliaGame]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaGame_GameStyleType] FOREIGN KEY([GameStyleTypeId])
REFERENCES [dbo].[GameStyleType] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaGame] CHECK CONSTRAINT [FK_MemorabiliaGame_GameStyleType]
GO

ALTER TABLE [dbo].[MemorabiliaGame]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaGame_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaGame] CHECK CONSTRAINT [FK_MemorabiliaGame_Person]
GO

ALTER TABLE [dbo].[MemorabiliaGame]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaGame_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaGame] CHECK CONSTRAINT [FK_MemorabiliaGame_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaGame] ON

INSERT INTO [dbo].[MemorabiliaGame] (Id, MemorabiliaId, GameStyleTypeId, PersonId, GameDate)
SELECT * 
FROM #TempMemorabiliaGameTable

SET IDENTITY_INSERT [dbo].[MemorabiliaGame] OFF

CREATE TABLE [dbo].[MemorabiliaCard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemorabiliaId] [int] NOT NULL,
	[Year] [int] NULL,
	[Numerator] [int] NULL,
	[Denominator] [int] NULL,
 CONSTRAINT [PK_MemorabiliaCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemorabiliaCard]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaCard_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaCard] CHECK CONSTRAINT [FK_MemorabiliaCard_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaCard] ON

INSERT INTO [dbo].[MemorabiliaCard] (Id, MemorabiliaId, [Year], Numerator, Denominator)
SELECT * 
FROM #TempMemorabiliaCardTable

SET IDENTITY_INSERT [dbo].[MemorabiliaCard] OFF

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
GO

ALTER TABLE [dbo].[MemorabiliaMagazine]  WITH CHECK ADD  CONSTRAINT [FK_MemorabiliaMagazine_Memorabilia] FOREIGN KEY([MemorabiliaId])
REFERENCES [dbo].[Memorabilia] ([Id])
GO

ALTER TABLE [dbo].[MemorabiliaMagazine] CHECK CONSTRAINT [FK_MemorabiliaMagazine_Memorabilia]
GO

SET IDENTITY_INSERT [dbo].[MemorabiliaMagazine] ON

INSERT INTO [dbo].[MemorabiliaMagazine] (Id, MemorabiliaId, [Date], Framed)
SELECT * 
FROM #TempMemorabiliaMagazineTable

SET IDENTITY_INSERT [dbo].[MemorabiliaMagazine] OFF

CREATE TABLE [dbo].[AutographSpot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutographId] [int] NOT NULL,
	[SpotId] [int] NOT NULL,
 CONSTRAINT [PK_AutographSpot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AutographSpot]  WITH CHECK ADD  CONSTRAINT [FK_AutographSpot_Autograph] FOREIGN KEY([AutographId])
REFERENCES [dbo].[Autograph] ([Id])
GO

ALTER TABLE [dbo].[AutographSpot] CHECK CONSTRAINT [FK_AutographSpot_Autograph]
GO

ALTER TABLE [dbo].[AutographSpot]  WITH CHECK ADD  CONSTRAINT [FK_AutographSpot_Spot] FOREIGN KEY([SpotId])
REFERENCES [dbo].[Spot] ([Id])
GO

ALTER TABLE [dbo].[AutographSpot] CHECK CONSTRAINT [FK_AutographSpot_Spot]
GO

SET IDENTITY_INSERT [dbo].[AutographSpot] ON

INSERT INTO [dbo].[AutographSpot] (Id, AutographId, SpotId)
SELECT * 
FROM #TempAutographSpotTable

SET IDENTITY_INSERT [dbo].[AutographSpot] OFF

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
GO

ALTER TABLE [dbo].[SportLeagueLevel]  WITH CHECK ADD  CONSTRAINT [FK_SportLeagueLevel_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([Id])
GO

ALTER TABLE [dbo].[SportLeagueLevel] CHECK CONSTRAINT [FK_SportLeagueLevel_Sport]
GO

ALTER TABLE [dbo].[SportLeagueLevel]  WITH CHECK ADD  CONSTRAINT [FK_SportLeagueLevel_LevelType] FOREIGN KEY([LevelTypeId])
REFERENCES [dbo].[LevelType] ([Id])
GO

ALTER TABLE [dbo].[SportLeagueLevel] CHECK CONSTRAINT [FK_SportLeagueLevel_LevelType]
GO

SET IDENTITY_INSERT [dbo].[SportLeagueLevel] ON

--INSERT INTO [dbo].[SportLeagueLevel] (Id, SportId, LevelTypeId, [Name], Abbreviation)
--SELECT * 
--FROM #TempSportLeagueLevelTable

SET IDENTITY_INSERT [dbo].[SportLeagueLevel] OFF