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
                           string imagePath, 
                           decimal? cost,
                           decimal? estimatedValue, 
                           int userId)
        {
            ItemTypeId = itemTypeId;
            ConditionId = conditionId;
            ImagePath = imagePath;
            Cost = cost;
            EstimatedValue = estimatedValue;
            UserId = userId;
            CreateDate = DateTime.UtcNow;
        }

        public MemorabiliaBaseballType BaseballType { get; set; }

        public MemorabiliaBrand Brand { get; set; }

        public MemorabiliaCommissioner Commissioner { get; set; }

        public Constants.Condition Condition => Constants.Condition.Find(ConditionId ?? 0);

        public int? ConditionId { get; private set; }

        public decimal? Cost { get; private set; }

        public DateTime CreateDate { get; private set; }

        public decimal? EstimatedValue { get; private set; }

        public string ImagePath { get; private set; }

        public Constants.ItemType ItemType => Constants.ItemType.Find(ItemTypeId);

        public int ItemTypeId { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }      
        
        public List<MemorabiliaPerson> People { get; private set; } = new List<MemorabiliaPerson>();

        public MemorabiliaSize Size { get; set; }

        public List<MemorabiliaSport> Sports { get; private set; } = new List<MemorabiliaSport>();

        public List<MemorabiliaTeam> Teams { get; private set; } = new List<MemorabiliaTeam>();

        public int UserId { get; private set; }

        public void Set(int? conditionId, 
                        string imagePath,
                        decimal? cost,
                        decimal? estimatedValue)
        {
            ConditionId = conditionId;
            ImagePath = imagePath;
            Cost = cost;
            EstimatedValue = estimatedValue;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void SetBaseballType(int memorabiliaBaseballTypeId, int baseballTypeId)
        {
            if (memorabiliaBaseballTypeId == 0)
            {
                BaseballType = new MemorabiliaBaseballType(Id, baseballTypeId);
                return;
            }

            BaseballType.Set(baseballTypeId);
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

        public void SetPeople(IEnumerable<int> personIds)
        {
            People.RemoveAll(team => !personIds.Contains(team.PersonId));
            People.AddRange(personIds.Where(personId => !People.Select(sport => sport.PersonId).Contains(personId)).Select(personId => new MemorabiliaPerson(Id, personId)));
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

        public void SetSports(IEnumerable<int> sportIds)
        {
            Sports.RemoveAll(team => !sportIds.Contains(team.SportId));
            Sports.AddRange(sportIds.Where(sportId => !Sports.Select(sport => sport.SportId).Contains(sportId)).Select(sportId => new MemorabiliaSport(Id, sportId)));
        }

        public void SetTeams(IEnumerable<int> teamIds)
        {
            Teams.RemoveAll(team => !teamIds.Contains(team.TeamId));
            Teams.AddRange(teamIds.Where(teamId => !Teams.Select(team => team.TeamId).Contains(teamId)).Select(teamId => new MemorabiliaTeam(Id, teamId)));
        }
    }
}
