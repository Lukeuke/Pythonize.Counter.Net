namespace Pythonize.Counter.Net;

/// <summary>
/// Represents a python-like counter that counts occurrences of items of type T.
/// </summary>
/// <typeparam name="T">The type of items to count.</typeparam>
public class Counter<T> where T : notnull
{
    private readonly Dictionary<T, int> _counts = new();
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Counter{T}"/> class with the specified enumerable of items.
    /// </summary>
    /// <param name="value">The enumerable of items to count.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    public Counter(IEnumerable<T> value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value), "value must not be null.");
        }
        
        foreach (var t in value)
        {
            if (_counts.TryGetValue(t, out var count))
            {
                _counts[t] = count + 1;
            }
            else
            {
                _counts[t] = 1;
            }
        }
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Counter{T}"/> class with the specified span of items.
    /// </summary>
    /// <param name="value">The span of items to count.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    public Counter(Span<T> value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value), "value must not be null.");
        }
        
        foreach (var t in value)
        {
            if (_counts.TryGetValue(t, out var count))
            {
                _counts[t] = count + 1;
            }
            else
            {
                _counts[t] = 1;
            }
        }
    }
    
    /// <summary>
    /// Gets the counts of items.
    /// </summary>
    /// <returns>A dictionary containing items as keys and their counts as values.</returns>
    public Dictionary<T, int> Get()
    {
        return _counts;
    }

    /// <summary>
    /// Returns an enumerable of elements based on the counts of items.
    /// </summary>
    /// <returns>An enumerable containing elements based on the counts of items.</returns>
    public IEnumerable<T> Elements()
    {
        foreach (var (key, value) in _counts)
        {
            for (var i = 0; i < value; i++)
            {
                yield return key;
            }
        }
    }
}