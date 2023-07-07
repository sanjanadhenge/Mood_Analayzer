
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
        //TC4.1
        [Test]
        public void GivenClassName_WhenAnalyze_ShouldReturnMoodAnalyzeObject()
        {
            string message = null;
            object expected = new MoodAnalyze(message);
            object obj = MoodAnalyzerFactory.CreateMoodAnalyze("MAnalyzer.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
            //Assert.AreEqual(expected, obj);

        }
        //TC4.2
        [Test]
        public void GivenClassNameImproper_WhenAnalyze_ShouldThrowException()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyze(message);
                object obj = MoodAnalyzerFactory.CreateMoodAnalyze("MAnalyzer.Mood_analyzer", "MoodAnalyzer");
                expected.Equals(obj);
                //Assert.AreEqual(expected, obj);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Class Not Found");
            }
        }
        //TC4.3
        [Test]
        public void GivenConstructorNameImproper_WhenAnalyze_ShouldThrowException()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyze(message);
                object obj = MoodAnalyzerFactory.CreateMoodAnalyze("MAnalyzer.MoodAnalyzer", "Mood_analyzer");
                expected.Equals(obj);
                //Assert.AreEqual(expected, obj);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Constructor Not Found");
            }
        }

    }
}