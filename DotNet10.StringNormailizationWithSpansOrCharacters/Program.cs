using System.Text;

// Unicode string normalization has been supported for a long time, but existing APIs only worked with the string type.
// This means that callers with data stored in different forms, such as character arrays or spans,
// must allocate a new string to use these APIs.
// Additionally, APIs that return a normalized string always allocate a new string to represent the normalized output.
// .NET 10 introduces new APIs that work with spans of characters, which expand normalization beyond string types
// and help to avoid unnecessary allocations.

var normalString = "Hello World";
var length1 = normalString.GetNormalizedLength(NormalizationForm.FormC);
var isNormalized1 = normalString.IsNormalized(NormalizationForm.FormC);
var destination = new char[length1];
normalString.TryNormalize(destination, out var written, NormalizationForm.FormC);

var normalSpan = normalString.AsSpan();
var length2 = normalSpan.GetNormalizedLength(NormalizationForm.FormC);
var isNormalized2 = normalSpan.IsNormalized(NormalizationForm.FormC);
var destinationSpan = new char[length2];
normalSpan.TryNormalize(destinationSpan, out var writtenSpan, NormalizationForm.FormC);