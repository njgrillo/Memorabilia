using System;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Domain.Entities
{
    public class Memorabilia : Framework.Domain.Entity.DomainEntity
    {
        public Memorabilia() { }

        public Memorabilia(DateTime? acquiredDate,
                           int acquisitionTypeId,
                           int? conditionId,
                           decimal? cost,
                           decimal? estimatedValue,
                           int itemTypeId,
                           int privacyTypeId,
                           int? purchaseTypeId,
                           int userId)
        {
            ItemTypeId = itemTypeId;
            ConditionId = conditionId;
            PrivacyTypeId = privacyTypeId;
            EstimatedValue = estimatedValue;
            UserId = userId;
            CreateDate = DateTime.UtcNow;

            if (acquisitionTypeId > 0)
                MemorabiliaAcquisition = new MemorabiliaAcquisition(Id, acquisitionTypeId, acquiredDate, cost, purchaseTypeId);
        }

        public virtual Acquisition Acquisition => MemorabiliaAcquisition.Acquisition;

        public virtual List<Autograph> Autographs { get; private set; } = new ();

        public virtual MemorabiliaBaseball Baseball { get; private set; }

        public virtual MemorabiliaBasketball Basketball { get; private set; }

        public virtual MemorabiliaBat Bat { get; private set; }

        public virtual MemorabiliaBook Book { get; private set; }

        public virtual MemorabiliaBrand Brand { get; private set; }

        public virtual MemorabiliaCard Card { get; private set; }

        public virtual MemorabiliaCommissioner Commissioner { get; private set; }

        public Constants.Condition Condition => Constants.Condition.Find(ConditionId ?? 0);

        public int? ConditionId { get; private set; }

        public DateTime CreateDate { get; private set; }

        public virtual MemorabiliaFigure Figure { get; private set; }

        public virtual MemorabiliaFootball Football { get; private set; }

        public decimal? EstimatedValue { get; private set; }

        public virtual MemorabiliaGame Game { get; private set; }

        public virtual MemorabiliaHelmet Helmet { get; private set; }

        public virtual List<MemorabiliaImage> Images { get; private set; } = new ();

        public Constants.ItemType ItemType => Constants.ItemType.Find(ItemTypeId);

        public int ItemTypeId { get; private set; }

        public virtual MemorabiliaJersey Jersey { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public virtual MemorabiliaLevelType LevelType { get; private set; }

        public virtual MemorabiliaMagazine Magazine { get; private set; }

        public virtual MemorabiliaAcquisition MemorabiliaAcquisition { get; private set; }

        public virtual MemorabiliaOrientation Orientation { get; private set; }

        public virtual List<MemorabiliaPerson> People { get; private set; } = new ();

        public virtual MemorabiliaPhoto Photo { get; private set; }

        public int PrivacyTypeId { get; private set; }

        public virtual MemorabiliaSize Size { get; private set; }

        public virtual List<MemorabiliaSport> Sports { get; private set; } = new ();

        public virtual List<MemorabiliaTeam> Teams { get; private set; } = new ();

        public virtual User User { get; set; }

        public int UserId { get; private set; }        

        public void Set(DateTime? acquiredDate,
                        int acquisitionTypeId,
                        int? conditionId,
                        decimal? cost,
                        decimal? estimatedValue,
                        int privacyTypeId,
                        int? purchaseTypeId)
        {
            ConditionId = conditionId;
            PrivacyTypeId = privacyTypeId;
            EstimatedValue = estimatedValue;
            LastModifiedDate = DateTime.UtcNow;

            MemorabiliaAcquisition.Set(acquisitionTypeId, acquiredDate, cost, purchaseTypeId);
        }

        public void SetBaseball(string anniversary,                                
                                int? baseballTypeId,  
                                int brandId, 
                                int commissionerId, 
                                DateTime? gameDate,
                                int? gameStyleTypeId,
                                int levelTypeId,
                                int? personId,
                                int sizeId, 
                                int sportId,
                                int? teamId,
                                int? year)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetSports(sportId);
            SetBaseballType(baseballTypeId, year, anniversary);
            SetCommissioner(commissionerId);
            SetGame(gameStyleTypeId, personId, gameDate);            

            if (!personId.HasValue)
                People = new List<MemorabiliaPerson>();
            else
                SetPeople(personId.Value);

            if (!teamId.HasValue)
                Teams = new List<MemorabiliaTeam>();
            else
                SetTeams(teamId.Value);
        }

        public void SetBasketball(int? basketballTypeId,
                                  int brandId,
                                  int commissionerId,
                                  DateTime? gameDate,
                                  int? gameStyleTypeId,
                                  int levelTypeId,
                                  int? personId,
                                  int sizeId,
                                  int sportId,
                                  int? teamId)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetSports(sportId);
            SetBasketballType(basketballTypeId.Value);
            SetCommissioner(commissionerId);
            SetGame(gameStyleTypeId, personId, gameDate);

            if (!personId.HasValue)
                People = new List<MemorabiliaPerson>();
            else
                SetPeople(personId.Value);

            if (!teamId.HasValue)
                Teams = new List<MemorabiliaTeam>();
            else
                SetTeams(teamId.Value);
        }

        public void SetBat(int? batTypeId,
                           int brandId,
                           int? colorId,
                           DateTime? gameDate,
                           int? gameStyleTypeId,
                           int? length,
                           int? personId,
                           int sizeId,
                           int sportId,
                           int? teamId)
        {
            SetBrand(brandId);
            SetSize(sizeId);
            SetSports(sportId);
            SetBatType(batTypeId, colorId, length);
            SetGame(gameStyleTypeId, personId, gameDate);

            if (!personId.HasValue)
                People = new List<MemorabiliaPerson>();
            else
                SetPeople(personId.Value);

            if (!teamId.HasValue)
                Teams = new List<MemorabiliaTeam>();
            else
                SetTeams(teamId.Value);
        }

        public void SetBook(string edition,
                            bool hardCover,
                            int[] personIds,
                            string publisher,
                            int[] sportIds,
                            int[] teamIds,
                            string title)
        {
            SetBook(edition, hardCover, publisher, title);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetCard(int brandId,
                            bool custom,
                            int? denominator,
                            int levelTypeId,
                            bool licensed,
                            int? numerator,
                            int[] personIds,
                            int sizeId,
                            int[] sportIds,
                            int[] teamIds,
                            int? year)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetCard(custom, denominator, licensed, numerator, year);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetFigure(int brandId,
                              int? figureSpecialtyTypeId,
                              int? figureTypeId,
                              int levelTypeId,
                              int[] personIds,
                              int sizeId,
                              int[] sportIds,
                              int[] teamIds,
                              int? year)
        {
            SetBrand(brandId);
            SetFigureType(figureSpecialtyTypeId, figureTypeId, year);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetFirstDayCover(int[] personIds,
                                     int sizeId,
                                     int[] sportIds,
                                     int[] teamIds)
        {
            SetSize(sizeId);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetFootball(int brandId,
                                int commissionerId,
                                int? footballTypeId,
                                DateTime? gameDate,
                                int? gameStyleTypeId,
                                int levelTypeId,
                                int? personId,
                                int sizeId,
                                int sportId,
                                int? teamId)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetSports(sportId);
            SetFootballType(footballTypeId.Value);
            SetCommissioner(commissionerId);
            SetGame(gameStyleTypeId, personId, gameDate);

            if (!personId.HasValue)
                People = new List<MemorabiliaPerson>();
            else
                SetPeople(personId.Value);

            if (!teamId.HasValue)
                Teams = new List<MemorabiliaTeam>();
            else
                SetTeams(teamId.Value);
        }

        public void SetGlove(int brandId,
                             DateTime? gameDate,
                             int? gamePersonId,
                             int? gameStyleTypeId,
                             int levelTypeId,
                             int[] personIds,
                             int sizeId,
                             int[] sportIds,
                             int[] teamIds)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetGame(gameStyleTypeId, gamePersonId, gameDate);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetHat(int brandId,
                           DateTime? gameDate,
                           int? gamePersonId,
                           int? gameStyleTypeId,
                           int levelTypeId,
                           int[] personIds,
                           int sizeId,
                           int[] sportIds,
                           int[] teamIds)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetGame(gameStyleTypeId, gamePersonId, gameDate);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetHelmet(int brandId,
                              DateTime? gameDate,
                              int? gameStyleTypeId,
                              int? helmetFinishId,
                              int? helmetQualityTypeId,
                              int? helmetTypeId,
                              int levelTypeId,
                              int? personId,
                              int sizeId,
                              int[] sportIds,
                              bool throwback,
                              params int[] teamIds)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetSports(sportIds);
            SetHelmet(helmetFinishId, helmetQualityTypeId, helmetTypeId, throwback);
            SetGame(gameStyleTypeId, personId, gameDate);
            SetTeams(teamIds);

            if (!personId.HasValue)
                People = new List<MemorabiliaPerson>();
            else
                SetPeople(personId.Value);                
        }

        public void SetHockeyStick(int brandId,
                                   DateTime? gameDate,
                                   int? gamePersonId,
                                   int? gameStyleTypeId,
                                   int levelTypeId,
                                   int? personId,
                                   int sizeId,
                                   int sportId,
                                   int? teamId)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetGame(gameStyleTypeId, gamePersonId, gameDate);
            SetSports(sportId);

            if (!personId.HasValue)
                People = new List<MemorabiliaPerson>();
            else
                SetPeople(personId.Value);

            if (!teamId.HasValue)
                Teams = new List<MemorabiliaTeam>();
            else
                SetTeams(teamId.Value);
        }

        public void SetImages(IEnumerable<string> filePaths, string primaryImageFilePath)
        {
            if (!filePaths.Any())
            {
                Images = new List<MemorabiliaImage>();
                return;
            }

            Images = filePaths.Select(filePath =>
                                        new MemorabiliaImage(Id,
                                                             filePath,
                                                             filePath == primaryImageFilePath
                                                                 ? Constants.ImageType.Primary.Id 
                                                                 : Constants.ImageType.Secondary.Id,
                                                             DateTime.UtcNow)).ToList();
        }

        public void SetJersey(int brandId, 
                              DateTime? gameDate,
                              int? gamePersonId,
                              int? gameStyleTypeId,
                              int levelTypeId,
                              int[] personIds,
                              int qualityTypeId,                              
                              int sizeId, 
                              int[] sportIds,
                              int styleTypeId,
                              int[] teamIds,
                              int typeId)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetJersey(qualityTypeId, styleTypeId, typeId);
            SetGame(gameStyleTypeId, gamePersonId, gameDate);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds); 
        }

        public void SetJerseyNumber(int[] sportIds, int[] teamIds)
        {
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetMagazine(int brandId,
                                DateTime? date,
                                bool framed,
                                int[] personIds,
                                int sizeId,
                                int[] sportIds,
                                int[] teamIds)
        {
            SetBrand(brandId);
            SetSize(sizeId);
            SetMagazine(date, framed);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);            
        }

        public void SetPhoto(int brandId,
                             bool framed,
                             int orientationId,
                             int[] personIds,
                             int photoTypeId,
                             int sizeId,
                             int[] sportIds,
                             int[] teamIds)
        {
            SetBrand(brandId);
            SetSize(sizeId);
            SetOrientation(orientationId);
            SetPhoto(photoTypeId, framed);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetPuck(int brandId,
                            DateTime? gameDate,
                            int? gamePersonId,
                            int? gameStyleTypeId,
                            int levelTypeId,
                            int[] personIds,
                            int sizeId,
                            int sportId,
                            int[] teamIds)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetGame(gameStyleTypeId, gamePersonId, gameDate);
            SetPeople(personIds);
            SetSports(sportId);
            SetTeams(teamIds);
        }

        public void SetPylon(DateTime? gameDate,
                             int? gameStyleTypeId,
                             int levelTypeId,
                             int sizeId,
                             int sportId,
                             int[] teamIds)
        {
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetGame(gameStyleTypeId: gameStyleTypeId, gameDate: gameDate);
            SetSports(sportId);
            SetTeams(teamIds);
        }

        public void SetShoe(int brandId,
                            DateTime? gameDate,
                            int? gamePersonId,
                            int? gameStyleTypeId,
                            int levelTypeId,
                            int[] personIds,
                            int sizeId,
                            int[] sportIds,
                            int[] teamIds)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetGame(gameStyleTypeId, gamePersonId, gameDate);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetSoccerball(int brandId,
                                  DateTime? gameDate,
                                  int? gamePersonId,
                                  int? gameStyleTypeId,
                                  int levelTypeId,
                                  int[] personIds,
                                  int sizeId,
                                  int[] sportIds,
                                  int[] teamIds)
        {
            SetBrand(brandId);
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetGame(gameStyleTypeId, gamePersonId, gameDate);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        public void SetTicket(DateTime? gameDate,
                              int? gamePersonId,
                              int? gameStyleTypeId,
                              int levelTypeId,
                              int[] personIds,
                              int sizeId,
                              int[] sportIds,
                              int[] teamIds)
        {
            SetLevelType(levelTypeId);
            SetSize(sizeId);
            SetGame(gameStyleTypeId, gamePersonId, gameDate);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);
        }

        private void SetBaseballType(int? baseballTypeId, int? year, string anniversary)
        {
            if (baseballTypeId.HasValue)
            {
                if (Brand.BrandId != Constants.Brand.Rawlings.Id)
                    return;

                if (Baseball == null)
                {
                    Baseball = new MemorabiliaBaseball(Id, baseballTypeId.Value, year, anniversary);
                    return;
                }

                Baseball.Set(baseballTypeId.Value, year, anniversary);
            }
            else
            {
                if (Baseball?.Id > 0)
                    Baseball = null;
            }            
        }

        private void SetBasketballType(int? basketballTypeId)
        {
            if (basketballTypeId.HasValue)
            {
                if (Basketball == null)
                {
                    Basketball = new MemorabiliaBasketball(Id, basketballTypeId.Value);
                    return;
                }

                Basketball.Set(basketballTypeId.Value);
            }
            else
            {
                if (Basketball?.Id > 0)
                    Basketball = null;
            }
        }

        private void SetBatType(int? batTypeId, int? colorId, int? length)
        {
            if (batTypeId.HasValue || colorId.HasValue || length.HasValue)
            {
                if (Bat == null)
                {
                    Bat = new MemorabiliaBat(Id, batTypeId, colorId, length);
                    return;
                }

                Bat.Set(batTypeId, colorId, length);
            }
            else
            {
                if (Bat?.Id > 0)
                    Bat = null;
            }
        }

        private void SetBook(string edition, bool hardCover, string publisher, string title)
        {
            if (Book == null)
            {
                Book = new MemorabiliaBook(Id, edition, hardCover, publisher, title);
                return;
            }

            Book.Set(edition, hardCover, publisher, title);  
        }

        private void SetBrand(int brandId)
        {
            if (Brand == null)
            {
                Brand = new MemorabiliaBrand(Id, brandId);
                return;
            }

            Brand.Set(brandId);
        }

        private void SetCard(bool custom, int? denominator, bool licensed, int? numerator, int? year)
        {
            if (Card == null)
            {
                Card = new MemorabiliaCard(Id, custom, denominator, licensed, numerator, year);
                return;
            }

            Card.Set(custom, denominator, licensed, numerator, year);
        }

        private void SetCommissioner(int commissionerId)
        {
            if (commissionerId > 0)
            {
                if (Commissioner == null)
                {
                    Commissioner = new MemorabiliaCommissioner(Id, commissionerId);
                    return;
                }

                Commissioner.Set(commissionerId);
            }
            else
            {
                if (Commissioner?.Id > 0)
                    Commissioner = null;
            }
        }

        private void SetFigureType(int? figureSpecialtyTypeId, int? figureTypeId, int? year)
        {
            if (figureSpecialtyTypeId.HasValue || figureTypeId.HasValue || year.HasValue)
            {
                if (Figure == null)
                {
                    Figure = new MemorabiliaFigure(Id, figureSpecialtyTypeId.Value, figureTypeId.Value, year.Value);
                    return;
                }

                Figure.Set(figureSpecialtyTypeId.Value, figureTypeId.Value, year.Value);
            }
            else
            {
                if (Figure?.Id > 0)
                    Figure = null;
            }
        }

        private void SetFootballType(int? footballTypeId)
        {
            if (footballTypeId.HasValue)
            {
                if (Football == null)
                {
                    Football = new MemorabiliaFootball(Id, footballTypeId.Value);
                    return;
                }

                Football.Set(footballTypeId.Value);
            }
            else
            {
                if (Football?.Id > 0)
                    Football = null;
            }
        }

        private void SetGame(int? gameStyleTypeId = null, int? personId = null, DateTime? gameDate = null)
        {
            if (gameStyleTypeId.HasValue)
            {
                if (ItemType.Id == Constants.ItemType.Jersey.Id && Jersey.JerseyQualityTypeId != Constants.JerseyQualityType.Authentic.Id)
                    return;

                if (Game == null)
                {
                    Game = new MemorabiliaGame(Id, gameStyleTypeId.Value, personId, gameDate);
                    return;
                }

                Game.Set(gameStyleTypeId.Value, personId, gameDate);
            }
            else
            {
                if (Game?.Id > 0)
                    Game = null;
            }
        }

        private void SetHelmet(int? helmetFinishId, int? helmetQualityTypeId, int? helmetTypeId, bool throwback)
        {
            if (Helmet == null)
            {
                Helmet = new MemorabiliaHelmet(Id, helmetFinishId, helmetQualityTypeId, helmetTypeId, throwback);
                return;
            }

            Helmet.Set(helmetFinishId, helmetQualityTypeId, helmetTypeId, throwback);
        }

        private void SetJersey(int qualityTypeId, int styleTypeId, int typeId)
        {
            if (Jersey == null)
            {
                Jersey = new MemorabiliaJersey(Id, qualityTypeId, styleTypeId, typeId);
                return;
            }

            Jersey.Set(qualityTypeId, styleTypeId, typeId);
        }

        private void SetLevelType(int levelTypeId)
        {
            if (LevelType == null)
            {
                LevelType = new MemorabiliaLevelType(Id, levelTypeId);
                return;
            }

            LevelType.Set(levelTypeId);
        }

        private void SetMagazine(DateTime? date, bool framed)
        {
            if (Magazine == null)
            {
                Magazine = new MemorabiliaMagazine(Id, date, framed);
                return;
            }

            Magazine.Set(date, framed);
        }

        private void SetOrientation(int orientationId)
        {
            if (Orientation == null)
            {
                Orientation = new MemorabiliaOrientation(Id, orientationId);
                return;
            }

            Orientation.Set(orientationId);
        }

        private void SetPeople(params int[] personIds)
        {
            if (personIds == null || !personIds.Any())
                People = new List<MemorabiliaPerson>();

            People.RemoveAll(team => !personIds.Contains(team.PersonId));
            People.AddRange(personIds.Where(personId => !People.Select(person => person.PersonId).Contains(personId)).Select(personId => new MemorabiliaPerson(Id, personId)));
        }

        private void SetPhoto(int photoTypeId, bool framed)
        {
            if (Photo == null)
            {
                Photo = new MemorabiliaPhoto(Id, photoTypeId, framed);
                return;
            }

            Photo.Set(photoTypeId, framed);
        }

        private void SetSize(int sizeId)
        {
            if (Size == null)
            {
                Size = new MemorabiliaSize(Id, sizeId);
                return;
            }

            Size.Set(sizeId);
        }

        private void SetSports(params int[] sportIds)
        {
            if (sportIds == null || !sportIds.Any())
                Sports = new List<MemorabiliaSport>();

            Sports.RemoveAll(sportId => !sportIds.Contains(sportId.SportId));
            Sports.AddRange(sportIds.Where(sportId => !Sports.Select(sport => sport.SportId).Contains(sportId)).Select(sportId => new MemorabiliaSport(Id, sportId)));
        }

        private void SetTeams(params int[] teamIds)
        {
            if (teamIds == null || !teamIds.Any())
                Teams = new List<MemorabiliaTeam>();

            Teams.RemoveAll(team => !teamIds.Contains(team.TeamId));
            Teams.AddRange(teamIds.Where(teamId => !Teams.Select(team => team.TeamId).Contains(teamId)).Select(teamId => new MemorabiliaTeam(Id, teamId)));
        }
    }
}
