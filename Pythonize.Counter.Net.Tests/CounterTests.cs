namespace Pythonize.Counter.Net.Tests;

internal sealed class CounterTests
{
    [Test]
    public void Counter_ConstructWithIEnumerable_CountsCorrectly()
    {
        // Arrange
        var values = new List<char> { 'a', 'b', 'a', 'c', 'a' };
        var counter = new Counter<char>(values);

        // Act
        var counts = counter.Get();

        // Assert
        Assert.AreEqual(3, counts['a']);
        Assert.AreEqual(1, counts['b']);
        Assert.AreEqual(1, counts['c']);
    }

    [Test]
    public void Counter_Get_EmptyCounter_ReturnsEmptyDictionary()
    {
        // Arrange
        var counter = new Counter<int>(new List<int>());

        // Act
        var counts = counter.Get();

        // Assert
        Assert.IsNotNull(counts);
        Assert.IsEmpty(counts);
    }

    [Test]
    public void Counter_Get_NullValue_ThrowsArgumentNullException()
    {
        // Arrange
        List<char> values = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Counter<char>(values));
    }
    
    [Test]
    public void Counter_ConstructWithString_CountsCorrectly()
    {
        // Arrange
        var value = "abacaba";
        var counter = new Counter<char>(value);

        // Act
        var counts = counter.Get();

        // Assert
        Assert.AreEqual(4, counts['a']);
        Assert.AreEqual(2, counts['b']);
        Assert.AreEqual(1, counts['c']);
    }
    
    [Test]
    public void Counter_ConstructWithIEnumerableString_CountsCorrectly()
    {
        // Arrange
        IEnumerable<string> values = new List<string> { "apple", "banana", "apple", "cherry", "apple" };
        var counter = new Counter<string>(values);

        // Act
        var counts = counter.Get();

        // Assert
        Assert.AreEqual(3, counts["apple"]);
        Assert.AreEqual(1, counts["banana"]);
        Assert.AreEqual(1, counts["cherry"]);
    }
    
    [Test]
    public void Counter_ConstructWithQueue_CountsCorrectly()
    {
        // Arrange
        var values = new Queue<int>();
        values.Enqueue(1);
        values.Enqueue(2);
        values.Enqueue(1);
        values.Enqueue(3);
        values.Enqueue(1);
        var counter = new Counter<int>(values);

        // Act
        var counts = counter.Get();

        // Assert
        Assert.AreEqual(3, counts[1]);
        Assert.AreEqual(1, counts[2]);
        Assert.AreEqual(1, counts[3]);
    }
    
    [Test]
    public void Counter_ConstructWithStack_CountsCorrectly()
    {
        // Arrange
        var values = new Stack<string>();
        values.Push("apple");
        values.Push("banana");
        values.Push("apple");
        values.Push("cherry");
        values.Push("apple");
        var counter = new Counter<string>(values);

        // Act
        var counts = counter.Get();

        // Assert
        Assert.AreEqual(3, counts["apple"]);
        Assert.AreEqual(1, counts["banana"]);
        Assert.AreEqual(1, counts["cherry"]);
    }
    
    [Test]
    public void Counter_ConstructWithSpan_CountsCorrectly()
    {
        // Arrange
        const string value = "abacaba";
        Span<char> span = value.ToCharArray();
        var counter = new Counter<char>(span);

        // Act
        var counts = counter.Get();

        // Assert
        Assert.AreEqual(4, counts['a']);
        Assert.AreEqual(2, counts['b']);
        Assert.AreEqual(1, counts['c']);
    }

}