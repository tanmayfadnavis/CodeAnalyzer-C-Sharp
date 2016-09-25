using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeAnalysis
{
    public class CommandLineParser
    {

        public void splitArgument(string[] args, out string path, out List<string> patterns, out List<string> options)
        {
            path = "";
            options = new List<string>();
            patterns = new List<string>();
            if (args.Length == 0)
            {
                path = "../../";
                patterns.Add("*.*");
            }
            foreach (string arg in args)
            {
                // Console.WriteLine(Directory.Exists(arg));
                //  string[] files = Directory.GetFiles(arg, "*.*");
                // foreach(string file in files)
                //  Console.WriteLine(file); 
                if (path.Length == 0)
                {
                    if (Directory.Exists(arg))
                        path = arg;
                }
                if (!(Directory.Exists(arg)))
                {
                    if (arg.Contains("/S") || arg.Contains("/X") || arg.Contains("/R"))
                        options.Add(arg);
                    else
                        patterns.Add(arg);
                }

            }

        }






        static void Main(string[] args)
        {
            Console.WriteLine("Demonstrating command line arguments \n");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");


            try
            {

                CommandLineParser argument = new CommandLineParser();

                string path;
                List<string> pattern;
                List<string> options;

                Console.WriteLine("Command Line Argument is = \n" + args);
                argument.splitArgument(args, out path, out pattern, out options);
                if (path.Length == 0)
                    path = "../../";
                // Console.WriteLine("path is {0} pattern is {1} option is {2}", temp[0], temp[1], temp[2]);
                Console.WriteLine("File Path is {0}\nFile Pattern is {1}\nOptions are{2}", path, pattern, options);

            }

            catch (Exception e)
            {
                Console.WriteLine("There is an error in command line {0} \n", args);
                Console.WriteLine("\n Error Message {0} \n \n", e.Message);
            }

            //Console.ReadLine();
        }

    }

    }
