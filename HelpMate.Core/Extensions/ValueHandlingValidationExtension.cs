using System;
using System.Diagnostics.CodeAnalysis;

namespace HelpMate.Core.Extensions
{
    public static class ValueHandlingValidationExtension
    {

        public static T Null<T>([NotNull] this IValueValidatorClause valueValidatorClause, [NotNull] T input, [NotNull] string parameterName)
        {
            if (input is null)
            {
                throw new ArgumentException($"The given input {parameterName} was null.", parameterName);
            }

            return input;
        }

        public static T Null<T>([NotNull] this IValueValidatorClause valueValidatorClause, T input, [NotNull] string parameterName, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return ValueValidator.ThrowsWhen.Null(input, parameterName);
            }

            if (input is null)
            {
                throw new InvalidOperationException(message);
            }

            return input;
        }

        public static string NullOrWhiteSpace([NotNull] this IValueValidatorClause valueValidatorClause, [NotNull] string input, [NotNull] string parameterName)
        {
            ValueValidator.ThrowsWhen.Null(input, parameterName);

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"The given input {parameterName} was null or empty.", parameterName);
            }

            return input;
        }

        public static Guid NullOrEmpty([NotNull] this IValueValidatorClause valueValidatorClause, [NotNull] Guid? input, [NotNull] string parameterName)
        {
            ValueValidator.ThrowsWhen.Null(input, parameterName);

            if (input.Equals(Guid.Empty))
            {
                throw new ArgumentException($"The given input {parameterName} was null or empty.", parameterName);
            }

            return input.Value;
        }

        public static bool False([NotNull] this IValueValidatorClause valueValidatorClause, [NotNull] bool input, [NotNull] string message)
        {
            if (!input)
            {
                throw new InvalidOperationException(message);
            }

            return input;
        }

        public static bool True([NotNull] this IValueValidatorClause valueValidatorClause, [NotNull] bool input, [NotNull] string message)
        {
            if (input)
            {
                throw new InvalidOperationException(message);
            }

            return input;
        }

        public static void NotDefined<T>([NotNull] this IValueValidatorClause valueValidatorClause, [NotNull] object input)
            where T: Enum
        {
            if (!Enum.IsDefined(typeof(T), input))
            {
                throw new ArgumentException($"The given input is not defined or does not exist.");
            }
        }
    }

    public interface IValueValidatorClause
    {

    }

    public class ValueValidator : IValueValidatorClause
    {
        public static IValueValidatorClause ThrowsWhen { get; } = new ValueValidator();

        private ValueValidator() { }
    }
}
