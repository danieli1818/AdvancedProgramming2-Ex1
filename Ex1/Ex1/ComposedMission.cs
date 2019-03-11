using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * The namespace Excercise_1 is the namespace of the exercise.
 * 
 */
/// <summary>
/// The namespace Excercise_1 is the namespace of the exercise
/// </summary>
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
    /// <summary>
    /// The ComposedMission class
    /// which implements the Interface IMission
    /// describes a composed mission
    /// which can be an expression
    /// which is made by a sequence of little basic expressions.
    /// This class has a calculate function
    /// which calculates the expression which it describes
    /// for a given value.
    /// </summary>
    public class ComposedMission : IMission
    {

        /*
         * Funcs Property
         * 
         */
        /// <summary>
        /// Funcs Property of the class ComposedMission
        /// it's a List of functions which get as a parameter a double
        /// and returns a double.
        /// </summary>
        private IList<FunctionsContainer.func> Funcs
        {
            get;
            set;
        }

        /// <summary>
        /// Name Property of the class ComposedMission
        /// it's the mission name.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Type Property of the class ComposedMission
        /// it's the mission type.
        /// </summary>
        public string Type
        {
            get;
            private set;
        }

        /// <summary>
        /// The EventHandler Event member of the class ComposedMission.
        /// It points to functions which get as parameters
        /// an object sender and a double value.
        /// These functions will be called
        /// after each call to the Calculate function
        /// with the object sender of this
        /// and the double value of the return value
        /// of the Calculate function.
        /// </summary>
        public event EventHandler<double> OnCalculate;

        /// <summary>
        /// The Calculate Function
        /// which gets as a parameter
        /// a double value
        /// and calculates the expression value
        /// given the value from the parameters
        /// and returns the expression value
        /// for it.
        /// Before each return it calls the functions
        /// which OnCalculate EventHandler points to.
        /// It's only if it points to at least
        /// one function.
        /// <param name="value">double value to which we calculate
        /// the expression value</para>
        /// <retValue>double the expression value for
        /// the given value from the parameters</retValue>
        /// </summary>
        public double Calculate(double value)
        {
            foreach (var func in Funcs)
            {
                value = func(value);
            }
            OnCalculate?.Invoke(this, value);
            return value;
        }

        /// <summary>
        /// The ComposedMission class's Constructor.
        /// It Intializes all the members and properties of the class's object.
        /// <param name="name">string name of the mission</para>
        public ComposedMission(string name)
        {
            Funcs = new List<FunctionsContainer.func>();
            Name = name;
            Type = "Composed";
            OnCalculate = null;
        }

        /// <summary>
        /// The function Add gets as a parameter a function
        /// which gets a double parameter and returns a double return value.
        /// It adds the function to the functions list of the expression
        /// it concatenates it to the other functions until now.
        /// <param name="func">function to concatenate to the expression</para>
        /// <retValue>ComposedMission of this to enable fluent programming</retValue>
        /// </summary>
        public ComposedMission Add(FunctionsContainer.func func)
        {
            Funcs.Add(func);
            return this;
        }
    }
}
