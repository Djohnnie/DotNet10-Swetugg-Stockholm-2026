using System.Globalization;

// The ISOWeek class was originally designed to work exclusively with DateTime, as it was introduced before the DateOnly type existed.
// Now that DateOnly is available, it makes sense for ISOWeek to support it as well.
// The following overloads are new:
// - GetWeekOfYear(DateOnly)
// - GetYear(DateOnly)
// - ToDateOnly(Int32, Int32, DayOfWeek)

var dateTime = new DateTime(2025, 5, 25);
var weekForDateTime = ISOWeek.GetWeekOfYear(dateTime);
var yearForDateTime = ISOWeek.GetYear(dateTime);
var dateTimeFromIso = ISOWeek.ToDateTime(yearForDateTime, weekForDateTime, DayOfWeek.Monday);
Console.WriteLine($"{dateTime} is in ISO week {weekForDateTime}.");

var dateOnly = new DateOnly(2025, 5, 25);
var weekForDateOnly = ISOWeek.GetWeekOfYear(dateOnly);
var yearForDateOnly = ISOWeek.GetYear(dateOnly);
var dateOnlyFromIso = ISOWeek.ToDateOnly(yearForDateTime, weekForDateTime, DayOfWeek.Monday);
Console.WriteLine($"{dateOnly} is in ISO week {weekForDateOnly}.");