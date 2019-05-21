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
                Application.Current.MainPage = new NavigationPage(new HomePage());
                //_HomePage = new HomePage();
                    
                //_Navigationpage.Navigation.PushModalAsync(_HomePage);
                });

                }
         }

    }
}
