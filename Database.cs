using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityExample;

namespace SimpleUniversity
{
    public class Database
    {
        /// <summary>
        /// static instance of class Database
        /// </summary>
        private static Database instance;

        /// <summary>
        /// Property to return singleton instance
        /// </summary>
        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        /// <summary>
        /// Setting variable List
        /// </summary>
        private List<Person> persons;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Database()
        {
            /// Creating new List
            persons = new List<Person>();
        }

        public void addPerson(Person p)
        {
            persons.Add(p);
        }

        public string getStudents()
        {
            string strout = "";
            foreach (Person p in persons)
            {
                if (p.GetType() == typeof(Student))
                {
                    strout = strout + p + "\n";
                }

            }
            return strout;
        }

        public string getStaff()
        {
            string strout = "";
            foreach (Person p in persons)
            {
                if (p.GetType() == typeof(Staff))
                {
                    strout = strout + p + "\n";
                }

            }
            return strout;
        }

        public string getAll()
        {
            string strout = "";
            foreach (Person p in persons)
            {
                strout = strout + p + "\n";
            }
            return strout;
        }

        public void populate()
        {
            addPerson(new Staff("John", 1997, "C123"));
            addPerson(new Student("Liam", 2003, "3015"));
            addPerson(new Staff("Mary", 1974, "C224"));
            addPerson(new Student("David", 1998, "3013"));
            addPerson(new Staff("Helen", 1960, "C34"));
            addPerson(new Student("Dean", 2002, "3018"));
            addPerson(new Staff("Christine", 1980, "C12"));
            addPerson(new Student("Callum", 1999, "3021"));
            addPerson(new Staff("Jennifer", 1945, "C237"));
        }
    }
}
