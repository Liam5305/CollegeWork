using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityExample
{
    /// <summary>
    /// simple Staff class adapted from
    /// Michael Kolling's demo BlueJ project
    /// </summary>
    public class Staff : Person
    {
        /// <summary>
        /// room description
        /// </summary>
        private string room;

        
        /// <summary>
        /// create a default Staff object
        /// </summary>
        public Staff():base("(unknown name)", 0000)
        {
           
            room = "(unknown room)";
        }

        /// <summary>
        /// Create a staff member with given name, year of birth and room number
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="yearOfBirth">year of birth</param>
        /// <param name="roomNumber">room number</param>
        public Staff(String name, int yearOfBirth, String roomNumber):base(name,yearOfBirth)
        {
            room = roomNumber;
        }

        /// <summary>
        /// get set property for room
        /// </summary>
        public string Room
        {
            get{return room;}
            set{room = value;}
        }

       /// <summary>
       /// Return a string representation of this object.
       /// </summary>
       /// <returns>string representation of a Staff</returns>
        public override string ToString()
        {
 	        return base.ToString() +
                   "Staff member\n" +
                   "Room: " + room + "\n";
        }

        
    }
}
