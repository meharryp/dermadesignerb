using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DermaDesigner
{
    /// <summary>
    /// Profiler for functions, finds the number of uses and average time between each function call @Gbps
    /// </summary>
    class DProf
    {
        private string FuncName = "";
        private string Spew = "";
        private DateTime TimerS;
        private int Count;
        private TimeSpan Total;
        private double LastAvg;
        public DProf(string FuncName)
        {
            this.FuncName = FuncName;
            Total = new TimeSpan();
            TimerS = new DateTime();
        }

        public void Start()
        {
            this.FuncName = FuncName;
            TimerS = DateTime.Now;
        }

        public string End()
        {
            TimeSpan Diff = DateTime.Now - TimerS;
            Total.Add(Diff);
            double TMilliseconds = Total.TotalMilliseconds;
            Count += 1;
            LastAvg = TMilliseconds/Count;
            return GetSpew();
        }

        public string GetSpew()
        {
            return String.Format("[{0}] COUNT: {1} AVG: {2}ms", FuncName, Count, LastAvg);
        }
    }
}
