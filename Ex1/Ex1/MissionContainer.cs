using System;
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

        public FunctionsContainer()
        {
            dict = new Dictionary<String, func>();
        }

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

        public ICollection<String> getAllMissions() => dict.Keys;


    }
}
