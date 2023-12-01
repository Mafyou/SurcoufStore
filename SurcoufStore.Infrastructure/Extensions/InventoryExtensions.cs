namespace SurcoufStore.Infrastructure.Extensions;

public static class InventoryExtensions
{
    public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> source,  Func<T, IEnumerable<T>> selector)
    {
        foreach (var parent in source)
        {
            var children = selector(parent);
            foreach (var child in children)
                yield return child;
            yield return parent;
        }
    }
}