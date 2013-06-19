using System;
using NUnit.Framework;
using OpenTableRobots;
using System.IO;

namespace OpenTableRobotsTest {

    /// <summary>
    /// A functional test that exercises the whole program.
    /// </summary>
    [TestFixture]
    public class ProgramTest {

        [Test]
        public void RunOverSampleFile() {
            var configFilePath = "../../../SampleData/input.txt";
            var outputFilePath = "../../../SampleData/output.txt";

            DeleteFile(outputFilePath);

            var args = new string[] { configFilePath,  outputFilePath };
            Program.Main(args);

            var output = File.ReadAllText(outputFilePath);
            var expectedOutput = "1 3 N" + Environment.NewLine + "5 1 E" + Environment.NewLine;
            Assert.AreEqual(expectedOutput, output);

            // Clean up.
            DeleteFile(outputFilePath);
        }

        private void DeleteFile(string outputFilePath) {
            File.Delete(outputFilePath);
        }
    }
}

