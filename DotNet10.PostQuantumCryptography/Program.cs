#pragma warning disable SYSLIB5006 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

using System.Security.Cryptography;

// .NET 10 includes support for three new asymmetric algorithms:
// ML-KEM (FIPS 203),
// ML-DSA (FIPS 204),
// and SLH-DSA (FIPS 205).
// The new types are:
// - System.Security.Cryptography.MLKem
// - System.Security.Cryptography.MLDsa
// - System.Security.Cryptography.SlhDsa
//
// Because it adds little benefit, these new types don't derive from AsymmetricAlgorithm.
// Rather than the AsymmetricAlgorithm approach of creating an object and then importing a key into it,
// or generating a fresh key, the new types all use static methods to generate or import a key.

Console.WriteLine($"ML-KEM is {(MLKem.IsSupported ? "" : "NOT")} supported on this platform");
Console.WriteLine($"ML-DSA is {(MLDsa.IsSupported ? "" : "NOT")} supported on this platform");
Console.WriteLine($"SLH-DSA is {(SlhDsa.IsSupported ? "" : "NOT")} supported on this platform");

using (MLKem key = MLKem.GenerateKey(MLKemAlgorithm.MLKem768))
{
    string publicKeyPem = key.ExportSubjectPublicKeyInfoPem();
}

static bool ValidateMLDsaSignature(ReadOnlySpan<byte> data, ReadOnlySpan<byte> signature, string publicKeyPath)
{
    var publicKeyPem = File.ReadAllText(publicKeyPath);

    using var key = MLDsa.ImportFromPem(publicKeyPem);
    return key.VerifyData(data, signature);
}

#pragma warning restore SYSLIB5006 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.