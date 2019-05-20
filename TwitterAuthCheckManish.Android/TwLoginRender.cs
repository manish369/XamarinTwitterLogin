using System;
using Xamarin.Auth;
using Android.App;
using Xamarin.Forms.Platform.Android;
using TwitterAuthCheckManish;
using TwitterAuthCheckManish.Droid;
using TwitterAuthCheckManish.Config;
using Xamarin.Forms;
using System.Runtime.Remoting.Contexts;
using Android.Content;
using System.Net;

[assembly:ExportRenderer(typeof(TwLogin),typeof(TwLoginRender))]

namespace TwitterAuthCheckManish.Droid
{
    public class TwLoginRender : PageRenderer
    {
        public TwLoginRender(Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            var activity = this.Context as Activity;
            var Authi = new OAuth1Authenticator(
            "wJYji5EICJOOoQZUHYHOPqUJH",
              "GB27rcwuUWD6PsrDLF4dwYVLcXwK6NZY5AAVjXeiYEZ5gxSXV5",
               new Uri("https://api.twitter.com/oauth/request_token"),
             new Uri("https://api.twitter.com/oauth/authorize"),
              new Uri("https://api.twitter.com/oauth/access_token"),
             new Uri("https://mobile.twitter.com/home")
            );

          Authi.Completed += Authi_Completed;        
         activity.StartActivity(Authi.GetUI(activity));
        }

        void Authi_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                UserInfo userInfo = new UserInfo();

                userInfo.Token = e.Account.Properties["oauth_token"];
                userInfo.TokenSecret = e.Account.Properties["oauth_token_secret"];
                userInfo.TwitterId = e.Account.Properties["user_id"];
                userInfo.ScreenName = e.Account.Properties["screen_name"];

                OAuthConfig.SuccessFullLogin.Invoke();
                Console.WriteLine("It working");
            }

        }

    }
}
