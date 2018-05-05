using System;
using System.IO;
using SplitFile.CommandLine;

namespace SplitFile {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            var definition = new CommandLineDefinition {
                new CommandLineArgument("i", "input", true, true, "The input file to split."),
                new CommandLineArgument("l", "lines", true, true, "The number of lines to split by."),
                new CommandLineArgument("o", "output", true, true, "")
            };

            var parser = new CommandLineParser();
            try {
                var result = parser.Parse(definition, args);

                var splitCount = int.Parse(result["lines"]);

                using (var reader = new StreamReader(result["input"])) {
                    string line;
                    var currentLine = 0;
                    var currentFile = 1;
                    StreamWriter currentStream = null;
                    while ((line = reader.ReadLine()) != null) {
                        if (currentStream == null) currentStream = OpenFile(result["input"], currentFile, result["output"]);
                        currentLine++;
                        currentStream.WriteLine(line);
                        if (currentLine >= splitCount) {
                            currentLine = 0;
                            currentFile++;
                            currentStream.Flush();
                            currentStream.Dispose();
                            currentStream = null;
                        }
                    }
                    if (currentStream != null) {
                        currentStream.Flush();
                    }
                }
            } catch (CommandLineArgumentException) {
                var helpText = parser.GenerateHelpText(definition, "SplitFile", "Splits files into user-defined chunks.");
                Console.WriteLine(helpText);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static StreamWriter OpenFile(string input, int fileNumber, string output) {
            var info = new FileInfo(input);
            var fileName = info.Name.Substring(0, info.Name.Length - info.Extension.Length) + "-" + fileNumber + info.Extension;
            return new StreamWriter(Path.Combine(output, fileName), false);
        }
    }
}
