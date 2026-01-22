using BenchmarkDotNet.Running;
using DotNet10.ImprovedZipArchive;
using static System.Net.Mime.MediaTypeNames;

// .NET 10 improves the performance and memory usage of ZipArchive.
// First, the way entries are written to a ZipArchive when in Update mode has been optimized.
// Previously, all ZipArchiveEntry instances were loaded into memory and rewritten,
// which could lead to high memory usage and performance bottlenecks.
// The optimization reduces memory usage and improves performance by avoiding the need to load all entries into memory.
// Second, the extraction of ZipArchive entries is now parallelized,
// and internal data structures are optimized for better memory usage.
// These improvements address issues related to performance bottlenecks and high memory usage,
// making ZipArchive more efficient and faster, especially when dealing with large archives.

// | Method | Job        | Runtime   | Mean    | Error   | StdDev  | Ratio | Gen0      | Gen1      | Gen2      | Allocated | Alloc Ratio |
// | ------ | ---------- | --------- | ------- | ------- | ------- | ----- | --------- | --------- | --------- | --------- | ----------- |
// | Test   | DefaultJob | .NET 10.0 | 15.48 s | 0.107 s | 0.095 s | 0.75  | 3000.0000 | 3000.0000 | 3000.0000 | 1 GB      | 0.25        |
// | Test   | .NET 9.0   | .NET 9.0  | 20.63 s | 0.212 s | 0.198 s | 1.00  | 8000.0000 | 8000.0000 | 8000.0000 | 4 GB      | 1.00        |

var summary = BenchmarkRunner.Run<ZipArchiveBenchmarks>();