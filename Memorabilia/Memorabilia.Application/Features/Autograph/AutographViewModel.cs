using System;

namespace Memorabilia.Application.Features.Autograph
{
    public class AutographViewModel
    {
        private readonly Domain.Entities.Autograph _autograph;

        public AutographViewModel() { }

        public AutographViewModel(Domain.Entities.Autograph autograph)
        {
            _autograph = autograph;
        }

        public int? ColorId => _autograph.ColorId;

        public string ColorName => _autograph.Color?.Name;

        public int? ConditionId => _autograph.ConditionId;

        public string ConditionName => _autograph.Condition?.Name;

        public DateTime CreateDate => _autograph.CreateDate;

        public int Id => _autograph.Id;

        public string ItemTypeName => _autograph.Memorabilia?.ItemType?.Name;

        public DateTime? LastModifiedDate => _autograph.LastModifiedDate;

        public int MemorabiliaId => _autograph.MemorabiliaId;        

        public int PersonId => _autograph.PersonId;

        public string PersonName => _autograph.Person?.FullName;

        public int? SpotId => _autograph.SpotId;

        public string SpotName => _autograph.Spot?.Name;

        public int? WritingInstrumentId => _autograph.WritingInstrumentId;

        public string WritingInstrumentName => _autograph.WritingInstrument?.Name;

        public int UserId => _autograph.UserId;
    }
}
