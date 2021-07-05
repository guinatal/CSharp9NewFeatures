using BenchmarkDotNet.Attributes;
using System;
using System.Runtime.CompilerServices;

namespace CSharpNewFeaturesConsoleApp.Benchmarks
{
    public class SkipLocalsInitBenchmark
    {
        [Params(512, 1024)]
        public int Size { get; set; }

        [Benchmark]
        public byte InitLocals()
        {
            Span<byte> s = stackalloc byte[Size];
            return s[0];
        }

        [Benchmark]
        [SkipLocalsInit]
        public byte SkipInitLocals()
        {
            Span<byte> s = stackalloc byte[Size];
            return s[0];
        }
    }
}
