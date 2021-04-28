using Ardalis.GuardClauses;
using System;
using System.Text.RegularExpressions;

namespace ExpenseTracker.Common.Extensions
{
    public static class Ardalis
    {
        /// <summary>
        /// Makes sure that the supplied value matches the regular expression
        /// </summary>
        /// <param name="guardClause"></param>
        /// <param name="regex">Regular expression to match against</param>
        /// <param name="valueToCheck">Value that needs to be checked against the RegEx</param>
        /// <param name="parameterName">Name of the parameter that provides the value</param>
        /// <returns>The value after it is checked</returns>
        public static string NotMatchingRegex(this IGuardClause guardClause,
            string regex, string valueToCheck, string parameterName)
        {
            if (!new Regex(regex).IsMatch(valueToCheck))
            {
                throw new ArgumentException("The value provided is not valid.",
                    parameterName);
            }

            return valueToCheck;
        }
    }
}