using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace Pythonize.Counter.Net.Benchmark;

public class CounterBenchmark
{
    private List<string> _list1000 = new();
    private List<string> _list100000 = new();
    private List<string> _list1000000 = new();
    
    [GlobalSetup]
    public void Setup()
    {
        for (var i = 1; i <= 100000; i++)
        {
            var s = RandomString(7);
            
            if (i < 1001)
            {
                _list1000.Add(s);
            }
            
            _list100000.Add(s);
        }
    }
    
    [Benchmark]
    public void CounterWithoutMarshall_Benchmark_1_000()
    { 
        Dictionary<string, int> counts = new();

        foreach (var t in _list1000)
        {
            if (counts.TryGetValue(t, out var count))
            {
                counts[t] = count + 1;
            }
            else
            {
                counts[t] = 1;
            }
        }
    }
    
    [Benchmark]
    public void CounterWithMarshall_Benchmark_1_000()
    {
        Dictionary<string, int> dictionary = new();
        foreach (var item in _list1000)
        {
            CollectionsMarshal.GetValueRefOrAddDefault(dictionary, item, out _)++;
        }
    }
    
    [Benchmark]
    public void CounterWithoutMarshall_Benchmark_100_000()
    { 
        Dictionary<string, int> counts = new();

        foreach (var t in _list100000)
        {
            if (counts.TryGetValue(t, out var count))
            {
                counts[t] = count + 1;
            }
            else
            {
                counts[t] = 1;
            }
        }
    }
    
    [Benchmark]
    public void CounterWithMarshall_Benchmark_100_000()
    {
        Dictionary<string, int> dictionary = new();
        foreach (var item in _list100000)
        {
            CollectionsMarshal.GetValueRefOrAddDefault(dictionary, item, out _)++;
        }
    }

    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
    }
}