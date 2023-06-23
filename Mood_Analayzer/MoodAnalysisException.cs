using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood_Analayzer
{
    public class MoodAnalysisException : Exception
    {
        public enum ExceptionType
        {
            NULL_MOOD, EMPTY_MOOD
        }
        public ExceptionType exceptionType;
        public MoodAnalysisException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
