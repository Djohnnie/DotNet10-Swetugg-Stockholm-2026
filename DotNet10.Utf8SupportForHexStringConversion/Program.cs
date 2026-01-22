// .NET 10 adds UTF-8 support for hex-string conversion operations in the Convert class.
// These new methods provide efficient ways to convert between UTF-8 byte sequences and
// hexadecimal representations without requiring intermediate string allocations.

var input1 = "2A";
var bytes1 = Convert.FromHexString(input1);
Console.WriteLine($"Byte value: {bytes1[0]}");

var input2 = "2A".AsSpan();
var bytes2 = Convert.FromHexString(input2);
Console.WriteLine($"Byte value: {bytes2[0]}");

var input3 = "2A"u8;
var bytes3 = Convert.FromHexString(input3);
Console.WriteLine($"Byte value: {bytes3[0]}");