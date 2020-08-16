﻿using System;
using System.Collections.Generic;

namespace DataStructures.Lists
{
    /// <summary>
    /// The Queue (FIFO) Data Structure.
    /// </summary>
	public class Queue<T> : IEnumerable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Instance varialbes.
        /// _collection: Array-Based List.
        /// Count: Public Getter for returning the number of elements.
        /// </summary>
        private ArrayList<T> _collection { get; set; }
        public int Count { get { return _collection.Count; } }


        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public Queue()
        {
            // The internal collection is implemented as an array-based list.
            // See the ArrayList.cs for the list implementation.
            _collection = new ArrayList<T>();
        }


        public Queue(int initialCapacity)
        {
            if (initialCapacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            // The internal collection is implemented as an array-based list.
            // See the ArrayList.cs for the list implementation.
            _collection = new ArrayList<T>(initialCapacity);
        }


        /// <summary>
        /// Checks whether the queue is empty.
        /// </summary>
        /// <returns>True if queue is empty, false otherwise.</returns>
        public bool IsEmpty
        {
            get { return _collection.IsEmpty; }
        }


        /// <summary>
        /// Returns the top element in queue
        /// </summary>
        public T Top
        {
            get
            {
                try
                {
                    return _collection.First;
                }
                catch (Exception)
                {
                    throw new Exception("Queue is empty.");
                }
            }
        }


        /// <summary>
        /// Inserts an element at the end of the queue
        /// </summary>
        /// <param name="dataItem">Element to be inserted.</param>
        public void Enqueue(T dataItem)
        {
            _collection.Add(dataItem);
        }


        /// <summary>
        /// Removes the top element in queue.
        /// </summary>
        public void Pop()
        {
            if (Count > 0)
            {
                _collection.RemoveAt(0);
            }
            else
            {
                throw new Exception("Queue is empty.");
            }
        }


        /// <summary>
        /// Removes the Top Element from queue, and assigns it's value to the "top" parameter.
        /// </summary>
        /// <return>The top element container.</return>
        public T Dequeue()
        {
            if (Count > 0)
            {
                var topItem = Top;
                _collection.RemoveAt(0);
				return topItem;
            }
            else
            {
                throw new Exception("Queue is empty.");
            }
        }


        /// <summary>
        /// Returns an array version of this queue.
        /// </summary>
        /// <returns>System.Array.</returns>
        public T[] ToArray()
        {
            return _collection.ToArray();
        }


        /// <summary>
        /// Returns a human-readable, multi-line, print-out (string) of this queue.
        /// </summary>
        /// <returns>String.</returns>
        public string ToHumanReadable()
        {
            return _collection.ToHumanReadable();
        }


		/********************************************************************************/


		public IEnumerator<T> GetEnumerator ()
		{
			return _collection.GetEnumerator ();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return this.GetEnumerator ();
		}

    }

}
