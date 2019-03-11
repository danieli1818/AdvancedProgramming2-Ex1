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
    /// interface IMission
    /// this interface represents a calculation mission
    /// </summary>
    public interface IMission
    {
        /// <summary>
        /// The EventHandler Event member of the interface Mission.
        /// It enforce every class that implements this interface
        /// to have this member.
        /// It points to functions which get as parameters
        /// an object sender and a double value.
        /// These functions will be called
        /// after each call to the Calculate function
        /// with the object sender of this
        /// and the double value of the return value
        /// of the Calculate function.
        /// </summary>
        event EventHandler<double> OnCalculate;  // An Event of when a mission is activated

        /// <summary>
        /// Name Property of the interface Mission.
        /// It enforce every class that implements this interface
        /// to have this member.
        /// it's the mission name.
        /// </summary>
        String Name { get;}

        /// <summary>
        /// Type Property of the interface Mission
        /// It enforce every class that implements this interface
        /// to have this member.
        /// it's the mission type.
        /// </summary>
        String Type { get; }

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
        double Calculate(double value);
    }
}
