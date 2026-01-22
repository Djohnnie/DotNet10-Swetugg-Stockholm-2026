```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3775)
11th Gen Intel Core i7-11370H 3.30GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100-preview.2.25164.34
  [Host]     : .NET 10.0.0 (10.0.25.16302), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 10.0.0 (10.0.25.16302), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 9.0   : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method | Job        | Runtime   | Mean    | Error   | StdDev  | Ratio | RatioSD | Gen0      | Gen1      | Gen2      | Allocated  | Alloc Ratio |
|------- |----------- |---------- |--------:|--------:|--------:|------:|--------:|----------:|----------:|----------:|-----------:|------------:|
| Test   | DefaultJob | .NET 10.0 | 15.12 s | 0.178 s | 0.166 s |  0.77 |    0.01 | 6000.0000 | 6000.0000 | 6000.0000 | 1023.89 MB |        0.25 |
| Test   | .NET 9.0   | .NET 9.0  | 19.62 s | 0.355 s | 0.315 s |  1.00 |    0.02 | 8000.0000 | 8000.0000 | 8000.0000 | 4096.83 MB |        1.00 |
