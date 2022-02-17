using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ToolCollection : iToolCollection
    {
        private int number;
        private Tool[][] collection;
        public ToolCollection(int category)
        {
            if (category == 1)
            {
                collection = new Tool[5][];
            }
            else
            {
                collection = new Tool[6][];
            }
        }                              
        public int Number
        {
            get { return number; }
        }
        public Tool[][] Collection
        {
            get { return collection; }
        }

        public void add(Tool aTool)
        {
            aTool.Quantity = 1;
            aTool.AvailableQuantity = 1;

            string input = Console.ReadLine();
            int type = int.Parse(input)-1;
            List<Tool> temp = new List<Tool>();
            if (collection[type] != null)
            {
                temp = collection[type].ToList();
            }
            temp.Add(aTool);
            collection[type] = temp.ToArray();
            number++;

            Console.Write("\nSuccessfully added tool "+aTool.Name+"\n"+
                              "\nPress any key to continue");
            Console.ReadKey();
        }

        public void delete(Tool aTool)
        {
            string input = Console.ReadLine();
            int type = int.Parse(input) - 1;
            List<Tool> temp = new List<Tool>();
            if (collection[type] != null)
            {
                temp = collection[type].ToList();
            }
            temp.Remove(aTool);
            collection[type] = temp.ToArray();
            number--;
            Console.Write("\nSuccessfully removed tool " + aTool.Name + "\n" +
                              "\nPress any key to continue");
            Console.ReadKey();
        }

        public bool search(Tool aTool)
        {
            for (int i = 0; i < number - 1; i++)
            {
                if (collection[i] != null)
                {
                    foreach (Tool tool in collection[i])
                    {
                        if (tool == aTool)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public Tool[] toArray()
        {
            List<Tool> temp = new List<Tool>();
            for (int i = 0; i < number-1; i++)
            {
                if (collection[i] != null)
                {
                    foreach (Tool tool in collection[i])
                    {
                        temp.Add(tool);
                    }
                }
            }
            Tool[] tool_return = temp.ToArray();
            return tool_return;
        }
    }
}
