using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class MainMenu
    {
        public MainMenu() { }

        //
        public static ToolLibrarySystem toolLibrarySystem = new ToolLibrarySystem();
        
        //Entry Point from program.cs
        public void Start()
        {
            Main_Menu();
        }
        static void Main_Menu()
        {
            Console.Clear();
            Console.Write("Welcome to the Tool Library\n"+
                          "===========Main Menu===========\n"+
                          "1. Staff Login\n"+
                          "2. Member Login\n"+
                          "0. Exit\n"+
                          "===============================\n");
            
            while (true)
            {
                Console.Write("\nPlease make a selection (1-2, or 0 to exit): ");
                string info = Console.ReadLine();
                if (int.TryParse(info, out int input))
                {
                    //If user wants to log into staff menu
                    if (input == 1)
                    {
                        //Asking user for inputs
                        Console.WriteLine("\nPlease enter username and password\n");
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();

                        //Checking if username/password is correct
                        if (username == "staff" && password == "today123")
                        {
                            Staff_Menu();
                        }
                        else
                        {
                            Console.Write("\nIncorrect Username or Password\n"+
                                "\nPress any key to continue: ");
                            Console.Read();
                            Main_Menu();
                        }
                    }
                    //If user wants to log into member menu
                    else if (input == 2)
                    {
                        //Ask user for inputs
                        Console.Write("\nPlease enter first name, last name and password\n"+
                                      "First name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Password: ");
                        string PIN = Console.ReadLine();

                        //If member with those details are found
                        if(toolLibrarySystem.add(new Member(firstName, lastName, null, PIN),1))
                        {
                            Member_Menu();
                        }
                        //If not take user back to main menu
                        Console.Write("\nPress any key to continue: ");
                        Console.ReadKey();
                        Main_Menu();
                    }
                    //If user wants to exit
                    else if (input == 0)
                    {
                        System.Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Input");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input");
                }
            }
        }

        //Function that runs the staff menu functionalities
        static void Staff_Menu()
        {
            Console.Clear();
            Console.Write("Welcome to the Tool Library\n" +
                          "===========Staff Menu===========\n" +
                          "1. Add a new tool\n" +
                          "2. Add new pieces of an existing tool\n" +
                          "3. Remove some pieces of a tool\n" +
                          "4. Register a new member\n" +
                          "5. Remove a member\n" +
                          "6. Find the contact number of a member\n" +
                          "0. Return to main menu\n" +
                          "================================\n"+
                          "Please make a selection (1-6, or 0 to return to main menu): ");
            string input = Console.ReadLine();

            //Check what user inputted
            if (input == "1")
            {
                Add_New_Tool();
            }
            else if (input == "2")
            {
                Add_Tool_Quanity();
            }
            else if (input == "3")
            {
                Remove_Tool_Quanity();
            }
            else if (input == "4")
            {
                Register_New_Member();
            }
            else if (input == "5")
            {
                Remove_Member();
            }
            else if (input == "6")
            {
                Search_Member();
            }
            else if (input == "0")
            {
                MainMenu.Main_Menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input, please enter a number between 1-6, or 0 to return to main menu");
                Staff_Menu();
            }
            //Reset to staff menu when function actions are completed
            Staff_Menu();
        }

        //Functions for staff menu
        static void Add_New_Tool()
        {
            Console.Clear();
            Console.Write("Tool Library System - Add New Tool To Library\n"+
                          "=============================================\n"+
                          "Enter the name of the new Tool: ");
            string name = Console.ReadLine();
            toolLibrarySystem.add(new Tool(name));
        }
        static void Add_Tool_Quanity()
        {
            Console.Clear();
            Console.WriteLine("Tool Library System - Add Tools To Library\n"+
                              "==========================================");
            toolLibrarySystem.add(new Tool(""), 1);
        }
        static void Remove_Tool_Quanity()
        {
            Console.Clear();
            Console.WriteLine("Tool Library System - Remove Tools from Library\n"+
                              "===============================================");
            toolLibrarySystem.delete(new Tool(""), -1);
        }
        static void Register_New_Member()
        {
            Console.Clear();
            Console.Write("Tool Library System - Register new Member\n"+
                          "=========================================\n"+
                          "Please Enter the members first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Please Enter the members last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Please Enter the members contact number: ");
            string contactNumber = Console.ReadLine();
            Console.Write("Please Enter the members pin: ");
            string pin = Console.ReadLine();
            toolLibrarySystem.add(new Member(firstName, lastName, contactNumber, pin),0);
        }
        static void Remove_Member()
        {
            Console.Clear();
            Console.Write("Tool Library System - Remove Member\n" +
                          "===================================\n" +
                          "Please Enter the members first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Please Enter the members last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Please Enter the members contact number: ");
            string contactNumber = Console.ReadLine();
            Console.Write("Please Enter the members pin: ");
            string pin = Console.ReadLine();
            toolLibrarySystem.delete(new Member(firstName, lastName, contactNumber, pin));
        }
        static void Search_Member()
        {
            Console.Clear();
            Console.Write("Tool Library System - Search Member\n" +
                          "===================================\n" +
                          "Please Enter the members first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Please Enter the members last name: ");
            string lastName = Console.ReadLine();
            toolLibrarySystem.add(new Member(firstName, lastName, "0", "?"),1);
            Console.Write("\nPress any key to continue: ");
            Console.ReadKey();
        }
        static void Member_Menu()
        {
            Console.Clear();
            Console.Write("Welcome to the Tool Library\n"+
                          "===========Member Menu===========\n"+
                          "Member Menu\n"+
                          "1. Display all the tools of a tool type\n"+
                          "2. Borrow a tool\n" +
                          "3. Return a tool\n" +
                          "4. List all the tools that I am renting\n" +
                          "5. Display top three (3) most frequentely rented tools\n" +
                          "0. Return to main menu\n"+
                          "=================================\n"+
                          "Please make a selection (1-5, or 0 to return to main menu): "                        );
            string input = Console.ReadLine();

            //Read input to see what user wants
            if(input == "1")
            {
                Console.Clear();
                Console.Write("Tool Library System - Display Tools\n" +
                          "===================================\n");
                Display_Tool_Types();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.Write("Tool Library System - Borrow Tool\n" +
          "===================================\n");
                Borrow_Tool(); 
            }
            else if (input == "3")
            {            
                Console.Clear();
                Console.Write("Tool Library System - Return Tool\n" +
         "===================================\n");
                Return_Tool();
            }
            else if (input == "4")
            {
                Console.Clear();
                Console.Write("Tool Library System - Display Tools Borrowed\n" +
          "===================================\n");
                Display_Tools_Borrowed();
            }
            else if (input == "5")
            {
                Console.Clear();
                Console.Write("Tool Library System - Display Top 3 Most Frequently Borrowed Tools\n" +
          "===================================\n");
                Display_Top_Three();
            }
            else if (input == "0")
            {
                Main_Menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input, please enter a number between 1-5, or 0 to return to main menu");
                Member_Menu();
            }
            Member_Menu();
        }
        //Member menu functions
        static void Display_Tool_Types()
        {
            toolLibrarySystem.displayTools("");
        }
        static void Borrow_Tool()
        {
            toolLibrarySystem.borrowTool(new Member("","","",""),new Tool(""));
        }
        static void Return_Tool()
        {
            toolLibrarySystem.returnTool(new Member("", "", "", ""), new Tool(""));
        }
        static void Display_Tools_Borrowed()
        {
            toolLibrarySystem.displayBorrowingTools(new Member("", "", "", ""));
        }
        static void Display_Top_Three()
        {
            Console.Clear();
            Console.Write("Displaying top three most borrowed tools\n"+
                          "========================================\n");
            toolLibrarySystem.displayTopTHree();
        }

    }
}
