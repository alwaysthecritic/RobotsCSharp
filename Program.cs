using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTableRobots
{
	class Program
	{
		public static void Main (string[] args)
		{
            if (args.Length == 0) {
                Console.WriteLine("Usage: battle <filePath>");
            } else {
                try {
                    var filePath = args[0];
                    Config config = ReadConfig(filePath);
                    List<Robot> results = new Battle(config).Run();
                    WriteResults(results);
                }
                catch (Exception e) {
                    // qq Does this actually provide good messages for all types of exception,
                    //    from file loading and config parsing?
                    Console.WriteLine(e.Message);
                }
            }
		}

        private static Config ReadConfig(String filePath) {
            string[] lines = System.IO.File.ReadAllLines(filePath, Encoding.UTF8);
            return new ConfigParser().Parse(lines);
        }

        private static void WriteResults(List<Robot> results) {

        }
	}
}
