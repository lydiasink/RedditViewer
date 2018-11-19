using System;
using Xamarin.Forms;

namespace Sample.Views
{
    public class ViewPicPage : ContentPage
    {
        public Label ItemTitle { get; set; }
        public Image Img { get; set; }
        public Label AuthorLabel { get; set; }
        public Label ScoreLabel { get; set; }

        public ViewPicPage(String itemTitle, String img, String author, 
                           String Score)
        {
            //Format Title
            ItemTitle = new Label();
            ItemTitle.Text = "Title: " + itemTitle;
            ItemTitle.FontSize = 20;
            ItemTitle.HorizontalTextAlignment = TextAlignment.Center;

            //Image
            Img = new Image { Source = img };
            Img.VerticalOptions = LayoutOptions.Fill;

            //Format Author
            AuthorLabel = new Label();
            AuthorLabel.Text = "Author: " + author;
            AuthorLabel.FontSize = 16;
            AuthorLabel.VerticalOptions = LayoutOptions.Start;

            //Format Score
            ScoreLabel = new Label();
            ScoreLabel.Text = "Score: " + Score;
            ScoreLabel.FontSize = 16;
            ScoreLabel.VerticalOptions = LayoutOptions.Start;

            Content = new StackLayout
            {   Spacing = 15,
                Children = {
                    Img,
                    ItemTitle,
                    AuthorLabel
                },
                Padding = 5,
                Margin = 5
            };
        }
    }
}
