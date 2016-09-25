using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CodeAnalysis
{
   public class XMLProcessor
    {

       public void process()
       {

           XmlDocument doc1 = new XmlDocument();
           doc1.LoadXml(" <codeAnalysis>   </codeAnalysis> ");

           XmlNode root = doc1.DocumentElement;

           Repository rep = Repository.getInstance();
           List<Elem> table = rep.locations;
           List<Elem> temp = rep.locations;

           //FOR DISPLAYING NAMESCAPE,CLASSES AND FUNCTIONS

           foreach(Elem e in table)
           {

               if(e.type.Equals("namespace"))
               {
                   //Create a new node.
                   XmlElement nameNode = doc1.CreateElement("namespace");
                   nameNode.SetAttribute("name", e.name);
                  // nameNode.SetAttribute("begin with", e.begin.ToString());
                  // nameNode.SetAttribute("end with", e.end.ToString());
                   root.AppendChild(nameNode);
               }

               if (e.type.Equals("class"))
               {

                   XmlElement classNode = doc1.CreateElement("class");
                    classNode.SetAttribute("name", e.name);
                    //classNode.SetAttribute("begin with", e.begin.ToString());
                    //classNode.SetAttribute("end with", e.end.ToString());
                    root.AppendChild(classNode);
               }

               if (e.type.Equals("function"))
               {
                   int size = e.end - e.begin;
                   int complexity = 0;
                   foreach (Elem t in temp)
                   {
                       if (t.type.Equals("control") && (t.begin > e.begin) && (t.end < e.end))
                           complexity++;
                       if (t.type.Equals("braceless") && (t.begin > e.begin) && (t.end < e.end))
                           complexity++;

                   }

                   XmlElement funtNode = doc1.CreateElement("function");
                   funtNode.SetAttribute("name", e.name);
                   funtNode.SetAttribute("size", size.ToString());
                   funtNode.SetAttribute("complexity", complexity.ToString());
                   root.AppendChild(funtNode);

               }

           }
           doc1.Save("Functions.xml");


           //FOR DISPLAYING RELATIONSHIPS

           XmlDocument doc2 = new XmlDocument();
           doc2.LoadXml(" <codeAnalysis>   </codeAnalysis> ");

           XmlNode root2 = doc2.DocumentElement;

           List<RelElem> table2 = rep.inheritance;

           List<RelElem> temp2 = rep.inheritance;

           foreach (Elem ee in table)
           {
               if (ee.type.Equals("class"))
               {
                   //CREATE NODE

                   XmlElement classNode = doc2.CreateElement("class");
                   classNode.SetAttribute("name", ee.name);
                   root2.AppendChild(classNode);

                   foreach (RelElem rr in table2)
                   {
                       if (rr.beginRel > ee.begin && rr.endRel < ee.end && ee.name != rr.withName && rr.type != "UsingTemp")
                       {
                           XmlElement relNode = doc2.CreateElement("relationship");
                           relNode.SetAttribute("type", rr.type);
                           relNode.SetAttribute("with", rr.withName);
                          // relNode.SetAttribute("begin with", rr.beginRel.ToString());
                           //relNode.SetAttribute("end with", rr.endRel.ToString());
                           classNode.AppendChild(relNode);

                          // Console.WriteLine("\nclass {0} has {1} relationship with {2}", ee.name, rr.type, rr.withName);
                       }
                   }
               }
           }

           doc2.Save("Relationships.xml");
           
           //Create a new node.
          /* XmlElement elem = doc1.CreateElement("price");
           // elem.InnerText="19.95";
           elem.SetAttribute("name", "myName");

           //Add the node to the document.
           root.InsertAfter(elem, root.FirstChild);

           XmlElement child = doc1.CreateElement("imchild");
           child.InnerText = "df";

           elem.AppendChild(child);*/

           Console.WriteLine("Display the modified XML...");
           
           Console.ReadLine();

       }
        static void Main(string[] args)
        {
        }
    }
}
