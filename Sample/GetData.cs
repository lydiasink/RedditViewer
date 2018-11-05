﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class RedditPic
{
    public string Title { get; set; }
    public string Thumb { get; set; }
    public int comCount { get; set; }
    public int crossPosts { get; set; }
    public string Author { get; set; }
    public int Score { get; set; }
    //public DateTime Created { get; set; } 

}

public class RedditNew
{
    public string Title { get; set; }
    public string Thumb { get; set; }
    public int comCount { get; set; }
    public int crossPosts { get; set; }
    public string Author { get; set; }
    public int Score { get; set; }
    //public DateTime Created { get; set; }

}

public static class GetData
{
    static async System.Threading.Tasks.Task<string> GetJsonPics()
    {
        var http = new HttpClient();
        var json = await http.GetStringAsync("https://www.reddit.com/r/pics.json?limit=50");
        return json;
    }

    static async System.Threading.Tasks.Task<string> GetJsonNew()
    {
        var http = new HttpClient();
        var json = await http.GetStringAsync("https://www.reddit.com/new.json?limit=50");
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
            //var createdUTC = System.Convert.ToDateTime(it_data["created_utc"].ToString());
            //TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            //DateTime created = TimeZoneInfo.ConvertTimeFromUtc(createdUTC, est);
            var score = System.Convert.ToInt32(it_data["score"].ToString());

            //convert the UTC to datetime

            // Create an object 
            a.Add(new RedditPic { 
                Title = title, 
                Thumb = thumb , 
                comCount = numComs,
                crossPosts = numCPs,
                Author = author,
                Score = score
               //Created = created
            });
        }
        return a;
    }

    static List<RedditNew> ConvertNew(JObject job)
    {
        var a = new List<RedditNew>();
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
            //var createdUTC = System.Convert.ToDateTime(it_data["created_utc"].ToString());
           // TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
           // DateTime created = TimeZoneInfo.ConvertTimeFromUtc(createdUTC, est);
            var score = System.Convert.ToInt32(it_data["score"].ToString());

            // Create an object 
            a.Add(new RedditNew
            {
                Title = title,
                Thumb = thumb,
                comCount = numComs,
                crossPosts = numCPs,
                Author = author,
                Score = score
               // Created = created
            });
        }
        return a;
    }

    public static async Task<List<RedditPic>> GetPics()
    {
        var json = await GetJsonPics();
        var job = ParseJson(json);
        var result = ConvertPics(job);
        return result;
    }

    public static async Task<List<RedditNew>> GetNew()
    {
        var json = await GetJsonNew();
        var job = ParseJson(json);
        var result = ConvertNew(job);
        return result;
    }

}