using System.IO.Compression;
using System.Text;

// .NET 10 introduces new asynchronous APIs that make it easier to
// perform non-blocking operations when reading from or writing to ZIP files.
// This feature was highly requested by the community.
// New async methods are available for extracting, creating, and updating ZIP archives.
// These methods enable developers to efficiently handle large files and improve application responsiveness,
// especially in scenarios involving I/O-bound operations.

// Extract a Zip archive
await ZipFile.ExtractToDirectoryAsync("archive.zip", "destinationFolder", overwriteFiles: true);

// Create a Zip archive
await ZipFile.CreateFromDirectoryAsync("sourceFolder", "archive.zip", CompressionLevel.SmallestSize, includeBaseDirectory: true, entryNameEncoding: Encoding.UTF8);

// Open an archive
await using var archive1 = await ZipFile.OpenReadAsync("archive.zip");

// Fine-grained manipulation
using FileStream archiveStream = File.OpenRead("archive.zip");
await using (ZipArchive archive2 = await ZipArchive.CreateAsync(archiveStream, ZipArchiveMode.Update, leaveOpen: false, entryNameEncoding: Encoding.UTF8))
{
    foreach (ZipArchiveEntry entry in archive2.Entries)
    {
        // Extract an entry to the filesystem
        await entry.ExtractToFileAsync(destinationFileName: "file.txt", overwrite: true);

        // Open an entry's stream
        await using Stream entryStream = await entry.OpenAsync();

        // Create an entry from a filesystem object
        ZipArchiveEntry createdEntry = await archive2.CreateEntryFromFileAsync("path/to/file.txt", "file.txt");
    }
}