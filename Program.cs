using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Web;
using System.Net;

namespace NewsProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Please choose a category\n Entertainment=1\n Health=2\n Science=3\n Technology=4\n Sport=5\n");
            
            int no = Int32.Parse(Console.ReadLine());

            if (no == 1)
            {
                getN(no);
            }
            else if (no == 2)
            {
                getN(no);
            }
            else if (no == 3)
            {
                getN(no);
            }
            else if (no == 4)
            {
                getN(no);
            }
            else if (no == 5)
            {
                getN(no);
            }
            else 
            {
                Console.WriteLine("Invalid Selection");
            }
            
            // init with your API key
           
        }



        public async static void GetNews()
        {

            string category = "science";
            string API_KEY = "0f50b33dd2db47f99fe246bc71857f2a";
            string url = $"https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey=0f50b33dd2db47f99fe246bc71857f2a";
            WebRequest request = HttpWebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                StreamReader reader =  new StreamReader( response.GetResponseStream());
                string urlText = reader.ReadToEnd(); // it takes the response from your url. now you can use as your need  
                Console.WriteLine(urlText);
            }
            catch (Exception ex)
            {

                throw;
            }
           
            
            
            
        }
        public async static void getN(int i)
        {
            var newsApiClient = new NewsApiClient("0f50b33dd2db47f99fe246bc71857f2a");
            var a = Categories.Science;
            if (i == 1)
            {
                  a = Categories.Entertainment;
            }
            else if (i == 2)
            {
                a = Categories.Health;
            }
            else if (i == 3)
            {
                a = Categories.Science;
            }
            else if (i == 4)
            {
                a = Categories.Technology;
            }
            else
            {
                a = Categories.Sports;

            }

            TopHeadlinesRequest e = new TopHeadlinesRequest();
            e.Category = a;
            e.Country = Countries.US;
            var articlesResponse =  newsApiClient.GetTopHeadlines(e);
            if (articlesResponse.Status == Statuses.Ok)
            {
                // total results found
                Console.WriteLine("print results" + articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {
                    // title
                    Console.WriteLine(article.Title);
                    // author
                    Console.WriteLine(article.Author);
                    // description
                    Console.WriteLine(article.Description);
                    // url
                    Console.WriteLine(article.Url);
                    // published at
                    Console.WriteLine(article.PublishedAt);
                }
            }
            Console.ReadLine();
        }
    }

    
}