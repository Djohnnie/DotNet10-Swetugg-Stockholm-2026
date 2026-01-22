using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

// Finding certificates uniquely by thumbprint is a fairly common operation, but the
// X509Certificate2Collection.Find(X509FindType, Object, Boolean) method (for the FindByThumbprint mode)
// only searches for the SHA-1 thumbprint value.
//
// There's some risk to using the Find method for finding SHA-2-256 ("SHA256") and
// SHA-3-256 thumbprints since these hash algorithms have the same lengths.
// Instead, .NET 10 introduces a new method that accepts the name of the hash algorithm to use for matching.

var thumbprint = "‎thumbprint";
var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
var collection1 = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: true);

// New in .NET 10:
var collection2 = store.Certificates.FindByThumbprint(HashAlgorithmName.SHA256, thumbprint);