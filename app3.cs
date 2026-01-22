// Beginning with C# 14 and .NET 10, you can create file-based apps, which simplifies building and running C# programs.
// You use the dotnet run command to run a program contained in a single *.cs file.
// For example, if the following code is stored in a file named app3.cs, you can run it by typing dotnet run app3.cs.

// File-based apps now support being published to native executables via the dotnet publish app.cs command,
// making it easier to create simple apps that you can redistribute as native executables.
// All file-based apps now target native AOT by default.
// If you need to use packages or features that are incompatible with native AOT,
// you can disable this using the #:property PublishAot=false directive in your .cs file.

// dotnet publish app3.cs

Console.WriteLine("This is app3.");