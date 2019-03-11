using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * The namespace Excercise_1 is the namespace of the exercise
 * 
 */
namespace Excercise_1
{
    /*
     * The ComposedMission class
     * which implements the Interface IMission
     * describes a composed mission
     * which can be an expression
     * which is made by a sequence of little basic expressions.
     * This class has a calculate function
     * which calculates the expression which it describes
     * for a given value.
     */
    public class ComposedMission : IMission
    {

        /*
         * Funcs Property
         * 
         */
        private IList<FunctionsContainer.func> Funcs
        {
            get;
            set;
        }

        public string Name
        {
            get;
            private set;
        }

        public string Type
        {
            get;
            private set;
        }

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            foreach (var func in Funcs)
            {
                value = func(value);
            }
            OnCalculate?.Invoke(this, value);
            return value;
        }

        public ComposedMission(string name)
        {
            Funcs = new List<FunctionsContainer.func>();
            Name = name;
            Type = "Composed";
            OnCalculate = null;
        }

        public ComposedMission Add(FunctionsContainer.func func)
        {
            Funcs.Add(func);
            return this;
        }
    }
}
