using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Namespace Excercise_1 of the exercise
 * 
 */
/// <summary>
/// Namespace Excercise_1 of the exercise
/// </summary>
namespace Excercise_1
{

    /// <summary>
    /// The SingleMission class
    /// which implements the Interface IMission
    /// represents a basic expression.
    /// This class has a calculate function
    /// which calculates the expression which it represents
    /// for a given value.
    /// </summary>
    public class SingleMission : IMission
    {
        /// <summary>
        /// Func Property of the class SingleMission
        /// it's a function which gets as a parameter a double
        /// and returns a double.
        /// </summary>
        private FunctionsContainer.func Func
        {
            get;
            set;
        }

        /// <summary>
        /// Name Property of the class SingleMission
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
        /// The EventHandler Event member of the class SingleMission.
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
            double returnValue = Func(value);
            OnCalculate?.Invoke(this, returnValue);
            return returnValue;
        }

        /// <summary>
        /// The SingleMission class's Constructor.
        /// It Intializes all the members and properties of the class's object.
        /// <param name="function">function of the expression
        /// the object of the class holds</para>
        /// <param name="name">string name of the mission</para>
        /// </summary>
        public SingleMission(FunctionsContainer.func function, string name)
        {
            Func = function;
            Name = name;
            Type = "Single";
            OnCalculate = null;
        }
    }
}
