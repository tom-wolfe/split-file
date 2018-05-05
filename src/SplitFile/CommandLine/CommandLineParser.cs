using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SplitFile.CommandLine {
    /// <summary>
    /// Provides the facility to parse command-line arguments passed to application based on a given definition.
    /// </summary>
    public class CommandLineParser {        
        #region -  Constructors   -

            /// <summary>
            /// Initializes a new instance of the <see cref="CommandLineParser"/>
            /// </summary>
            public CommandLineParser() { }

        #endregion

        #region -  Methods  -

            /// <summary>
            /// Parses a collection of command-line parameters.
            /// </summary>
            /// <param name="definition">The definition that the command-line arguments must correspond to.</param>
            /// <param name="args">The arguments to parse.</param>
            /// <returns>The parsed argument values.</returns>
            public object Parse(CommandLineDefinition definition, string args) {
                return Parse(definition, Split(args));
            }

            /// <summary>
            /// Parses a collection of command-line parameters.
            /// </summary>
            /// <param name="definition">The definition that the command-line arguments must correspond to.</param>
            /// <param name="args">The arguments to parse.</param>
            /// <returns>The parsed argument values.</returns>
            public Dictionary<string, string> Parse(CommandLineDefinition definition, IEnumerable<string> args) {
                var argValues = new Dictionary<string, string>();
                var enumerator = args.GetEnumerator();
                while (enumerator.MoveNext()) {
                    var arg = enumerator.Current;
                    if (string.IsNullOrEmpty(arg)) continue;

                    var argName = ParseArgumentName(arg);
                    var argObj = FindArgument(definition, argName);
                    var argValue = ParseArgumentValue(argObj, enumerator);
                    argValues.Add(argObj.LongName, argValue);
                }
                EnsureRequiredArgumentsPresent(definition, argValues);
                return argValues;
            }

            /// <summary>
            /// Generates the usage information for a given command-line argument set.
            /// </summary>
            /// <returns>The usage information for the given command-line argument set.</returns>
            public string GenerateHelpText(CommandLineDefinition definition, string applicationName, string applicationDescription) {
                var helpText = new StringBuilder();
                helpText.AppendLine(applicationDescription);
                helpText.AppendLine();

                helpText.Append(applicationName);
                foreach (var arg in (from a in definition where a.Required orderby a.ShortName select a)) {
                    helpText.AppendFormat(" -{0}", arg.ShortName);
                    if (arg.RequiresValue) { helpText.Append(" \"value\""); }
                }

                foreach (var arg in (from a in definition where !a.Required orderby a.ShortName select a)) {
                    helpText.Append(" [");
                    helpText.AppendFormat("-{0}", arg.ShortName);
                    if (arg.RequiresValue) { helpText.Append(" \"value\""); }
                    helpText.Append("]");
                }

                helpText.AppendLine();
                helpText.AppendLine();

                var longestShortName = (from arg in definition select arg.ShortName.Length).Max() * -1;
                var longestLongName = (from arg in definition select arg.LongName.Length).Max() * -1;

                var formatString = string.Format(" {{0}} -{{1,{0}}} --{{2,{1}}}  {{3}}{{4}}", longestShortName, longestLongName);

                foreach (var arg in definition.OrderByDescending(a => a.Required).ThenBy(a => a.ShortName)) {
                    helpText.AppendFormat(formatString, arg.Required ? "R" : " ", arg.ShortName, arg.LongName, arg.Description, Environment.NewLine);
                }
                return helpText.ToString();
            }

        #endregion

        #region -  Private Methods  -

            private static CommandLineArgument FindArgument(CommandLineDefinition definition, string argName) {
                var argObj = definition.FindArgument(argName);
                if (argObj == null) { throw new UnrecognisedCommandLineArgumentException(); }
                return argObj;
            }

            private static string ParseArgumentName(string arg) {
                if (arg.StartsWith("--")) {
                    return arg.Substring(2);
                }

                if ((new[] { '-', '/' }).Contains(arg[0])) {
                    return arg.Substring(1);
                }
                throw new InvalidCommandLineArgumentNameException();
            }

            private static string ParseArgumentValue(CommandLineArgument argument, IEnumerator<string> enumerator) {
                var argValue = string.Empty;
                if (argument.RequiresValue) {
                    if (!enumerator.MoveNext()) {
                        throw new MissingCommandLineArgumentValueException(argument);
                    }
                    argValue = enumerator.Current;
                }
                return argValue;
            }

            private static void EnsureRequiredArgumentsPresent(IEnumerable<CommandLineArgument> definition, IDictionary<string, string> argumentValues) {
                var missingRequiredArgs = from a in definition
                                          where a.Required && !argumentValues.ContainsKey(a.LongName)
                                          select a;

                foreach (var requiredArgument in missingRequiredArgs) {
                    throw new MissingRequiredCommandLineArgumentException(requiredArgument);
                }
            }

            /// <summary>
            /// Splits a set of command-line arguments by whitespace.
            /// </summary>
            /// <param name="args">The arguments to parse.</param>
            /// <returns>The split command-line arguments.</returns>
            private static IEnumerable<string> Split(string args) {
                var reader = new StringReader(args);
                var buffer = new StringBuilder();
                while (reader.Peek() != -1) {
                    var c = (char)reader.Read();

                    if (c == '"') {
                        while (reader.Peek() != '"' && reader.Peek() != -1) {
                            buffer.Append((char)reader.Read());
                        }
                    } else if (!char.IsWhiteSpace(c)) {
                        buffer.Append(c);
                        continue;
                    }
                    
                    yield return buffer.ToString();
                    buffer = new StringBuilder();
                }
            }

        #endregion
    }
}