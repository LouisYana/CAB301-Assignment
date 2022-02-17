using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    //Interface is commented out as a return value was changed.
    public class ToolLibrarySystem //: iToolLibrarySystem
    {
        //9 tool collections for each of the categories
        private ToolCollection gardening = new ToolCollection(1);
        private ToolCollection flooring = new ToolCollection(2);
        private ToolCollection fencing = new ToolCollection(1);
        private ToolCollection measuring = new ToolCollection(2);
        private ToolCollection cleaning = new ToolCollection(2);
        private ToolCollection painting = new ToolCollection(2);
        private ToolCollection electronic = new ToolCollection(1);
        private ToolCollection electricity = new ToolCollection(1);
        private ToolCollection automotive = new ToolCollection(2);

        //Member collection and current member inofrmation
        private MemberCollection memberCollection = new MemberCollection();
        private Member currentMember;

        //variables to be used
        public string[][] types = new string[9][];
        public string[] categories = new string[9];

        public ToolLibrarySystem()
        {
            //Names of the categories for reference
            categories[0] = "Gardening Tools";
            categories[1] = "Flooring Tools";
            categories[2] = "Fencing Tools";
            categories[3] = "Measuring Tools";
            categories[4] = "Cleaning Tools";
            categories[5] = "Painting Tools";
            categories[6] = "Electronic Tools";
            categories[7] = "Electricity Tools";
            categories[8] = "Automotive Tools";
            
            //Names of the types for reference
            types[0] = new string[5];
            types[0][0] ="Line Trimmers" ;
            types[0][1] ="Lawn Mowers" ;
            types[0][2] ="Hand Tools" ;
            types[0][3] ="Wheelbarrows" ;
            types[0][4] ="Garden Power Tools";
            types[1] = new string[6];
            types[1][0] = "Scrapers";
            types[1][1] = "Floor Lasers";
            types[1][2] = "Floor Leveling Tools";
            types[1][3] = "Floor Leveling Materials";
            types[1][4] = "Floor Hand Tools";
            types[1][5] = "Tiling Tools";
            types[2] = new string[5];
            types[2][0] = "Hand Tools";
            types[2][1] = "Electric Fencing";
            types[2][2] = "Steel Fencing Tools";
            types[2][3] = "Power Tools";
            types[2][4] = "Fencing Accessories";
            types[3] = new string[6];
            types[3][0] = "Distance Tools";
            types[3][1] = "Laser Measurer";
            types[3][2] = "Measuring Jugs";
            types[3][3] = "Temperature & Humidity Tools";
            types[3][4] = "Leveling Tools";
            types[3][5] = "Markers";
            types[4] = new string[6];
            types[4][0] = "Draining";
            types[4][1] = "Car Cleaning";
            types[4][2] = "Vacuum";
            types[4][3] = "Pressure Cleaners";
            types[4][4] = "Pool Cleaning";
            types[4][5] = "Floor Cleaning";
            types[5] = new string[6];
            types[5][0] = "Saning Tools";
            types[5][1] = "Brushes";
            types[5][2] = "Rollers";
            types[5][3] = "Paint Removal Tools";
            types[5][4] = "Paint Scrapers";
            types[5][4] = "Sprayers";
            types[6] = new string[5];
            types[6][0] = "Voltage Tester";
            types[6][1] = "Oscilloscopes";
            types[6][2] = "Thermal Imaging";
            types[6][3] = "Data Test Tool";
            types[6][4] = "Insulation Testers";
            types[7] = new string[5];
            types[7][0] = "Test Equipment";
            types[7][1] = "Safety Equipment";
            types[7][2] = "Basic Hand Tools";
            types[7][3] = "Circuit Protection";
            types[7][4] = "Cable Tools";
            types[8] = new string[6];
            types[8][0] = "Jacks";
            types[8][1] = "Air Compressors";
            types[8][2] = "Battery Chargers";
            types[8][3] = "Socket Tools";
            types[8][4] = "Braking";
            types[8][5] = "Drivetrain"; 
        }

        //Function to return the correct collection
        private Tool[][] Collection_Return(int category)
        {
            if (category == 1)
            {
                return gardening.Collection;
            }
            else if (category == 2)
            {
                return flooring.Collection;
            }
            else if (category == 3)
            {
                return fencing.Collection;
            }
            else if (category == 4)
            {
                return measuring.Collection;
            }
            else if (category == 5)
            {
                return cleaning.Collection;
            }
            else if (category == 6)
            {
                return  painting.Collection;
            }
            else if (category == 7)
            {
                return electronic.Collection;
            }
            else if (category == 8)
            {
                return  electricity.Collection;
            }
            else if (category == 9)
            {
                return  automotive.Collection;
            }
            return null;
        }

        //Function to print out a list of the category names
        private void Display_Categories()
        {
            Console.WriteLine("\nSelect the Category\n");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + categories[i]);
            }
        }

        //Function to print out a lsit of the type names
        private void Display_Types(int category)
        {
            for (int i = 0; i < types[category-1].Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + types[category-1][i]);
            }
        }

        //Function to print out all the tools of a category and type
        private void Display_Tools(int category, int type)
        {
            Tool[][] collection = Collection_Return(category);
            if (collection[type] != null)
            {
                Console.WriteLine("\tName\tQuantity\tAvailable Quantity");
                for (int i = 0; i < collection[type].Length; i++)
                {
                    Console.WriteLine((i + 1) + ".\t" + collection[type][i].Name + "\t" + collection[type][i].Quantity + "\t\t" +
                        "" + collection[type][i].AvailableQuantity);
                }
            }
        }

        //Add tool to the tool collection
        public void add(Tool aTool)
        {
            Display_Categories();
            Console.Write("\nSelect option from menu: ");
            string category = Console.ReadLine();
            int int_category = int.Parse(category);
            Console.Write("\nSelect the Tool Type\n\n");
            Display_Types(int_category);
            Console.Write("\nSelect option from menu: ");
            if (category == "1")
            {
                gardening.add(aTool);
            }
            else if(category == "2") 
            {
                flooring.add(aTool);
            }
            else if (category == "3")
            {
                fencing.add(aTool);
            }
            else if (category == "4")
            {
                measuring.add(aTool);
            }
            else if (category == "5")
            {
                cleaning.add(aTool);
            }
            else if (category == "6")
            {
                painting.add(aTool);
            }
            else if (category == "7")
            {
                electronic.add(aTool);
            }
            else if (category == "8")
            {
                electricity.add(aTool);
            }
            else if (category == "9")
            {
                automotive.add(aTool);
            }
            else
            {
                Console.Write("Incorrect input\n"+
                    "Press any key to continue: ");
                Console.ReadKey();
            }
        }

        //Increase quantity of a Tool
        public void add(Tool aTool, int quantity)
        {
            Display_Categories();
            Console.Write("\nSelect option from menu: ");
            string input = Console.ReadLine();
            int category = int.Parse(input);
            Console.Write("\nSelect the Tool Type\n\n");
            for (int i = 0; i < types[category].Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + types[category][i]);
            }
            Console.Write("\nSelect option from menu: ");
            input = Console.ReadLine();
            int type = int.Parse(input)-1;
            Tool[][] collection = Collection_Return(category);
            Console.WriteLine();
            if (collection[type] != null)
            {
                Console.WriteLine("\tName\tQuantity");
                for (int i = 0; i < collection[type].Length; i++)
                {
                    Console.WriteLine((i + 1) + ".\t" + collection[type][i].Name + "\t" + collection[type][i].Quantity);
                }
            }
            Console.Write("\nWhich Tool would you like to update: ");
            string tool_input = Console.ReadLine();
            int int_tool_input = int.Parse(tool_input) - 1;
            Console.Write("\nHow much are you adding: ");
            string quantity_input = Console.ReadLine();
            int int_quantity_input = int.Parse(quantity_input);

            //Increasing quantity and available quantity of the tool
            collection[type][int_tool_input].Quantity += int_quantity_input;
            collection[type][int_tool_input].AvailableQuantity += int_quantity_input;
            Console.Write("\nUpdated the quantity of " + collection[type][int_tool_input].Name +
                " in the library to " + collection[type][int_tool_input].Quantity+"\n"+
                "\nPress any key to continue");
            Console.ReadKey();

        }

        //Function to add member and check members contact details and verify login
        public bool add(Member aMember, int option)
        {
            if (option == 0) // Add Member
            {
                memberCollection.add(aMember);
                Console.Write("Successfully added member " + aMember.FirstName + " " + aMember.LastName + "\n\n" +
                              "Press any key to continue: ");
                Console.ReadKey();
                return false;
            }
            else //Find members contact details or verify login
            {
                return (search(aMember));
            }
        }

        //Function to let user borrow a Tool
        public void borrowTool(Member aMember, Tool aTool)
        {
            //Check if they have borrowed the limit of tools
            if (currentMember.Amount_Borrowed >= 3)
            {
                Console.Write("You cannot borrow more than 3 items at a time, please return item before borrowing\n" +
                              "Press any key to continue: ");
                Console.ReadKey();
            }
            else
            {
                Display_Categories();
                Console.Write("\nSelect option from menu: ");
                string input = Console.ReadLine();
                int category = int.Parse(input);
                Display_Types(category);
                Console.Write("\nSelect option from menu: ");
                input = Console.ReadLine();
                int type = int.Parse(input) - 1;
                Display_Tools(category, type);
                Console.Write("\nPlease select the tool you want to borrow: ");
                input = Console.ReadLine();
                int int_tool = int.Parse(input) - 1;
                Tool[][] collection = Collection_Return(category);

                //Add tool to the member currently logged in
                currentMember.addTool(collection[type][int_tool]);
                Console.Write("\n"+currentMember.FirstName + " has succesfully borrowed " + collection[type][int_tool].Name+"\n"+
                    "\nPress any key to continue: ");
                Console.ReadKey();
            }
        }

        //Function to delete a Tool
        public void delete(Tool aTool)
        {
            Display_Categories();
            Console.Write("\nSelect option from menu: ");
            string input = Console.ReadLine();
            int category = int.Parse(input);
            Console.Write("\nSelect the Tool Type\n\n");
            for (int i = 0; i < types[category].Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + types[category][i]);
            }
            Console.Write("\nSelect option from menu: ");
            input = Console.ReadLine();
            int type = int.Parse(input) - 1;
            Tool[][] collection = Collection_Return(category);
            Console.WriteLine();
            if (collection[type] != null)
            {
                Console.WriteLine("\tName\tQuantity");
                for (int i = 0; i < collection[type].Length; i++)
                {
                    Console.WriteLine((i + 1) + ".\t" + collection[type][i].Name + "\t" + collection[type][i].Quantity);
                }
            }
            Console.Write("\nWhich Tool would you like to delete: ");
            string tool_input = Console.ReadLine();
            int int_tool_input = int.Parse(tool_input) - 1;
            
        }

        //Function to reduce a Tools quantity
        public void delete(Tool aTool, int quantity)
        {
            Display_Categories();
            Console.Write("\nSelect option from menu: ");
            string input = Console.ReadLine();
            int category = int.Parse(input);
            Console.Write("\nSelect the Tool Type\n\n");
            for (int i = 0; i < types[category].Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + types[category][i]);
            }
            Console.Write("\nSelect option from menu: ");
            input = Console.ReadLine();
            int type = int.Parse(input) - 1;
            Tool[][] collection = Collection_Return(category);
            Console.WriteLine();
            if (collection[type] != null)
            {
                Console.WriteLine("\tName\tQuantity");
                for (int i = 0; i < collection[type].Length; i++)
                {
                    Console.WriteLine((i + 1) + ".\t" + collection[type][i].Name + "\t" + collection[type][i].Quantity);
                }
            }
            Console.Write("\nWhich Tool would you like to update: ");
            string tool_input = Console.ReadLine();
            int int_tool_input = int.Parse(tool_input) - 1;
            Console.Write("\nHow much are you removing: ");
            string quantity_input = Console.ReadLine();
            int int_quantity_input = int.Parse(quantity_input);

            //Decrease a tools quantity
            collection[type][int_tool_input].Quantity -= int_quantity_input;
            collection[type][int_tool_input].AvailableQuantity -= int_quantity_input;
            Console.Write("\nUpdated the quantity of " + collection[type][int_tool_input].Name + " in the library to " + collection[type][int_tool_input].Quantity+"\n"+
            "Press any key to continue: ");
            Console.ReadKey();
        }

        //Function to delete member from member collection
        public void delete(Member aMember)
        {
            memberCollection.delete(aMember);
        }

        //Function to display all the tools that a member is borrowing
        public void displayBorrowingTools(Member aMember)
        {
            for(int i = 0; i < currentMember.Amount_Borrowed; i++)
            {
                Console.WriteLine((i + 1) + ". " + currentMember.Tools[i]);
            }
            Console.Write("\nPlease enter any key to continue: ");
            Console.ReadKey();
        }

        //Function to display tools of a given type
        public void displayTools(string aToolType)
        {
            Display_Categories();
            Console.Write("Select option from menu: ");
            string input = Console.ReadLine();
            int category = int.Parse(input);
            Console.Write("\nSelect the Tool Type\n");
            for (int i = 0; i < types[category].Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + types[category][i]);
            }
            Console.Write("Select option from menu: ");
            input = Console.ReadLine();
            int type = int.Parse(input) - 1;
            Tool[][] collection = Collection_Return(category);
            
            if (collection[type] != null)
            {
                Console.WriteLine("\tName\tQuantity\tAvailable Quantity");
                for (int i = 0; i < collection[type].Length; i++)
                {
                    Console.WriteLine((i + 1) + ".\t" + collection[type][i].Name + "\t" + collection[type][i].Quantity+"\t\t" +
                        ""+collection[type][i].AvailableQuantity);
                }
            }
            Console.Write("\nPlease enter any key to continue: ");
            Console.ReadKey();
        }

        //Function to print out the top three most borrowed items
        public void displayTopTHree()
        {
            Tool[] allTools;
            Tool[] topThree = new Tool[3];
            List<Tool> toolList;

            //Gathering every tool in the TLS
            allTools = gardening.toArray().Concat(flooring.toArray()).Concat(fencing.toArray()).Concat(measuring.toArray()).Concat(cleaning.toArray()).Concat(painting.toArray()).Concat(electronic.toArray()).Concat(electricity.toArray()).Concat(automotive.toArray()).ToArray();
            
            //Maximum Key Deletion algorithm
            for (int i = 0; i < 3; i++)
            {
                allTools = HeapBottomUp(allTools);
                topThree[i] = allTools[0];
                allTools[0] = allTools[allTools.Length - 1];
                toolList = new List<Tool>(allTools);
                toolList.RemoveAt(allTools.Length - 1);
                allTools = toolList.ToArray();
            }
            Console.Write("\tName\t\tAmount Borrowed\n");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t"+topThree[i].Name+"\t\t"+topThree[i].NoBorrowings);
            }
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
        }

        //Function to return a list of tools a user is borrowing
        public string[] listTools(Member aMember)
        {
            return aMember.Tools;
        }

        //Function that returns a tool
        public void returnTool(Member aMember, Tool aTool)
        {
            string[] list_tools = listTools(currentMember);

            //Check if the user has any tools currently borrowed
            if (currentMember.Amount_Borrowed == 0)
            {
                Console.Write("You have no tools to return\n\n" +
                    "Press any key to continue: ");
                Console.ReadKey();
            }
            else
            {
                for (int i = 0; i < currentMember.Amount_Borrowed; i++)
                {
                    Console.WriteLine((i + 1) + ". " + list_tools[i]);
                }
                Console.Write("Please select from the following options: ");
                string input = Console.ReadLine();
                int toolPosition = int.Parse(input) - 1;
                currentMember.deleteTool(new Tool(list_tools[toolPosition]));

                Console.Write("\nSuccessfully returned "+list_tools[toolPosition]+
                    "\n\nPlease enter any key to continue: ");
                Console.ReadKey();
            }
        }
        
        //Search Funtion that doubles as a contact getter and a login verification
        private bool search(Member aMember)
        {
            //Find member with those details
            Member found = memberCollection.search(aMember);

            //If member isnt null
            if (found!=null)
            {
                //Set current member as the found member
                currentMember = found;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Heap bottom up function to turn the array into a heap
        static Tool[] HeapBottomUp(Tool[] input)
        {
            double n = input.Length - 1;
            int k;
            Tool v;
            int j;
            bool heap;
            for (int i = (int)Math.Ceiling(n / 2); i >= 0; i--)
            {
                k = i;
                v = input[k];
                heap = false;
                while (!heap && 2 * k <= n) //Heapify
                {
                    j = 2 * k;
                    if (j < n)
                    {
                        if (input[j].NoBorrowings < input[j + 1].NoBorrowings)
                        {
                            j++;
                        }
                    }
                    if (v.NoBorrowings >= input[j].NoBorrowings)
                    {
                        heap = true;
                    }
                    else
                    {
                        input[k] = input[j];
                        k = j;
                    }
                }
                input[k] = v;
            }
            return input;
        }
    }
}
