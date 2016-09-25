/////////////////////////////////////////////////////////////////////////
// CmdLine.cs  -  Package to parse command line arguments                  //
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
 * The analyzer package takes the input from the eecutive package.
 * The input are the files to be processed and it sends the files
 * to the parser for analysis.
 * 
 * Public Interface
 * ================
 *
 * public void doAnalysis(string[] files)
 * 
/*
 * Build Process
 * =============
 * Required Files:
 *   Analyzer.cs
 *   
 * Build command:
 *   csc /D:TEST_ANA Analyzer.cs FileMgr.cs
 *
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
   public class Analyzer
    {

       public void doAnalysis(string[] files)
       {

           
               //Console.Write("\n  Processing file {0}\n", file as string);

               //CSsemi.CSemiExp semi = new CSsemi.CSemiExp();
               //semi.displayNewLines = false;
              // if (!semi.open(file as string))
               //{
                //   Console.Write("\n  Can't open {0}\n\n", file);
                 //  return;
               //}

               Parser p = new Parser();
               p.parseFiles(files);

           //  semi.close();


           
       }

#if(TEST_ANA)
       static void Main(string[] args)
        {
          Console.Write("Testing FileMgr Class");
            Console.Write("\n======================\n");

            FileManager fm = new FileManager();
            fm.addPattern("*.cs");
            fm.findFiles("../../");
            List<string> files = fm.getFiles();
            foreach (string file in files)
                Console.Write("\n  {0}", file);
            Analyzer a=new Analyzer()
            doAnalysis(files);
            Console.ReadLine(); 

        }
#endif
    }
}
