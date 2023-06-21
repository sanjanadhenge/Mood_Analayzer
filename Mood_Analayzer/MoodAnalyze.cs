using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood_Analayzer
{
    public class MoodAnalyze
    {
        string message;
        public MoodAnalyze()
        {
            this.message = message;
        }
        public MoodAnalyze(string message)
        {
            this.message = message;
        }
        public string Analyze()
        {
            if(this.message.ToLower().Contains("sad"))
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }
    }
}
