﻿using System;
using System.Collections.Generic;

namespace DataStructures.Lists
{
    /// <summary>
    /// Singly Linked List Data Structure
    /// </summary>
    public class SLinkedList<T>
    {
        /// <summary>
        /// The Singly-Linked List Node class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        internal class SLinkedListNode
        {
            public SLinkedListNode Next { get; set; }
            public T Data { get; set; }

            public SLinkedListNode()
            {
                Next = null;
                Data = default(T);
            }

            public SLinkedListNode(T dataItem)
            {
                Next = null;
                Data = dataItem;
            }
        }


        /// <summary>
        /// Instance variables
        /// </summary>
        private SLinkedListNode _firstNode { get; set; }
        private SLinkedListNode _lastNode { get; set; }
        public int Count { private set; get; }


        /// <summary>
        /// A function that is used to update the _lastNode reference.
        /// </summary>
        private void UpdateLastNode()
        {
            var currentNode = _firstNode;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            _lastNode = currentNode;
        }


        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SLinkedList()
        {
            _firstNode = null;
            _lastNode = null;
            Count = 0;
        }


        /// <summary>
        /// The Is List Empty check.
        /// </summary>
        /// <returns>true, if the list is empty, false otherwise.</returns>
        public bool IsEmpty()
        {
            return (Count == 0);
        }


        /// <summary>
        /// Getter function that returns the first element
        /// </summary>
        public T First
        {
            get
            {
                return (_firstNode == null ? default(T) : _firstNode.Data);
            }
        }


        /// <summary>
        /// Getter function that returns the last element
        /// </summary>
        public T Last
        {
            get
            {
                if (Count == 0)
                {
                    throw new Exception("Empty list.");
                }
                else if (_lastNode == null)
                {
                    var currentNode = _firstNode;
                    while (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }
                    _lastNode = currentNode;
                    return currentNode.Data;
                }
                else
                {
                    return _lastNode.Data;
                }
            }
        }


        /// <summary>
        /// Inserts the specified dataItem at the beginning of the list.
        /// </summary>
        /// <param name="dataItem">The data value to be inserted to the list.</param>
        public void Prepend(T dataItem)
        {
            SLinkedListNode newNode = new SLinkedListNode(dataItem);

            if (_firstNode == null)
            {
                _firstNode = _lastNode = newNode;
            }
            else
            {
                var currentNode = _firstNode;
                newNode.Next = currentNode;
                _firstNode = newNode;
            }

            // Increment the count.
            ++Count;
        }


        /// <summary>
        /// Inserts the specified dataItem at the end of the list.
        /// </summary>
        /// <param name="dataItem">The data value to be inserted to the list.</param>
        public void Append(T dataItem)
        {
            SLinkedListNode newNode = new SLinkedListNode(dataItem);

            if (_firstNode == null)
            {
                _firstNode = _lastNode = newNode;
            }
            else
            {
                if (_lastNode == null)
                {
                    UpdateLastNode();
                }

                var currentNode = _lastNode;
                currentNode.Next = newNode;
                _lastNode = newNode;
            }

            // Increment the count.
            ++Count;
        }


        /// <summary>
        /// Inserts a specified item dataItem at an index.
        /// </summary>
        /// <param name="dataItem">Data item.</param>
        /// <param name="index">Index.</param>
        public void InsertAt(T dataItem, int index)
        {
            // Handle scope of insertion.
            // Prepend? Append? Or Insert in the range?
            if (index == 0)
            {
                Prepend(dataItem);
            }
            else if (index == Count)
            {
                Append(dataItem);
            }
            else if (index > 0 && index < Count)
            {
                var currentNode = _firstNode;
                SLinkedListNode newNode = new SLinkedListNode(dataItem);

                for (int i = 1; i < index; ++i)
                {
                    currentNode = currentNode.Next;
                }

                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;

                // Increment the count
                ++Count;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }


        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">The index of the list node to be removed.</param>
        public void RemoveAt(int index)
        {
            // Handle index out of bound errors
            if (Count == 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            // Remove
            if (index == 0)
            {
                _firstNode = _firstNode.Next;

                // Decrement the count.
                --Count;
            }
            else
            {
                int i = 0;
                var currentNode = _firstNode;
                while (currentNode.Next != null)
                {
                    if (i + 1 == index)
                    {
                        currentNode.Next = currentNode.Next.Next;

                        // Decrement the count.
                        --Count;

                        if (index == (Count - 1))
                        {
                            _lastNode = null;
                        }

                        break;
                    }

                    ++i;
                    currentNode = currentNode.Next;
                }
            }
        }


        /// <summary>
        /// Clears all the items in the list.
        /// </summary>
        public void Clear()
        {
            _firstNode = null;
            _lastNode = null;
            Count = 0;
        }


        /// <summary>
        /// Get the element at the specified index
        /// </summary>
        /// <param name="index">Index of element</param>
        /// <returns>Element</returns>
        public T GetAt(int index)
        {
            if (index == 0)
            {
                return First;
            }
            else if (index == (Count - 1))
            {
                return Last;
            }
            else if (index > 0 && index < (Count - 1))
            {
                var currentNode = _firstNode;
                for (int i = 0; i < index; ++i)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Data;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }


        /// <summary>
        /// Returns a number of elements as specified by countOfElements, starting from the specified index.
        /// </summary>
        /// <param name="index">Starting index.</param>
        /// <param name="countOfElements">The number of elements to return.</param>
        /// <returns>Singly-Linked List of elements</returns>
        public SLinkedList<T> GetRange(int index, int countOfElements)
        {
            SLinkedList<T> newList = new SLinkedList<T>();
            var currentNode = this._firstNode;

            // Handle Index out of Bound errors
            if (Count == 0)
            {
                return newList;
            }
            else if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            // Move the currentNode reference to the specified index
            for (int i = 0; i < index; ++i)
            {
                currentNode = currentNode.Next;
            }

            // Append the elements to the new list using the currentNode reference
            while (currentNode != null && newList.Count <= countOfElements)
            {
                newList.Append(currentNode.Data);
                currentNode = currentNode.Next;
            }

            return newList;
        }


        /// <summary>
        /// Return an array version of this list.
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] array = new T[Count];

            var currentNode = _firstNode;
            for (int i = 0; i < Count; ++i)
            {
                if (currentNode != null)
                {
                    array[i] = currentNode.Data;
                    currentNode = currentNode.Next;
                }
                else
                {
                    break;
                }
            }

            return array;
        }


        /// <summary>
        /// Returns a System.List version of this SLinkedList instace.
        /// </summary>
        /// <returns>System.List of elements</returns>
        public List<T> ToList()
        {
            List<T> list = new List<T>();

            var currentNode = _firstNode;
            for (int i = 0; i < Count; ++i)
            {
                if (currentNode != null)
                {
                    list.Add(currentNode.Data);
                    currentNode = currentNode.Next;
                }
                else
                {
                    break;
                }
            }

            return list;
        }


        /// <summary>
        /// Returns the list items as a readable multi--line string.
        /// </summary>
        /// <returns></returns>
        public string ToReadable()
        {
            int i = 0;
            var currentNode = _firstNode;
            string listAsString = string.Empty;

            while (currentNode != null)
            {
                listAsString = String.Format("{0}[{1}] => {2}\r\n", listAsString, i, currentNode.Data);
                currentNode = currentNode.Next;
                ++i;
            }

            return listAsString;
        }

    }

}
