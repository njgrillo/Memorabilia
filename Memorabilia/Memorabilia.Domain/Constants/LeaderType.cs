namespace Memorabilia.Domain.Constants;

public sealed class LeaderType : DomainItemConstant
{
    public static readonly LeaderType AAFCReceivingYards = new(61, "AAFC Receiving Yards");
    public static readonly LeaderType AAFCReceptions = new(62, "AAFC Receptions");
    public static readonly LeaderType AAFCRushingTouchdowns = new(65, "AAFC Rushing Touchdowns");
    public static readonly LeaderType AAFCRushingYards = new(64, "AAFC Rushing Yards");
    public static readonly LeaderType ABAScoringChampion = new (77, "ABA Scoring Champion");
    public static readonly LeaderType ABLScoring = new (73, "ABL Scoring");
    public static readonly LeaderType AFLCompletionPercentage = new(58, "AFL Completion Percentage");
    public static readonly LeaderType AFLInterceptions = new(67, "AFL Interceptions");
    public static readonly LeaderType AFLPasserRating = new(57, "AFL Passer Rating");
    public static readonly LeaderType AFLPassingTouchdowns = new(54, "AFL Passing Touchdowns");
    public static readonly LeaderType AFLPassingYards = new(53, "AFL Passing Yards");
    public static readonly LeaderType AFLReceivingTouchdowns = new(42, "AFL Receiving Touchdowns");
    public static readonly LeaderType AFLReceivingYards = new(40, "AFL Receiving Yards");
    public static readonly LeaderType AFLReceptions = new(41, "AFL Receptions");
    public static readonly LeaderType AmericanLeagueAdjustedBattingRuns = new(123, "American League Adjusted Batting Runs");
    public static readonly LeaderType AmericanLeagueAdjustedBattingWins = new(126, "American League Adjusted Batting Wins");
    public static readonly LeaderType AmericanLeagueAdjustedEarnedRunAveragePlus = new(252, "American League Adjusted ERA+");
    public static readonly LeaderType AmericanLeagueAdjustedOnBasePlusSluggingPercentagePlus = new(117, "American League Adjusted OPS+");
    public static readonly LeaderType AmericanLeagueAdjustedPitchingRuns = new(258, "American League Adjusted Pitching Runs");
    public static readonly LeaderType AmericanLeagueAdjustedPitchingWins = new(261, "American League Adjusted Pitching Wins");
    public static readonly LeaderType AmericanLeagueAtBatsPerHomeRun = new(165, "American League At Bats Per Home Run");
    public static readonly LeaderType AmericanLeagueAtBatsPerStrikeout = new(162, "American League At Bats Per Strikeout");
    public static readonly LeaderType AmericanLeagueBaseOutRunsAdded = new(171, "American League Base-Out Runs Added");
    public static readonly LeaderType AmericanLeagueBaseOutWinsAdded = new(183, "American League Base-Out Wins Added");
    public static readonly LeaderType AmericanLeagueBattersFaced = new(246, "American League Batters Faced");
    public static readonly LeaderType AmericanLeagueBattingChampion = new(1, "American League Batting Champion", "AL Batting Champ");
    public static readonly LeaderType AmericanLeagueCaughtStealing = new(153, "American League Caught Stealing");
    public static readonly LeaderType AmericanLeagueChampionshipWinProbabilityAdded = new(180, "American League Championship Win Probability Added");
    public static readonly LeaderType AmericanLeagueCompleteGames = new(213, "American League Complete Games");
    public static readonly LeaderType AmericanLeagueDefensiveWinsAboveReplacement = new(84, "American League Defensive Wins Above Replacement");
    public static readonly LeaderType AmericanLeagueDoubles = new(105, "American League Doubles");
    public static readonly LeaderType AmericanLeagueEarnedRunAverageLeader = new(11, "American League Earned Run Average Leader", "AL ERA Leader");
    public static readonly LeaderType AmericanLeagueEarnedRunsAllowed = new(237, "American League Earned Runs Allowed");
    public static readonly LeaderType AmericanLeagueExtraBaseHits = new(129, "American League Extra Base Hits");
    public static readonly LeaderType AmericanLeagueFieldingIndependentPitching = new(255, "American League Fielding Independent Pitching");
    public static readonly LeaderType AmericanLeagueGamesFinished = new(249, "American League Games Finished");
    public static readonly LeaderType AmericanLeagueGamesPitched = new(204, "American League Games Pitched");
    public static readonly LeaderType AmericanLeagueGamesStarted = new(210, "American League Games Started");
    public static readonly LeaderType AmericanLeagueGroundedIntoDoublePlays = new(150, "American League Ground Into Double Plays");
    public static readonly LeaderType AmericanLeagueHitBatsmen = new(243, "American League Hit Batsmen");
    public static readonly LeaderType AmericanLeagueHitByPitch = new(138, "American League Hit By Pitch");
    public static readonly LeaderType AmericanLeagueHitsAllowed = new(225, "American League Hits Allowed");
    public static readonly LeaderType AmericanLeagueHitsLeader = new(18, "American League Hits Leader", "AL Hits Leader");
    public static readonly LeaderType AmericanLeagueHitsPerNineInningsPitched = new(195, "American League Hits Per Nine Innings Pitched");
    public static readonly LeaderType AmericanLeagueHomeRunLeader = new(2, "American League Home Run Leader", "AL HR Leader");
    public static readonly LeaderType AmericanLeagueHomeRunsAllowed = new(219, "American League Home Runs Allowed");
    public static readonly LeaderType AmericanLeagueHomeRunsPerNineInningsPitched = new(231, "American League Home Runs Per Nine Innings Pitched");
    public static readonly LeaderType AmericanLeagueInningsPitched = new(207, "American League Innings Pitched");
    public static readonly LeaderType AmericanLeagueIntentionalWalks = new(147, "American League Intentional Walks");
    public static readonly LeaderType AmericanLeagueLosses = new(234, "National League Losses");
    public static readonly LeaderType AmericanLeagueOffensiveWinPercentage = new(135, "American League Offensive Win Percentage");
    public static readonly LeaderType AmericanLeagueOffensiveWinsAboveReplacement = new(87, "American League Offensive Wins Above Replacement");
    public static readonly LeaderType AmericanLeagueOnBasePercentage = new(90, "American League On-Base Percentage");
    public static readonly LeaderType AmericanLeagueOnBasePlusSluggingPercentage = new(96, "American League On-Base Plus Slugging Percentage");
    public static readonly LeaderType AmericanLeagueOutsMade = new(168, "American League Outs Made");
    public static readonly LeaderType AmericanLeaguePlateAppearances = new(99, "American League Plate Appearances");
    public static readonly LeaderType AmericanLeaguePowerSpeedNumber = new(159, "American League Power-Speed Number");
    public static readonly LeaderType AmericanLeagueRunBattedInLeader = new(3, "American League Run Batted In Leader", "AL RBI Leader");
    public static readonly LeaderType AmericanLeagueRunsCreated = new(120, "American League Runs Created");
    public static readonly LeaderType AmericanLeagueRunsLeader = new(29, "American League Runs Leader", "AL Runs Leader");
    public static readonly LeaderType AmericanLeagueSacrificeFlies = new(144, "American League Sacrifice Flies");
    public static readonly LeaderType AmericanLeagueSacrificeHits = new(141, "American League Sacrifice Hits");
    public static readonly LeaderType AmericanLeagueSavesLeader = new(24, "American League Saves Leader", "AL Saves Leader");
    public static readonly LeaderType AmericanLeagueShutouts = new(216, "American League Shutouts");
    public static readonly LeaderType AmericanLeagueSingles = new(114, "American League Singles");
    public static readonly LeaderType AmericanLeagueSituationalWinsAdded = new(177, "American League Situational Wins Added");
    public static readonly LeaderType AmericanLeagueSluggingPercentage = new(93, "American League Slugging Percentage");
    public static readonly LeaderType AmericanLeagueStolenBaseLeader = new(7, "American League Stolen Base Leader", "AL Stolen Base Leader");
    public static readonly LeaderType AmericanLeagueStolenBasePercentage = new(156, "American League Stolen Base Percentage");
    public static readonly LeaderType AmericanLeagueStrikeoutLeader = new(13, "American League Strikeout Leader", "AL Strikeout Leader");
    public static readonly LeaderType AmericanLeagueStrikeoutsBatter = new(111, "American League Strikeouts (Batter)");
    public static readonly LeaderType AmericanLeagueStrikeoutsPerNineInningsPitched = new(201, "American League Strikeouts Per Nine Innings Pitched");
    public static readonly LeaderType AmericanLeagueStrikeoutToWalkRatio = new(228, "American League Strikeout-to-Walk Ratio");
    public static readonly LeaderType AmericanLeagueTimesOnBase = new(132, "American League Times On Base");
    public static readonly LeaderType AmericanLeagueTotalBases = new(102, "American League Total Bases");
    public static readonly LeaderType AmericanLeagueTriplesLeader = new(26, "American League Triples Leader", "AL Triples Leader");
    public static readonly LeaderType AmericanLeagueWalks = new(108, "American League Walks");
    public static readonly LeaderType AmericanLeagueWalksAllowed = new(222, "American League Walks Allowed");
    public static readonly LeaderType AmericanLeagueWalksAndHitsPerNineInningsPitched = new(192, "American League Walks & Hits Per Nine Innings Pitched");
    public static readonly LeaderType AmericanLeagueWalksPerNineInningsPitched = new(198, "American League Walks Per Nine Innings Pitched");
    public static readonly LeaderType AmericanLeagueWildPitches = new(240, "National League Wild Pitches");
    public static readonly LeaderType AmericanLeagueWinLossPercentage = new(189, "American League Win-Loss Percentage");
    public static readonly LeaderType AmericanLeagueWinProbabilityAdded = new(174, "American League Win Probability Added");
    public static readonly LeaderType AmericanLeagueWinsAboveReplacement = new(81, "American League Wins Above Replacement");
    public static readonly LeaderType AmericanLeagueWinsAboveReplacementPitchers = new(186, "American League Wins Above Replacement - Pitchers", "AL WAR - Pitchers");
    public static readonly LeaderType AmericanLeagueWinsLeader = new(15, "American League Wins Leader", "AL Wins Leader");
    public static readonly LeaderType BAAScoringChampion = new (75, "BAA Scoring Champion");    
    public static readonly LeaderType CompletionPercentage = new (36, "NFL Completion Percentage");    
    public static readonly LeaderType ForcedFumbles = new (60, "NFL Forced Fumbles");    
    public static readonly LeaderType Interceptions = new (43, "NFL Interceptions");    
    public static readonly LeaderType KickoffReturnYards = new (56, "NFL Kickoff Return Yards");
    public static readonly LeaderType MajorLeagueBaseballAdjustedBattingRuns = new(122, "Major League Baseball Adjusted Batting Runs");
    public static readonly LeaderType MajorLeagueBaseballAdjustedBattingWins = new(125, "Major League Baseball Adjusted Batting Wins");
    public static readonly LeaderType MajorLeagueBaseballAdjustedEarnedRunAveragePlus = new(251, "Major League Baseball Adjusted ERA+");
    public static readonly LeaderType MajorLeagueBaseballAdjustedOnBasePlusSluggingPercentagePlus = new(116, "Major League Baseball Adjusted OPS+");
    public static readonly LeaderType MajorLeagueBaseballAdjustedPitchingRuns = new(257, "Major League Baseball Adjusted Pitching Runs");
    public static readonly LeaderType MajorLeagueBaseballAdjustedPitchingWins = new(260, "Major League Baseball Adjusted Pitching Wins");
    public static readonly LeaderType MajorLeagueBaseballAtBatsPerHomeRun = new(164, "Major League Baseball At Bats Per Home Run");
    public static readonly LeaderType MajorLeagueBaseballAtBatsPerStrikeout = new(161, "Major League Baseball At Bats Per Strikeout");
    public static readonly LeaderType MajorLeagueBaseballBaseOutRunsAdded = new(170, "Major League Baseball Base-Out Runs Added");
    public static readonly LeaderType MajorLeagueBaseballBaseOutWinsAdded = new(182, "Major League Baseball Base-Out Wins Added");
    public static readonly LeaderType MajorLeagueBaseballBattersFaced = new(245, "Major League Baseball Batters Faced");
    public static readonly LeaderType MajorLeagueBaseballBattingChampion = new(32, "Major League Baseball Batting Champion", "MLB Batting Champ");
    public static readonly LeaderType MajorLeagueBaseballCaughtStealing = new(152, "Major League Baseball Caught Stealing");
    public static readonly LeaderType MajorLeagueBaseballChampionshipWinProbabilityAdded = new(179, "Major League Baseball Championship Win Probability Added");
    public static readonly LeaderType MajorLeagueBaseballCompleteGames = new(212, "Major League Baseball Complete Games");
    public static readonly LeaderType MajorLeagueBaseballDefensiveWinsAboveReplacement = new(83, "Major League Baseball Defensive Wins Above Replacement");
    public static readonly LeaderType MajorLeagueBaseballDoubles = new(104, "Major League Baseball Doubles");
    public static readonly LeaderType MajorLeagueBaseballEarnedRunAverageLeader = new(23, "Major League Baseball Earned Run Average Leader", "MLB ERA Leader");
    public static readonly LeaderType MajorLeagueBaseballEarnedRunsAllowed = new(236, "Major League Baseball Earned Runs Allowed");
    public static readonly LeaderType MajorLeagueBaseballExtraBaseHits = new(128, "Major League Baseball Extra Base Hits");
    public static readonly LeaderType MajorLeagueBaseballFieldingIndependentPitching = new(254, "Major League Baseball Fielding Independent Pitching");
    public static readonly LeaderType MajorLeagueBaseballGamesFinished = new(248, "Major League Baseball Games Finished");
    public static readonly LeaderType MajorLeagueBaseballGamesPitched = new(203, "Major League Baseball Games Pitched");
    public static readonly LeaderType MajorLeagueBaseballGamesStarted = new(209, "Major League Baseball Games Started");
    public static readonly LeaderType MajorLeagueBaseballGroundedIntoDoublePlays = new(149, "Major League Baseball Ground Into Double Plays");
    public static readonly LeaderType MajorLeagueBaseballHitBatsmen = new(242, "Major League Baseball Hit Batsmen");
    public static readonly LeaderType MajorLeagueBaseballHitByPitch = new(137, "Major League Baseball Hit By Pitch");
    public static readonly LeaderType MajorLeagueBaseballHitsAllowed = new(224, "Major League Baseball Hits Allowed");
    public static readonly LeaderType MajorLeagueBaseballHitsLeader = new(20, "Major League Baseball Hits Leader", "MLB Hits Leader");
    public static readonly LeaderType MajorLeagueBaseballHitsPerNineInningsPitched = new(194, "Major League Baseball Hits Per Nine Innings Pitched");
    public static readonly LeaderType MajorLeagueBaseballHomeRunLeader = new(9, "Major League Baseball Home Run Leader", "MLB HR Leader");
    public static readonly LeaderType MajorLeagueBaseballHomeRunsAllowed = new(218, "Major League Baseball Home Runs Allowed");
    public static readonly LeaderType MajorLeagueBaseballHomeRunsPerNineInningsPitched = new(230, "Major League Baseball Home Runs Per Nine Innings Pitched");
    public static readonly LeaderType MajorLeagueBaseballInningsPitched = new(206, "Major League Baseball Innings Pitched");
    public static readonly LeaderType MajorLeagueBaseballIntentionalWalks = new(146, "Major League Basseball Intentional Walks");
    public static readonly LeaderType MajorLeagueBaseballLosses = new(233, "Major League Baseball Losses");
    public static readonly LeaderType MajorLeagueBaseballOffensiveWinPercentage = new(134, "Major League Baseball Offensive Win Percentage");
    public static readonly LeaderType MajorLeagueBaseballOffensiveWinsAboveReplacement = new(86, "Major League Baseball Offensive Wins Above Replacement");
    public static readonly LeaderType MajorLeagueBaseballOnBasePercentage = new(89, "Major League Baseball On-Base Percentage");
    public static readonly LeaderType MajorLeagueBaseballOnBasePlusSluggingPercentage = new(95, "Major League Baseball On-Base Plus Slugging Percentage");
    public static readonly LeaderType MajorLeagueBaseballOutsMade = new(167, "Major League Baseball Outs Made");
    public static readonly LeaderType MajorLeagueBaseballPlateAppearances = new(98, "Major League Baseball Plate Appearances");
    public static readonly LeaderType MajorLeagueBaseballPowerSpeedNumber = new(158, "Major League Baseball Power-Speed Number");
    public static readonly LeaderType MajorLeagueBaseballRunsBattedInLeader = new(17, "Major League Baseball Runs Batted In Leader", "MLB RBI Leader");
    public static readonly LeaderType MajorLeagueBaseballRunsCreated = new(119, "Major League Baseball Runs Created");
    public static readonly LeaderType MajorLeagueBaseballRunsLeader = new(31, "Major League Baseball Runs Leader", "MLB Runs Leader");
    public static readonly LeaderType MajorLeagueBaseballSacrificeFlies = new(143, "Major League Baseball Sacrifice Flies");
    public static readonly LeaderType MajorLeagueBaseballSacrificeHits = new(140, "Major League Baseball Sacrifice Hits");
    public static readonly LeaderType MajorLeagueBaseballSavesLeader = new(22, "Major League Baseball Saves Leader", "MLB Saves Leader");
    public static readonly LeaderType MajorLeagueBaseballShutouts = new(215, "Major League Baseball Shutouts");
    public static readonly LeaderType MajorLeagueBaseballSingles = new(113, "Major League Baseball Singles");
    public static readonly LeaderType MajorLeagueBaseballSituationalWinsAdded = new(176, "Major League Baseball Situational Wins Added");
    public static readonly LeaderType MajorLeagueBaseballSluggingPercentage = new(92, "Major League Baseball Slugging Percentage");
    public static readonly LeaderType MajorLeagueBaseballStolenBaseLeader = new (33, "Major League Baseball Stolen Base Leader", "MLB Stolen Base Leader");
    public static readonly LeaderType MajorLeagueBaseballStolenBasePercentage = new(155, "Major League Baseball Stolen Base Percentage");
    public static readonly LeaderType MajorLeagueBaseballStrikeoutLeader = new(21, "Major League Baseball Strikeout Leader", "MLB Strikeout Leader");
    public static readonly LeaderType MajorLeagueBaseballStrikeoutsBatter = new(110, "Major League Baseball Strikeouts (Batter)");
    public static readonly LeaderType MajorLeagueBaseballStrikeoutsPerNineInningsPitched = new(200, "Major League Baseball Strikeouts Per Nine Innings Pitched");
    public static readonly LeaderType MajorLeagueBaseballStrikeoutToWalkRatio = new(227, "Major League Baseball Strikeout-to-Walk Ratio");
    public static readonly LeaderType MajorLeagueBaseballTimesOnBase = new(131, "Major League Baseball Times On Base");
    public static readonly LeaderType MajorLeagueBaseballTotalBases = new(101, "Major League Baseball Total Bases");
    public static readonly LeaderType MajorLeagueBaseballTriplesLeader = new(28, "Major League Baseball Triples Leader", "MLB Triples Leader");
    public static readonly LeaderType MajorLeagueBaseballWalks = new(107, "Major League Baseball Walks");
    public static readonly LeaderType MajorLeagueBaseballWalksAllowed = new(221, "Major League Baseball Walks Allowed");
    public static readonly LeaderType MajorLeagueBaseballWalksAndHitsPerNineInningsPitched = new(191, "Major League Baseball Walks & Hits Per Nine Innings Pitched");
    public static readonly LeaderType MajorLeagueBaseballWalksPerNineInningsPitched = new(197, "Major League Baseball Walks Per Nine Innings Pitched");
    public static readonly LeaderType MajorLeagueBaseballWildPitches = new(239, "Major League Baseball Wild Pitches");
    public static readonly LeaderType MajorLeagueBaseballWinLossPercentage = new(188, "Major League Baseball Win-Loss Percentage");
    public static readonly LeaderType MajorLeagueBaseballWinProbabilityAdded = new(173, "Major League Baseball Win Probability Added");
    public static readonly LeaderType MajorLeagueBaseballWinsAboveReplacement = new(80, "Major League Baseball Wins Above Replacement");
    public static readonly LeaderType MajorLeagueBaseballWinsAboveReplacementPitchers = new(185, "Major League Baseball Wins Above Replacement - Pitchers", "MLB WAR - Pitchers");
    public static readonly LeaderType MajorLeagueBaseballWinsLeader = new(10, "Major League Baseball Wins Leader", "MLB Wins Leader");
    public static readonly LeaderType NationalLeagueAdjustedBattingRuns= new(124, "National League Adjusted Batting Runs");
    public static readonly LeaderType NationalLeagueAdjustedBattingWins= new(127, "National League Adjusted Batting Wins");
    public static readonly LeaderType NationalLeagueAdjustedEarnedRunAveragePlus = new(253, "National League Adjusted ERA+");
    public static readonly LeaderType NationalLeagueAdjustedOnBasePlusSluggingPercentagePlus = new(118, "National League Adjusted OPS+");
    public static readonly LeaderType NationalLeagueAdjustedPitchingRuns = new(259, "National League Adjusted Pitching Runs");
    public static readonly LeaderType NationalLeagueAdjustedPitchingWins = new(262, "National League Adjusted Pitching Wins");
    public static readonly LeaderType NationalLeagueAssists = new(55, "National League Assists", "NL Assists");
    public static readonly LeaderType NationalLeagueAtBatsPerHomeRun = new(166, "National League At Bats Per Home Run");
    public static readonly LeaderType NationalLeagueAtBatsPerStrikeout = new(163, "National League At Bats Per Strikeout");
    public static readonly LeaderType NationalLeagueBaseOutRunsAdded = new(172, "National League Base-Out Runs Added");
    public static readonly LeaderType NationalLeagueBaseOutWinsAdded = new(184, "National League Base-Out Wins Added");
    public static readonly LeaderType NationalLeagueBattersFaced = new(247, "National League Batters Faced");
    public static readonly LeaderType NationalLeagueBattingChampion = new(4, "National League Batting Champion", "NL Batting Champ");
    public static readonly LeaderType NationalLeagueCaughtStealing = new(154, "National League Caught Stealing");
    public static readonly LeaderType NationalLeagueChampionshipWinProbabilityAdded = new(181, "National League Championship Win Probability Added");
    public static readonly LeaderType NationalLeagueCompleteGames = new(214, "National League Complete Games");
    public static readonly LeaderType NationalLeagueDefensiveWinsAboveReplacement = new(85, "National League Defensive Wins Above Replacement");
    public static readonly LeaderType NationalLeagueDoubles = new(106, "National League Doubles");
    public static readonly LeaderType NationalLeagueFieldingIndependentPitching = new(256, "National League Fielding Independent Pitching");
    public static readonly LeaderType NationalLeagueEarnedRunAverageLeader = new(12, "National League Earned Run Average Leader", "NL ERA Leader");
    public static readonly LeaderType NationalLeagueEarnedRunsAllowed = new(238, "National League Earned Runs Allowed");
    public static readonly LeaderType NationalLeagueExtraBaseHits = new(130, "National League Extra Base Hits");
    public static readonly LeaderType NationalLeagueGamesFinished = new(250, "National League Games Finished");
    public static readonly LeaderType NationalLeagueGamesPitched = new(205, "National League Games Pitched");
    public static readonly LeaderType NationalLeagueGamesStarted = new(211, "National League Games Started");
    public static readonly LeaderType NationalLeagueGroundedIntoDoublePlays = new(151, "National League Ground Into Double Plays");
    public static readonly LeaderType NationalLeagueHitBatsmen = new(244, "National League Hit Batsmen");
    public static readonly LeaderType NationalLeagueHitByPitch = new(139, "National League Hit By Pitch");
    public static readonly LeaderType NationalLeagueHitsAllowed = new(226, "National League Hits Allowed");
    public static readonly LeaderType NationalLeagueHitsLeader = new(19, "National League Hits Leader", "NL Hits Leader");
    public static readonly LeaderType NationalLeagueHitsPerNineInningsPitched = new(196, "National League Hits Per Nine Innings Pitched");
    public static readonly LeaderType NationalLeagueHomeRunLeader = new(5, "National League Home Run Leader", "NL HR Leader");
    public static readonly LeaderType NationalLeagueHomeRunsAllowed = new(220, "National League Home Runs Allowed");
    public static readonly LeaderType NationalLeagueHomeRunsPerNineInningsPitched = new(232, "National League Home Runs Per Nine Innings Pitched");
    public static readonly LeaderType NationalLeagueInningsPitched = new(208, "National League Innings Pitched");
    public static readonly LeaderType NationalLeagueIntentionalWalks = new(148, "National League Intentional Walks");
    public static readonly LeaderType NationalLeagueLosses = new(235, "National League Losses");
    public static readonly LeaderType NationalLeagueOffensiveWinPercentage = new(136, "National League Offensive Win Percentage");
    public static readonly LeaderType NationalLeagueOffensiveWinsAboveReplacement = new(88, "National League Offensive Wins Above Replacement");
    public static readonly LeaderType NationalLeagueOnBasePercentage = new(91, "National League On-Base Percentage");
    public static readonly LeaderType NationalLeagueOnBasePlusSluggingPercentage = new(97, "National League On-Base Plus Slugging Percentage");
    public static readonly LeaderType NationalLeagueOutsMade = new(169, "National League Outs Made");
    public static readonly LeaderType NationalLeaguePlateAppearances = new(100, "National League Plate Appearances");
    public static readonly LeaderType NationalLeaguePowerSpeedNumber = new(160, "National League Power-Speed Number");
    public static readonly LeaderType NationalLeagueRunBattedInLeader = new(6, "National League Run Batted In Leader", "NL RBI Leader");
    public static readonly LeaderType NationalLeagueRunsCreated = new(121, "National League Runs Created");
    public static readonly LeaderType NationalLeagueRunsLeader = new(30, "National League Runs Leader", "NL Runs Leader");
    public static readonly LeaderType NationalLeagueSacrificeFlies = new(145, "National League Sacrifice Flies");
    public static readonly LeaderType NationalLeagueSacrificeHits = new(142, "National League Sacrifice Hits");
    public static readonly LeaderType NationalLeagueSavesLeader = new(25, "National League Saves Leader", "NL Saves Leader");
    public static readonly LeaderType NationalLeagueShutouts = new(217, "National League Shutouts");
    public static readonly LeaderType NationalLeagueSingles = new(115, "National League Singles");
    public static readonly LeaderType NationalLeagueSituationalWinsAdded = new(178, "National League Situational Wins Added");
    public static readonly LeaderType NationalLeagueSluggingPercentage = new(94, "National League Slugging Percentage");
    public static readonly LeaderType NationalLeagueStolenBaseLeader = new(8, "National League Stolen Base Leader", "NL Stolen Base Leader");
    public static readonly LeaderType NationalLeagueStolenBasePercentage = new(157, "National League Stolen Base Percentage");
    public static readonly LeaderType NationalLeagueStrikeoutLeader = new(14, "National League Strikeout Leader", "NL Strikeout Leader");
    public static readonly LeaderType NationalLeagueStrikeoutsBatter = new(112, "National League Strikeouts (Batter)");
    public static readonly LeaderType NationalLeagueStrikeoutsPerNineInningsPitched = new(202, "National League Strikeouts Per Nine Innings Pitched");
    public static readonly LeaderType NationalLeagueStrikeoutToWalkRatio = new(229, "National League Strikeout-to-Walk Ratio");    
    public static readonly LeaderType NationalLeagueTimesOnBase = new(133, "National League Times On Base");
    public static readonly LeaderType NationalLeagueTotalBases = new(103, "National League Total Bases");
    public static readonly LeaderType NationalLeagueTriplesLeader = new(27, "National League Triples Leader", "NL Triples Leader");
    public static readonly LeaderType NationalLeagueWalks = new(109, "National League Walks");
    public static readonly LeaderType NationalLeagueWalksAllowed = new(223, "National League Walks Allowed");
    public static readonly LeaderType NationalLeagueWalksAndHitsPerNineInningsPitched = new(193, "National League Walks & Hits Per Nine Innings Pitched");
    public static readonly LeaderType NationalLeagueWalksPerNineInningsPitched = new(199, "National League Walks Per Nine Innings Pitched");
    public static readonly LeaderType NationalLeagueWildPitches = new(241, "National League Wild Pitches");
    public static readonly LeaderType NationalLeagueWinLossPercentage = new(190, "National League Win-Loss Percentage");
    public static readonly LeaderType NationalLeagueWinProbabilityAdded = new(175, "National League Win Probability Added");
    public static readonly LeaderType NationalLeagueWinsAboveReplacement = new(82, "National League Wins Above Replacement");
    public static readonly LeaderType NationalLeagueWinsAboveReplacementPitchers = new(187, "National League Wins Above Replacement - Pitchers", "NL WAR - Pitchers");
    public static readonly LeaderType NationalLeagueWinsLeader = new(16, "National League Wins Leader", "NL Wins Leader");
    public static readonly LeaderType NBAAssists = new(74, "NBA Assists");
    public static readonly LeaderType NBABlocks = new(78, "NBA Blocks");
    public static readonly LeaderType NBAReboundingLeader = new(71, "NBA Rebounding Leader");
    public static readonly LeaderType NBAScoringChampion = new(70, "NBA Scoring Champion");
    public static readonly LeaderType NBASteals = new(76, "NBA Steals");
    public static readonly LeaderType NBLScoring = new(72, "NBL Scoring");
    public static readonly LeaderType NBLScoringChampion = new(69, "NBL Scoring Champion");
    public static readonly LeaderType NCAADivisionIScoringLeader = new (68, "NCAA Division I Scoring Leader");
    public static readonly LeaderType PasserRating = new (46, "NFL Passer Rating");
    public static readonly LeaderType PassingTouchdowns = new (45, "NFL Passing Touchdowns");
    public static readonly LeaderType PassingYards = new (44, "NFL Passing Yards");
    public static readonly LeaderType PuntingAverage = new (48, "NFL Punting Average");
    public static readonly LeaderType PuntingYards = new (49, "NFL Punting Yards");
    public static readonly LeaderType PuntReturnYards = new (79, "NFL Punt Return Yards");
    public static readonly LeaderType ReceivingTouchdowns = new (52, "NFL Receiving Touchdowns");
    public static readonly LeaderType ReceivingYards = new (50, "NFL Receiving Yards");
    public static readonly LeaderType Receptions = new (51, "NFL Receptions");
    public static readonly LeaderType Rushes = new (66, "NFL Rushes");
    public static readonly LeaderType RushingTouchdowns = new (37, "NFL Rushing Touchdowns");
    public static readonly LeaderType RushingYards = new (38, "NFL Rushing Yards");
    public static readonly LeaderType Sacks = new (59, "NFL Sacks");
    public static readonly LeaderType Scoring = new (39, "NFL Scoring");
    public static readonly LeaderType Tackles = new (63, "NFL Tackles");

    public static LeaderType[] All
        => Baseball.Union(Basketball)
                   .Union(Football)
                   .Union(Hockey)
                   .Distinct()
                   .ToArray();

    public static readonly LeaderType[] Baseball =
    [
        AmericanLeagueAdjustedBattingRuns,
        AmericanLeagueAdjustedBattingWins,
        AmericanLeagueAdjustedEarnedRunAveragePlus,
        AmericanLeagueAdjustedOnBasePlusSluggingPercentagePlus,
        AmericanLeagueAdjustedPitchingRuns,
        AmericanLeagueAdjustedPitchingWins,
        AmericanLeagueAtBatsPerHomeRun,
        AmericanLeagueAtBatsPerStrikeout,
        AmericanLeagueBaseOutRunsAdded,
        AmericanLeagueBaseOutWinsAdded,
        AmericanLeagueBattersFaced,
        AmericanLeagueBattingChampion,
        AmericanLeagueCaughtStealing,
        AmericanLeagueChampionshipWinProbabilityAdded,
        AmericanLeagueCompleteGames,
        AmericanLeagueDefensiveWinsAboveReplacement,
        AmericanLeagueDoubles,
        AmericanLeagueEarnedRunAverageLeader,
        AmericanLeagueEarnedRunsAllowed,
        AmericanLeagueExtraBaseHits,
        AmericanLeagueFieldingIndependentPitching,
        AmericanLeagueGamesFinished,
        AmericanLeagueGamesPitched,
        AmericanLeagueGamesStarted,
        AmericanLeagueGroundedIntoDoublePlays,
        AmericanLeagueHitBatsmen,
        AmericanLeagueHitByPitch,
        AmericanLeagueHitsAllowed,
        AmericanLeagueHitsLeader,   
        AmericanLeagueHitsPerNineInningsPitched,
        AmericanLeagueHomeRunLeader,
        AmericanLeagueHomeRunsAllowed,
        AmericanLeagueHomeRunsPerNineInningsPitched,
        AmericanLeagueInningsPitched,
        AmericanLeagueIntentionalWalks,
        AmericanLeagueLosses,
        AmericanLeagueOffensiveWinPercentage,
        AmericanLeagueOffensiveWinsAboveReplacement,
        AmericanLeagueOnBasePercentage,
        AmericanLeagueOnBasePlusSluggingPercentage,
        AmericanLeagueOutsMade,
        AmericanLeaguePlateAppearances,
        AmericanLeaguePowerSpeedNumber,
        AmericanLeagueRunBattedInLeader,
        AmericanLeagueRunsCreated,
        AmericanLeagueRunsLeader,
        AmericanLeagueSacrificeFlies,
        AmericanLeagueSacrificeHits,
        AmericanLeagueSavesLeader,
        AmericanLeagueShutouts,
        AmericanLeagueSingles,
        AmericanLeagueSituationalWinsAdded,
        AmericanLeagueSluggingPercentage,
        AmericanLeagueStolenBaseLeader,
        AmericanLeagueStolenBasePercentage,
        AmericanLeagueStrikeoutLeader,
        AmericanLeagueStrikeoutsBatter,
        AmericanLeagueStrikeoutsPerNineInningsPitched,
        AmericanLeagueStrikeoutToWalkRatio,
        AmericanLeagueTimesOnBase,
        AmericanLeagueTotalBases,
        AmericanLeagueTriplesLeader,
        AmericanLeagueWalks,
        AmericanLeagueWalksAllowed,
        AmericanLeagueWalksAndHitsPerNineInningsPitched,
        AmericanLeagueWalksPerNineInningsPitched,
        AmericanLeagueWildPitches,
        AmericanLeagueWinLossPercentage,
        AmericanLeagueWinProbabilityAdded,
        AmericanLeagueWinsAboveReplacement,
        AmericanLeagueWinsAboveReplacementPitchers,
        AmericanLeagueWinsLeader,
        MajorLeagueBaseballAdjustedBattingRuns,
        MajorLeagueBaseballAdjustedBattingWins,
        MajorLeagueBaseballAdjustedEarnedRunAveragePlus,
        MajorLeagueBaseballAdjustedOnBasePlusSluggingPercentagePlus,
        MajorLeagueBaseballAdjustedPitchingRuns,
        MajorLeagueBaseballAdjustedPitchingWins,
        MajorLeagueBaseballAtBatsPerHomeRun,
        MajorLeagueBaseballAtBatsPerStrikeout,
        MajorLeagueBaseballBaseOutRunsAdded,
        MajorLeagueBaseballBaseOutWinsAdded,
        MajorLeagueBaseballBattersFaced,
        MajorLeagueBaseballBattingChampion,
        MajorLeagueBaseballCaughtStealing,
        MajorLeagueBaseballChampionshipWinProbabilityAdded,
        MajorLeagueBaseballCompleteGames,
        MajorLeagueBaseballDefensiveWinsAboveReplacement,
        MajorLeagueBaseballDoubles,
        MajorLeagueBaseballEarnedRunAverageLeader,
        MajorLeagueBaseballEarnedRunsAllowed,
        MajorLeagueBaseballExtraBaseHits,
        MajorLeagueBaseballFieldingIndependentPitching,
        MajorLeagueBaseballGamesFinished,
        MajorLeagueBaseballGamesPitched,
        MajorLeagueBaseballGamesStarted,
        MajorLeagueBaseballGroundedIntoDoublePlays,
        MajorLeagueBaseballHitBatsmen,
        MajorLeagueBaseballHitByPitch,
        MajorLeagueBaseballHitsAllowed,
        MajorLeagueBaseballHitsLeader,    
        MajorLeagueBaseballHitsPerNineInningsPitched,
        MajorLeagueBaseballHomeRunLeader,
        MajorLeagueBaseballHomeRunsAllowed,
        MajorLeagueBaseballHomeRunsPerNineInningsPitched,
        MajorLeagueBaseballInningsPitched,
        MajorLeagueBaseballIntentionalWalks,
        MajorLeagueBaseballLosses,
        MajorLeagueBaseballOffensiveWinPercentage,
        MajorLeagueBaseballOffensiveWinsAboveReplacement,
        MajorLeagueBaseballOnBasePercentage,
        MajorLeagueBaseballOnBasePlusSluggingPercentage,
        MajorLeagueBaseballOutsMade,
        MajorLeagueBaseballPlateAppearances,
        MajorLeagueBaseballPowerSpeedNumber,
        MajorLeagueBaseballRunsBattedInLeader,
        MajorLeagueBaseballRunsCreated,
        MajorLeagueBaseballRunsLeader,
        MajorLeagueBaseballSacrificeFlies,
        MajorLeagueBaseballSacrificeHits,
        MajorLeagueBaseballSavesLeader,
        MajorLeagueBaseballShutouts,
        MajorLeagueBaseballSingles,
        MajorLeagueBaseballSituationalWinsAdded,
        MajorLeagueBaseballSluggingPercentage,
        MajorLeagueBaseballStolenBaseLeader,
        MajorLeagueBaseballStolenBasePercentage,
        MajorLeagueBaseballStrikeoutLeader,
        MajorLeagueBaseballStrikeoutsBatter,
        MajorLeagueBaseballStrikeoutsPerNineInningsPitched,
        MajorLeagueBaseballStrikeoutToWalkRatio,
        MajorLeagueBaseballTimesOnBase,
        MajorLeagueBaseballTotalBases,
        MajorLeagueBaseballTriplesLeader,
        MajorLeagueBaseballWalks,
        MajorLeagueBaseballWalksAllowed,
        MajorLeagueBaseballWalksAndHitsPerNineInningsPitched,
        MajorLeagueBaseballWalksPerNineInningsPitched,
        MajorLeagueBaseballWildPitches,
        MajorLeagueBaseballWinLossPercentage,
        MajorLeagueBaseballWinProbabilityAdded,
        MajorLeagueBaseballWinsAboveReplacement,
        MajorLeagueBaseballWinsAboveReplacementPitchers,
        MajorLeagueBaseballWinsLeader,
        NationalLeagueAdjustedBattingRuns,
        NationalLeagueAdjustedBattingWins,
        NationalLeagueAdjustedEarnedRunAveragePlus,
        NationalLeagueAdjustedOnBasePlusSluggingPercentagePlus,
        NationalLeagueAdjustedPitchingRuns,
        NationalLeagueAdjustedPitchingWins,
        NationalLeagueAssists,
        NationalLeagueAtBatsPerHomeRun,
        NationalLeagueAtBatsPerStrikeout,
        NationalLeagueBaseOutRunsAdded,
        NationalLeagueBaseOutWinsAdded,
        NationalLeagueBattersFaced,
        NationalLeagueBattingChampion,
        NationalLeagueCaughtStealing,
        NationalLeagueChampionshipWinProbabilityAdded,
        NationalLeagueCompleteGames,
        NationalLeagueDefensiveWinsAboveReplacement,
        NationalLeagueDoubles,
        NationalLeagueEarnedRunAverageLeader,
        NationalLeagueEarnedRunsAllowed,
        NationalLeagueExtraBaseHits,
        NationalLeagueFieldingIndependentPitching,
        NationalLeagueGamesFinished,
        NationalLeagueGamesPitched,
        NationalLeagueGamesStarted,
        NationalLeagueGroundedIntoDoublePlays,
        NationalLeagueHitBatsmen,
        NationalLeagueHitByPitch,
        NationalLeagueHitsAllowed,
        NationalLeagueHitsLeader,
        NationalLeagueHitsPerNineInningsPitched,
        NationalLeagueHomeRunLeader,
        NationalLeagueHomeRunsAllowed,
        NationalLeagueHomeRunsPerNineInningsPitched,
        NationalLeagueInningsPitched,
        NationalLeagueIntentionalWalks,
        NationalLeagueLosses,
        NationalLeagueOffensiveWinPercentage,
        NationalLeagueOffensiveWinsAboveReplacement,
        NationalLeagueOnBasePercentage,
        NationalLeagueOnBasePlusSluggingPercentage,
        NationalLeagueOutsMade,
        NationalLeaguePlateAppearances,
        NationalLeaguePowerSpeedNumber,
        NationalLeagueRunBattedInLeader,
        NationalLeagueRunsCreated,
        NationalLeagueRunsLeader,
        NationalLeagueSacrificeFlies,
        NationalLeagueSacrificeHits,
        NationalLeagueSavesLeader,
        NationalLeagueShutouts,
        NationalLeagueSingles,
        NationalLeagueSituationalWinsAdded,
        NationalLeagueSluggingPercentage,
        NationalLeagueStolenBaseLeader,
        NationalLeagueStolenBasePercentage,
        NationalLeagueStrikeoutLeader,
        NationalLeagueStrikeoutsBatter,
        NationalLeagueStrikeoutsPerNineInningsPitched,
        NationalLeagueStrikeoutToWalkRatio,
        NationalLeagueTimesOnBase,
        NationalLeagueTotalBases,
        NationalLeagueTriplesLeader,
        NationalLeagueWalks,
        NationalLeagueWalksAllowed,
        NationalLeagueWalksAndHitsPerNineInningsPitched,
        NationalLeagueWalksPerNineInningsPitched,
        NationalLeagueWildPitches,
        NationalLeagueWinLossPercentage,
        NationalLeagueWinProbabilityAdded,
        NationalLeagueWinsAboveReplacement,
        NationalLeagueWinsAboveReplacementPitchers,
        NationalLeagueWinsLeader
    ];

    public static readonly LeaderType[] Basketball =
    [
        ABAScoringChampion,
        ABLScoring,
        BAAScoringChampion,
        NBAAssists,
        NBABlocks,
        NBAReboundingLeader,
        NBAScoringChampion,
        NBASteals,
        NBLScoring,
        NBLScoringChampion,
        NCAADivisionIScoringLeader
    ];

    public static readonly LeaderType[] Football =
    [
        AAFCReceivingYards,
        AAFCReceptions,
        AAFCRushingTouchdowns,
        AAFCRushingYards,
        AFLCompletionPercentage,
        AFLInterceptions,
        AFLPasserRating,
        AFLPassingTouchdowns,
        AFLPassingYards,
        AFLReceivingTouchdowns,
        AFLReceivingYards,
        AFLReceptions,
        CompletionPercentage,
        ForcedFumbles,
        Interceptions,
        KickoffReturnYards,
        PasserRating,
        PassingTouchdowns,
        PassingYards,
        PuntingAverage,
        PuntingYards,
        PuntReturnYards,
        ReceivingTouchdowns,
        ReceivingYards,
        Receptions,
        Rushes,
        RushingTouchdowns,
        RushingYards,
        Sacks,
        Scoring,
        Tackles
    ];

    public static readonly LeaderType[] Hockey =
    [];

    private LeaderType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { } 

    public static LeaderType Find(int id)
        => All.SingleOrDefault(leaderType => leaderType.Id == id);

    public static LeaderType[] GetAll(params Sport[] sports)
    {
        if (sports.IsNullOrEmpty())
            return All;

        var leaderTypes = new List<LeaderType>();

        if (sports.Any(sport => sport == Sport.Baseball))
            leaderTypes.AddRange(Baseball);

        if (sports.Any(sport => sport == Sport.Basketball))
            leaderTypes.AddRange(Basketball);

        if (sports.Any(sport => sport == Sport.Football))
            leaderTypes.AddRange(Football);

        if (sports.Any(sport => sport == Sport.Hockey))
            leaderTypes.AddRange(Hockey);

        return leaderTypes.OrderBy(leaderType => leaderType.Name).ToArray();
    }

    public override string ToString()
        => Name;
}
