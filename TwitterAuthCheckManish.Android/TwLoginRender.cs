using System;
using Xamarin.Auth;
using Android.App;
using Xamarin.Forms.Platform.Android;
using TwitterAuthCheckManish;
using TwitterAuthCheckManish.Droid;
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
            consumerKey: "wJYji5EICJOOoQZUHYHOPqUJH",
            consumerSecret: "GB27rcwuUWD6PsrDLF4dwYVLcXwK6NZY5AAVjXeiYEZ5gxSXV5",
            requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
            authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
            accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
            callbackUrl: new Uri("http://mobile.twitter.com")

            );

            Authi.Completed += (object sender, AuthenticatorCompletedEventArgs evt) => {

                if (evt.IsAuthenticated)
                {
                    UserInfo userInfo = new UserInfo();

                    userInfo.Token = evt.Account.Properties["oauth_token"];
                    userInfo.TokenSecret = evt.Account.Properties["oauth_token_secret"];
                    userInfo.TwitterId = evt.Account.Properties["user_id"];
                    userInfo.ScreenName = evt.Account.Properties["screen_name"];


                    Console.WriteLine("It working");
                }

            };

        

            activity.StartActivity(Authi.GetUI(activity));
        }
    }
}
