﻿using System;

using DataStructures.Common;
using DataStructures.Lists;
using DataStructures.Hashing;

namespace DataStructures.Hashing
{
    /// <summary>
    /// Implements a family of Universal Hash Functions
    /// </summary>
    public class UniversalHashingFamily
    {
        // A large prime, arbitrarily chosen
        // In decimal = 2,146,435,069;
        private const int BIG_PRIME = 0x7FEFFFFD;

        private Random _randomizer { get; set; }
        private int _numberOfHashFunctions { get; set; }
        private int[] _firstMultipliersVector { get; set; }
        private int[] _secondMultipliersVector { get; set; }
        private static readonly PrimesList _primes = PrimesList.Instance;

        /// <summary>
        /// Initializes the family with a specified number of hash functions.
        /// </summary>
        public UniversalHashingFamily(int numberOfHashFunctions)
        {
            if (numberOfHashFunctions <= 0)
                throw new ArgumentOutOfRangeException("Number of hash functions should be greater than zero.");

            _randomizer = new Random();
            _numberOfHashFunctions = numberOfHashFunctions;
            _firstMultipliersVector = new int[_numberOfHashFunctions];
            _secondMultipliersVector = new int[_numberOfHashFunctions];

            GenerateNewFunctions();
        }

        /// <summary>
        /// Returns number of member hash functions.
        /// </summary>
        public int NumberOfFunctions
        {
            get { return _numberOfHashFunctions; }
        }

        /// <summary>
        /// Generates new hash functions with new randomized multipliers.
        /// </summary>
        public void GenerateNewFunctions()
        {
            // Clear the multipliers vectors
            Array.Clear(_firstMultipliersVector, 0, _firstMultipliersVector.Length);
            Array.Clear(_secondMultipliersVector, 0, _secondMultipliersVector.Length);

            int randomeIndexMin = 0;
            int randomIndexMax = _primes.Count - 1;

            for (int i = 0; i < _numberOfHashFunctions; i++)
            {
                // Get only the primes that are smaller than the biggest-chosen prime.
                int randomIndex = _randomizer.Next(randomeIndexMin, randomIndexMax);

                while (_primes[randomIndex] < BIG_PRIME)
                    randomIndex = _randomizer.Next(randomeIndexMin, randomIndexMax);
                
                _firstMultipliersVector[i] = _primes[randomIndex];

                randomIndex = _randomizer.Next(randomeIndexMin, randomIndexMax);

                while (_primes[randomIndex] < BIG_PRIME)
                    randomIndex = _randomizer.Next(randomeIndexMin, randomIndexMax);

                _secondMultipliersVector[i] = _primes[randomIndex];
            }
        }

        /// <summary>
        /// Returns hash value of a string, given the specified number of the hash function to use.
        /// </summary>
        /// <param name="preHashedKey">Int pre-hash code of an object.</param>
        /// <param name="whichHashFunction">Non-zero, non-negative integer that specified the number of the hash function to use.</param>
        /// <returns></returns>
        public int UniversalHash(int preHashedKey, int whichHashFunction)
        {
            if (whichHashFunction <= 0 || whichHashFunction > _numberOfHashFunctions)
                throw new ArgumentOutOfRangeException("WhichHashFunction parameter should be greater than zero or equal to the number of Hash Functions.");

            int a = _firstMultipliersVector[whichHashFunction - 1];
            int b = _secondMultipliersVector[whichHashFunction - 1];

            return ((a * preHashedKey) + b) % BIG_PRIME;
        }

        /// <summary>
        /// Returns hash value of a string, given the specified number of the hash function to use.
        /// </summary>
        /// <param name="key">string key.</param>
        /// <param name="whichHashFunction">Non-zero, non-negative integer that specified the number of the hash function to use.</param>
        public int UniversalHash(string key, int whichHashFunction)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key is either an empty string or null.");

            int prehash = 0;
            var characters = key.ToCharArray();

            foreach (var character in characters)
            {
                prehash += Convert.ToInt32(Char.GetNumericValue(character));
            }

            return UniversalHash(prehash, whichHashFunction);
        }

    }

}
