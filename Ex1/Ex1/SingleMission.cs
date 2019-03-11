using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {

        private FunctionsContainer.func Func
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
            double returnValue = Func(value);
            OnCalculate?.Invoke(this, returnValue);
            return returnValue;
        }

        public SingleMission(FunctionsContainer.func function, string name)
        {
            Func = function;
            Name = name;
            Type = "Single";
            OnCalculate = null;
        }
    }
}
