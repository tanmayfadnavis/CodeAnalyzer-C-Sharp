/////////////////////////////////////////////////////////////////////////
// ScopeStack.cs  -  Generic stack to help with static analysis        //
//                   Holds application specific Element type           //
// ver 1.0                                                             //
// Language:    C#, Visual Studio 13.0, .Net Framework 4.5             //
// Platform:    Lenovo V570, Win 7, SP 1                              //
// Application: Pr#2  CSE681, Fall 2014                               //
// Author:     Tanmay Fadnavis, Syracuse University,                  //
//                 tfadnavi@syr.edu                                  //
/////////////////////////////////////////////////////////////////////////
/*
 * Package Operations
 * ==================
 * The Executive package via the class Executive, provides the entry point
 * for the code analyzer. It communicates with CommandLineParser package,
 * FileManager package,Analyzer Package,Display Package and XML processor
 * Package. It communicates the output of one package to the other.
 * 
 * 
 *
/*
 * Build Process
 * =============
 * Required Files:
 *   Executive.cs, CmdLine.cs, FileMgr.cs,Analyzer.cs,Display.cd,XMLProcessor.cs
 * 
 * Compiler Command:
 *   csc /target:exe /define:TEST_EXECUTIVE Executive.cs, CmdLine.cs, FileMgr.cs /
 *   Analyzer.cs,Display.cd,XMLProcessor.cs
 * 
 * Maintenance History
 * ===================
 * ver 1.0 : Oct 2014
 *   - first release
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis
{
    class Executive
    {
        private string path;
        private List<string> pattern=new List<string>();
        private List<string> options=new List<string>();
        private bool recurse;

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public  bool Recurse
        {
            get
            {
                return recurse;
            }

            set
            {
                recurse = value;
            }
        }
        static public string[] getFiles(string path, List<string> patterns,bool recurse)
        {
            FileManager fm = new FileManager();
            foreach (string pattern in patterns)
                fm.addPattern(pattern);

            fm.findFiles(path,patterns,recurse);
            return fm.getFiles().ToArray();

        }

      

        static void Main(string[] args)
        {
            Executive e = new Executive();
            
            
                try
                {

                    CommandLineParser argument = new CommandLineParser();

                    //Console.WriteLine("Command Line Argument is = \n" + arg);
                    argument.splitArgument(args, out e.path, out e.pattern, out e.options);

                   // Console.WriteLine("path is {0}", e.path);
                    if (e.path.Length == 0)
                        e.path = "../../";
                   

                    //Console.WriteLine("File Path is {0}\nFile Pattern is {1}\nOptions are{2}", e.Path, e.pattern, e.options);

                }

                catch (Exception exp)
                {
                    Console.WriteLine("There is an error in command line {0} \n", args);
                    Console.WriteLine("\n Error Message {0} \n \n", exp.Message);
                }
            
            Console.WriteLine(e.Recurse);
            e.Recurse=e.options.Contains("/S");
            Console.WriteLine(e.Recurse);   
                

            
            string[] files = Executive.getFiles(e.path,e.pattern,e.Recurse);

            Analyzer ana = new Analyzer();

            Display d = new Display();
                
           
                 ana.doAnalysis(files);
                 d.display();
            

             Console.WriteLine("after display");

             XMLProcessor xp = new XMLProcessor();

             xp.process();


            Console.ReadLine();
        }

        
    }
}
