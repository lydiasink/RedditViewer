using System;
using Xamarin.Forms;

namespace Sample.Views
{
    public class ViewPicPage : ContentPage
    {
        public String itemTitle { get; set; }
        public String Thumb { get; set; }
        public String Author { get; set; }

        public ViewPicPage(String itemTitle, String thumb, String author)
        {

            Label itemTitleLabel = new Label();
            itemTitleLabel.Text = "Title: " + itemTitle;
            itemTitleLabel.FontSize = 24;
            itemTitleLabel.HorizontalTextAlignment = TextAlignment.Center;
            Image image = new Image { Source = thumb};

            image.VerticalOptions = LayoutOptions.Fill;
            Label authorLabel = new Label();
            authorLabel.Text = "Author: " + author;
            authorLabel.FontSize = 18;
            authorLabel.VerticalOptions = LayoutOptions.Start;

            Content = new StackLayout
            {   Spacing = 15,
                Children = {
                    image,
                    itemTitleLabel,
                    authorLabel
                },
                Padding = 5,
                Margin = 5
            };
        }
    }
}
