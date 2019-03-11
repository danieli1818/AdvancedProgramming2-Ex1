using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {

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
