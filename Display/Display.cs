using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAnalysis
{
   public class Display
    {

        public void display()
        {

            Repository rep = Repository.getInstance();
            List<Elem> table = rep.locations;
                
                //DISPLAY LOCATION TABLE

                Console.Write("\n\n  locations table contains:");

               // Console.WriteLine("repository locations are {0} \n",rep.locations);

                foreach (Elem e in table)
                {
                    Console.Write("\n  {0,10}, {1,25}, {2,5}, {3,5}", e.type, e.name, e.begin, e.end);
                }
                Console.WriteLine();
                Console.Write("\n\n  That's all folks!\n\n");

                // COUNT FOR COMPLEXITY AND FUNCTION SIZES

                List<Elem> temp = rep.locations;

                foreach(Elem e in table)
                {
                    if(e.type.Equals("namespace"))
                    {
                        Console.WriteLine("\n {0,10},{1,25},{2,5},{3,5}", e.type, e.name, e.begin, e.end);
                    }

                    //search for the namespace for that particular class

                    if(e.type.Equals("class"))
                    {
                        foreach(Elem tt in temp)
                        {
                            if(tt.type.Equals("namespace"))
                            {
                                if((tt.begin < e.begin) && (tt.end > e.end))
                                {
                                    Console.WriteLine("\n{0,10},{1,10}.{2,5},{3,5},{4,5}", e.type, tt.name, e.name, e.begin, e.end);
                                }
                            }
                        }


                    }
                    if(e.type.Equals("function"))
                    {
                        int size = e.end - e.begin;
                        int complexity=0;
                        foreach(Elem t in temp)
                        {
                            if(t.type.Equals("control") && (t.begin > e.begin) && (t.end < e.end))
                                complexity++;
                            if (t.type.Equals("braceless") && (t.begin > e.begin) && (t.end < e.end))
                                complexity++;

                        }

                        Console.WriteLine("\n Function name is{0,10} size is{1,5} complexity is{2,5}", e.name, size, complexity);

                    }

                }

                //DISPLAY RELATIONSHIPS

                List<RelElem> table2 = rep.inheritance;

                List<RelElem> temp2 = rep.inheritance;
               //Console.Write("\n\n  relationship table contains:");
                
                
                foreach (RelElem e in table2)
                {
                    Console.Write("\n  {0,10}, {1,25},{2,20}, {3,5}, {4,5}", e.type, e.name, e.withName, e.beginRel, e.endRel);
                }
                Console.WriteLine();
                Console.Write("\n\n  That's all folks!\n\n");
                Console.ReadLine();
                
                //DISPLAY FINAL RELATIONSHIPS

               /* foreach(Elem ee in table)
                {
                    if(ee.type.Equals("class"))
                    {
                        foreach(RelElem rr in table2)
                        {
                            if(rr.beginRel > ee.begin && rr.endRel < ee.end && ee.name != rr.withName && rr.type!="UsingTemp")
                            {
                                Console.WriteLine("\nclass {0} has {1} relationship with {2}", ee.name, rr.type, rr.withName);
                            }
                        }
                    }
                } */
     
        }

        static void Main(string[] args)
        {
        }
    }
}
