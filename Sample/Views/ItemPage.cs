using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using Sample.Models;

namespace Sample.Views
{
    public class ItemPage : ContentPage
    {
        public ListView _list;
        public Button viewButton = new Button();
        public Button sortButton = new Button();
        public Label title = new Label();
        public List<Listing> theItems;

        public ItemPage(String title, String type)
        {
            Title = title;
            theItems = Sample.App.Items[type];
            int size = theItems.Count;

            System.Console.WriteLine("size of " + type + " " + size);

            //Format sort buttons
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
            _list.ItemsSource = theItems;
            _list.ItemTemplate = new DataTemplate(() =>
            {
                var cell = new ImageCell();
                cell.SetBinding(ImageCell.TextProperty, "_title");
                cell.SetBinding(ImageCell.ImageSourceProperty, "_thumb");
                cell.TextColor = Color.FromRgb(0, 0, 0);
                
                return cell;
            });

            _list.IsVisible = true;

        
            //Enable events 
            _list.ItemSelected += _list_ItemSelected;
            sortButton.Clicked += sortButton_Clicked;
            viewButton.Clicked += viewButton_Clicked;

            //Populate the screen with a stacklayout
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
                        var sortedItems = theItems
                                      .OrderBy(x => x.getComCount())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Number of Crossposts")
                    {
                        var sortedItems = theItems
                                      .OrderBy(x => x.getCrossposts())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Author")
                    {
                        var sortedItems = theItems
                                      .OrderBy(x => x.getAuthor())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Score")
                    {
                        var sortedItems = theItems
                                      .OrderBy(x => x.getScore())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Subreddit")
                    {
                        var sortedItems = theItems
                                      .OrderBy(x => x.getSubReddit())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Date Created")
                    {
                        var sortedItems = theItems
                                      .OrderBy(x => x.getDate())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                }
                else if (order == "Descending")
                {
                    if (sortBy == "Number of Comments")
                    {
                        var sortedItems = theItems
                                      .OrderByDescending(x => x.getComCount())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Number of Crossposts")
                    {
                        var sortedItems = theItems
                                      .OrderByDescending(x => x.getCrossposts())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Author")
                    {
                        var sortedItems = theItems
                                                .OrderByDescending(x => x.getAuthor())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Score")
                    {
                        var sortedItems = theItems
                                      .OrderByDescending(x => x.getScore())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Subreddit")
                    {
                        var sortedItems = theItems
                                                .OrderByDescending(x => x.getSubReddit())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
                    }
                    else if (sortBy == "Date Created")
                    {
                        var sortedItems = theItems
                                      .OrderByDescending(x => x.getDate())
                                      .ToList()
                                      ;
                        _list.ItemsSource = sortedItems;
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
            Listing currentItem = (Listing)_list.SelectedItem;
            String ttl = currentItem.getTitle();
            //String thumb = currentItem.Thumb;
            String author = currentItem.getAuthor();
            String score = System.Convert.ToString(currentItem.getScore());
            String created = System.Convert.ToString(currentItem.getDate());
            String subreddit = currentItem.getSubReddit();
            String numCom = System.Convert.ToString(currentItem.getComCount());
            String numCP = System.Convert.ToString(currentItem.getCrossposts());
            String url = currentItem.getURL();

            ViewListingPage v = new ViewListingPage(ttl, author, score, created,
                                                   subreddit, numCom, numCP, url);
            Navigation.PushAsync(v);
        }
    }
}
