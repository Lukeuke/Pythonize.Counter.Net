namespace Pythonize.Counter.Net.Tests;

public class CounterTestsMostCommon
{
    [Test]
    public void Constructor_CountsOccurrences_WhenValueIsEnumerable()
    {
        // Arrange
        IEnumerable<string> values = new List<string> { "apple", "banana", "apple", "orange", "apple" };

        // Act
        var counter = new Counter<string>(values);

        // Assert
        Assert.AreEqual(3, counter.MostCommon(1).First().Value);
        Assert.AreEqual(1, counter.MostCommon(2).Last().Value);
    }

    [Test]
    public void Constructor_CountsOccurrences_WhenValueIsSpan()
    {
        // Arrange
        Span<int> values = stackalloc int[] { 1, 2, 1, 3, 1 };

        // Act
        var counter = new Counter<int>(values);

        // Assert
        Assert.AreEqual(3, counter.MostCommon(1).First().Value);
        Assert.AreEqual(1, counter.MostCommon(3).Last().Value);
    }

    [Test]
    public void MostCommon_ReturnsMostCommonElements()
    {
        // Arrange
        var items = new List<string> { "a", "b", "c", "a", "b", "a" };
        var counter = new Counter<string>(items);

        // Act
        var mostCommon = counter.MostCommon(2).ToList();

        // Assert
        Assert.AreEqual(2, mostCommon.Count);
        Assert.AreEqual("a", mostCommon[0].Key);
        Assert.AreEqual(3, mostCommon[0].Value);
        Assert.AreEqual("b", mostCommon[1].Key);
        Assert.AreEqual(2, mostCommon[1].Value);
    }

    [Test]
    public void MostCommon_ThrowsException_WhenCountIsLessThanOne()
    {
        // Arrange
        var items = new List<string> { "a", "b", "c", "a", "b", "a" };
        var counter = new Counter<string>(items);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => counter.MostCommon(0));
    }
}