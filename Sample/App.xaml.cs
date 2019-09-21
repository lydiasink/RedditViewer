using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sample.Models;
using Sample.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sample
{

    public partial class App : Application
    {
        public static List<RedditPic> Pics;
        public static Dictionary<string, List<Listing>> Items;

        async Task InitData()
        {
            Pics = await GetData.GetPics(); //Getting the data from the website
            Items = new Dictionary<string, List<Listing>>();
            Items.Add("new", await GetData.GetItems("new"));
            Items.Add("hot", await GetData.GetItems("hot"));
            //Items.Add("random", await GetData.GetItems("random"));
            Items.Add("controversial", await GetData.GetItems("controversial"));
            Items.Add("rising", await GetData.GetItems("rising"));
        }

        public App()
        {
            InitializeComponent();

            Task.Run(() => InitData()).Wait();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

