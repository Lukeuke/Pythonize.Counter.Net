namespace Pythonize.Counter.Net.Tests;

internal sealed class CounterTestsSubtract
{
    [Test]
    public void Test()
    {
        // Arrange
        var values = new List<char> { 'a', 'b', 'a', 'c', 'a' };
        
        var counter1 = new Counter<char>(values);
        var counter2 = new Counter<char>(values);
        
        // Act
        counter1.Subtract(counter2);

        // Assert
        Assert.That(counter1.Get(), Is.Empty);
    }
}