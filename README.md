<img align="right" src="/HelpMate.Core/helpmatecore_logo.png" />

# HelpMate.Core

A tiny helper for writing .NET Core applications. This library provides a simple set of extension methods that you can use to perform common validations and conversions in C#.

# Installation
1. Download and Install the latest `AutoWrapper.Core` from NuGet or via CLI:

```
PM> Install-Package HelpMate.Core -Version 1.0.0
```

2. Declare the following namespace in the class:

```csharp
using HelpMate.Core;
```

# Sample Usage

```csharp
var date = "6/10/2020".ToDateTime();
```

# Available Extension Methods

Here are the list of available methods as of version 1.

### Converters

```csharp
DateTime ToDateTime(this string value)
DateTime? ToNullableDateTime(this string value)
short ToInt16(this string value)
int ToInt32(this string value)
int? ToNullableInt32(this string value)
long ToInt64(this string value)
long? ToNullableInt64(this string value)
bool ToBoolean(this string value)
float ToFloat(this string value)
decimal ToDecimal(this string value)
double ToDouble(this string value)
string ToBase64Encode(this string value)
string ToBase64Encode(this byte[] value)
string ToBase64Decode(this string value)
byte[] ToByteFromBase64CharArray(this string value) 
byte[] ToByteArray(this string value)
string ToDateTimeFormat(this string date, string format)
static string ToCamelCase(this string value)
int GetYearsFromDate(this DateTime date)
int GetYearsDifference(this DateTime date, DateTime dateToCompare)
```

### Validators

```csharp
bool IsValidEmailFormat(this string value)
bool IsValidCreditCardNumber(this string value)
bool IsValidJson(this string json)
bool IsValidDateTime(DateTime? date)
bool IsValidDateTimeString(string date)
bool IsValidStandardDateString(this string value) 
bool IsFutureDate(this string date) 
bool IsNumber(this string value)
bool IsWholeNumber(this string value)
bool IsDecimalNumber(this string value)
bool IsBoolean(this string value)
bool IsHtml(this string value)
```
