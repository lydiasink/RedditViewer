using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sample.Models;

public static class GetData
{
    static async System.Threading.Tasks.Task<string> GetJsonPics()
    {
        var http = new HttpClient();
        var json = await http.GetStringAsync("https://www.reddit.com/r/pics.json?limit=50");
        return json;
    }

    static async System.Threading.Tasks.Task<string> GetJson(String type)
    {
        var http = new HttpClient();
        string stem = "https://www.reddit.com/";
        var job = stem + type + ".json?limit=50";
        string json = await http.GetStringAsync(job);     
        return json;
    }

    static JObject ParseJson(string json)
    {
        var parsed = JObject.Parse(json);
        return parsed;
    }

    static List<RedditPic> ConvertPics(JObject job)
    {
        var a = new List<RedditPic>();
        var data = job["data"];
        var children = data["children"];
        foreach (var it in children.Children())
        {
            var it_data = it["data"];
            // extract only the data we care about
            var title = it_data["title"].ToString();
            var thumb = it_data["thumbnail"].ToString();
            var numComs = System.Convert.ToInt32(it_data["num_comments"].ToString());
            var numCPs = System.Convert.ToInt32(it_data["num_crossposts"].ToString());
            var author = it_data["author"].ToString();
            var image = it_data["url"].ToString();
            var score = System.Convert.ToInt32(it_data["score"].ToString());
            int seconds = System.Convert.ToInt32(it_data["created_utc"].ToString());
            DateTime since1970 = new DateTime(1970, 1, 1, 0, 0, 0);
            DateTime created = since1970.AddSeconds(seconds);
            var sr = it_data["subreddit"].ToString();
            var urlstr = it_data["url"].ToString();

            // Create an object 
            a.Add(new RedditPic
            {
                Title = title,
                Thumb = thumb,
                comCount = numComs,
                crossPosts = numCPs,
                Author = author,
                Score = score,
                Img = image,
                Created = created,
                subreddit = sr,
                url = urlstr
            });
        }
        return a;
    }

    static List<Listing> ConvertItem(JObject job)
    {
        var a = new List<Listing>();
        var data = job["data"];
        var children = data["children"];
        foreach (var it in children.Children())
        {
            var it_data = it["data"];
            // extract only the data we care about
            var ttl = it_data["title"].ToString();
            var numComs = System.Convert.ToInt32(it_data["num_comments"].ToString());
            var numCPs = System.Convert.ToInt32(it_data["num_crossposts"].ToString());
            var author = it_data["author"].ToString();
            int seconds = System.Convert.ToInt32(it_data["created_utc"].ToString());
            DateTime since1970 = new DateTime(1970, 1, 1, 0, 0, 0);
            DateTime created = since1970.AddSeconds(seconds);
            var score = System.Convert.ToInt32(it_data["score"].ToString());
            var sr = it_data["subreddit"].ToString();
            var urlstr = it_data["url"].ToString();

            // Create an object 
            a.Add(new Listing(ttl, numComs, numCPs, author, score, created, sr, urlstr));
        }
        return a;
    }

    public static async Task<List<RedditPic>> GetPics()
    {
        string json = await GetJsonPics();
        var job = ParseJson(json);
        var result = ConvertPics(job);
        return result;
    }

    public static async Task<List<Listing>> GetItems(String type)
    {
        string json = await GetJson(type);
        var job = ParseJson(json);
        var result = ConvertItem(job);
        return result;
    }
}