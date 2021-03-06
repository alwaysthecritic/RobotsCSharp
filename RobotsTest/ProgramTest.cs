using System;
using NUnit.Framework;
using System.IO;
using System.Text.RegularExpressions;

namespace Robots {

    /// <summary>
    /// Functional tests that exercise the whole program.
    /// </summary>
    [TestFixture]
    public class ProgramTest {

        private readonly string NewLine = Environment.NewLine;

        [Test]
        public void RunOverSampleFile() {
            var configFilePath = "../../../SampleData/input.txt";
            var outputFilePath = "../../../SampleData/output.txt";

            File.Delete(outputFilePath);

            var args = new string[] { configFilePath,  outputFilePath };
            Program.Main(args);

            var output = File.ReadAllText(outputFilePath);
            var expectedOutput = "1 3 N" + NewLine + "5 1 E" + NewLine;
            Assert.AreEqual(expectedOutput, output);

            File.Delete(outputFilePath);
        }

        [Test]
        public void NotEnoughArgsShowsUsage() {
            using (var consoleOutput = new ConsoleOutput())
            {
                var args = new string[] { "foo" };
                Program.Main(args);

                var expectedConsoleOut = "Usage: Robots.exe <configFilePath> <outputFilePath>" + NewLine;
                Assert.AreEqual(expectedConsoleOut, consoleOutput.GetOuput());
            }
        }

        [Test]
        public void ConfigFileNotFoundShowsHelpfulMessage() {
            using (var consoleOutput = new ConsoleOutput())
            {
                var args = new string[] { "foo", "bar" };
                Program.Main(args);

                // Message will show absolute file path so need to ignore the machine-specific bit
                var prefix = "Could not find file \"/";
                var suffix = "/Robots/RobotsTest/bin/Debug/foo\"." + NewLine;
                StringAssert.StartsWith(prefix, consoleOutput.GetOuput());
                StringAssert.EndsWith(suffix, consoleOutput.GetOuput());
            }
        }
    }
}

