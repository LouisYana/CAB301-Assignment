using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Tool : iTool, IComparable<Tool>
    {
        private string name;
        private MemberCollection getBorrowers;
        private int quantity;
        private int availableQuantity;
        private int noBorrowings;
        
        public Tool(string name)
        {
            this.name = name;
            this.quantity = 1;
            this.availableQuantity = 1;
            this.noBorrowings = 0;
        }
        public Tool(string name, int quantity, int availableQuantity,int noBorrowings)
        {
            this.name = name;
            this.quantity = quantity;
            this.availableQuantity = availableQuantity;
            this.noBorrowings = noBorrowings;
        }

        public string Name {
            get { return name; }
            set { name = value; } 
        }
        public int Quantity {
            get { return quantity; }
            set { quantity = value; }
        }
        public int AvailableQuantity {
            get { return availableQuantity; }
            set { availableQuantity = value; }
        }
        public int NoBorrowings {
            get { return noBorrowings; }
            set { noBorrowings = value; }
        }

        public MemberCollection GetBorrowers
        {
            get { return getBorrowers; }
        }

        public void addBorrower(Member aMember)
        {
            getBorrowers.add(aMember);
            availableQuantity++;
        }

        public int CompareTo(Tool other)
        {
            if (this.name.CompareTo(other.name) == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public void deleteBorrower(Member aMember)
        {
            getBorrowers.delete(aMember);
            availableQuantity++;
        }

 
    }
}
