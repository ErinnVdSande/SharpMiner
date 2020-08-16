﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using DataStructures;

namespace C_Sharp_Algorithms
{
    /// <summary>
    /// Functions that use the classes and use them with dummy data.
    /// These are used as simple functionality tests.
    /// </summary>
    public static class DummyTests
    {
        public static void Test_SinglyLinkedList()
        {
            int index = 0;
            SLList<int> listOfNumbers = new SLList<int>();

            listOfNumbers.Append(10);
            listOfNumbers.Append(124);
			listOfNumbers.Prepend(654);
			listOfNumbers.Prepend(8);
            listOfNumbers.Append(127485693);
            listOfNumbers.Append(34);
            listOfNumbers.Append(823);

            Console.WriteLine(listOfNumbers.ToReadable());

            listOfNumbers.RemoveAt(0);
			Console.WriteLine("Removed 1st:\r\n" + listOfNumbers.ToReadable());

            listOfNumbers.RemoveAt(3);
            listOfNumbers.RemoveAt(4);
			Console.WriteLine("Removed 3rd & 4th:\r\n" + listOfNumbers.ToReadable());

			listOfNumbers.RemoveAt(2);
			Console.WriteLine("Removed 3rd:\r\n" + listOfNumbers.ToReadable());

			listOfNumbers.RemoveAt(2);

			Console.WriteLine("Removed 3rd:\r\n" + listOfNumbers.ToReadable());

			listOfNumbers.RemoveAt(0);
            Console.WriteLine("Remove 1st:\r\n" + listOfNumbers.ToReadable());

			listOfNumbers.Prepend (3);
			listOfNumbers.Prepend (2);
			listOfNumbers.Prepend (1);
			// Print List and Count
			Console.WriteLine(listOfNumbers.ToReadable());
			Console.WriteLine("Count: " + listOfNumbers.Count + "\r\n");

			listOfNumbers.InsertAt (444, listOfNumbers.Count);
			listOfNumbers.InsertAt (555, listOfNumbers.Count);
            listOfNumbers.InsertAt(222, 2);
			Console.WriteLine(listOfNumbers.ToReadable());
			Console.WriteLine("Count: " + listOfNumbers.Count + "\r\n");

            index = 0;
            Console.WriteLine("Get At " + index + ": " + listOfNumbers.GetAt(index));

            index = (listOfNumbers.Count / 2) + 1;
            Console.WriteLine("Get At " + index + ": " + listOfNumbers.GetAt(index));

            index = (listOfNumbers.Count / 2) + 2;
            Console.WriteLine("Get At " + index + ": " + listOfNumbers.GetAt(index));

            index = (listOfNumbers.Count - 1);
            Console.WriteLine("Get At " + index + ": " + listOfNumbers.GetAt(index));

            Console.WriteLine();

            Console.WriteLine("GetRange(0, 3):\r\n" + listOfNumbers.GetRange(0, 3).ToReadable());

            var arrayVersion = listOfNumbers.ToArray();

			// Capture the console.
            Console.ReadLine();
        }

        public static void Test_DoublyLinkedList()
        {
            int index = 0;
            DLList<string> listOfStrings = new DLList<string>();

            listOfStrings.Append("fst");
            listOfStrings.Append("sec");
            listOfStrings.Append("trd");
            listOfStrings.Append("for");
            listOfStrings.Append("fft");
            listOfStrings.Append("sxt");
            listOfStrings.Append("svn");
            listOfStrings.Append("egt");

            // Print
            Console.WriteLine(listOfStrings.ToReadable());

            // Remove 1st
            listOfStrings.RemoveAt(0);
            Console.WriteLine("Removed 1st:\r\n" + listOfStrings.ToReadable());

            // Remove 5th and 6th
            listOfStrings.RemoveAt(4);
            listOfStrings.RemoveAt(5);
            Console.WriteLine("Removed 5th & 6th:\r\n" + listOfStrings.ToReadable());

            // Remove 4th
            listOfStrings.RemoveAt(3);
            Console.WriteLine("Removed last:\r\n" + listOfStrings.ToReadable());

            // Remove 3rd
            listOfStrings.RemoveAt(2);
            Console.WriteLine("Removed last:\r\n" + listOfStrings.ToReadable());

            // Remove 1st
            listOfStrings.RemoveAt(0);
            Console.WriteLine("Remove 1st:\r\n" + listOfStrings.ToReadable());

            listOfStrings.Prepend("semsem3");
            listOfStrings.Prepend("semsem2");
            listOfStrings.Prepend("semsem1");
            Console.WriteLine("Prepend 3 items:\r\n" + listOfStrings.ToReadable());
            Console.WriteLine("Count: " + listOfStrings.Count);

            listOfStrings.InsertAt("InsertedAtLast1", listOfStrings.Count);
            listOfStrings.InsertAt("InsertedAtLast2", listOfStrings.Count);
            listOfStrings.InsertAt("InsertedAtMiddle", (listOfStrings.Count / 2));
            Console.WriteLine("Inserts 3 items At:\r\n" + listOfStrings.ToReadable());

            // Print count
            Console.WriteLine("Count: " + listOfStrings.Count);

            Console.WriteLine();

            index = 0;
            Console.WriteLine("Get At " + index + ": " + listOfStrings.GetAt(index));

            index = (listOfStrings.Count / 2) + 1;
            Console.WriteLine("Get At " + index + ": " + listOfStrings.GetAt(index));

            index = (listOfStrings.Count / 2) + 2;
            Console.WriteLine("Get At " + index + ": " + listOfStrings.GetAt(index));

            index = (listOfStrings.Count - 1);
            Console.WriteLine("Get At " + index + ": " + listOfStrings.GetAt(index));

            Console.WriteLine();

            Console.WriteLine("GetRange(0, 3):\r\n" + listOfStrings.GetRange(0, 3).ToReadable());

            var arrayVersion = listOfStrings.ToArray();

            Console.ReadLine();
        }
    }
}
