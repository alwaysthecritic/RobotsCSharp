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

            File.Delete(outputFilePath);

            var args = new string[] { configFilePath,  outputFilePath };
            Program.Main(args);

            var output = File.ReadAllText(outputFilePath);
            var expectedOutput = "1 3 N" + Environment.NewLine + "5 1 E" + Environment.NewLine;
            Assert.AreEqual(expectedOutput, output);

            // Clean up.
            File.Delete(outputFilePath);
        }
    }
}

