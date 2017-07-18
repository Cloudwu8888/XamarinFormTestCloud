using TestXamarin.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestXamarin
{
	public partial class App : Application
	{
        public App()
		{
            InitializeComponent();
            
           
			SetMainPage();
		}

		public static void SetMainPage()
		{
            MobileCenter.Start("android=2aa58a3a-0b5a-4071-8822-ca90b46028ba" +
                         "uwp=8191e4bc-19da-4106-8190-c6976147bce5" +
                         "ios=b0dfc34a-a7a2-4299-8590-c0ed0a585c9e",
                         typeof(Analytics), typeof(Crashes));
            Analytics.TrackEvent("Cat is hungry");

            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Xamarin.Forms.Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Xamarin.Forms.Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                }
            };
        }
	}
}
