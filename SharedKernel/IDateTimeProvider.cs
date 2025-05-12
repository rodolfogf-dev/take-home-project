namespace THA.Common;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
