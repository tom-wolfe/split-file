using System;
using System.Linq;

namespace SplitFile.CommandLine {
    /// <summary>
    /// Represents a possible command-line argument/switch passed to the application.
    /// </summary>
    public class CommandLineArgument {
        #region -  Constructors  -

            /// <summary>
            /// Initializes a new instance of the <see cref="CommandLineArgument"/> class.
            /// </summary>
            /// <param name="shortName">The abbreviated, usually single-letter, name of the command-line argument, excluding the preceding hyphen or slash.</param>
            /// <param name="longName">The full-length name of the command line argument, excluding the preceding hyphen or slash.</param>
            /// <param name="required">A Boolean value indicating whether or not this argument is required.</param>
            /// <param name="requiresValue">A Boolean value indicating whether or not this argument requires a supplementary value.</param>
            public CommandLineArgument(string shortName, string longName, bool required, bool requiresValue) 
                : this(shortName, longName, required, requiresValue, string.Empty) { }

            /// <summary>
            /// Initializes a new instance of the <see cref="CommandLineArgument"/> class.
            /// </summary>
            /// <param name="shortName">The abbreviated, usually single-letter, name of the command-line argument.</param>
            /// <param name="longName">The full-length name of the command line argument.</param>
            /// <param name="required">A Boolean value indicating whether or not this argument is required.</param>
            /// <param name="requiresValue">A Boolean value indicating whether or not this argument requires a supplementary value.</param>
            /// <param name="description">A value describing the purpose of the argument and how to use it that can be displayed to the user.</param>
            public CommandLineArgument(string shortName, string longName, bool required, bool requiresValue, string description) {
                if (shortName == null) throw new ArgumentNullException("shortName");
                if (longName == null) throw new ArgumentNullException("longName");

                ShortName = shortName;
                LongName = longName;

                ValidateName(ShortName);
                ValidateName(LongName);

                Required = required;
                RequiresValue = requiresValue;
                Description = description ?? string.Empty;
            }

        #endregion

        #region -  Properties  -

            /// <summary>
            /// Gets the abbreviated name of the command-line argument.
            /// </summary>
            public string ShortName { get; private set; }

            /// <summary>
            /// Gets the full-length name of the command-line argument.
            /// </summary>
            public string LongName { get; private set; }

            /// <summary>
            /// Gets a description of the argument and how to use it.
            /// </summary>
            public string Description { get; private set; }

            /// <summary>
            /// Gets a Boolean value indicating whether or not this argument is required.
            /// </summary>
            public bool Required { get; private set; }

            /// <summary>
            /// Gets a Boolean value indicating whether or not this argument requires a supplementary value.
            /// </summary>
            public bool RequiresValue { get; private set; }

        #endregion

        #region -  Methods  -

            private void ValidateName(string validName) {
                if (Enumerable.Any(validName, c => !char.IsLetterOrDigit(c))) {
                    throw new InvalidCommandLineArgumentNameException(this);
                }
            }

        #endregion
    }
}