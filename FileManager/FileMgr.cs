using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeAnalysis
{
    public class FileManager
    {

        private List<string> files = new List<string>();
        private List<string> patterns = new List<string>();
        //private bool recurse = true;

        public void findFiles(string path,List<string> patterns,bool recurse)
        {
            if (patterns.Count == 0)
                addPattern("*.*");
            foreach (string pattern in patterns)
            {
                string[] newFiles = Directory.GetFiles(path, pattern);
                for (int i = 0; i < newFiles.Length; i++)
                    newFiles[i] = Path.GetFullPath(newFiles[i]);
                files.AddRange(newFiles);
            } 
            if (recurse)
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                    findFiles(dir,patterns,recurse);
            }
        }

        public void addPattern(string pattern)
        {
            patterns.Add(pattern);
        } 

        public List<string> getFiles()
        {
            return files;
        } 
        static void Main(string[] args)
        {
           /* Console.Write("Testing FileMgr Class");
            Console.Write("\n======================\n");

            FileManager fm = new FileManager();
            fm.addPattern("*.*");
            fm.findFiles("../../");
            List<string> files = fm.getFiles();
            foreach (string file in files)
                Console.Write("\n  {0}", file);
            Console.ReadLine(); */
        }
    }
}
