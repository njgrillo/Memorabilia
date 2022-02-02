using System;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Domain.Entities
{
    public class Memorabilia : Framework.Domain.Entity.DomainEntity
    {
        public Memorabilia() { }

        public Memorabilia(int itemTypeId,
                           int? conditionId,
                           int acquisitionTypeId,
                           DateTime? acquiredDate,
                           decimal? cost,
                           int? purchaseTypeId,
                           int privacyTypeId,
                           decimal? estimatedValue, 
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

        public MemorabiliaBaseballType BaseballType { get; set; }

        public MemorabiliaBrand Brand { get; set; }

        public MemorabiliaCommissioner Commissioner { get; set; }

        public Constants.Condition Condition => Constants.Condition.Find(ConditionId ?? 0);

        public int? ConditionId { get; private set; }

        public DateTime CreateDate { get; private set; }

        public decimal? EstimatedValue { get; private set; }

        public List<MemorabiliaImage> Images { get; private set; } = new List<MemorabiliaImage>();

        public Constants.ItemType ItemType => Constants.ItemType.Find(ItemTypeId);

        public int ItemTypeId { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public MemorabiliaAcquisition MemorabiliaAcquisition { get; set; }

        public List<MemorabiliaPerson> People { get; private set; } = new List<MemorabiliaPerson>();

        public int PrivacyTypeId { get; set; }

        public MemorabiliaSize Size { get; set; }

        public List<MemorabiliaSport> Sports { get; private set; } = new List<MemorabiliaSport>();

        public List<MemorabiliaTeam> Teams { get; private set; } = new List<MemorabiliaTeam>();

        public int UserId { get; private set; }

        public void AddImages(IEnumerable<string> filePaths)
        {
            if (!filePaths.Any())
                return;

            Images.Add(filePaths.Select(filePath => 
                                        new MemorabiliaImage(Id, 
                                                             filePath, 
                                                             Constants.ImageType.Primary.Id, 
                                                             DateTime.UtcNow))
                                .First());

            foreach (var filePath in filePaths.Skip(1))
            {
                Images.Add(new MemorabiliaImage(Id, filePath, Constants.ImageType.Secondary.Id, DateTime.UtcNow));
            }
        }

        public void RemovePeople()
        {
            People = new List<MemorabiliaPerson> { };
        }

        public void RemoveTeams()
        {
            Teams = new List<MemorabiliaTeam> { };
        }

        public void Set(int? conditionId,
                        int acquisitionTypeId,
                        DateTime? acquiredDate,
                        decimal? cost,
                        int? purchaseTypeId,
                        int privacyTypeId,
                        decimal? estimatedValue)
        {
            ConditionId = conditionId;
            PrivacyTypeId = privacyTypeId;
            EstimatedValue = estimatedValue;
            LastModifiedDate = DateTime.UtcNow;

            MemorabiliaAcquisition.Set(acquisitionTypeId, acquiredDate, cost, purchaseTypeId);
        }

        public void SetBaseballType(int memorabiliaBaseballTypeId, int baseballTypeId, int? year, string anniversary)
        {
            if (Brand.BrandId != Constants.Brand.Rawlings.Id)
                return;

            if (memorabiliaBaseballTypeId == 0)
            {
                BaseballType = new MemorabiliaBaseballType(Id, baseballTypeId, year, anniversary);
                return;
            }

            BaseballType.Set(baseballTypeId, year, anniversary);
        }

        public void SetBrand(int memorabiliaBrandId, int brandId)
        {
            if (memorabiliaBrandId == 0)
            {
                Brand = new MemorabiliaBrand(Id, brandId);
                return;
            }

            Brand.Set(brandId);
        }

        public void SetCommissioner(int memorabiliaCommissionerId, int commissionerId)
        {
            if (memorabiliaCommissionerId == 0)
            {
                Commissioner = new MemorabiliaCommissioner(Id, commissionerId);
                return;
            }

            Commissioner.Set(commissionerId);
        }        

        public void SetPeople(params int[] personIds)
        {
            People.RemoveAll(team => !personIds.Contains(team.PersonId));
            People.AddRange(personIds.Where(personId => !People.Select(person => person.PersonId).Contains(personId)).Select(personId => new MemorabiliaPerson(Id, personId)));
        }

        public void SetSize(int memorabiliaSizeId, int sizeId)
        {
            if (memorabiliaSizeId == 0)
            {
                Size = new MemorabiliaSize(Id, sizeId);
                return;
            }

            Size.Set(sizeId);
        }

        public void SetSports(params int[] sportIds)
        {
            Sports.RemoveAll(sportId => !sportIds.Contains(sportId.SportId));
            Sports.AddRange(sportIds.Where(sportId => !Sports.Select(sport => sport.SportId).Contains(sportId)).Select(sportId => new MemorabiliaSport(Id, sportId)));
        }

        public void SetTeams(params int[] teamIds)
        {
            Teams.RemoveAll(team => !teamIds.Contains(team.TeamId));
            Teams.AddRange(teamIds.Where(teamId => !Teams.Select(team => team.TeamId).Contains(teamId)).Select(teamId => new MemorabiliaTeam(Id, teamId)));
        }
    }
}
