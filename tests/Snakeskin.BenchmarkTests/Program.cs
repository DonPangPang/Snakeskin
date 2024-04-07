// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Snakeskin.BenchmarkTests;

Console.WriteLine("Starting benchmark");
//var summary = BenchmarkRunner.Run<SnakeskinTest>();

var summary = BenchmarkRunner.Run<RandomGeneratorTest>();

Console.WriteLine("Benchmark finished");