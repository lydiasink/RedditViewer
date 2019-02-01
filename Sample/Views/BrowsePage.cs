using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Views

{
    public class BrowsePage : ContentPage
    {
        public BrowsePage()
        {
            Title = "Browse";

            // Select memo
            Label select_label = new Label
            {
                Text = " Select a category below:  ",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                TextColor = Color.FromRgb(50, 50, 50),
                FontSize = 18,
                BackgroundColor = Color.FromRgb(200,200,200)
            };


            // Set buttons to represent categories

            Button popular_button = new Button
            {
                Text = "Popular ",
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(90, 79, 135),
                BorderColor = Color.FromRgb(0, 0, 50),
                FontSize = 20

            };

            Button new_button = new Button
            {
                Text = " New Items ",
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(90, 79, 135),
                BorderColor = Color.FromRgb(0, 0, 50),
                FontSize = 20

            };

            Button oc_button = new Button
            {
                Text = " Original Content ",
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(100, 118, 219),
                BorderColor = Color.FromRgb(0, 0, 100),
                FontSize = 20
            };

            Button subreddits_button = new Button
            {
                Text = " Subreddits ",
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(100, 118, 219),
                BorderColor = Color.FromRgb(0, 0, 100),
                FontSize = 20
            };

            Button pictures_button = new Button
            {
                Text = " Pictures ",
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(100, 118, 219),
                BorderColor = Color.FromRgb(0, 0, 100),
                FontSize = 20
            };


            /// INITIALIZE STRUCTURE
            var scroll = new ScrollView();
            Content = scroll;

            var elements = new StackLayout
            {
                Children = {
                    select_label,
                    popular_button,
                    new_button,
                    oc_button,
                    subreddits_button,
                    pictures_button
                },
                Padding = 5,
                Margin = 5
            };

            scroll.Content = elements;


        }
    }
}
