﻿namespace Memorabilia.Domain.Entities
{
    public class Personalization : Framework.Domain.Entity.DomainEntity
    {
        public Personalization() { }

        public Personalization(int autographId, string greeting, string text)
        {
            AutographId = autographId;
            Greeting = greeting;
            Text = text;
        }

        public int AutographId { get; private set; }

        public string Greeting  { get; private set; }

        public string Text { get; private set; }

        public void Set(string greeting, string text)
        {
            Greeting = greeting;
            Text = text;
        }
    }
}
