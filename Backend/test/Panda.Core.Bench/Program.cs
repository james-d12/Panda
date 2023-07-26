using BenchmarkDotNet.Running;
using Panda.Core.Domain.Bench;

var summary = BenchmarkRunner.Run<TableBench>();