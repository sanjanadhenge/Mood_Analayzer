
using Mood_Analayzer;

namespace TestProject1
{
    public class Tests
    {
        //TC1.1-Return SAD
        [Test]
        public void GivenSadMood_WhenAnalyze_shouldReturnSad()
        {
            MoodAnalyze moodAnalyzer = new MoodAnalyze("I am in Sad Mood");
            string result1 = moodAnalyzer.Analyze();

            Assert.AreEqual("SAD", result1);
        }
        //TC1.2 - Return Happy
        [Test]
        public void GivenAnyMood_WhenAnalyze_shouldReturnSad()
        {
            MoodAnalyze moodAnalyzer = new MoodAnalyze("I am in Happy Mood");
            string result = moodAnalyzer.Analyze();

            Assert.AreEqual("HAPPY", result);
        }
        //TC 2.1
        [Test]
        public void GivenNullMood_WhenAnalyze_shouldReturnSad()
        {

            string message = null;
            MoodAnalyze moodAnalyzer = new MoodAnalyze(message);
            string result = moodAnalyzer.Analyze();
            Assert.AreEqual("HAPPY", result);

        }
        //TC3.1
        [Test]
        public void GivenInvalidMood_WhenAnalyze_shouldReturnSad()
        {
            try
            {
                string message = null;
                MoodAnalyze moodAnalyzer = new MoodAnalyze(message);
                string result = moodAnalyzer.Analyze();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Message is null");
            }
        }
        //TC3.2
        [Test]
        public void GivenEmptyMood_WhenAnalyze_shouldReturnSad()
        {
            try
            {
                string message = "";
                MoodAnalyze moodAnalyzer = new MoodAnalyze(message);
                string result = moodAnalyzer.Analyze();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Message is Empty");
            }


        }
    }
}