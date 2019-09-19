using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NexTechCore;
using NexTechInfrastructure;

namespace NexTechTestApp.Tests
{
    [TestClass]
    public class HackerNewsServiceTest
    {
        [TestMethod]
        public void TestGetArticleIds()
        {
            //retrive list of current top article ids
            List<string> articleIds = HackerNewsService.GetNewArticleIdList();

            //check that all new article id loaded
            foreach (string artId in articleIds)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(artId), "Failed to retrive an article id");
            }
        }

        [TestMethod]
        public void TestGetArticle()
        {
            //create and seed random
            Random rand = new Random((int) DateTime.Now.Ticks);

            //retrive list of current top article ids
            List<string> articleIds = HackerNewsService.GetNewArticleIdList();

            //randomly get a current top article to load
            string artId = articleIds[rand.Next(0, articleIds.Count)];

            Article art = HackerNewsService.GetArticle(artId);

            Assert.IsTrue(art != null, "Failed to retrive an article");
        }

        [TestMethod]
        public void TestArticleToString()
        {
            List<Article> allNewArticles = HackerNewsService.GetNewArticles();

            //check that we are not getting any completely null articles (specific code to prevent that from happening)
            foreach(Article art in allNewArticles)
            {
                Assert.IsTrue(art != null);
            }
        }
    }
}
