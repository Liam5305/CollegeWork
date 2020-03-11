using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCollection
{   
    /// <summary>
    /// Author: Liam Rutherford
    /// Date of last update: 13/11/19
    /// A collection class than can hold integers
    /// uses a linear array
    /// </summary>

    public class LinearArrayList
    {   
        /// <summary>
        /// Stores number of values in the collection
        /// </summary>
        private int count;

        /// <summary>
        /// Stores the values in the list
        /// </summary>
        private int[] values;

        /// <summary>
        /// Sets the maximum capacity of values
        /// Sets count to 0
        /// </summary>
        public LinearArrayList(int capacity)
        {
            values = new int[capacity];
            count = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public LinearArrayList()
        {
            values = new int[10];
            count = 0;
        }

        /// <summary>
        /// Public get property called count that returns the number of items in the list
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }

        /// <summary>
        /// Confirms whether or not list is full
        /// </summary>
        /// <returns>Returns true if full, otherwise false</returns>
        public bool isFull()
        {
            return (count >= values.Length);
        }

        /// <summary>
        /// Need to finish, Pete said it was like isFull
        /// </summary>
        /// <returns>Returns true if empty, otherwise false</returns>
        public bool isEmpty()
        {
            return (count == 0);
        }

        /// <summary>
        /// Confirms whether the list is full, displays "List is full". If not, adds integer to first index
        /// </summary>
        /// <param name="value">Adding a number at the start but returning a value</param>
        public void addFirst(int value)
        {
            if (isFull())
            {
                throw new Exception("List is full");
            }
            for (int i = count; i>0; i--)
            {
                values[i] = values[i - 1];
            }
            values[0] = value;
            count++;
        }
        /// <summary>
        /// Confirms whether the list is full, displays "List is full". If not, adds integer to last index
        /// </summary>
        /// <param name="value">Adding a number at the end and returning the value</param>
        public void addLast(int value)
        {
            if (isFull())
            {
                throw new Exception("List is full");
            }
            else
            {
                values[count++] = value;
            }
            
        }
        /// <summary>
        /// Removes first integer on list
        /// </summary>
        /// <returns>Removes first integer and returns a value</returns>
        public int removeFirst()
        {

            if (isEmpty())
            {
                throw new Exception("Array is empty.");
            }
            int value = values[0];
            count--;
            for (int i = 0; i <= values.Length - 1; i++)
            {
                if (i == values.Length - 1)
                {
                    values[i] = 0;
                }
                else
                {
                    values[i] = values[i + 1];
                }
            }

            return value;
        }
        /// <summary>
        /// Removes last integer on list
        /// </summary>
        /// <returns>Removes last integer and returns a value</returns>
        public int removeLast()
        {
            if (isEmpty())
            {
                throw new Exception("Array is empty");
            }
            return values[--count];
        }
        /// <summary>
        /// Destroys the list
        /// </summary>
        public void destroy()
        {
            for (int i = 0; i < count; i++)
            {
                values[i] = 0;
            }
            count = 0;
        }
        /// <summary>
        /// Displays the array on screen
        /// </summary>
        public void displayUI()
        {
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(values[i]);
                }
            }
        }
        /// <summary>
        /// Searches through the values and throws exception if array is empty
        /// </summary>
        /// <param name="value"></param>
        public int search(int value)
        {
            int indexNum = 0;

            for (int i = 0; i != count; i++)
            {
                if (values[i] == value)
                {
                    indexNum = i;
                    return indexNum;
                }
            }
            indexNum = -1;
            return indexNum;
        }
        /// <summary>
        /// Sorts the values into numerical order
        /// </summary>
        public void sort()
        {
            int counter = 0;
            int nextNum = 0;
            int index = 0;

            int smallestNum = 0;

            for (int i = 0; i < count; i++)
            {
                smallestNum = values[i];
                counter = i;

                if (values[i] < count - 1)
                    nextNum = values[i + 1];

                // Inner loop
                for (int s = counter; counter < count; s++)
                {
                    if (values[counter] < smallestNum)
                    {
                        nextNum = values[i];
                        smallestNum = values[counter];
                        index = s;
                    }
                    counter++;
                }
                if (values[i] != smallestNum)
                {
                    values[i] = smallestNum;
                    values[index] = nextNum;
                }
            }
        }
    }
}
