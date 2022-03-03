--.Include(memorabilia => memorabilia.Autographs)
--                                                                               .Include("Autographs.Acquisition")
--                                                                               .Include("Autographs.Authentications")
--                                                                               .Include("Autographs.Images")
--                                                                               .Include("Autographs.Inscriptions")
--                                                                               .Include("Autographs.Person")
--                                                                               .Include("Autographs.Spot")

SELECT memorabilia.Id
     , memorabilia.ItemTypeId
	 , memorabilia.ConditionId
	 , memorabilia.EstimatedValue
	 , memorabilia.PrivacyTypeId
	 , memorabilia.UserId
	 , memorabilia.CreateDate
	 , memorabilia.LastModifiedDate
	 , memorabiliaAcquisition.Id
	 , memorabiliaAcquisition.MemorabiliaId
	 , memorabiliaAcquisition.AcquisitionId
	 , memAcquisition.Id
	 , memAcquisition.AcquisitionTypeId
	 , memAcquisition.AcquiredDate
	 , memAcquisition.PurchaseTypeId
	 , memAcquisition.Cost
	 , memorabiliaBaseball.Id
	 , memorabiliaBaseball.MemorabiliaId
	 , memorabiliaBaseball.BaseballTypeId
	 , memorabiliaBaseball.Year
	 , memorabiliaBaseball.Anniversary
	 , memorabiliaBasketball.Id
	 , memorabiliaBasketball.MemorabiliaId
	 , memorabiliaBasketball.BasketballTypeId
	 , memorabiliaBat.Id
	 , memorabiliaBat.MemorabiliaId
	 , memorabiliaBat.BatTypeId
	 , memorabiliaBat.Length
	 , memorabiliaBat.ColorId
	 , memorabiliaBrand.Id
	 , memorabiliaBrand.MemorabiliaId
	 , memorabiliaBrand.BrandId
	 , memorabiliaCard.Id
	 , memorabiliaCard.MemorabiliaId
	 , memorabiliaCard.Year
	 , memorabiliaCard.Numerator
	 , memorabiliaCard.Denominator
	 , memorabiliaCard.Licensed
	 , memorabiliaCard.Custom
	 , memorabiliaCommissioner.Id
	 , memorabiliaCommissioner.MemorabiliaId
	 , memorabiliaCommissioner.CommissionerId
	 , memorabiliaFootball.Id
	 , memorabiliaFootball.MemorabiliaId
	 , memorabiliaFootball.FootballTypeId
	 , memorabiliaGame.Id
	 , memorabiliaGame.MemorabiliaId
	 , memorabiliaGame.GameStyleTypeId
	 , memorabiliaGame.PersonId
	 , memorabiliaGame.GameDate
	 , memorabiliaHelmet.Id
	 , memorabiliaHelmet.MemorabiliaId
	 , memorabiliaHelmet.HelmetQualityTypeId
	 , memorabiliaHelmet.HelmetTypeId
	 , memorabiliaHelmet.HelmetFinishId
	 , memorabiliaHelmet.Throwback
	 , memorabiliaImage.Id
	 , memorabiliaImage.MemorabiliaId
	 , memorabiliaImage.FilePath
	 , memorabiliaImage.UploadDate
	 , memorabiliaImage.ImageTypeId
	 , memorabiliaJersey.Id
	 , memorabiliaJersey.MemorabiliaId
	 , memorabiliaJersey.JerseyQualityTypeId
	 , memorabiliaJersey.JerseyStyleTypeId
	 , memorabiliaJersey.JerseyTypeId
	 , memorabiliaLevelType.Id
	 , memorabiliaLevelType.MemorabiliaId
	 , memorabiliaLevelType.LevelTypeId
	 , memorabiliaMagazine.Id
	 , memorabiliaMagazine.MemorabiliaId
	 , memorabiliaMagazine.Date
	 , memorabiliaMagazine.Framed
	 , memorabiliaOrientation.Id
	 , memorabiliaOrientation.MemorabiliaId
	 , memorabiliaOrientation.OrientationId
	 , memorabiliaPerson.Id
	 , memorabiliaPerson.MemorabiliaId
	 , memorabiliaPerson.PersonId
	 , memorabiliaPhoto.Id
	 , memorabiliaPhoto.MemorabiliaId
	 , memorabiliaPhoto.PhotoTypeId
	 , memorabiliaPhoto.Framed
	 , memorabiliaSize.Id
	 , memorabiliaSize.MemorabiliaId
	 , memorabiliaSize.SizeId
	 , memorabiliaSport.Id
	 , memorabiliaSport.MemorabiliaId
	 , memorabiliaSport.SportId
	 , memorabiliaTeam.Id
	 , memorabiliaTeam.MemorabiliaId
	 , memorabiliaTeam.TeamId
	 , [user].Id
	 , [user].EmailAddress
	 , [user].FirstName
	 , [user].LastName
	 , [user].Password
	 , [user].Phone
	 , [user].Username
	 , [user].RoleId
	 , [user].CreateDate
	 , [user].UpdateDate
     , autograph.Id
	 , autograph.MemorabiliaId
	 , autograph.ConditionId
	 , autograph.WritingInstrumentId
	 , autograph.ColorId
	 , autograph.EstimatedValue
	 , autograph.Grade
	 , autograph.CreateDate
	 , autograph.LastModifiedDate
	 , autographAcquisition.Id
	 , autographAcquisition.AcquisitionTypeId
	 , autographAcquisition.AcquiredDate
	 , autographAcquisition.PurchaseTypeId
	 , autographAcquisition.Cost
	 , autographAuthentication.Id
	 , autographAuthentication.AutographId
	 , autographAuthentication.AuthenticationCompanyId
	 , autographAuthentication.Verification
	 , autographAuthentication.HasHologram
	 , autographAuthentication.HasLetter
	 , autographAuthentication.Witnessed
	 , autographImage.Id
	 , autographImage.AutographId
	 , autographImage.FilePath
	 , autographImage.UploadDate
	 , autographImage.ImageTypeId
	 , autographSpot.Id
	 , autographSpot.AutographId
	 , autographSpot.SpotId
	 , inscription.Id
	 , inscription.AutographId
	 , inscription.InscriptionTypeId
	 , inscription.InscriptionText
	 , person.Id
	 , person.FirstName
	 , person.LastName
	 , person.MiddleName
	 , person.Suffix
	 , person.Nickname
	 , person.LegalName
	 , person.DisplayName
	 , person.BirthDate
	 , person.DeathDate
	 , person.ImagePath
	 , person.CreateDate
	 , person.LastModifiedDate
FROM Memorabilia memorabilia
LEFT JOIN MemorabiliaAcquisition memorabiliaAcquisition ON memorabiliaAcquisition.MemorabiliaId = memorabilia.Id
LEFT JOIN Acquisition memAcquisition ON memAcquisition.Id = memorabiliaAcquisition.AcquisitionId
LEFT JOIN MemorabiliaBaseball memorabiliaBaseball ON memorabiliaBaseball.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaBasketball memorabiliaBasketball ON memorabiliaBasketball.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaBat memorabiliaBat ON memorabiliaBat.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaBrand memorabiliaBrand ON memorabiliaBrand.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaCard memorabiliaCard ON memorabiliaCard.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaCommissioner memorabiliaCommissioner ON memorabiliaCommissioner.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaFootball memorabiliaFootball ON memorabiliaFootball.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaGame memorabiliaGame ON memorabiliaGame.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaHelmet memorabiliaHelmet ON memorabiliaHelmet.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaImage memorabiliaImage ON memorabiliaImage.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaJersey memorabiliaJersey ON memorabiliaJersey.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaLevelType memorabiliaLevelType ON memorabiliaLevelType.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaMagazine memorabiliaMagazine ON memorabiliaMagazine.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaOrientation memorabiliaOrientation ON memorabiliaOrientation.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaPerson memorabiliaPerson ON memorabiliaPerson.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaPhoto memorabiliaPhoto ON memorabiliaPhoto.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaSize memorabiliaSize ON memorabiliaSize.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaSport memorabiliaSport ON memorabiliaSport.MemorabiliaId = memorabilia.Id
LEFT JOIN MemorabiliaTeam memorabiliaTeam ON memorabiliaTeam.MemorabiliaId = memorabilia.Id
LEFT JOIN [User] [user] ON [user].Id = memorabilia.UserId
LEFT JOIN Autograph autograph ON autograph.MemorabiliaId = memorabilia.Id
LEFT JOIN Acquisition autographAcquisition ON autographAcquisition.Id = autograph.AcquisitionId
LEFT JOIN AutographAuthentication autographAuthentication ON autographAuthentication.AutographId = autograph.Id
LEFT JOIN AutographImage autographImage ON autographImage.AutographId = autographImage.AutographId
LEFT JOIN Inscription inscription ON inscription.AutographId = autograph.Id
LEFT JOIN Person person ON person.Id = autograph.PersonId
LEFT JOIN AutographSpot autographSpot ON autographSpot.AutographId = autograph.Id