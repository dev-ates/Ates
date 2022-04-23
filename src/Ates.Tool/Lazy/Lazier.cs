namespace Ates.Tool.Lazy;

using Microsoft.Extensions.DependencyInjection;

public class Lazier<T> : Lazy<T> where T : class
{
    public Lazier(IServiceProvider provider) : base(() => provider.GetRequiredService<T>())
    {
    }
}
