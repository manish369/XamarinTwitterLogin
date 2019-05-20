using System;
using Xamarin.Forms;
namespace TwitterAuthCheckManish.Config
{
    public class OAuthConfig

    {
       public static HomePage _HomePage;
        static NavigationPage _Navigationpage;

        public static Action SuccessFullLogin
        { 
            get{
                return new Action(() =>
                {
                _Navigationpage = new NavigationPage();
                _HomePage = new HomePage();
                _Navigationpage.Navigation.PushAsync(_HomePage);
                });

                }
         }

    }
}
