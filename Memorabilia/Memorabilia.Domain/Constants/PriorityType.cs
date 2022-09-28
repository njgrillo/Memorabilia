﻿namespace Memorabilia.Domain.Constants
{
    public sealed class PriorityType
    {
        public static readonly PriorityType MustHave = new(1, "Must Have", string.Empty);
        public static readonly PriorityType NiceToHave = new(2, "Nice to Have", string.Empty);
        public static readonly PriorityType NoWay = new(4, "No Way", string.Empty);
        public static readonly PriorityType TakeItOrLeaveIt = new(3, "Take it or Leave it", string.Empty);

        public static readonly PriorityType[] All =
        {
            MustHave,
            NiceToHave,
            NoWay,
            TakeItOrLeaveIt
        };

        private PriorityType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static PriorityType Find(int id)
        {
            return All.SingleOrDefault(priorityType => priorityType.Id == id);
        }
    }
}
