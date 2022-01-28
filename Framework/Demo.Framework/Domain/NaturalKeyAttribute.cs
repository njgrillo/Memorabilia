using System;

namespace Demo.Framework.Domain
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NaturalKeyAttribute : Attribute
    {
    }
}
