# Persian.Plus

Utilities for Persian/Farsi text processing, validation, number conversion, and date handling in .NET.

## Install

```bash
dotnet add package Persian.Plus
```

## Features

- Persian text and phrase validation helpers
- Iranian national identifiers validation (National Code, National Legal Code, Postal Code)
- Iranian bank validations (IBAN, Shetab card)
- Iranian mobile number validation, coercion, and masking
- Persian/English number conversion and number-to-text (`Textify`)
- Persian calendar/date-time helpers (`PersianDateTime`, events/holidays)
- DataAnnotations attributes for model validation
- Persian text normalization utilities

## PersianDateTime sample

```csharp
using System;
using System.Linq;
using Persian.Plus.DateTime;

// 1) Create from Jalali date parts
var a = new PersianDateTime(1403, 12, 29, 14, 30, 45);
Console.WriteLine($"{a:yyyy/MM/dd HH:mm:ss}");
// Output: 1403/12/29 14:30:45

// 2) Convert from System.DateTime (Gregorian -> PersianDateTime)
var g = new DateTime(2025, 3, 20, 10, 0, 0);
var b = new PersianDateTime(g);
Console.WriteLine($"{b:yyyy/MM/dd HH:mm:ss}");
// Output: 1403/12/30 10:00:00

// 3) Parse supported string formats
var p1 = PersianDateTime.Parse("1404/01/01");
Console.WriteLine($"{p1:yyyy/MM/dd}");
// Output: 1404/01/01

var p1b = PersianDateTime.Parse("14040101");
Console.WriteLine($"{p1b:yyyy/MM/dd}");
// Output: 1404/01/01

var p2 = PersianDateTime.Parse("14040101112233");
Console.WriteLine($"{p2:yyyy/MM/dd HH:mm:ss}");
// Output: 1404/01/01 11:22:33

var unixSeconds = PersianDateTime.Parse("1711900800");
Console.WriteLine($"{unixSeconds:yyyy/MM/dd HH:mm:ss}");
// Output: (depends on local timezone conversion)

var unixMilliseconds = PersianDateTime.Parse("1711900800000");
Console.WriteLine($"{unixMilliseconds:yyyy/MM/dd HH:mm:ss}");
// Output: (depends on local timezone conversion)

// 4) TryParse
var ok = PersianDateTime.TryParse("1404-01-15", out var p3);
Console.WriteLine(ok);
// Output: True
Console.WriteLine($"{p3:yyyy/MM/dd}");
// Output: 1404/01/15

var bad = PersianDateTime.TryParse("not-a-date", out var _);
Console.WriteLine(bad);
// Output: False

// 5) Date arithmetic
var d = new PersianDateTime(1404, 1, 1);
Console.WriteLine($"{d.AddDays(10):yyyy/MM/dd}");
// Output: 1404/01/11
Console.WriteLine($"{d.AddMonths(1):yyyy/MM/dd}");
// Output: 1404/02/01
Console.WriteLine($"{d.AddYears(1):yyyy/MM/dd}");
// Output: 1405/01/01

// 6) Operators and comparisons
var x = new PersianDateTime(1404, 1, 1);
var y = new PersianDateTime(1404, 1, 2);
Console.WriteLine(x < y);
// Output: True
Console.WriteLine(y > x);
// Output: True
Console.WriteLine(x == new PersianDateTime(1404, 1, 1));
// Output: True

// 7) TimeSpan operators
var plus = x + TimeSpan.FromDays(5);
Console.WriteLine($"{plus:yyyy/MM/dd}");
// Output: 1404/01/06

var diff = y - x;
Console.WriteLine(diff.TotalDays);
// Output: 1

// 8) Implicit conversion with System.DateTime
DateTime systemDate = x;
PersianDateTime backToPersian = systemDate;
Console.WriteLine($"{backToPersian:yyyy/MM/dd}");
// Output: 1404/01/01

// 9) Properties
Console.WriteLine(x.Year);        // Output: 1404
Console.WriteLine(x.Month);       // Output: 1
Console.WriteLine(x.Day);         // Output: 1
Console.WriteLine(x.IsLeapYear);  // Output: False (for 1404)
Console.WriteLine(x.DaysInMonth); // Output: 31 (Farvardin)

// 10) Now
var now = PersianDateTime.Now;
Console.WriteLine($"{now:yyyy/MM/dd HH:mm:ss}");
// Output: (current Persian date/time)

// 11) Events and holidays in range
var start = new PersianDateTime(1404, 1, 1);
var end = new PersianDateTime(1404, 1, 31);
var events = start.GetEventsTill(end);
var holidays = events.Where(e => e.EventType.HasFlag(EventType.Holiday));
Console.WriteLine(holidays.Any());
// Output: True
```

## Common extension samples

`NormalizePersianText` cleans and standardizes Persian text. Based on selected flags it can fix Arabic/Persian character variants (like `ي` -> `ی`, `ك` -> `ک`), apply half-space/ZWNJ rules, normalize spacing/line-breaks, remove diacritics, and run punctuation cleanup.

```csharp
using Persian.Plus.Extensions;
using Persian.Plus.Extensions.Number;
using Persian.Plus.Extensions.Normalizer;

var validMobile = "09121234567".IsValidIranianMobileNumber();
// Output: true
var coerceMobile = "+989121234567".CoerceIranianMobileNumber();
// Output: 09121234567
var maskedMobile = "09121234567".MaskIranianMobileNumber();
// Output: 091212xxx67

var isPersianOnly = "علیرضا وفی".ContainsOnlyPersianLetters();
// Output: true
var isPersianOrEnglish = "علیرضا Vafi".ContainsOnlyPersianOrEnglishLetters();
// Output: true

var persianDigits = "123456".ToPersianNumbers();
// Output: ۱۲۳۴۵۶
var englishDigits = "۱۲۳۴۵۶".ToEnglishNumbers();
// Output: 123456
var words = 1250.Textify(Language.Persian);
// Output: یکهزار و دویست و پنجاه

var normalized = "سلام  دنيا".NormalizePersianText(
    PersianNormalizerFlags.ApplyPersianCharacters |
    PersianNormalizerFlags.ApplyHalfSpaceRule |
    PersianNormalizerFlags.CleanupSpacingAndLineBreaks);
// Output: سلام دنیا
```

## DataAnnotations sample

```csharp
using Persian.Plus.DataAnnotations;

public class PersonDto
{
    [PersianLetters]
    public string Name { get; set; }

    [IranianNationalCode]
    public string NationalCode { get; set; }

    [IranianMobileNumber]
    public string MobileNumber { get; set; }
}
```
