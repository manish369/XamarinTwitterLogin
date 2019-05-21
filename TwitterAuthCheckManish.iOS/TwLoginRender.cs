using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Auth;
using TwitterAuthCheckManish.iOS;
using TwitterAuthCheckManish;
using TwitterAuthCheckManish.Config;
using System.Threading;
[assembly: ExportRenderer(typeof(TwLogin), typeof(TwLoginRender))]

namespace TwitterAuthCheckManish.iOS
{

    public class TwLoginRender :PageRenderer
    {

        public static HomePage _HomePage;
        static NavigationPage _Navigationpage;

        public TwLoginRender()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

           
         
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var Authi = new OAuth1Authenticator(
              consumerKey: "wJYji5EICJOOoQZUHYHOPqUJH",
              consumerSecret: "GB27rcwuUWD6PsrDLF4dwYVLcXwK6NZY5AAVjXeiYEZ5gxSXV5",
              requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
              authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
              accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
              callbackUrl: new Uri("https://mobile.twitter.com/home")

              );

            Authi.Completed += (sender, e) => {
                if (e.IsAuthenticated)
                { 
                    UserInfo userInfo = new UserInfo();

                    userInfo.Token = e.Account.Properties["oauth_token"];
                    userInfo.TokenSecret = e.Account.Properties["oauth_token_secret"];
                    userInfo.TwitterId = e.Account.Properties["user_id"];
                    userInfo.ScreenName = e.Account.Properties["screen_name"];

                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        OAuthConfig.SuccessFullLogin.Invoke();
                        DismissViewController(true, null);
                        //_Navigationpage = new NavigationPage();
                       // _Navigationpage.Navigation.PopAsync();
                       // _Navigationpage.Navigation.PopAsync();
                        //_Navigationpage = new NavigationPage(new HomePage());
                       // _HomePage = new HomePage();

                     //_Navigationpage.Navigation.PushModalAsync(_HomePage);
                     
                   });
                   
                    Console.WriteLine("It working");
                }
            };

            var webui = Authi.GetUI();
            PresentViewController(webui, true, null);

        }
    }
}
