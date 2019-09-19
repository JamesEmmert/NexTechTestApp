using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NexTechCore;

namespace NexTechTestApp.Tests
{
    [TestClass]
    public class ArticleTest
    {
        [TestMethod]
        public void TestArticleNullStrings()
        {
            Article art = new Article();
            art.Title = null;
            art.By = null;
            art.Url = null;

            Assert.IsTrue(art.Title == "", "Article Title did not return empty string when set to null");
            Assert.IsTrue(art.By == "", "Article By did not return empty string when set to null");
            Assert.IsTrue(art.Url == "", "Article Url did not return empty string when set to null");
        }

        [TestMethod]
        public void TestArticleToString()
        {
            Article art = new Article();
            art.Title = "Some Title";
            art.By = "a user";
            art.Url = "https://www.google.com/";

            Assert.IsTrue(art.ToString() == art.Title + " " + art.By + " " + art.Url, "Article ToString did not return correctly");
        }
    }
}
