using System;
using Xamarin.Forms;
using System.Runtime.InteropServices;

namespace Sample.Views
{
    public class ViewListingPage : ContentPage
    {
        public String url;

        public ViewListingPage(String itemTitle, String author, String Score,
                              String subreddit, String numCom, String numCP,
                              String urlstr)
        {

            //Create a button with link to open in browser
            url = urlstr;

            Button urlButton = new Button
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Text = "View in Browser",
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(144, 198, 141),
                BorderColor = Color.FromRgb(0, 0, 50),
                Margin = 5,
                WidthRequest = 125
            };


            //Format Title
            FormattedString title =  new FormattedString {

                Spans = {
                    new Span {
                        Text = "Title: ",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.FromRgb(216,79,0),
                        FontSize = 22
                    },

                    new Span {
                        Text = itemTitle,
                        TextColor = Color.FromRgb(0,0,0),
                        FontSize = 22
                    }
                }
            };

            Label titleinfo = new Label
            {
                FormattedText = title,
                LineBreakMode = LineBreakMode.WordWrap
            };

            //Format Author
            FormattedString auth = new FormattedString
            {

                Spans = {
                    new Span {
                        Text = "Author: ",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.FromRgb(25,77,209),
                        FontSize = 16
                    },

                    new Span {
                        Text = author,
                        TextColor = Color.FromRgb(0,0,0),
                        FontSize = 16
                    }
                }
            };

            Label authorInfo = new Label
            {
                FormattedText = auth,
                LineBreakMode = LineBreakMode.WordWrap
            };


            //Format Score
            FormattedString scr = new FormattedString
            {
                Spans = {
                    new Span {
                        Text = "Score: ",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.FromRgb(25,77,209),
                        FontSize = 16
                    },

                    new Span {
                        Text = Score,
                        TextColor = Color.FromRgb(0,0,0),
                        FontSize = 16
                    }
                }
            };

            Label scoreInfo = new Label
            {
                FormattedText = scr,
                LineBreakMode = LineBreakMode.WordWrap
            };

            //Format Subreddit
            FormattedString sr = new FormattedString
            {
                Spans = {
                    new Span {
                        Text = "Subreddit: ",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.FromRgb(25,77,209),
                        FontSize = 16
                    },

                    new Span {
                        Text = subreddit,
                        TextColor = Color.FromRgb(0,0,0),
                        FontSize = 16
                    }
                }
            };

            Label srInfo = new Label
            {
                FormattedText = sr,
                LineBreakMode = LineBreakMode.WordWrap
            };

            //Format comment count
            FormattedString cc = new FormattedString
            {
                Spans = {
                    new Span {
                        Text = "Number of Comments: ",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.FromRgb(25,77,209),
                        FontSize = 16
                    },

                    new Span {
                        Text = numCom,
                        TextColor = Color.FromRgb(0,0,0),
                        FontSize = 16
                    }
                }
            };

            Label numCominfo = new Label
            {
                FormattedText = cc,
                LineBreakMode = LineBreakMode.WordWrap
            };

            //Format crossposts count
            FormattedString crossposts = new FormattedString
            {

                Spans = {
                    new Span {
                        Text = "Number of Crossposts: ",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.FromRgb(25,77,209),
                        FontSize = 16
                    },

                    new Span {
                        Text = numCP,
                        TextColor = Color.FromRgb(0,0,0),
                        FontSize = 16
                    }
                }
            };

            Label numCPinfo = new Label
            {
                FormattedText = crossposts,
                LineBreakMode = LineBreakMode.WordWrap
            };

            Content = new StackLayout
            {
                Spacing = 15,
                Children = {
                    urlButton,
                    titleinfo,
                    authorInfo,
                    srInfo,
                    scoreInfo,
                    numCominfo,
                    numCPinfo
                },
                Padding = 5,
                Margin = 5
            };

            //Enable events for the button
            urlButton.Clicked += urlButton_Clicked;
        }

        void urlButton_Clicked(object sender, EventArgs e) 
        {
            //open this item in browser 
           // ProcessStartInfo info = new ProcessStartInfo()
        }

    }


}
