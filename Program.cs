using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace OpenTableRobots
{
	public class Program
	{
		public static void Main (string[] args)
		{
            if (args.Length < 2) {
                Console.WriteLine("Usage: battle <configFilePath> <outputFilePath>");
            } else {
                // All Exceptions (IO and otherwise) are handled as one.
                try {
                    var configFilePath = args[0];
                    var outputFilePath = args[1];

                    Config config = ReadConfig(configFilePath);
                    List<Robot> results = new Battle(config).Run();
                    WriteResults(outputFilePath, results);
                }
                catch (Exception e) {
                    // qq Does this actually provide good messages for all types of exception,
                    //    from file loading and config parsing?
                    Console.WriteLine(e.Message);
                }
            }
		}

        private static Config ReadConfig(string filePath) {
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            return new ConfigParser().Parse(lines);
        }

        private static void WriteResults(string filePath, List<Robot> results) {
            var outputLines = results.Select(robot => GenerateOutputLine(robot));
            File.WriteAllLines(filePath, outputLines);
        }

        private static string GenerateOutputLine(Robot robot) {
            return string.Format("{0} {1} {2}", robot.X, robot.Y, robot.Facing);
        }
	}
}
