using System;


namespace Sample.Models
{
    public class Listing
    {
        public string _title { get; }
        public string _thumb { get; }
        public int _comCount { get; set; }
        public int _crossPosts { get; set; }
        public string _author { get; set; }
        public int _score { get; set; }
        public string _img { get; set; }
        public DateTime _created { get; set; }
        public string _subreddit { get; set; }
        public string _url { get; set; }

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
                    created, subreddit, url)
        {
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
                       string subreddit, string url)
        {

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


        public Boolean hasImage()
        {
            return _img.Length > 0;
        }

        public String getTitle()
        {
            return this._title;
        }
        public String getThumb()
        {
            return this._thumb;
        }
        public int getComCount()
        {
            return this._comCount;
        }
        public int getCrossposts()
        {
            return this._crossPosts;
        }
        public string getAuthor()
        {
            return this._author;
        }
        public int getScore()
        {
            return this._score;
        }
        public String getImg()
        {
            return this._img;
        }
        public DateTime getDate()
        {
            return this._created;
        }
        public String getSubReddit()
        {
            return this._subreddit;
        }
        public String getURL()
        {
            return this._url;
        }

    }
}
