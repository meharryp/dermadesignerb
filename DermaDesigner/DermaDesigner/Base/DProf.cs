using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DermaDesigner
{
    /// <summary>
    /// Profiler for functions, finds the number of uses and average time between each function call @Gbps
    /// </summary>
    public class DProf
    {
        private string FuncName = "";
        private DateTime TimerS;
        private int Count;
        private double LastAvg;
        public DProf(string FuncName)
        {
            this.FuncName = FuncName;
            TimerS = new DateTime();
            TimerS = DateTime.Now;
        }

        public void Start()
        {
        }

        public string End()
        {
            TimeSpan Diff = DateTime.Now - TimerS;
            double TotalSeconds = Diff.TotalSeconds;
            Count += 1;
            LastAvg = Math.Round(Count / TotalSeconds);
            return GetSpew();
        }

        public string GetSpew()
        {
            return String.Format("[{0}] COUNT: {1} AVG: {2}/s", FuncName, Count, LastAvg);
        }
        
        public void Reset()
        {
            TimerS = DateTime.Now;
            Count = 0;
        }
    }
}
