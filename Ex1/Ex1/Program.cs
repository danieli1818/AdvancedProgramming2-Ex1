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

    /// <summary>
    /// The Program class
    /// which holds the Main function.
    /// </summary>
    class Program
    {

        /// <summary>
        /// The RunMissions Function
        /// which gets as parameters
        /// a List of Missions missions
        /// and a double val
        /// and runs all the missions' Calculate function
        /// in the missions list
        /// with the double val value
        /// and prints the Name of the mission and the val
        /// and the missions' Calculate function's return value
        /// for the the double val parameter.
        /// <param name="missions">List of Missions</para>
        /// <param name="val">double value which is the input parameter
        /// for the function Calculate of the missions
        /// in List of Missions missions</para>
        /// </summary>
        public static void RunMissions(IList<IMission> missions, double val)
        {
            foreach (var m in missions)
            {
                Console.WriteLine($"{m.Name}({val}) = {m.Calculate(val)}\n");
            }
        }

        /// <summary>
        /// The PrintAvailableFunctions Function
        /// which gets as a parameter
        /// a FunctionsContainer container
        /// and prints the available functions of it.
        /// <param name="container">FunctionsContainer to print
        /// the available functions of it</para>
        /// </summary>
        public static void PrintAvailableFunctions(FunctionsContainer container)
        {
            var fuctionListNames = container.getAllMissions();
            Console.WriteLine("All Available Functions:");
            foreach (var funcName in fuctionListNames)
            {
                Console.WriteLine(funcName);
            }
            Console.WriteLine("####################################\n");
        }

        /// <summary>
        /// The Main Function
        /// which gets as parameters
        /// the args string array.
        /// And runs the program.
        /// <param name="args">the string array of arguments</para>
        /// </summary>
        public static void Main(string[] args)
        {
            FunctionsContainer funcList = new FunctionsContainer();     // Creating the mission conatiner
            funcList["Double"] = val => val * 2;                    // Double the Value
            funcList["Triple"] = val => val * 3;                    // Triple the Value
            funcList["Square"] = val => val * val;                  // Square the Value
            funcList["Sqrt"] = val => Math.Sqrt(val);               // Taking the square root
            funcList["Plus2"] = val => val + 2;                    // Double the Value

            PrintAvailableFunctions(funcList);

            // This handler will output the screen every mission that was activated and it's value
            EventHandler<double> LogHandler = (sender, val) =>
            {
                IMission mission = sender as IMission;

                if (mission != null)
                {
                    Console.WriteLine($"Mission of Type: {mission.Type} with the Name {mission.Name} returned {val}");
                }
            };

            EventHandler<double> SqrtHandler = (sender, val) =>
            {
                // This function will Create a sqrt mission and will continue to sqrt until a number less than 2
                SingleMission sqrtMission = new SingleMission(funcList["Sqrt"], "SqrtMission");

                double newVal;
                do
                {
                    newVal = sqrtMission.Calculate(val);     // getting the new Val
                    Console.WriteLine($"sqrt({val}) = {newVal}");

                    val = newVal;                           // Storing the new Val;
                } while (val > 2);
                Console.WriteLine("----------------------------------------");
            };

            ComposedMission mission1 = new ComposedMission("mission1")
                .Add(funcList["Square"])
                .Add(funcList["Sqrt"]);

            ComposedMission mission2 = new ComposedMission("mission2")
                .Add(funcList["Triple"])
                .Add(funcList["Plus2"])
                .Add(funcList["Square"]);

            SingleMission mission3 = new SingleMission(funcList["Double"], "mission3");

            ComposedMission mission4 = new ComposedMission("mission4")
                .Add(funcList["Triple"])
                .Add(funcList["Stam"])              // Notice that this function does not exist and still it works
                .Add(funcList["Plus2"]);

            PrintAvailableFunctions(funcList);

            funcList["Stam"] = val => val + 100;
            SingleMission mission5 = new SingleMission(funcList["Stam"], "mission5");

            var missionList = new List<IMission>() { mission1, mission2, mission3, mission4, mission5 };

            foreach (var m in missionList)
            {
                m.OnCalculate += LogHandler;
                m.OnCalculate += SqrtHandler;
            }

            missionList.Add(mission2);
            missionList.Add(mission1);
            missionList.Add(mission3);
            missionList.Add(mission5);

            RunMissions(missionList, 100);
            RunMissions(missionList, 2);

            PrintAvailableFunctions(funcList);
        }
    }
}
