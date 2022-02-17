using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Member : iMember, IComparable<Member> 
    {
        private string firstName;
        private string lastName;
        private string contactNumber;
        private string pin;
        private string[] tools;
        private Tool[] memberTools;
        
        private int amount_borrowed;

        public Member(string firstName, string lastName, string contactNumber, string pin)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.contactNumber = contactNumber;
            this.pin = pin;
            tools = new string[3];
            memberTools = new Tool[3];

            amount_borrowed = 0;
        }

        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }
        public string ContactNumber {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public string PIN {
            get { return pin; }
            set { pin = value; }
        }

        public string[] Tools
        {
            get
            {
                return tools;
            }
        }
        public int Amount_Borrowed
        {
            get { return amount_borrowed; }
        }

        public void addTool(Tool aTool)
        {
            tools[amount_borrowed] = aTool.Name;
            memberTools[amount_borrowed] = aTool;
            aTool.AvailableQuantity--;
            aTool.NoBorrowings++;
            amount_borrowed++;
        }

        public int CompareTo(Member other)
        {
            if (this.lastName.CompareTo(other.lastName) < 0)
            {
                return -1;
            }
            //Check if login details are correct and if so return 2 to verfiy login
            else if (this.lastName.CompareTo(other.lastName) == 0 && this.firstName.CompareTo(other.firstName) == 0 && this.pin.CompareTo(other.pin)==0)
            {
                return 2;
            }
            //Check if name is correct and return 0 for contact number search
            else if (this.lastName.CompareTo(other.lastName) == 0 && this.firstName.CompareTo(other.firstName) == 0)
            {
                return 0;
            }
            else if (this.lastName.CompareTo(other.lastName) == 0 && this.firstName.CompareTo(other.firstName) < 0)
            {
                return -1;
            }
            else if (this.lastName.CompareTo(other.lastName) == 0 && this.firstName.CompareTo(other.firstName) > 0)
            {
                return 1;
            }
            else
            {
                return 1;
            }
        }

        public void deleteTool(Tool aTool)
        {
            tools = tools.Where(x => x != aTool.Name).ToArray();
            for (int i = 0; i < memberTools.Length; i++)
            {
                if (memberTools[i].CompareTo(aTool) == 0)
                {
                    memberTools[i].AvailableQuantity++;
                    amount_borrowed--;
                    
                    memberTools[i] = null;
                    break;
                }
            }
            if (amount_borrowed > 0)
            {
                for (int i = 0; i < memberTools.Length; i++)
                {
                    if (memberTools[i] == null && i!=2)
                    {
                        memberTools[i] = memberTools[i + 1];
                    }
                }
            }
            
        }
        public override string ToString()
        {
            return firstName + lastName;
        }
       
    }
}
