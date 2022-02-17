using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class MemberCollection //: iMemberCollection
    {
        private int number;

        //binary search tree
        BSTree aBSTree = new BSTree();

        public MemberCollection()
        {
            
        }

        public int Number
        {
            get { return number; }
        }
        public void add(Member aMember)
        {
            aBSTree.Insert(aMember);
            number++;
        }

        public void delete(Member aMember)
        {
            if (aBSTree.Delete(aMember))
            {
                Console.WriteLine("Successfully removed member " + aMember.FirstName + " " + aMember.LastName + "\n\n");
                number--;
            }
            else
            {
                Console.WriteLine("Could not remove member " + aMember.FirstName + " " + aMember.LastName + "\n\n");
            }
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
        }

        public Member search(Member aMember)
        {
            Member found = aBSTree.Search(aMember);
            //If login details are correct return the found member
            if (aMember.CompareTo(found) == 2)
            {
                return found;
            }
            //If login details are incorrect but name matches we are trying to find contact number so print out the number and return null
            else if (aMember.CompareTo(found) == 0 && aMember.ContactNumber != null)
            {
                Console.WriteLine("\nContact Number for "+aMember.FirstName+" "+aMember.LastName+" is "+found.ContactNumber);
                return null;
            }
            //If login details and name is wrong
            Console.WriteLine("\nCannot Find Member With Those Details");
            return null;
        }

        public Member[] toArray()
        {
            throw new NotImplementedException();
        }
    }
}
