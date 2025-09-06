using System;
using System.Collections.Generic;

namespace Project
{
    
    public static class ListExtensions
    {
        private static readonly Random rng = new Random();

        /// <summary>
        /// Gets a random element from the list.
        /// </summary>
        public static T GetRandom<T>(this List<T> list)
        {
            if (list == null || list.Count == 0)
                throw new InvalidOperationException("Cannot get a random element from an empty or null list.");

            int index = rng.Next(list.Count);
            return list[index];
        }
    }
}