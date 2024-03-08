// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Snakeskin.BenchmarkTests;

Console.WriteLine("Starting benchmark");
var summary = BenchmarkRunner.Run<SnakeskinTest>();
Console.WriteLine("Benchmark finished");
