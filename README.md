<img align="right" src="/HelpMate.Core/helpmatecore_logo.png" />

# HelpMate.Core

A tiny helper for writing .NET Core applications. This library provides a simple set of extension methods that you can use to perform common validations and conversions in C#.

# Installation
1. Download and Install the latest `HelpMate.Core` from NuGet or via CLI:

```
PM> Install-Package HelpMate.Core -Version 1.1.0
```

2. Declare the following namespace in the class:

```csharp
using HelpMate.Core;
```

# Sample Usage
Assuming you would want to convert a `string` value to a `DateTime` object type. To handle this, you would probably use one of the built-in methods in .NET such as the [Convert.ToDateTime()](https://docs.microsoft.com/en-us/dotnet/api/system.convert.todatetime?view=netcore-3.1) method.

```csharp
string dateString = "6/10/2020";
var date = Convert.ToDateTime(dateString);
``` 

That should work perfectly as we expect, however that will throw a `System.FormatException` if you are trying to convert a `string` value which is not a valid date format. This could potentially happen especially when our code is consuming data from user inputs or other data sources that we never control. To fix that, we can use the [DateTime.TryParse()](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tryparse?view=netcore-3.1) method to safely handle the conversion as shown in the following:

```csharp
string dateString = "60/1011/2020"; // this is an invalid date
var isValid = DateTime.TryParse(dateString, out var date);

if (isValid)
{
   // date is valid
}  
```

You can see that our code is now safe to handle `DateTime` conversion, however, the code is kinda long to just do a basic conversion. Imagine you have a lot of the same conversion cluttering within the different areas of your project. That could be messy and may cost you a bit of development time. To avoid that, you would end up creating some helper functions that do common tasks such as conversions. 

With `HelpMate.Core`, you don't need to write helper functions yourself anymore every time you implement a new project that do common things, not unless if necessary. Instead, you can just plug this package into your project and then you're good to go.

Here's a sample usage on how to do `DateTime` conversion easily:

```csharp
string dateString = "60/1011/2020"; // this is an invalid date
var date = dateString.ToDateTime();

if (date.IsValidDateTime())
{
   // Date is valid
}  
```

As you could probably guessed, the implementation in the preceding code is somewhat similar to `DateTime.TryParse()`. Yes it is and in fact, it uses the `DateTime.TryParse()` method under the hood. The goal is to provide convenience and to make your code much cleaner and shorter.

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
bool IsValidPhoneNumber(this string value, int minLength = default, int maxLength = default)
bool IsValidJson(this string json)
bool IsValidDateTime(this DateTime? date)
bool IsValidDateTime(this DateTime date)
bool IsValidDateTimeString(this string date)
bool IsValidStandardDateString(this string value) 
bool IsFutureDate(this string date) 
bool IsNumber(this string value)
bool IsWholeNumber(this string value)
bool IsDecimalNumber(this string value)
bool IsBoolean(this string value)
bool IsHtml(this string value)
bool IsAlphaNumeric(this string value)
bool IsAlphaNumericStrict(this string value)
```

# Release History

See release logs here: [Release Logs](https://github.com/proudmonkey/HelpMate.Core/blob/master/RELEASE.md)

# Feedback and Give a Star!
It's still in its initial version, opensource and of course contributions are welcome. I’m pretty sure there are still lot of things to improve in this library. Try it out and let me know your thoughts.

Feel free to submit a ticket if you find bugs or request a new feature. Your valuable feedback is much appreciated to better improve this library. If you find this useful, please give it a **star** to show your support for this project.

# Attribution
Icon made by <a href="https://www.flaticon.com/authors/freepik" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>
