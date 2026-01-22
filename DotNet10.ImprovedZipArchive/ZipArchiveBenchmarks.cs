using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.IO.Compression;

namespace DotNet10.ImprovedZipArchive;

[SimpleJob(RuntimeMoniker.Net90, baseline: true)]
[SimpleJob(RuntimeMoniker.HostProcess)]
[MemoryDiagnoser]
public class ZipArchiveBenchmarks
{
    private const string File1Path = @"c:\temp\largeFile1.txt";
    private const string File2Path = @"c:\temp\largeFile2.txt";
    private const string File3Path = @"c:\temp\largeFile3.txt";
    private const string ZipFile1Path = @"c:\temp\archive.zip";
    private const string ZipFile2Path = @"c:\temp\archive.copy.zip";

    [GlobalSetup]
    public void Setup()
    {
        CreateLargeFile(File1Path, 2048);
        CreateLargeFile(File2Path, 1024);
        CreateLargeFile(File3Path, 512);

        using (var zipStream = new FileStream(ZipFile1Path, FileMode.Create))
        using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create))
        {
            zipArchive.CreateEntryFromFile(File1Path, Path.GetFileName(File1Path));
            zipArchive.CreateEntryFromFile(File2Path, Path.GetFileName(File2Path));
        }
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        File.Delete(File1Path);
        File.Delete(File2Path);
        File.Delete(File3Path);
        File.Delete(ZipFile1Path);
        File.Delete(ZipFile2Path);
    }

    [Benchmark]
    //[MaxIterationCount(20)]
    public void Test()
    {
        File.Copy(ZipFile1Path, ZipFile2Path, true);
        using var zipStream = new FileStream(ZipFile2Path, FileMode.Open);
        using var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Update);
        zipArchive.CreateEntryFromFile(File3Path, Path.GetFileName(File3Path));
    }

    private void CreateLargeFile(string filePath, int sizeInMB)
    {
        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[1024 * 1024];
            Random.Shared.NextBytes(buffer);

            for (int i = 0; i < sizeInMB; i++)
            {
                fileStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}