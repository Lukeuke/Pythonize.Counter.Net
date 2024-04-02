namespace Pythonize.Counter.Net.Tests;

public class CounterTestsTotal
{
    [Test]
    public void CalculateTotal_WhenValueIsEnumerable()
    {
        // Arrange
        IEnumerable<string> values = new List<string> { "apple", "banana", "apple", "orange", "apple" };

        // Act
        var counter = new Counter<string>(values);

        // Assert
        Assert.AreEqual(5, counter.Total());
    }
    
    [Test]
    public void CalculateTotal_WhenValueIsEmpty()
    {
        // Arrange
        IEnumerable<string> values = new List<string> {  };

        // Act
        var counter = new Counter<string>(values);

        // Assert
        Assert.AreEqual(0, counter.Total());
    }
}