
using Mood_Analayzer;

namespace TestProject1
{
    public class Tests
    {
        //TC1.1-Return SAD
        [Test]
        public void GivenSadMood_WhenAnalyze_shouldReturnSad()
        {
            string message = "I am in Sad Mood";
            MoodAnalyze moodAnalyzer = new MoodAnalyze();
            string result1 = moodAnalyzer.Analyze(message);

            Assert.AreEqual("SAD", result1);
        }
        //TC1.2 - Return Happy
        [Test]
        public void GivenAnyMood_WhenAnalyze_shouldReturnSad()
        {
            string message = "I am in Any Mood";
            MoodAnalyze moodAnalyzer = new MoodAnalyze();
            string result = moodAnalyzer.Analyze(message);

            Assert.AreEqual("HAPPY", result);
        }
    }
}