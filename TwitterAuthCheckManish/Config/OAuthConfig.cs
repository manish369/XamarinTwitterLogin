using System;
using Xamarin.Forms;
namespace TwitterAuthCheckManish.Config
{
    public class OAuthConfig

    {
        static HomePage _HomePage;
        static NavigationPage _Navigationpage;

        public static Action SuccessFullLogin
        { 
            get{
                return new Action(() =>
                {
                    _Navigationpage.Navigation.PushModalAsync(_HomePage);
                });

                }
         }

    }
}
