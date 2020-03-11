using System;
using System.IO;
using FileExtensionsStarter;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace FileExtensionsStarter
{   [Serializable]
    //remember to make class support persistence!!!
    public class DefaultProgDatabase
    {

        public static DefaultProgDatabase Instance;

        Dictionary<String, String> extensions;
        /// <summary>
        /// Default constructor
        /// should perform any intialisation
        /// </summary>
        public DefaultProgDatabase()
        {
            extensions = new Dictionary<string, string>();

        }

        /// <summary>
        /// returns default program corresponding to extension
        /// throws exception if not found
        /// </summary>
        /// <param name="extension">extension to find default program</param>
        /// <returns>default program</returns>
        public string findDefaultProgram(string extension)
        {
            string value="";
            String searchKey = extension;

            if (extensions.ContainsKey(searchKey))
            {
                extensions.TryGetValue(searchKey, out value);
                value = "The default program for " + extension + " is " + value + ".";
                return value;
            }
            else
            {
                throw new Exception("Default program for " + extension + " is not found.");
            }
        }

        /// <summary>
        /// SHOULD DELETE ENTRY CORRESPONDING TO ENTRY
        /// </summary>
        /// <param name="extension">key of entry to delete</param>
        /// <returns>true if deleted or false</returns>
        public bool deleteEntry(string extension)
        {

            String searchKey = extension;

            if (extensions.ContainsKey(searchKey))
            {
                extensions.Remove(searchKey);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Should clear all entries
        /// </summary>
        public void clearAll()
        {
            extensions.Clear();
        }


        public bool isEmpty()
        {
            return (extensions.Count == 0);
        }
        /// <summary>
        /// SHOULD ADD NEW ENTRY WITH 
        /// KEY AS EXTENSION AND PROGRAM AS VALUE
        /// 
        /// RETURN TRUE IF SUCCESSFUL
        /// RETURN FALSE IF ALREADY ENTRY FOR KEY
        /// </summary>
        /// <param name="extension">extension</param>
        /// <param name="program">defaulty program</param>
        /// <returns>Returns true if successful and false if already entry for key</returns>
        public bool addEntry(string extension, string program)
        {
            String searchKey = extension;

            if (extensions.ContainsKey(searchKey) )
            {
                return false;
            }
            else
            {
                extensions.Add(extension, program);
                return true;
            }
        }

        /// <summary>
        /// SHOULD return a string list of all the entries
        /// each entry should be on one line
        /// in format shown in test document
        /// </summary>
        /// <returns>Returns a string list of all entries</returns>
        public string getAll()
        {
            string value = "";

            if (isEmpty() == false)
            {
                foreach (var entry in extensions)
                {
                    value = value + "- File extension: " + entry.Key + " opens with " + entry.Value + ".\n";
                }
            }
            else
            {
                throw new Exception("There is no entries to display.");
            }
            return value;   
        }

        /// <summary>
        /// SHOULD POPULATE WITH SOME ENTRIES
        /// FOR TESTING
        /// </summary>
        public void populate()
        {
            extensions.Add(".txt", "Notepad");
            extensions.Add(".doc", "Microsoft Word");
            extensions.Add(".html", "Google Chrome");
        }

        public bool read()
        {
            try
            {
                using (StreamReader sr = new StreamReader("datafile.dat"))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        extensions.Add(line, sr.ReadLine());
                    }
                }
                return true;
            }
            catch (Exception)

            {
                return false;
            }
        }

        public void write()
        {
            using (StreamWriter sw = new StreamWriter("datafile.dat"))
            {
                foreach (var entry in extensions)
                {
                    sw.WriteLine(entry.Key);
                    sw.WriteLine(entry.Value);
                }
            }
        }
    }
}
