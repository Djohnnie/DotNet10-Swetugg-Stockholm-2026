#!/usr/local/share/dotnet/dotnet run

// Beginning with C# 14 and .NET 10, you can create file-based apps, which simplifies building and running C# programs.
// You use the dotnet run command to run a program contained in a single *.cs file.
// For example, if the following code is stored in a file named app2.cs, you can run it by typing dotnet run app2.cs.

// The first line of the program contains the #! sequence (shebang) for unix shells.
// The location of the dotnet CLI can vary on different distributions.
// On any unix system, if you set the execute (+x) permission on such a C# file that contains the shebang directive,
// you can run the C# file directly from the command line.

// ./app2.cs

Console.WriteLine("This is app2.");