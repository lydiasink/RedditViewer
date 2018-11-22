using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Views
{
    public class New : ContentPage
    {
        public ListView _list;
        public Button viewButton = new Button();
        public Button sortButton = new Button();
        public Label title = new Label();

        public New()
        {
            Title = "What's New";

            //Format sort button
            sortButton.Text = " Sort by... ";
            sortButton.BackgroundColor = Color.FromHex("50D859");
            sortButton.TextColor = Color.FromRgb(255, 255, 255);
            sortButton.Margin = 5;
            sortButton.BorderColor = Color.FromRgb(0, 0, 50);
            sortButton.HeightRequest = 25;
            sortButton.WidthRequest = 75;

            //Format view button
            viewButton.Text = " View ";
            viewButton.BackgroundColor = Color.FromHex("A450D8");
            viewButton.TextColor = Color.FromRgb(255, 255, 255);
            viewButton.Margin = 5;
            viewButton.HeightRequest = 25;
            viewButton.WidthRequest = 75;
            viewButton.BorderColor = Color.FromRgb(0, 0, 50);
            viewButton.IsVisible = false;

            //initialize list of content
            _list = new ListView();
            _list.ItemsSource = Sample.App.NewItems;
            _list.ItemTemplate = new DataTemplate(() =>
            {
                var cell = new ImageCell();
                cell.SetBinding(ImageCell.TextProperty, "Title");
                cell.SetBinding(ImageCell.ImageSourceProperty, "Thumb");
                return cell;
            });

            //Enable events 
            _list.ItemSelected += _list_ItemSelected;
            sortButton.Clicked += sortButton_Clicked;
            viewButton.Clicked += viewButton_Clicked;

            Content = new StackLayout
            {
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        Children = {
                            sortButton,
                            viewButton
                        }
                    },
                    _list
                }
            };
        }

        //Sorting the items - when button is clicked
        async void sortButton_Clicked(object sender, EventArgs e)
        {
            var sortBy = await Application.Current.MainPage.DisplayActionSheet(
                "Sort By",
                "Cancel",
                null,
                "Number of Comments",
                "Number of Crossposts",
                "Author",
                "Score",
                "Subreddit",
                "Date Created"
            );

            if (sortBy != "Cancel")
            {
                var order = await Application.Current.MainPage.DisplayActionSheet(
                    "Sort order: " + sortBy,
                    "Cancel",
                    null,
                    "Ascending",
                    "Descending"
                );
                if (order == "Ascending")
                {

                    if (sortBy == "Number of Comments")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderBy(x => x.comCount)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Number of Crossposts")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderBy(x => x.crossPosts)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Author")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderBy(x => x.Author)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Score")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderBy(x => x.Score)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Subreddit")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderBy(x => x.subreddit)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Date Created")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderBy(x => x.Created)
                                      .ToList()
                                      ;
                    }
                }
                else if (order == "Descending")
                {
                    if (sortBy == "Number of Comments")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderByDescending(x => x.comCount)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Number of Crossposts")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderByDescending(x => x.crossPosts)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Author")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderByDescending(x => x.Author)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Score")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderByDescending(x => x.Score)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Subreddit")
                    {
                        var sortedItems = Sample.App.NewItems
                                      .OrderByDescending(x => x.subreddit)
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Date Created"){
                        var sortedItems = Sample.App.NewItems
                                      .OrderByDescending(x => x.Created)
                                      .ToList()
                                      ;
                    }
                }

            };
        }

        // Show the view button 
        void _list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewButton.IsVisible = true;
        }

        //View the item
        void viewButton_Clicked(object sender, EventArgs e)
        {
            RedditNew currentItem = (RedditNew)_list.SelectedItem;
            String ttl = currentItem.Title;
            //String thumb = currentItem.Thumb;
            String author = currentItem.Author;
            String score = System.Convert.ToString(currentItem.Score);
            String created = System.Convert.ToString(currentItem.Created);
            String subreddit = currentItem.subreddit;
            String numCom = System.Convert.ToString(currentItem.comCount);
            String numCP = System.Convert.ToString(currentItem.crossPosts);
            String url = currentItem.url;

            ViewListingPage v = new ViewListingPage(ttl, author, score, created,
                                                   subreddit, numCom, numCP, url);
            Navigation.PushAsync(v);
        }
    }
}
