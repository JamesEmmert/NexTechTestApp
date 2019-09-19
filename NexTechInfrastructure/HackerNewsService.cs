using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using NexTechCore;

namespace NexTechInfrastructure
{
    public class HackerNewsService
    {
        static string hackerNewsPath = "https://hacker-news.firebaseio.com/v0/";

        public static List<Article> GetNewArticles()
        {
            //get the ids of the newest articles
            List<string> articleIds = GetNewArticleIdList();

            List<Article> articles = new List<Article>();

            //sometimes the api is rueturning a null opbject, i suspect when a new article is being added to the site. 
            //  if that happens, create a new article instead of inserting a null item
            return articleIds.Select(ai => GetArticle(ai) ?? new Article()).ToList();

        }

        public static List<string> GetNewArticleIdList()
        {
            List<string> articles = new List<string>();
            var articleIdsWebRequest = WebRequest.Create(hackerNewsPath + "newstories.json");

            if (articleIdsWebRequest == null)
            {
                throw (new Exception("Web request could not be completed for new articles"));
            }

            articleIdsWebRequest.ContentType = "application/json";

            using (var s = articleIdsWebRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    string articleIds = sr.ReadToEnd();
                    //list comes back with a bracket at the begining and end that we need to remove
                    articleIds = articleIds.Remove(articleIds.Length - 1, 1).Remove(0, 1);

                    //spliting apart the comma delimited string that is returned
                    articles = articleIds.Split(',').ToList();
                }
            }

            return articles;
        }

        public static Article GetArticle(string articleId)
        {
            var articleWebRequest = WebRequest.Create(hackerNewsPath + "item/" + articleId + ".json");
            if (articleWebRequest == null)
            {
                throw (new Exception("Web request could not be completed for article id: " + articleId));
            }

            articleWebRequest.ContentType = "application/json";

            using (var webResponse = articleWebRequest.GetResponse())
            {
                using (var sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    string articleJson = sr.ReadToEnd();

                    return JsonConvert.DeserializeObject<Article>(articleJson);
                }
            }
        }
    }
}
