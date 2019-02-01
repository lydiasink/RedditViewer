using System;


namespace Sample.Models
{
    public class Listing
    {
        private string _title { get; set; }
        private string _thumb { get; }
        private int _comCount { get; set; }
        private int _crossPosts { get; set; }
        private string _author { get; set; }
        private int _score { get; set; }
        private string _img { get; set; }
        private DateTime _created { get; set; }
        private string _subreddit { get; set; }
        private string _url { get; set; }

        /*
         * Constructor creates a new listing if all parameters are 
         * known, and there is no image
         * 
         * @param title the title of the listing
         * @param cc the number of comments
         * @param cp the number of crossPosts
         * @param author the author's username
         * @param score the score of the listing
         * @param created date and time of listing's creation
         * @param subreddit the specified subreddit for the listing
         * @param url the web address of this specific listing
         * 
         * */
        public Listing(string title, int cc, int cp,
                       string author, int score, DateTime created,
                      string subreddit, string url)
        : this(title, "", cc, cp, author, score, "",
                    created, subreddit, url) {
        }

        /*
         * Constructor creates a new listing if all parameters are known,
         * and there IS an image
         * 
         * @param title the title of the listing
         * @param thumb the thumbnail of the image
         * @param cc the number of comments
         * @param cp the number of crossPosts
         * @param author the author's username
         * @param score the score of the listing
         * @param image the full sized image
         * @param created date and time of listing's creation
         * @param subreddit the specified subreddit for the listing
         * @param url the web address of this specific listing
         * */
        public Listing(string title, string thumb, int cc, int cp,
                       string author, int score, string image, DateTime created,
                       string subreddit, string url) {

            _title = title;
            _thumb = thumb;
            _comCount = cc;
            _crossPosts = cp;
            _author = author;
            _score = score;
            _img = image;
            _created = created;
            _subreddit = subreddit;
            _url = url;

        }


        public Boolean hasImage() {
            return _img.Length > 0;
        }


    }
}
