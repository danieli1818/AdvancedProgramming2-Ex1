﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Namespace Excercise_1 of the exercise
 * 
 */
namespace Excercise_1
{
  
    /*
     * class FunctionsContainer
     * this class contains all the functions that were added to it
     * according to each one's name.
     * All functions are getting as a parameter a double x 
     * and returns a double value.
     */
    public class FunctionsContainer
    {
        public delegate double func(double x);
        private IDictionary<String, func> dict;

        /*
         * The FunctionsContainer Constructor
         * which creates the dictionary of the string to the function.
         */
        public FunctionsContainer()
        {
            dict = new Dictionary<String, func>();
        }

        /*
         * The Indexer of the FunctionsContainer class
         * which its get is getting the function with 
         * the name of the String str
         * which we get from the parameter
         * of the Indexer.
         * Its set is setting function
         * with the name of the String str
         * which we get from the parameter
         * of the Indexer,
         * to the value function.
         */
        public func this[String str]
        {
            get
            {
                if (!dict.ContainsKey(str))
                {
                    dict[str] = x => x;
                }
                return dict[str];
            }
            set
            {
                dict[str] = value;
            }
        }

        /*
         * The getAllMissions function
         * returns a Collection
         * of all the names
         * of the functions
         * which are contained
         * in the FunctionContainer.
         */
        public ICollection<String> getAllMissions() => dict.Keys;


    }
}
