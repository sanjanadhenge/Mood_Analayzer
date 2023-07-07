using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mood_Analayzer
{
    public class MoodAnalyzerReflector
    {
        public static string ChangeMoodDyanmically(string fieldName, string message)
        {
            try
            {
                MoodAnalyze moodAnalyze = new MoodAnalyze(message);
                Type type = typeof(MoodAnalyze);
                FieldInfo fieldInfo = type.GetField(fieldName);
                if (message == null)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "Message should not be null");
                }
                message = InvokeMethod(message, "Analyze");
                fieldInfo.SetValue(moodAnalyze, message);

                return moodAnalyze.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "Field Not Found");
            }
        }
        public static string InvokeMethod(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("Mood_Analayzer.MoodAnalyze");
                object moodAnalyze = MoodAnalyzerReflector.CreateMoodAnalyzeUsingParameterizedConstructor("Mood_Analayzer.MoodAnalyze", "MoodAnalyze", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyze, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Method Not Found");
            }

        }
        public static object CreateMoodAnalyzeUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyze);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { "HAPPY" });
                    return instance;

                }
                else
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
            }


        }
        public static object CreateMoodAnalyze(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(pattern, constructorName);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type type = executing.GetType(className);
                    return Activator.CreateInstance(type);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
            }
        }
    }
}
