using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sample.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sample
{

    public partial class App : Application
    {
        public static List<RedditPic> Pics;
        public static List<RedditNew> NewItems;

        async Task InitData()
        {
            Pics = await GetData.GetPics(); //Getting the data from the website
            NewItems = await GetData.GetNew();
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
