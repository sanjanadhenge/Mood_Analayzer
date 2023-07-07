using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood_Analayzer
{
    public class MoodAnalyze
    {
        public string message;
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
            try
            {
                if (message.ToLower().Contains("sad"))
                {
                    return "SAD";
                }
                else
                    return "HAPPY";
            }
            catch (Exception)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NULL_MOOD, "Message is null");
            }

        }
    }
}
