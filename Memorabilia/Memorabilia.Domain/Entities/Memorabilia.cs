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

        public Acquisition Acquisition => MemorabiliaAcquisition.Acquisition;

        public List<Autograph> Autographs { get; private set; } = new ();

        public MemorabiliaBaseball Baseball { get; private set; }

        public MemorabiliaBasketball Basketball { get; private set; }

        public MemorabiliaBat Bat { get; private set; }

        public MemorabiliaBrand Brand { get; private set; }

        public MemorabiliaCard Card { get; private set; }

        public MemorabiliaCommissioner Commissioner { get; private set; }

        public Constants.Condition Condition => Constants.Condition.Find(ConditionId ?? 0);

        public int? ConditionId { get; private set; }

        public DateTime CreateDate { get; private set; }

        public MemorabiliaFootball Football { get; private set; }

        public decimal? EstimatedValue { get; private set; }

        public MemorabiliaGame Game { get; private set; }

        public List<MemorabiliaImage> Images { get; private set; } = new ();

        public Constants.ItemType ItemType => Constants.ItemType.Find(ItemTypeId);

        public int ItemTypeId { get; private set; }

        public MemorabiliaJersey Jersey { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public MemorabiliaLevelType LevelType { get; private set; }

        public MemorabiliaMagazine Magazine { get; private set; }

        public MemorabiliaAcquisition MemorabiliaAcquisition { get; private set; }

        public MemorabiliaOrientation Orientation { get; private set; }

        public List<MemorabiliaPerson> People { get; private set; } = new ();

        public MemorabiliaPhoto Photo { get; private set; }

        public int PrivacyTypeId { get; private set; }

        public MemorabiliaSize Size { get; private set; }

        public List<MemorabiliaSport> Sports { get; private set; } = new ();

        public List<MemorabiliaTeam> Teams { get; private set; } = new ();

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
                                int? authenticTypeId,
                                int? baseballTypeId,  
                                int brandId, 
                                int commissionerId, 
                                DateTime? gameDate,
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
            SetBaseballType(baseballTypeId.Value, year, anniversary);
            SetCommissioner(commissionerId);
            SetGame(authenticTypeId, personId, gameDate);            

            if (!personId.HasValue)
                People = new List<MemorabiliaPerson>();
            else
                SetPeople(personId.Value);

            if (!teamId.HasValue)
                Teams = new List<MemorabiliaTeam>();
            else
                SetTeams(teamId.Value);
        }

        public void SetBasketball(int basketballTypeId)
        {
            if (Basketball == null)
            {
                Basketball = new MemorabiliaBasketball(Id, basketballTypeId);
                return;
            }

            Basketball.Set(basketballTypeId);
        }

        public void SetBat(int batTypeId, int? length)
        {
            if (Bat == null)
            {
                Bat = new MemorabiliaBat(Id, batTypeId, length);
                return;
            }

            Bat.Set(batTypeId, length);
        }

        public void SetCard(int? denominator, int? numerator, int? year)
        {
            if (Card == null)
            {
                Card = new MemorabiliaCard(Id, year, numerator, denominator);
                return;
            }

            Card.Set(year, numerator, denominator);
        }

        public void SetFootball(int footballTypeId)
        {
            if (Football == null)
            {
                Football = new MemorabiliaFootball(Id, footballTypeId);
                return;
            }

            Football.Set(footballTypeId);
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

        public void SetJersey(int? authenticTypeId,
                              int brandId, 
                              DateTime? gameDate,
                              int? gamePersonId,
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
            SetGame(authenticTypeId, gamePersonId, gameDate);
            SetPeople(personIds);
            SetSports(sportIds);
            SetTeams(teamIds);

            if (Jersey.Id == 0)
                Jersey = new MemorabiliaJersey(Id, qualityTypeId, styleTypeId, typeId);
            else
                Jersey.Set(qualityTypeId, styleTypeId, typeId);
        }

        public void SetMagazine(DateTime? date, bool framed)
        {
            if (Magazine == null)
            {
                Magazine = new MemorabiliaMagazine(Id, date, framed);
                return;
            }

            Magazine.Set(date, framed);
        }

        public void SetPhoto(int photoTypeId, bool framed)
        {
            if (Photo == null)
            {
                Photo = new MemorabiliaPhoto(Id, photoTypeId, framed);
                return;
            }

            Photo.Set(photoTypeId, framed);
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

        private void SetBrand(int brandId)
        {
            if (Brand == null)
            {
                Brand = new MemorabiliaBrand(Id, brandId);
                return;
            }

            Brand.Set(brandId);
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

        private void SetGame(int? authenticTypeId, int? personId, DateTime? gameDate)
        {
            if (authenticTypeId.HasValue)
            {
                if (ItemType.Id == Constants.ItemType.Jersey.Id && Jersey.JerseyQualityTypeId != Constants.JerseyQualityType.Authentic.Id)
                    return;

                if (Game == null)
                {
                    Game = new MemorabiliaGame(Id, authenticTypeId.Value, personId, gameDate);
                    return;
                }

                Game.Set(authenticTypeId.Value, personId, gameDate);
            }
            else
            {
                if (Game?.Id > 0)
                    Game = null;
            }
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
