﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using DataStructures;
using Algorithms;

namespace C_Sharp_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
			ArrayList<int> list = new ArrayList<int> ();
			list.Add (23);
			list.Add (42);
			list.Add (4);
			list.Add (16);
			list.Add (8);
			list.Add (15);
			list.Add (9);
			list.Add (55);
			list.Add (0);
			list.Add (34);
			list.Add (12);
			list.Add (2);

			Console.WriteLine ("Before Sort:\r\n" + list.ToHumanReadable() + "\r\n");

			list.InsertionSort ();

			Console.WriteLine ("After Sort:\r\n" + list.ToHumanReadable() + "\r\n");

			// ANOTHER LIST TO SORT

			List<long> list2 = new List<long> ();
			list2.Add (23);
			list2.Add (42);
			list2.Add (4);
			list2.Add (16);
			list2.Add (8);
			list2.Add (15);
			list2.Add (9);
			list2.Add (55);
			list2.Add (0);
			list2.Add (34);
			list2.Add (12);
			list2.Add (2);

			list2.InsertionSort ();


			//DummyTests.Test_Queue();
            //DummyTests.Test_Stack();

			//DummyTests.Test_ArrayList ();
			//DummyTests.Test_DoublyLinkedList();
			//DummyTests.Test_SinglyLinkedList ();
        }
    }
}
