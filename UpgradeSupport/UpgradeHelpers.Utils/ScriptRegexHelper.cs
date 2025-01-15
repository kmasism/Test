using System.Text.RegularExpressions;

namespace UpgradeHelpers.Helpers
{
    /// <summary>
    /// The ScriptRegexHelper is an utility that provides functionality related to Regular Expressions uses.
    /// </summary>
    public class ScriptRegexHelper
    {
        /// <summary>
        /// String that specifies the pattern of the regular expression.
        /// </summary>
        public string Pattern { get; set; }
        /// <summary>
        /// Enum that allows to specify options or flags that control how 
        /// regular expressions are applied.
        /// </summary>
        private RegexOptions Options;
        /// <summary>
        /// Boolean to control whether the regular expression pattern matching 
        /// should be case-sensitive or not.
        /// </summary>
        public bool IgnoreCase
        {
            get
            {
                return (Options & RegexOptions.IgnoreCase) != 0;
            }
            set
            {
                if (value)
                {
                    Options |= RegexOptions.IgnoreCase;
                }
                else
                {
                    Options &= ~RegexOptions.IgnoreCase;
                }
            }
        }
        /// <summary>
        /// Boolean to control whether the regular expression pattern matching 
        /// should match multiple lines of text
        /// </summary>
        public bool Multiline
        {
            get
            {
                return (Options & RegexOptions.Multiline) != 0;
            }
            set
            {
                if (value)
                {
                    Options |= RegexOptions.Multiline;
                }
                else
                {
                    Options &= ~RegexOptions.Multiline;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the ScriptRegexHelper class.
        /// </summary>
        public ScriptRegexHelper()
            : this(null, RegexOptions.None)
        {
        }
        /// <summary>
        /// Initializes a new instance of the ScriptRegexHelper class.
        /// </summary>
        /// <param name="pattern">The Pattern to use for the regular expression.</param>
        public ScriptRegexHelper(string pattern)
            : this(pattern, RegexOptions.None)
        {
        }
        /// <summary>
        /// Initializes a new instance of the ScriptRegexHelper class.
        /// </summary>
        /// <param name="pattern">The Pattern to use for the regular expression.</param>
        /// <param name="options">The options to control how regular expressions are applied.</param>
        public ScriptRegexHelper(string pattern, RegexOptions options)
        {
            this.Pattern = pattern;
            this.Options = options;
        }
        /// <summary>
        /// Locates all substrings that match a Pattern and substitutes them with a specified
        /// replacement string.
        /// </summary>
        /// <param name="input">The string in which matching substrings are sought.</param>
        /// <param name="replacement">The string to replace matched substrings.</param>
        /// <returns>A new string with the original substring replaced by the replacement string.</returns>
        public string Replace(string input, string replacement)
        {
            return Regex.Replace(input, Pattern, replacement, Options);
        }
        /// <summary>
        /// Searches the specified input string for all occurrences that match the Pattern,
        /// using the specified regular expression options(Options).
        /// </summary>
        /// <param name="input">The string to be searched for matching patterns.</param>
        /// <returns>A collection of Match objects representing the matches found.</returns>
        public MatchCollection Execute(string input)
        {
            return Regex.Matches(input, Pattern, Options);
        }
        /// <summary>
        /// Check if the input has any matches based on the pattern and the options available.
        /// </summary>
        /// <param name="input">The string in which to search for a matching pattern.</param>
        /// <returns>True if a match is found; otherwise, returns false.</returns>
        public bool Test(string input)
        {
            return Regex.IsMatch(input, Pattern, Options);
        }
    }

}
