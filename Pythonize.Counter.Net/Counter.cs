using System.Runtime.InteropServices;

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
        
        foreach (var item in value)
        {
            CollectionsMarshal.GetValueRefOrAddDefault(_counts, item, out _)++;
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
        
        foreach (var item in value)
        {
            CollectionsMarshal.GetValueRefOrAddDefault(_counts, item, out _)++;
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
    /// Removes an item from Counter
    /// </summary>
    /// <param name="item">Item to remove</param>
    /// <returns>true or false if item was removed</returns>
    public bool Remove(T item)
    {
        return _counts.Remove(item);
    }

    /// <summary>
    /// Method subtracts two counters
    /// </summary>
    /// <param name="counter">Counter class from which we want to subtract</param>
    /// <exception cref="ArgumentException">Thrown when ne of counter types does not match.</exception>
    public void Subtract(Counter<T> counter)
    {
        if (_counts.GetType() != counter.Get().GetType())
        {
            throw new ArgumentException("One of types does not match.");
        }

        foreach (var (value, count) in counter.Get())
        {
            _counts[value] -= count;
            
            if (_counts[value] == 0)
            {
                _counts.Remove(value);
            }
        }
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

    /// <summary>
    /// Returns the specified number of most common elements along with their counts from the dictionary.
    /// </summary>
    /// <param name="count">The number >1 of most common elements to return.</param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> containing the specified number of most common elements along with their counts.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is less than 1.</exception>
    public IEnumerable<KeyValuePair<T, int>> MostCommon(int count)
    {
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "value must be greater than 0");
        }
        
        return _counts.OrderByDescending(pair => pair.Value)
            .Take(count);
    }

    /// <summary>
    /// Calculate the sum of the counts.
    /// </summary>
    /// <returns>Sum of the counts.</returns>
    public int Total()
    {
        return _counts.Values.Sum();
    }
}