namespace Memorabilia.Application.Hangfire.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class HangfireJobAttribute : Attribute
{
	public HangfireJobAttribute() { }
}
