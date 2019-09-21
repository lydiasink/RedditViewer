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
                BackgroundColor = Color.FromRgb(200, 200, 200)
            };


            // Set buttons to represent categories
            Button popular_button = new Button
            {
                Text = "Popular ",
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(25, 79, 200),
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

            Button rising_button = new Button
            {
                Text = " Rising ",
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(200, 25, 100),
                BorderColor = Color.FromRgb(0, 0, 100),
                FontSize = 20,

            };

            /*
            Button random_button = new Button
            {
                Text = " Random ",
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(100, 118, 219),
                BorderColor = Color.FromRgb(0, 0, 100),
                FontSize = 20
            }; */

            Button contro_button = new Button
            {
                Text = " Controversial ",
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
                    //random_button,
                    contro_button,
                    rising_button
                },
                Padding = 5,
                Margin = 5
            };

            scroll.Content = elements;

            //enable events
            new_button.Clicked += New_Button_Clicked;
            //random_button.Clicked += Random_Button_Clicked;
            popular_button.Clicked += Popular_Button_Clicked;
            rising_button.Clicked += Rising_Button_Clicked;
            contro_button.Clicked += Contro_Button_Clicked;
        }

        void Rising_Button_Clicked(object sender, EventArgs e)
        {
            ItemPage page = new ItemPage("Rising", "rising");

            Navigation.PushAsync(page);
        }

        void New_Button_Clicked(object sender, EventArgs e)
        {
            ItemPage page = new ItemPage(Title = "What's New", "new");

            Navigation.PushAsync(page);
        }

        void Popular_Button_Clicked(object sender, EventArgs e)
        {
            ItemPage page = new ItemPage(Title = "Popular", "hot");

            Navigation.PushAsync(page);
        }

        void Contro_Button_Clicked(object sender, EventArgs e)
        {
            ItemPage page = new ItemPage(Title = "Controversial", "controversial");

            Navigation.PushAsync(page);
        }

        /*
        void Random_Button_Clicked(object sender, EventArgs e)
        {
            ItemPage page = new ItemPage(Title = "Random", "random");

            Navigation.PushAsync(page);
        } */
    }

}
