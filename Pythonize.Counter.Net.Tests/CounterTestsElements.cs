namespace Pythonize.Counter.Net.Tests;

internal sealed class CounterTestsElements
{
    [Test]
    public void Elements_ReturnsCorrectElements()
    {
        // Arrange
        var items = new List<string> { "a", "b", "c", "a", "b", "a" };
        var counter = new Counter<string>(items);

        // Act
        var elements = counter.Elements();

        // Assert
        Assert.AreEqual(6, elements.Count());
        Assert.AreEqual(3, elements.Count(e => e == "a"));
        Assert.AreEqual(2, elements.Count(e => e == "b"));
        Assert.AreEqual(1, elements.Count(e => e == "c"));
    }
    
    [Test]
    public void Elements_ReturnsEmptyIEnumerable_WhenCounterIsEmpty()
    {
        // Arrange
        var counter = new Counter<string>(new List<string>());

        // Act
        var elements = counter.Elements();

        // Assert
        Assert.IsEmpty(elements);
    }
}