using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityExample
{
    /// <summary>
    /// simple Student class adapted from
    /// Michael Kolling's demo BlueJ project
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// student ID number
        /// </summary>
        private String SID;    // student ID number

   /// <summary>
   /// Create a student with default settings for detail information.
   /// </summary>
    public Student():base("(unknown name)", 0000)
    {
        SID = "(unknown ID)";
    }

    /// <summary>
    /// Create a student with given name, year of birth and student ID
    /// </summary>
    /// <param name="name">name</param>
    /// <param name="yearOfBirth">year of birth</param>
    /// <param name="studentID">ID</param>
    public Student(String name, int yearOfBirth, String studentID): base(name, yearOfBirth)
    {
        SID = studentID;
    }
      
    /// <summary>
    /// read only poperty for ID
    /// </summary>
     public string ID
     {
         get{return SID;}
     }
    

    /// <summary>
    /// Return a string representation of this object.
    /// </summary>
    /// <returns>string representation of Student object</returns>
    public override String ToString()    // redefined from "Person"
    {
        return base.ToString() +
               "Student\n" +
               "Student ID: " + SID + "\n";
    }
}
    
}
