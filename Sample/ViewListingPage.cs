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
            StackLayout titleinfo = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Horizontal,
                Children =  
                {    
                    new Label {

                        Text = "Title: ",
                        FontSize = 20,
                        TextColor = Color.FromRgb(216, 79, 0), //orange
                        FontAttributes = FontAttributes.Bold,
                        LineBreakMode = LineBreakMode.NoWrap,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        Margin = 3
                    },
                    new Label {
                        Text = itemTitle,
                        FontSize = 20,
                        LineBreakMode = LineBreakMode.TailTruncation
                    }
                }
            };

            //Format Author
            StackLayout authorinfo = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children =  {
                    new Label {
                        Text = "Author: ",
                        FontSize = 16,
                        TextColor = Color.FromRgb(25, 77, 209), //blue
                        FontAttributes = FontAttributes.Bold
                    },
                    new Label {
                        Text = author,
                        FontSize = 16
                    }
                }
            };

            //Format Score
            StackLayout scoreinfo = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children =  {
                    new Label {
                        Text = "Score: ",
                        FontSize = 16,
                        TextColor = Color.FromRgb(25, 77, 209), //blue
                        FontAttributes = FontAttributes.Bold,
                        LineBreakMode = LineBreakMode.NoWrap
                    },
                    new Label {
                        Text = Score,
                        FontSize = 16,
                        LineBreakMode = LineBreakMode.WordWrap
                    }
                }
            };

            //Format Subreddit
            StackLayout srinfo = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children =  {
                    new Label {
                        Text = "Subreddit: ",
                        FontSize = 16,
                        TextColor = Color.FromRgb(25, 77, 209), //blue
                        FontAttributes = FontAttributes.Bold,
                        LineBreakMode = LineBreakMode.NoWrap
                    },
                    new Label {
                        Text = subreddit,
                        FontSize = 16,
                        LineBreakMode = LineBreakMode.WordWrap
                    }
                }
            };

            //Format comment count
            StackLayout numcominfo = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children =  {
                    new Label {
                        Text = "Number of Comments: ",
                        FontSize = 16,
                        TextColor = Color.FromRgb(25, 77, 209), //blue
                        FontAttributes = FontAttributes.Bold,
                        LineBreakMode = LineBreakMode.NoWrap
                    },
                    new Label {
                        Text = numCom,
                        FontSize = 16,
                        LineBreakMode = LineBreakMode.WordWrap
                    }
                }
            };

            //Format crossposts count
            StackLayout numCPinfo = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children =  {
                    new Label {
                        Text = "Number of Crossposts: ",
                        FontSize = 16,
                        TextColor = Color.FromRgb(25, 77, 209), //blue
                        FontAttributes = FontAttributes.Bold,
                        LineBreakMode = LineBreakMode.NoWrap
                    },
                    new Label {
                        Text = numCP,
                        FontSize = 16,
                        LineBreakMode = LineBreakMode.WordWrap
                    }
                }
            };

            Content = new StackLayout
            {
                Spacing = 15,
                Children = {
                    urlButton,
                    titleinfo,
                    authorinfo,
                    srinfo,
                    scoreinfo,
                    numcominfo,
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
