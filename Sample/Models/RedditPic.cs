using System;
namespace Sample.Models
{
    public class RedditPic
    {
        public string Title { get; set; }
        public string Thumb { get; set; } //Small image for view in list
        public int comCount { get; set; }
        public int crossPosts { get; set; }
        public string Author { get; set; }
        public int Score { get; set; }
        public string Img { get; set; } //Large image for specific item view
        public DateTime Created { get; set; }
        public string subreddit { get; set; }
        public string url { get; set; }

    }
}
